namespace MAUIsland.GitHubProvider.IntegrationTests;

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

    }

    [Fact]
    public async Task GetAuthorTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        await gitHubService.GetAuthor(owner);
    }

    [Fact]
    public async Task GetGitHubIssuesTest()
    {
        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        await gitHubService.GetGitHubIssues(owner, repositoryName);
    }

    [Fact]
    public async Task GetGitHubIssuesByLabelsTest()
    {
        string issueLabel = "bug";
        string questionLabel = "question";
        List<string> labelsList = new() { issueLabel, questionLabel };

        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        await gitHubService.GetGitHubIssuesByLabels(owner, repositoryName, labelsList);
    }

    [Fact]
    public async Task GetGitHubIssueByIdTest()
    {
        string issueId = "1";

        var gitHubService = serviceProvider!.GetRequiredService<IGitHubService>();
        await gitHubService.GetGitHubIssueById(owner, repositoryName, issueId);
    }

    #endregion
}