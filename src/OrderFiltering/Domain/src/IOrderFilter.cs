namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public interface IOrderFilter
{
	bool ApplyFilter(Order value);
}
