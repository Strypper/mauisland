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
        services.RegisterGitHubFeatures();
        serviceProvider = services.BuildServiceProvider();
    }
    #endregion

    #region [ Methods ]

    [Fact]
    public async Task GetRepositoryTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var result = await gitHubService.GetRepository(owner, repositoryName);

        //Assert
        Assert.IsType<ServiceSuccess>(result.AsT0);
        Assert.NotEmpty(result.AsT0.SuccessCode);
        Assert.NotEmpty(result.AsT0.SuccessMessage);
        Assert.NotEmpty(result.AsT0.ServiceName);
        Assert.NotEmpty(result.AsT0.MethodName);
        Assert.NotEmpty(result.AsT0.ConsumerName);
        Assert.NotEqual(DateTime.MinValue, result.AsT0.EventOccuredAt);
        Assert.NotNull(result.AsT0.AttachedData);

        var repositoryModel = result.AsT0.AttachedData as GitHubRepositoryModel;
        Assert.NotNull(repositoryModel);
        Assert.NotEqual(0, repositoryModel.GitHubId);
        Assert.NotNull(repositoryModel.Name);
        Assert.NotNull(repositoryModel.Url);
    }

    [Fact]
    public async Task GetAuthorTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var result = await gitHubService.GetAuthor(owner);

        //Assert
        Assert.IsType<ServiceSuccess>(result.AsT0);
        Assert.NotEmpty(result.AsT0.SuccessCode);
        Assert.NotEmpty(result.AsT0.SuccessMessage);
        Assert.NotEmpty(result.AsT0.ServiceName);
        Assert.NotEmpty(result.AsT0.MethodName);
        Assert.NotEmpty(result.AsT0.ConsumerName);
        Assert.NotEqual(DateTime.MinValue, result.AsT0.EventOccuredAt);
        Assert.NotNull(result.AsT0.AttachedData);

        var authorModel = result.AsT0.AttachedData as GitHubAuthorModel;
        Assert.NotNull(authorModel);
        Assert.NotNull(authorModel.Name);
        Assert.NotNull(authorModel.Url);
        Assert.NotNull(authorModel.AvatarUrl);
        Assert.NotNull(authorModel.Bio);
        Assert.NotNull(authorModel.Company);
        Assert.NotNull(authorModel.Login);
    }

    [Fact]
    public async Task GetGitHubIssuesTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var result = await gitHubService.GetGitHubIssues(owner, repositoryName);

        //Assert
        Assert.IsType<ServiceSuccess>(result.AsT0);
        Assert.NotEmpty(result.AsT0.SuccessCode);
        Assert.NotEmpty(result.AsT0.SuccessMessage);
        Assert.NotEmpty(result.AsT0.ServiceName);
        Assert.NotEmpty(result.AsT0.MethodName);
        Assert.NotEmpty(result.AsT0.ConsumerName);
        Assert.NotEqual(DateTime.MinValue, result.AsT0.EventOccuredAt);
        Assert.NotNull(result.AsT0.AttachedData);

        var githubIssuesModel = result.AsT0.AttachedData as IEnumerable<GitHubIssueModel>;
        Assert.NotNull(githubIssuesModel);
        if (githubIssuesModel.Any())
        {
            foreach (var issue in githubIssuesModel)
            {
                Assert.True(issue.Number > 0);
                Assert.NotNull(issue.Title);
                Assert.NotNull(issue.Url);
                Assert.NotNull(issue.State);
                Assert.NotNull(issue.User);
                Assert.NotEqual(DateTimeOffset.MinValue, issue.CreatedAt);
            }
        }
    }

    [Fact]
    public async Task GetGitHubIssuesByLabelsTest()
    {
        string issueLabel = "bug";
        string questionLabel = "question";
        List<string> labelsList = new() { issueLabel, questionLabel };

        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var result = await gitHubService.GetGitHubIssuesByLabels(owner, repositoryName, labelsList);

        //Assert
        Assert.IsType<ServiceSuccess>(result.AsT0);
        Assert.NotEmpty(result.AsT0.SuccessCode);
        Assert.NotEmpty(result.AsT0.SuccessMessage);
        Assert.NotEmpty(result.AsT0.ServiceName);
        Assert.NotEmpty(result.AsT0.MethodName);
        Assert.NotEmpty(result.AsT0.ConsumerName);
        Assert.NotEqual(DateTime.MinValue, result.AsT0.EventOccuredAt);
        Assert.NotNull(result.AsT0.AttachedData);

        var githubIssuesModel = result.AsT0.AttachedData as IEnumerable<GitHubIssueModel>;
        Assert.NotNull(githubIssuesModel);
        if (githubIssuesModel.Any())
        {
            foreach (var issue in githubIssuesModel)
            {
                Assert.True(issue.Number > 0);
                Assert.NotNull(issue.Title);
                Assert.NotNull(issue.Url);
                Assert.NotNull(issue.State);
                Assert.NotNull(issue.User);
                Assert.NotEqual(DateTimeOffset.MinValue, issue.CreatedAt);
            }
        }
    }

    [Fact]
    public async Task GetGitHubIssueByNoTest()
    {
        int issueNo = 1;

        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        var result = await gitHubService.GetGitHubIssueByNo(owner, repositoryName, issueNo);

        //Assert
        Assert.IsType<ServiceSuccess>(result.AsT0);
        Assert.NotEmpty(result.AsT0.SuccessCode);
        Assert.NotEmpty(result.AsT0.SuccessMessage);
        Assert.NotEmpty(result.AsT0.ServiceName);
        Assert.NotEmpty(result.AsT0.MethodName);
        Assert.NotEmpty(result.AsT0.ConsumerName);
        Assert.NotEqual(DateTime.MinValue, result.AsT0.EventOccuredAt);
        Assert.NotNull(result.AsT0.AttachedData);

        var githubIssueModel = result.AsT0.AttachedData as GitHubIssueModel;
        Assert.NotNull(githubIssueModel);
        Assert.True(githubIssueModel.Number > 0);
        Assert.NotNull(githubIssueModel.Title);
        Assert.NotNull(githubIssueModel.Url);
        Assert.NotNull(githubIssueModel.State);
        Assert.NotNull(githubIssueModel.User);
        Assert.NotEqual(DateTimeOffset.MinValue, githubIssueModel.CreatedAt);

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