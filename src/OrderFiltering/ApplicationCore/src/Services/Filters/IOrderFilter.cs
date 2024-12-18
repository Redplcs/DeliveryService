using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services.Filters;

public interface IOrderFilter
{
	bool ApplyFilter(Order order);
}
