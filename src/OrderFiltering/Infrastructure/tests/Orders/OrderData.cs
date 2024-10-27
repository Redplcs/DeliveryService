using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using System.Globalization;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Tests.Orders;

public class OrderData
{
	public static string CreateSerializedOrder(out Order order)
	{
		order = CreateValidOrder();

		return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3:yyyy-MM-dd HH:mm:ss}",
			order.Id, order.Weight, order.DeliveryDistrictId, order.DeliveryTime);
	}

	public static string CreateSerializedOrder(out OrderId orderId, out float weight, out DistrictId deliveryDistrictId, out DateTime deliveryTime)
	{
		var serialized = CreateSerializedOrder(out var order);

		orderId = order.Id;
		weight = order.Weight;
		deliveryDistrictId = order.DeliveryDistrictId;
		deliveryTime = order.DeliveryTime;

		return serialized;
	}

	public static Order CreateValidOrder()
	{
		var currentTimestamp = DateTime.UtcNow;

		var orderId = OrderId.Create();
		var weight = 1.0f;
		var deliveryDistrictId = DistrictId.Create();
		// Truncate milliseconds because datetime format does not mean to have it
		var deliveryTime = new DateTime(currentTimestamp.Ticks - (currentTimestamp.Ticks % TimeSpan.TicksPerSecond), DateTimeKind.Utc);

		return Order.Create(orderId, weight, deliveryDistrictId, deliveryTime);
	}
}
