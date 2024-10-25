using EffectiveMobile.DeliveryService.OrderFiltering.Application.Commands;
using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using Moq;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Application.Tests.Commands;

public class FilterOrdersByDistrictCommandTests
{
	[Fact]
	public void ExecuteAsync()
	{
		var district = DistrictId.Create();
		var stubOrderProvider = new Mock<IOrderProvider>();
		stubOrderProvider.Setup(i => i.GetOrders()).Returns(
		[
			Order.Create(OrderId.Create(), 1.0f, district, DateTime.UtcNow),
			Order.Create(OrderId.Create(), 1.0f, district, DateTime.UtcNow),
			Order.Create(OrderId.Create(), 1.0f, DistrictId.Create(), DateTime.UtcNow)
		]);
		var command = new FilterOrdersByDistrictCommand(stubOrderProvider.Object);
		command.AddParameter(district);

		var filteredOrders = command.Execute();

		Assert.NotNull(filteredOrders);
		Assert.Equal(2, filteredOrders.Count());
	}
}
