using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EffectiveMobile.DeliveryService.OrderFiltering.WebApi.Extensions;

public static class EndpointRouteBuilderExtensions
{
	public static void MapCrudEndpoints(this IEndpointRouteBuilder app)
	{
		var endpoints = app.MapGroup("/api/orders");

		endpoints.MapPost("/", (Order order, [FromServices] IOrderRepository repository) =>
		{
			if (repository.Find(order.Id) is not null)
			{
				return Results.BadRequest("The order with same id already exists");
			}

			repository.Add(order);
			repository.Save();

			return Results.Created($"/api/orders/{order.Id}", order);
		});

		endpoints.MapGet("/", ([FromServices] IOrderRepository repository) =>
		{
			var orders = repository.GetOrders().ToList();

			return Results.Ok(orders);
		});

		endpoints.MapPut("/{id}", (Guid id, Order input, [FromServices] IOrderRepository repository) =>
		{
			var order = repository.Find(id);

			if (order is null)
			{
				return Results.NotFound(id);
			}

			order.Weight = input.Weight;
			order.DeliveryDistrictId = input.DeliveryDistrictId;
			order.DeliveryTime = input.DeliveryTime;

			repository.Update(order);
			repository.Save();

			return Results.Ok(order);
		});

		endpoints.MapDelete("/{id}", (Guid id, [FromServices] IOrderRepository repository) =>
		{
			var order = repository.Find(id);

			if (order is null)
			{
				return Results.NotFound(id);
			}

			repository.Remove(order);
			repository.Save();

			return Results.Ok(order);
		});
	}
}
