using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using System.Globalization;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Tests;

public class TextOrderParserTests
{
	[Fact]
	public void Parse_OrderSerializedToString_ReturnsDeserializedOrder()
	{
		var input = CreateSerializedOrder(
			out var expectedOrderId,
			out var expectedWeight,
			out var expectedDeliveryDistrictId,
			out var expectedDeliveryTime);

		var order = TextOrderParser.Parse(input);

		Assert.NotNull(order);
		Assert.Equal(expectedOrderId, order.Id);
		Assert.Equal(expectedWeight, order.Weight);
		Assert.Equal(expectedDeliveryDistrictId, order.DeliveryDistrictId);
		Assert.Equal(expectedDeliveryTime, order.DeliveryTime);
	}

	[Fact]
	public void TryParse_OrderSerializedToString_ReturnsTrueAndDeserializedOrder()
	{
		var input = CreateSerializedOrder(
			out var expectedOrderId,
			out var expectedWeight,
			out var expectedDeliveryDistrictId,
			out var expectedDeliveryTime);

		var parsed = TextOrderParser.TryParse(input, out var order);

		Assert.True(parsed);
		Assert.NotNull(order);
		Assert.Equal(expectedOrderId, order.Id);
		Assert.Equal(expectedWeight, order.Weight);
		Assert.Equal(expectedDeliveryDistrictId, order.DeliveryDistrictId);
		Assert.Equal(expectedDeliveryTime, order.DeliveryTime);
	}

	private static string CreateSerializedOrder(out OrderId orderId, out float weight, out DistrictId deliveryDistrictId, out DateTime deliveryTime)
	{
		var utcNow = DateTime.UtcNow;

		orderId = OrderId.Create();
		weight = 1.0f;
		deliveryDistrictId = DistrictId.Create();
		deliveryTime = new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second, DateTimeKind.Utc);

		return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3:yyyy-MM-dd HH:mm:ss}", orderId, weight, deliveryDistrictId, deliveryTime);
	}
}
