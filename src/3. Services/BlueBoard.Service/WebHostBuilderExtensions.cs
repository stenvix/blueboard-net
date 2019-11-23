using BlueBoard.Service.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BlueBoard.Service
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder SetupService(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureServices(services =>
            {
                using (var provider = services.BuildServiceProvider())
                {
                    var configuration = provider.GetRequiredService<IConfiguration>();
                    services.Configure<ServiceOptions>(configuration.GetSection(ServiceOptions.SectionName));
                }
            });
            return webHostBuilder;
        }

        public static IWebHostBuilder UseSerilog(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.ConfigureServices(services =>
            {
                services.AddLogging(builder => builder.AddSerilog());
            });

            webHostBuilder.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });

            return webHostBuilder;
        }
    }
}
