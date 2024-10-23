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
}
