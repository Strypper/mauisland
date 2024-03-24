using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.Features.LocalDbFeatures;

public static class ServiceExtension
{

    public static void RegisterLocalDbFeatures(this IServiceCollection services, string databasePath)
    {
        DatabaseSettings settings = new()
        {
            DatabasePath = databasePath
        };
        services.AddSingleton(settings);

    }
}
