using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services.Filters;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Tests.Services.Filters;

public class DistrictIdOrderFilterTests : OrderFilterTestsBase<DistrictIdOrderFilter>
{
	[Fact]
	public void ApplyFilter_WhenDistrictIdSame_ReturnsTrue()
	{
		// Arrange
		var districtId = Guid.NewGuid();
		var order = new Order() { DeliveryDistrictId = districtId };
		var filter = new DistrictIdOrderFilter(districtId);

		// Act
		var filtered = filter.ApplyFilter(order);

		// Assert
		Assert.True(filtered);
	}

	[Fact]
	public void ApplyFilter_WhenDistrictIdNotSame_ReturnsFalse()
	{
		// Arrange
		var districtId = Guid.NewGuid();
		var otherDistrictId = Guid.NewGuid();
		var order = new Order() { DeliveryDistrictId = districtId };
		var filter = new DistrictIdOrderFilter(otherDistrictId);

		// Act
		var filtered = filter.ApplyFilter(order);

		// Assert
		Assert.False(filtered);
	}

	protected override DistrictIdOrderFilter CreateFilter()
	{
		return new DistrictIdOrderFilter(filterBy: default);
	}
}
