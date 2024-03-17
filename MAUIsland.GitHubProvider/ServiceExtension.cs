using Microsoft.Extensions.DependencyInjection;
using Octokit;

namespace MAUIsland.GitHubProvider;

public static class ServiceExtension
{

    public static void RegisterLogicProvider(this IServiceCollection services)
    {
        services.AddTransient(x => new GitHubClient(new ProductHeaderValue("Totechs Corps")));
        services.AddTransient<IGitHubService, OctokitGitHubClient>();
    }
}
