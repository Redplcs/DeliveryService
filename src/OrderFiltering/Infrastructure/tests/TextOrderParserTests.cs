using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using System.Globalization;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Tests;

public class TextOrderParserTests
{
	[Fact]
	public void Parse_OrderSerializedToString_ReturnsDeserializedOrder()
	{
		var input = OrderData.CreateSerializedOrder(
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
		var input = OrderData.CreateSerializedOrder(
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
}
