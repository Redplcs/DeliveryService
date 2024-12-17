using EffectiveMobile.DeliveryService.OrderManagementService.Domain;
using Microsoft.EntityFrameworkCore;

namespace EffectiveMobile.DeliveryService.OrderManagementService.Infrastructure;

public class OrderingContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Order> Orders => Set<Order>();
}
