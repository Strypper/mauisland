using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.Features.LocalDbFeatures.GitHub;

public static class ServiceExtension
{

    public static void RegisterLocalDbFeaturesGitHub(this IServiceCollection services)
    {
        services.AddTransient<IGitHubIssueLocalDbService, GitHubIssueLocalDbService>();
    }
}