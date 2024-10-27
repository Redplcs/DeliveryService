using EffectiveMobile.DeliveryService.OrderFiltering.Application.Commands;
using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Application.Services;

public class OrderFilteringService(
	IFilterOrdersByDistrictCommand filterOrdersByDistrictCommand,
	IOrderSender sender,
	IConfiguration configuration,
	ILogger<OrderFilteringService> logger) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		var cityDistrict = configuration.GetSection("_cityDistrict");

		if (cityDistrict.Exists())
		{
			var districtGuid = Guid.Parse(cityDistrict.Value!);
			filterOrdersByDistrictCommand.AddParameter(new DistrictId(districtGuid));

			logger.LogInformation("Filtering by district: {district}", districtGuid);

			var filteredOrders = filterOrdersByDistrictCommand.Execute();

			LogFilteredOrders(filteredOrders);

			await sender.Send(filteredOrders);

			logger.LogInformation("Filtered orders saved to file");
		}

		// TODO: _firstDeliveryDateTime
	}

	private void LogFilteredOrders(IEnumerable<Order> orders)
	{
		var stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Filtered {orders.Count()} orders:");

		foreach (var order in orders)
		{
			stringBuilder.AppendLine($"\t" +
				$"OrderId = {order.Id}, " +
				$"Weight = {order.Weight}, " +
				$"DeliveryDistrictId = {order.DeliveryDistrictId}, " +
				$"DeliveryTime = {order.DeliveryTime}");
		}

		logger.LogInformation(stringBuilder.ToString());
	}
}
