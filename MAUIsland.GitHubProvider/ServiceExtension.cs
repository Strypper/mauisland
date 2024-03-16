using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.GitHubProvider;

public static class ServiceExtension
{

    public static void RegisterLogicProvider(this IServiceCollection services)
    {
        services.AddTransient<IGitHubService, OctokitGitHubClient>();
    }
}
