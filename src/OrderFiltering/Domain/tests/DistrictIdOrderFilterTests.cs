namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain.Tests;

public class DistrictIdOrderFilterTests
{
	[Fact]
	public void ApplyFilter_OrderFiltered_ReturnsTrue()
	{
		var filterBy = DistrictId.Create();
		var filter = new DistrictIdOrderFilter(filterBy);
		var orderId = OrderId.Create();
		var weight = 1.0f;
		var deliveryTime = DateTime.UtcNow;
		var order = Order.Create(orderId, weight, filterBy, deliveryTime);

		bool filtered = filter.ApplyFilter(order);

		Assert.True(filtered);
	}

	[Fact]
	public void ApplyFilter_OrderUnfiltered_ReturnsFalse()
	{
		var filterBy = DistrictId.Create();
		var filter = new DistrictIdOrderFilter(filterBy);
		var orderId = OrderId.Create();
		var weight = 1.0f;
		var deliveryTime = DateTime.UtcNow;
		var otherDistrictId = DistrictId.Create();
		var order = Order.Create(orderId, weight, otherDistrictId, deliveryTime);

		bool filtered = filter.ApplyFilter(order);

		Assert.False(filtered);
	}

	[Fact]
	public void ApplyFilter_NullOrder_ThrowsArgumentNullException()
	{
		var filterBy = DistrictId.Create();
		var filter = new DistrictIdOrderFilter(filterBy);

		Assert.Throws<ArgumentNullException>(paramName: "value", () =>
		{
			_ = filter.ApplyFilter(value: null!);
		});
	}
}
