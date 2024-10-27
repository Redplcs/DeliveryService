namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public class DeliveryTimeOrderFilter(DateTime startTime) : IOrderFilter
{
	public bool ApplyFilter(Order value)
	{
		ArgumentNullException.ThrowIfNull(value, nameof(value));
		return startTime <= value.DeliveryTime && value.DeliveryTime <= startTime.AddMinutes(30);
	}
}
