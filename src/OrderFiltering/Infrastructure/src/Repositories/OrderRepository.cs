using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Repositories;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
	public void Add(Order order)
	{
		context.Orders.Add(order);
	}

	public IQueryable<Order> GetOrders()
	{
		return context.Orders;
	}

	public void Remove(Order order)
	{
		context.Orders.Remove(order);
	}

	public void Save()
	{
		context.SaveChanges();
	}

	public void Update(Order order)
	{
		context.Orders.Update(order);
	}
}
