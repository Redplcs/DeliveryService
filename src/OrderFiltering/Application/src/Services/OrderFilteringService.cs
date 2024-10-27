using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Application.Services;

public class OrderFilteringService(
	IOrderProvider orders,
	IOrderSender sender,
	IConfiguration configuration,
	ILogger<OrderFilteringService> logger) : BackgroundService
{
	private readonly IConfigurationSection _cityDistrict = configuration.GetSection(nameof(_cityDistrict));
	private readonly IConfigurationSection _firstDeliveryDateTime = configuration.GetSection(nameof(_firstDeliveryDateTime));

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		IEnumerable<Order> incomingOrders = orders.GetOrders();
		LogOrders(logger, $"Received {incomingOrders.Count()} orders", incomingOrders);

		incomingOrders = OrderByTime(incomingOrders);
		LogOrders(logger, "Incoming orders sorted by time", incomingOrders);

		if (_cityDistrict.Exists())
		{
			if (!Guid.TryParse(_cityDistrict.Value!, out var districtGuid))
			{
				logger.LogWarning("The {paramName} value is not valid guid. Ignoring filtering by district", nameof(_cityDistrict));
			}
			else
			{
				var districtId = new DistrictId(districtGuid);
				incomingOrders = FilterByDistrictId(incomingOrders, districtId);
				LogOrders(logger, "Incoming orders filtered by district id", incomingOrders);
			}
		}

		if (_firstDeliveryDateTime.Exists())
		{
			if (!DateTime.TryParse(_firstDeliveryDateTime.Value!, out var deliveryTime))
			{
				logger.LogWarning("The {paramName} value is not valid time. Ignoring filtering by delivery time", nameof(deliveryTime));
			}
			else
			{
				incomingOrders = FilterByFirstDeliveryDateTime(incomingOrders, deliveryTime);
				LogOrders(logger, "Incoming orders filtered by delivery time", incomingOrders);
			}
		}

		await sender.Send(incomingOrders);
		LogOrders(logger, "Incoming order sended", incomingOrders);
	}

	private static IEnumerable<Order> OrderByTime(IEnumerable<Order> source)
	{
		return source.OrderBy(x => x.DeliveryTime);
	}

	private static IEnumerable<Order> FilterByDistrictId(IEnumerable<Order> source, DistrictId id)
	{
		var filter = new DistrictIdOrderFilter(id);
		return source.Where(filter.ApplyFilter);
	}

	private static IEnumerable<Order> FilterByFirstDeliveryDateTime(IEnumerable<Order> source, DateTime deliveryTime)
	{
		var filter = new DeliveryTimeOrderFilter(deliveryTime, deliveryTime.AddMinutes(30));
		return source.Where(filter.ApplyFilter);
	}

	private static void LogOrders(ILogger<OrderFilteringService> logger, string header, IEnumerable<Order> orders)
	{
		var stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(header);

		foreach (var order in orders)
		{
			stringBuilder.Append('\t');
			stringBuilder.Append("OrderId = ");
			stringBuilder.Append(order.Id);
			stringBuilder.Append(", ");
			stringBuilder.Append("Weight = ");
			stringBuilder.Append(order.Weight);
			stringBuilder.Append(", ");
			stringBuilder.Append("DeliveryDistrictId = ");
			stringBuilder.Append(order.DeliveryDistrictId);
			stringBuilder.Append(", ");
			stringBuilder.Append("DeliveryTime = ");
			stringBuilder.Append(order.DeliveryTime);
			stringBuilder.AppendLine();
		}

		logger.LogInformation("{message}", stringBuilder);
	}
}
