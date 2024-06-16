using MAUIsland.NuGetFeatures;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace NuGetFeatures.IntegrationTests;

public class Version1Test
{
    #region [ Fields ]

    private readonly IServiceProvider serviceProvider;
    #endregion

    #region [ CTor ]

    public Version1Test()
    {
        var services = new ServiceCollection();
        services.RegisterNuGetFeatures();
        serviceProvider = services.BuildServiceProvider();
    }
    #endregion

    #region [ Methods ]



    [Fact]
    public async Task GetRepositoryTest()
    {
        var nugetFeatures = serviceProvider!.GetRequiredService<INuGetFeatures>();
        var result = await nugetFeatures.GetNuGetByName("efcore");

        //Assert
        Assert.IsType<ServiceSuccess>(result.AsT0);
        Assert.NotEmpty(result.AsT0.SuccessCode);
        Assert.NotEmpty(result.AsT0.SuccessMessage);
        Assert.NotEmpty(result.AsT0.ServiceName);
        Assert.NotEmpty(result.AsT0.MethodName);
        Assert.NotEmpty(result.AsT0.ConsumerName);
        Assert.NotEqual(DateTime.MinValue, result.AsT0.EventOccuredAt);
        Assert.NotNull(result.AsT0.AttachedData);

        //var repositoryModel = result.AsT0.AttachedData as GitHubRepositoryModel;
        //Assert.NotNull(repositoryModel);
        //Assert.NotEqual(0, repositoryModel.GitHubId);
        //Assert.NotNull(repositoryModel.Name);
        //Assert.NotNull(repositoryModel.Url);
    }
    #endregion
}
