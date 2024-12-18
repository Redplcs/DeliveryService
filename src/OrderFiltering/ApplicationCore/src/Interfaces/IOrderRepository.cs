using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;

public interface IOrderRepository
{
	void Add(Order order);
	IQueryable<Order> GetOrders();
	void Update(Order order);
	void Remove(Order order);
	void Save();
}
