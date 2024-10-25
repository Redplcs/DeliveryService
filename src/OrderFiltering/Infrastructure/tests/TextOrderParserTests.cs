using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using System.Globalization;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Tests;

public class TextOrderParserTests
{
	[Fact]
	public void Parse_OrderSerializedToString_ReturnsDeserializedOrder()
	{
		var expectedOrderId = OrderId.Create();
		var expectedWeight = 1.0f;
		var expectedDeliveryDistrictId = DistrictId.Create();
		var expectedDeliveryTime = DateTime.UtcNow;
		var input = string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3:yyyy-MM-dd HH:mm:ss}",
			expectedOrderId, expectedWeight, expectedDeliveryDistrictId, expectedDeliveryTime);

		var order = TextOrderParser.Parse(input);

		Assert.NotNull(order);
		Assert.Equal(expectedOrderId, order.Id);
		Assert.Equal(expectedWeight, order.Weight);
		Assert.Equal(expectedDeliveryDistrictId, order.DeliveryDistrictId);
		Assert.Equal(expectedDeliveryTime, order.DeliveryTime);
	}
}
