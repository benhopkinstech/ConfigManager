using ConfigManager.Application.Interfaces;
using ConfigManager.Application.Services;

namespace ConfigManager.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IConfigManagerService, ConfigManagerService>();

        return services;
    }
}