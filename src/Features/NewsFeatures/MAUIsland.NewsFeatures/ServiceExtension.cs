using MAUIsland.NewsFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.GitHubFeatures;

public static class ServiceExtension
{
    public static void RegisterNewsFeatures(this IServiceCollection services)
    {
        services.AddTransient<INewsService, ImplVersion1>();
    }
}
