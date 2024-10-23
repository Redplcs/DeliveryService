namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain.Tests;

public class OrderTests
{
	[Fact]
	public void Create_ZeroId_ThrowsArgumentOutOfRangeException()
	{
		var id = new OrderId();
		var weight = 1.0f;
		var deliveryDistrictId = DistrictId.Create();
		var deliveryTime = DateTime.UtcNow;

		Assert.Throws<ArgumentOutOfRangeException>(paramName: nameof(id), () =>
		{
			_ = Order.Create(id, weight, deliveryDistrictId, deliveryTime);
		});
	}

	[Theory]
	[InlineData(0.0f)]
	[InlineData(-1.0f)]
	public void Create_InvalidWeight_ThrowsArgumentOutOfRangeException(float weight)
	{
		var id = OrderId.Create();
		var deliveryDistrictId = DistrictId.Create();
		var deliveryTime = DateTime.UtcNow;

		Assert.Throws<ArgumentOutOfRangeException>(paramName: nameof(weight), () =>
		{
			_ = Order.Create(id, weight, deliveryDistrictId, deliveryTime);
		});
	}
}
