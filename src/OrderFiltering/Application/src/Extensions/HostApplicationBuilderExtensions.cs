using EffectiveMobile.DeliveryService.OrderFiltering.Application.Services;
using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Orders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Application.Extensions;

public static class HostApplicationBuilderExtensions
{
	public static IHostApplicationBuilder AddFileTextOrderProviderIfHasParameter(this IHostApplicationBuilder app, string parameterName)
	{
		var parameterSection = app.Configuration.GetSection(parameterName);

		if (parameterSection.Exists())
		{
			var filePath = parameterSection.Value!;

			app.Services.AddSingleton<IOrderProvider, TextFileOrderProvider>(_ =>
			{
				var fileStream = File.OpenRead(filePath);
				return new TextFileOrderProvider(fileStream);
			});
		}
		
		return app;
	}

	public static IHostApplicationBuilder AddFileTextOrderSenderIfHasParameter(this IHostApplicationBuilder app, string parameterName)
	{
		var parameterSection = app.Configuration.GetSection(parameterName);

		if (parameterSection.Exists())
		{
			var filePath = parameterSection.Value!;

			app.Services.AddSingleton<IOrderSender, TextFileOrderSender>(_ =>
			{
				var fileStream = File.OpenWrite(filePath);
				return new TextFileOrderSender(fileStream);
			});
		}

		return app;
	}

	public static IHostApplicationBuilder AddFileTextLoggingIfHasParameter(this IHostApplicationBuilder app, string parameterName)
	{
		var parameterSection = app.Configuration.GetSection(parameterName);

		if (parameterSection.Exists())
		{
			var filePath = parameterSection.Value!;

			app.Services.AddLogging(logging =>
			{
				logging.AddFile(options =>
				{
					options.Path = filePath;
				});
			});
		}

		return app;
	}

	public static IHostApplicationBuilder AddOrderFilteringService(this IHostApplicationBuilder app)
	{
		app.Services.AddHostedService<OrderFilteringService>();
		return app;
	}
}
