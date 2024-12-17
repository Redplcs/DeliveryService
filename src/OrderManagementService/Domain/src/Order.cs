using System.ComponentModel.DataAnnotations;

namespace EffectiveMobile.DeliveryService.OrderManagementService.Domain;

public class Order
{
	[Required, Key]
	public Guid Id { get; set; }

	[Required, Range(0.01, 1000)]
	public double Weight { get; set; }

	[Required]
	public Guid DeliveryDistrictId { get; set; }

	[Required, DataType(DataType.DateTime)]
	public DateTimeOffset DeliveryTime { get; set; }
}
