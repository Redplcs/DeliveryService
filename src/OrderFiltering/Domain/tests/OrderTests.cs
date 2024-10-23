namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain.Tests;

public class OrderTests
{
	public static readonly IEnumerable<object[]> InvalidOrderIds = [
		[ new OrderId() ]
	];

	[Theory]
	[MemberData(nameof(InvalidOrderIds))]
	public void Create_InvalidId_ThrowsArgumentOutOfRangeException(OrderId id)
	{
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
