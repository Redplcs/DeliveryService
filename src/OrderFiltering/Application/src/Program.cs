using Microsoft.Extensions.Hosting;

var host = Host.CreateApplicationBuilder(args);

await host.Build().RunAsync();
