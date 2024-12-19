using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services;

public class OrderFilteringService(IOrderRepository repository) : IOrderFilteringService
{
	public IEnumerable<Order> GetOrdersByDeliveryTimeRange(DateTimeOffset startTime, DateTimeOffset endTime)
	{
		var query = from order in repository.GetOrders()
					where startTime <= order.DeliveryTime && order.DeliveryTime <= endTime
					orderby order.DeliveryTime
					select order;

		return [.. query];
	}

	public IEnumerable<Order> GetOrdersByDistrict(Guid districtId)
	{
		var query = from order in repository.GetOrders()
					where order.DeliveryDistrictId == districtId
					orderby order.DeliveryTime
					select order;

		return [.. query];
	}
}
