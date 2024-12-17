using EffectiveMobile.DeliveryService.OrderManagementService.Domain;
using EffectiveMobile.DeliveryService.OrderManagementService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<OrderingContext>(options => options.UseInMemoryDatabase(databaseName: "OrderManagementDatabase"));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapPost("/orders", CreateOrder);
app.MapGet("/orders", ReadOrders);
app.MapGet("/orders/{id}", ReadOrderById);
app.MapPut("/orders/{id}", UpdateOrder);
app.MapDelete("/orders/{id}", DeleteOrder);
app.Run();

static IResult CreateOrder(Order order, [FromServices] IOrderRepository repository)
{
	if (repository.GetById(order.Id) is not null)
	{
		return Results.BadRequest("The order already exists");
	}

	if (!MiniValidator.TryValidate(order, out var errors))
	{
		return Results.ValidationProblem(errors);
	}

	repository.Add(order);

	return Results.Created($"/orders/{order.Id}", order);
}

static IResult ReadOrders([FromServices] IOrderRepository repository)
{
	var orders = repository.GetAll();

	return Results.Ok(orders);
}

static IResult ReadOrderById(Guid id, [FromServices] IOrderRepository repository)
{
	var order = repository.GetById(id);

	if (order is null)
	{
		return Results.NotFound();
	}

	return Results.Ok(order);
}

static IResult UpdateOrder(Guid id, Order input, [FromServices] IOrderRepository repository)
{
	var order = repository.GetById(id);

	if (order is null)
	{
		return Results.NotFound();
	}

	if (!MiniValidator.TryValidate(input, out var errors))
	{
		return Results.ValidationProblem(errors);
	}

	order.Weight = input.Weight;
	order.DeliveryDistrictId = input.DeliveryDistrictId;
	order.DeliveryTime = input.DeliveryTime;

	repository.Update(order);

	return Results.Ok(order);
}

static IResult DeleteOrder(Guid id, [FromServices] IOrderRepository repository)
{
	var order = repository.GetById(id);

	if (order is null)
	{
		return Results.NotFound();
	}

	repository.Remove(order);

	return Results.Ok(order);
}
