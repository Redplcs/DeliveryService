using EffectiveMobile.DeliveryService.OrderFiltering.Domain;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Application.Commands;

public interface IFilterOrdersByDistrictCommand : ICommand<IEnumerable<Order>>
{
	void AddParameter(DistrictId districtId);
}
