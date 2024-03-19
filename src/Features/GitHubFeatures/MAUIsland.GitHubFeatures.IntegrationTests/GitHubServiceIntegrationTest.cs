using System.Reflection;

namespace MAUIsland.GitHubFeatures.IntegrationTests;

public class GitHubServiceIntegrationTest
{
    #region [ Fields ]

    private readonly string httpHeader = "Totechs Corps";
    private readonly string repositoryName = "IntegrationTests";
    private readonly string owner = "Strypper";


    private readonly IServiceProvider serviceProvider;
    #endregion

    #region [ CTor ]

    public GitHubServiceIntegrationTest()
    {
        var services = new ServiceCollection();
        services.RegisterLogicProvider();
        serviceProvider = services.BuildServiceProvider();
    }
    #endregion

    #region [ Methods ]

    [Fact]
    public async Task GetRepositoryTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var repositoryModel = await gitHubService.GetRepository(owner, repositoryName);

        //Assert
        Assert.NotNull(repositoryModel);
    }

    [Fact]
    public async Task GetAuthorTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var authorModel = await gitHubService.GetAuthor(owner);

        //Assert
        Assert.NotNull(authorModel);
    }

    [Fact]
    public async Task GetGitHubIssuesTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var githubIssueModels = await gitHubService.GetGitHubIssues(owner, repositoryName);

        //Assert
        Assert.NotNull(githubIssueModels);
    }

    [Fact]
    public async Task GetGitHubIssuesByLabelsTest()
    {
        string issueLabel = "bug";
        string questionLabel = "question";
        List<string> labelsList = new() { issueLabel, questionLabel };

        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var githubIssueModels = await gitHubService.GetGitHubIssuesByLabels(owner, repositoryName, labelsList);

        //Assert
        Assert.NotNull(githubIssueModels);
    }

    [Fact]
    public async Task GetGitHubIssueByNoTest()
    {
        int issueNo = 1;

        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var githubIssueModel = await gitHubService.GetGitHubIssueByNo(owner, repositoryName, issueNo);

        //Assert
        Assert.NotNull(githubIssueModel);
        Assert.NotEmpty(githubIssueModel.Title);
    }

    #endregion

    #region [ Private Methods ]
    private void AssertStringPropertyNotNullOrEmpty<T>(T model)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(string))
            {
                if (IsNullable(property.PropertyType))
                    continue;

                object? valueObj = property.GetValue(model);
                string value = valueObj is not null ? valueObj.ToString() : null;

                Assert.False(string.IsNullOrEmpty(value), $"Property {property.Name} must not be null or empty.");
            }
        }
    }

    private bool IsNullable(Type type)
    {
        return Nullable.GetUnderlyingType(type) != null;
    }
    #endregion
}