using EffectiveMobile.DeliveryService.OrderManagementService.Domain;

namespace EffectiveMobile.DeliveryService.OrderManagementService.Infrastructure;

public class OrderRepository(OrderingContext context) : IOrderRepository
{
	public void Add(Order order)
	{
		context.Orders.Add(order);
		context.SaveChanges();
	}

	public IEnumerable<Order> GetAll()
	{
		return [.. context.Orders];
	}

	public Order? GetById(Guid id)
	{
		return context.Orders.FirstOrDefault(order => order.Id == id);
	}

	public void Remove(Order order)
	{
		context.Orders.Remove(order);
		context.SaveChanges();
	}

	public void RemoveById(Guid id)
	{
		var order = GetById(id);

		if (order is not null)
		{
			Remove(order);
		}
	}

	public void Update(Order order)
	{
		context.Orders.Update(order);
		context.SaveChanges();
	}
}
