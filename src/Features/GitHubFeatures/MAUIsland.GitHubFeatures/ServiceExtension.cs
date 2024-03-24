using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.GitHubFeatures;

public static class ServiceExtension
{
    public static void RegisterGitHubFeatures(this IServiceCollection services)
    {
        services.AddTransient<IGitHubService, OctokitGitHubClient>();
    }
}
