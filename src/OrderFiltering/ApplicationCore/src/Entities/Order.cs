namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;

public class Order
{
	public Guid Id { get; set; }
	public double Weight { get; set; }
	public Guid DeliveryDistrictId { get; set; }
	public DateTimeOffset DeliveryTime { get; set; }
}
