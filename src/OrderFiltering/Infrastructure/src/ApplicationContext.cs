using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Order> Orders => Set<Order>();
}
