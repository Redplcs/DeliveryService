using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;
using EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure;
using EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Repositories;
using EffectiveMobile.DeliveryService.OrderFiltering.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(databaseName: "Orders"));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapCrudEndpoints();
app.Run();
