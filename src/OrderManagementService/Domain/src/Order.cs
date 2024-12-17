namespace EffectiveMobile.DeliveryService.OrderManagementService.Domain;

public class Order
{
	public Order(Guid id)
	{
		Id = id;
	}

	public Guid Id { get; }
	public double Weight { get; set; }
	public Guid DeliveryDistrictId { get; set; }
	public DateTimeOffset DeliveryTime { get; set; }
}
