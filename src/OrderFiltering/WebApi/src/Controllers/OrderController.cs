using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EffectiveMobile.DeliveryService.OrderFiltering.WebApi.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrderController(IOrderRepository repository) : ControllerBase
{
	[HttpPost]
	public IActionResult Create(Order order)
	{
		if (repository.Find(order.Id) is not null)
		{
			return BadRequest("The order with same id already exists");
		}

		repository.Add(order);
		repository.Save();

		return CreatedAtAction(nameof(Read), order);
	}

	[HttpGet]
	public IActionResult Read()
	{
		var orders = repository.GetOrders().ToList();

		return Ok(orders);
	}

	[HttpPut]
	public IActionResult Update(Guid id, Order input)
	{
		var order = repository.Find(id);

		if (order is null)
		{
			return NotFound(id);
		}

		order.Weight = input.Weight;
		order.DeliveryDistrictId = input.DeliveryDistrictId;
		order.DeliveryTime = input.DeliveryTime;

		repository.Update(order);
		repository.Save();

		return Ok(order);
	}

	[HttpDelete]
	public IActionResult Delete(Guid id)
	{
		var order = repository.Find(id);

		if (order is null)
		{
			return NotFound(id);
		}

		repository.Remove(order);
		repository.Save();

		return Ok(order);
	}
}
