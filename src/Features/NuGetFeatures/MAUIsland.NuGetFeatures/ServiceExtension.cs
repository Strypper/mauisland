using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.NuGetFeatures;

public static class ServiceExtension
{
    public static void RegisterNuGetFeatures(this IServiceCollection services)
    {
        services.AddTransient<INuGetFeatures, Version1>();
    }
}
