using MAUIsland.NewsFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace MAUIsland.GitHubFeatures.IntegrationTests;

public class NewsServiceIntegrationTest
{
    #region [ Fields ]

    private readonly IServiceProvider serviceProvider;
    #endregion

    #region [ CTor ]

    public NewsServiceIntegrationTest()
    {
        var services = new ServiceCollection();
        services.RegisterNewsFeatures();
        serviceProvider = services.BuildServiceProvider();
    }
    #endregion

    #region [ Methods ]

    [Fact]
    public async Task GetNewsTest()
    {
        var newsService = serviceProvider!.GetRequiredService<INewsService>();
        var result = await newsService.GetNews();
    }
    #endregion

}