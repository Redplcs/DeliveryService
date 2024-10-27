using EffectiveMobile.DeliveryService.OrderFiltering.Application.Commands;
using EffectiveMobile.DeliveryService.OrderFiltering.Application.Services;
using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Orders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = Host.CreateApplicationBuilder(args);

AddFileTextOrderProviderIfHasParameter("_inputOrder");
AddFileTextOrderSenderIfHasParameter("_deliveryOrder");
AddFileTextLoggingIfHasParameter("_deliveryLog");

host.Services.AddSingleton<IFilterOrdersByDistrictCommand, FilterOrdersByDistrictCommand>();
host.Services.AddHostedService<OrderFilteringService>();

await host.Build().RunAsync();
return;

void AddFileTextOrderProviderIfHasParameter(string parameterName)
{
	var parameterSection = host.Configuration.GetSection(parameterName);

	if (parameterSection.Exists())
	{
		var filePath = parameterSection.Value!;

		host.Services.AddSingleton<IOrderProvider, TextFileOrderProvider>(_ =>
		{
			var fileStream = File.OpenRead(filePath);
			return new TextFileOrderProvider(fileStream);
		});
	}
}

void AddFileTextOrderSenderIfHasParameter(string parameterName)
{
	var parameterSection = host.Configuration.GetSection(parameterName);

	if (parameterSection.Exists())
	{
		var filePath = parameterSection.Value!;

		host.Services.AddSingleton<IOrderSender, TextFileOrderSender>(_ =>
		{
			var fileStream = File.OpenWrite(filePath);
			return new TextFileOrderSender(fileStream);
		});
	}
}

void AddFileTextLoggingIfHasParameter(string parameterName)
{
	var parameterSection = host.Configuration.GetSection(parameterName);

	if (parameterSection.Exists())
	{
		var filePath = parameterSection.Value!;

		host.Services.AddLogging(logging =>
		{
			logging.AddFile(options =>
			{
				options.Path = filePath;
			});
		});
	}
}
