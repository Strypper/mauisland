using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.GitHubFeatures;

public static class ServiceExtension
{
    public static void RegisterGitHubFeatures(this IServiceCollection services, string accessToken)
    {
        services.AddSingleton(new FeatureSettings()
        {
            AccessToken = accessToken,
        });
        services.AddTransient<IGitHubService, OctokitGitHubClient>();
    }
}