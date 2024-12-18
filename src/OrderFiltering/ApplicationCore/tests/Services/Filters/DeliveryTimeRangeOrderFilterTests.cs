using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services.Filters;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Tests.Services.Filters;

public class DeliveryTimeRangeOrderFilterTests : OrderFilterTestsBase<DeliveryTimeRangeOrderFilter>
{
	[Fact]
	public void ApplyFilter_WhenOrderInRange_ReturnsTrue()
	{
		// Arrange
		var currentTime = DateTimeOffset.UtcNow;
		var startTime = currentTime.AddDays(-1);
		var endTime = currentTime.AddDays(1);
		var order = new Order() { DeliveryTime = currentTime };
		var filter = new DeliveryTimeRangeOrderFilter(startTime, endTime);

		// Act
		var filtered = filter.ApplyFilter(order);

		// Assert
		Assert.True(filtered);
	}

	[Fact]
	public void ApplyFilter_WhenOrderOutOfRange_ReturnsFalse()
	{
		// Arrange
		var currentTime = DateTimeOffset.UtcNow;
		var startTime = currentTime.AddDays(-1);
		var endTime = currentTime.AddDays(1);
		var deliveryTime = currentTime.AddMonths(1);
		var order = new Order() { DeliveryTime = deliveryTime };
		var filter = new DeliveryTimeRangeOrderFilter(startTime, endTime);

		// Act
		var filtered = filter.ApplyFilter(order);

		// Assert
		Assert.False(filtered);
	}

	protected override DeliveryTimeRangeOrderFilter CreateFilter()
	{
		return new DeliveryTimeRangeOrderFilter(startTime: default, endTime: default);
	}
}
