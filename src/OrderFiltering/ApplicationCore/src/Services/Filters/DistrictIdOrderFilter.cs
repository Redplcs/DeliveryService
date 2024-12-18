using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services.Filters;

public class DistrictIdOrderFilter(Guid filterBy) : IOrderFilter
{
	public bool ApplyFilter(Order order)
	{
		if (order is null)
		{
			return false;
		}

		return order.DeliveryDistrictId == filterBy;
	}
}
