using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using System.Globalization;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Tests;

public class OrderData
{
	public static string CreateSerializedOrder(out OrderId orderId, out float weight, out DistrictId deliveryDistrictId, out DateTime deliveryTime)
	{
		var utcNow = DateTime.UtcNow;

		orderId = OrderId.Create();
		weight = 1.0f;
		deliveryDistrictId = DistrictId.Create();
		deliveryTime = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, DateTimeKind.Utc);

		return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3:yyyy-MM-dd HH:mm:ss}", orderId, weight, deliveryDistrictId, deliveryTime);
	}
}
