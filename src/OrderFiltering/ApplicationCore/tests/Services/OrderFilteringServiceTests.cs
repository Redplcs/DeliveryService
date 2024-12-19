using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services;
using Moq;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Tests.Services;

public class OrderFilteringServiceTests
{
	[Fact]
	public void GetOrdersByDeliveryTimeRange_WhenFirstOrderInRange_ReturnsIt()
	{
		// Arrange
		var currentTime = DateTimeOffset.UtcNow;
		var startTime = currentTime.AddDays(-1);
		var endTime = currentTime.AddDays(1);
		var repository = CreateArrayOrderRepository([
			new() { DeliveryTime = currentTime },
			new() { DeliveryTime = currentTime.AddMonths(1) }
		]);
		var service = new OrderFilteringService(repository);

		// Act
		var orders = service.GetOrdersByDeliveryTimeRange(startTime, endTime);

		// Assert
		Assert.Single(orders);
	}

	[Fact]
	public void GetOrdersByDistrict_WhenFirstOrderHasRequiredDistrictId_ReturnsIt()
	{
		// Arrange
		var districtId = Guid.NewGuid();
		var repository = CreateArrayOrderRepository([
			new() { DeliveryDistrictId = districtId },
			new() { DeliveryDistrictId = Guid.NewGuid() }
		]);
		var service = new OrderFilteringService(repository);

		// Act
		var orders = service.GetOrdersByDistrict(districtId);

		// Assert
		Assert.Single(orders);
	}

	private static IOrderRepository CreateArrayOrderRepository(params Order[] orders)
	{
		var mock = new Mock<IOrderRepository>();

		mock.Setup(repository => repository.GetOrders()).Returns(orders.AsQueryable);

		return mock.Object;
	}
}
