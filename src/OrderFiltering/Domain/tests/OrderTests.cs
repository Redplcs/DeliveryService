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
}
