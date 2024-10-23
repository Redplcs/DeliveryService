namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public class DistrictIdOrderFilter(DistrictId filterBy) : IOrderFilter
{
	public bool ApplyFilter(Order value)
	{
		return value.DeliveryDistrictId == filterBy;
	}
}
