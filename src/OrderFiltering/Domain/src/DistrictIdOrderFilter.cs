namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public class DistrictIdOrderFilter(DistrictId filterBy) : IOrderFilter
{
	public bool ApplyFilter(Order value)
	{
		ArgumentNullException.ThrowIfNull(value, nameof(value));
		return value.DeliveryDistrictId == filterBy;
	}
}
