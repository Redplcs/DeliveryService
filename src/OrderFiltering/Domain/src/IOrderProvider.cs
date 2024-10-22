namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public interface IOrderProvider
{
	IReadOnlyCollection<Order> GetOrders();
}
