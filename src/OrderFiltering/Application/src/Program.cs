using EffectiveMobile.DeliveryService.OrderFiltering.Application.Extensions;
using Microsoft.Extensions.Hosting;

var host = Host.CreateApplicationBuilder(args);

host.AddFileTextOrderProviderIfHasParameter("_inputOrder");
host.AddFileTextOrderSenderIfHasParameter("_deliveryOrder");
host.AddFileTextLoggingIfHasParameter("_deliveryLog");
host.AddOrderFilteringService();

await host.Build().RunAsync();
