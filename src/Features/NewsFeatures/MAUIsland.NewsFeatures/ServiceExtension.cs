using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.NewsFeatures;

public static class ServiceExtension
{
    public static void RegisterNewsFeatures(this IServiceCollection services)
    {
        services.AddTransient<INewsService, ImplVersion1>();
    }
}
