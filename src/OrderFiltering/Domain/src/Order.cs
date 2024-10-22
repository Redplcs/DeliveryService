namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public class Order
{
	public OrderId Id { get; }
	public float Weight { get; }
	public AreaId DeliveryAreaId { get; }
	public DateTime DeliveryTime { get; }
}
