using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services.Filters;

public class DeliveryTimeRangeOrderFilter(DateTimeOffset startTime, DateTimeOffset endTime) : IOrderFilter
{
	public bool ApplyFilter(Order order)
	{
		if (order is null)
		{
			return false;
		}

		return startTime <= order.DeliveryTime && order.DeliveryTime <= endTime;
	}
}
