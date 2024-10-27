namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public interface IOrderSender
{
	Task Send(IEnumerable<Order> orders);
}
