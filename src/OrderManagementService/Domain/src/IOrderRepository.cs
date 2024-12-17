namespace EffectiveMobile.DeliveryService.OrderManagementService.Domain;

public interface IOrderRepository
{
	void Add(Order order);
	IEnumerable<Order> GetAll();
	Order? GetById(Guid id);
	void Update(Order order);
	void Remove(Order order);
	void RemoveById(Guid id);
}
