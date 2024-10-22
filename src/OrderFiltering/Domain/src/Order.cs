namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public class Order
{
	public Guid Id { get; }
	public float Weight { get; }
	public Guid DeliveryAreaId { get; }
	public DateTime DeliveryTime { get; }
}
