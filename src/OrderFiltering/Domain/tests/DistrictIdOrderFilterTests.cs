namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain.Tests;

public class DistrictIdOrderFilterTests
{
	[Fact]
	public void ApplyFilter_OrderIsValid_ReturnsTrue()
	{
		var filterBy = DistrictId.Create();
		var validOrder = Order.Create(OrderId.Create(), 1.0f, filterBy, DateTime.UtcNow);
		var filter = new DistrictIdOrderFilter(filterBy);

		bool isValid = filter.ApplyFilter(validOrder);

		Assert.True(isValid);
	}

	[Fact]
	public void ApplyFilter_OrderIsInvalid_ReturnsFalse()
	{
		var filterBy = DistrictId.Create();
		var invalidOrder = Order.Create(OrderId.Create(), 1.0f, DistrictId.Create(), DateTime.UtcNow);
		var filter = new DistrictIdOrderFilter(filterBy);

		bool isValid = filter.ApplyFilter(invalidOrder);

		Assert.False(isValid);
	}
}
