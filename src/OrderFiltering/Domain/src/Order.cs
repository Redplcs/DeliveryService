namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public class Order
{
	public OrderId Id { get; private set; }
	public float Weight { get; private set; }
	public DistrictId DeliveryDistrictId { get; private set; }
	public DateTime DeliveryTime { get; private set; }

	public static Order Create(OrderId id, float weight, DistrictId deliveryDistrictId, DateTime deliveryTime)
	{
		ArgumentOutOfRangeException.ThrowIfEqual(id, default, nameof(id));			// OrderId must be unique, not equals zero
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(weight, nameof(weight));	// Weight cannot be zero or negative
		ArgumentOutOfRangeException.ThrowIfEqual(deliveryDistrictId, default, nameof(deliveryDistrictId));  // DistrictId must be unique, not equals zero

		return new Order
		{
			Id = id,
			Weight = weight,
			DeliveryDistrictId = deliveryDistrictId,
			DeliveryTime = deliveryTime
		};
	}
}
