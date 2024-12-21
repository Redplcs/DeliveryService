using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Interfaces;
using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services;
using EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure;
using EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(databaseName: "Orders"));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderFilteringService, OrderFilteringService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
