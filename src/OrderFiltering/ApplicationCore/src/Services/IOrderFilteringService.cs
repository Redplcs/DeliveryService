using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services;

public interface IOrderFilteringService
{
	IEnumerable<Order> GetOrdersByDistrict(Guid districtId);
	IEnumerable<Order> GetOrdersByDeliveryTimeRange(DateTimeOffset startTime, DateTimeOffset endTime);
}
