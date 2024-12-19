using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EffectiveMobile.DeliveryService.OrderFiltering.WebApi.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrderController(IOrderRepository repository, IOrderFilteringService service) : ControllerBase
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
	public IActionResult Read(DateTimeOffset? startTime, DateTimeOffset? endTime, Guid? districtId)
	{
		if (startTime.HasValue && endTime.HasValue)
		{
			return GetOrdersByDeliveryTimeRange(startTime.Value, endTime.Value);
		}
		
		if (districtId.HasValue)
		{
			return GetOrdersByDistrict(districtId.Value);
		}

		var orders = repository.GetOrders().ToList();

		return Ok(orders);
	}

	private IActionResult GetOrdersByDeliveryTimeRange(DateTimeOffset startTime, DateTimeOffset endTime)
	{
		var orders = service.GetOrdersByDeliveryTimeRange(startTime, endTime);

		if (!orders.Any())
		{
			return NoContent();
		}

		return Ok(orders);
	}

	private IActionResult GetOrdersByDistrict(Guid districtId)
	{
		var orders = service.GetOrdersByDistrict(districtId);

		if (!orders.Any())
		{
			return NoContent();
		}

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
