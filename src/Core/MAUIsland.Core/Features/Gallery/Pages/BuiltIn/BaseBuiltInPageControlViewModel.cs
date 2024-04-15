using DiscordRPC;
using DiscordRPC.Logging;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class BaseBuiltInPageControlViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]
    protected DiscordRpcClient client;
    protected IGitHubService GitHubService { get; }
    protected IGitHubIssueLocalDbService GitHubIssueLocalDbService { get; }
    #endregion

    #region [ CTor ]

    public BaseBuiltInPageControlViewModel(IAppNavigator appNavigator,
                                           IGitHubService gitHubService,
                                           IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                               : base(appNavigator)
    {
        GitHubService = gitHubService;
        GitHubIssueLocalDbService = gitHubIssueLocalDbService;

        // Subscribe to the Pushed event
        Shell.Current.Navigated += OnShellNavigated;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string emptyViewText = "No issues found for this control";

    [ObservableProperty]
    string gitHubAPIRateLimit = "https://docs.github.com/en/rest/using-the-rest-api/rate-limits-for-the-rest-api?apiVersion=2022-11-28";

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    #endregion

    #region [ Methods ]

    public async Task RefreshControlIssues(bool forced,
                                           string controlName,
                                           string gitHubAuthorName,
                                           string gitHubrepositoryName,
                                           IEnumerable<string> labels)
    {
        if (IsBusy)
            return;

        IsBusy = true;

        var now = DateTime.UtcNow;

        // First: sync from local db.
        // TODO: how to get control name?
        var allLocalDbIssues = await GetIssueByControlNameFromLocalDb(controlName);

        // If localdb version is not null & not outdated => use local version.
        if (allLocalDbIssues != null && allLocalDbIssues.Any() && !allLocalDbIssues.Any(x => (now - x.LastUpdated).TotalHours > 1))
        {
            if (ControlIssues is null || forced)
            {
                ControlIssues = new(allLocalDbIssues.Select(x => new ControlIssueModel()
                {
                    IssueId = x.IssueId,
                    Title = x.Title,
                    IssueLinkUrl = x.IssueLinkUrl,
                    MileStone = x.MileStone,
                    OwnerName = x.OwnerName,
                    AvatarUrl = x.UserAvatarUrl,
                    CreatedDate = x.CreatedDate,
                    LastUpdated = x.LastUpdated
                }));
            }
            IsBusy = false;

            // Done.
            return;
        }

        // If localdb does not have issue info, or info outdated => sync from GitHub & save.
        var result = await GitHubService.GetGitHubIssuesByLabels(gitHubAuthorName,
                                                                 gitHubrepositoryName,
                                                                 labels);


        if (result.IsT0) // Check if result is ServiceSuccess
        {
            var issues = result.AsT0.AttachedData as IEnumerable<GitHubIssueModel>;

            // Save to localdb.
            foreach (var issue in issues)
            {
                await UpdateLocalIssue(issue, controlName);
            }

            IsBusy = false;

            if (ControlIssues is null || forced)
            {
                ControlIssues = new(issues.Select(x => new ControlIssueModel()
                {
                    IssueId = x.Id,
                    Title = x.Title,
                    IssueLinkUrl = x.HtmlUrl,
                    MileStone = x.Milestone is null ? "No mile stone" : x.Milestone.Title,
                    OwnerName = x.User.Login,
                    AvatarUrl = x.User.AvatarUrl,
                    CreatedDate = x.CreatedAt.DateTime,
                    LastUpdated = x.UpdatedAt is null ? x.CreatedAt.DateTime : x.UpdatedAt.Value.DateTime
                }));
            }
        }
        else
        {
            IsBusy = false;

            var error = result.AsT1;
            EmptyViewText = error.ErrorDetail;
            await AppNavigator.ShowSnackbarAsync(error.ErrorDetail,
                                                 async () =>
                                                 {
                                                     await AppNavigator.OpenUrlAsync(GitHubAPIRateLimit);
                                                 },
                                                 "Visit GitHub API Rate Limits Policies");
        }
    }

    public async Task<IEnumerable<GitHubIssueLocalDbModel>> GetIssueByControlNameFromLocalDb(string controlName)
    {
        try
        {
            var now = DateTime.UtcNow;

            var result = await GitHubIssueLocalDbService.GetByControlNameAsync(controlName);
            return result is not null ?
                        result
                        :
                        new List<GitHubIssueLocalDbModel>().AsEnumerable();
        }
        catch (Exception e)
        {
            await AppNavigator.ShowSnackbarAsync(e.Message, null, null);
            return new List<GitHubIssueLocalDbModel>().AsEnumerable();
        }
    }

    public async Task UpdateLocalIssue(GitHubIssueModel issue, string controlName)
    {
        try
        {
            var now = DateTime.UtcNow;

            var localIssue = await GitHubIssueLocalDbService.GetByIssueUrlAsync(issue.Url);

            if (localIssue is null)
            {
                await GitHubIssueLocalDbService.AddAsync(new()
                {
                    IssueId = issue.Id,
                    Title = issue.Title,
                    IssueLinkUrl = issue.HtmlUrl,
                    ControlName = controlName,
                    MileStone = issue.Milestone?.Title,
                    OwnerName = issue.User?.Login,
                    UserAvatarUrl = issue.User?.AvatarUrl,
                    CreatedDate = issue.CreatedAt.DateTime,
                    LastUpdated = now
                });
                return;
            }

            // Update fields: milestone (TODO: what else?).
            localIssue.MileStone = issue.Milestone?.Title;
            localIssue.LastUpdated = now;

            await GitHubIssueLocalDbService.UpdateAsync(localIssue);
        }
        catch (Exception e)
        {
            await AppNavigator.ShowSnackbarAsync(e.Message, null, null);
        }
    }

    private void OnShellNavigated(object sender, ShellNavigatedEventArgs e)
{
    // Get the page name
    var pageLink = e.Current.Location.ToString();

    var splitPageName = pageLink.Split('/');
    var pageName = splitPageName[splitPageName.Length - 1];

    var textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
    var capitalizedLastPart = textInfo.ToTitleCase(pageName.ToLower());
    //Set the rich presence
    //Call this as many times as you want and anywhere in your code.
    client.SetPresence(new RichPresence()
    {
        Details = "MaUIland",
        State = $"Viewing {capitalizedLastPart}",
        Assets = new Assets()
        {
            LargeImageKey = "https://raw.githubusercontent.com/Strypper/mauisland/main/src/Presentations/Windows/Resources/Images/logos/mauisland_logo.png",
            LargeImageText = "Lachee's Discord IPC Library",
            SmallImageKey = "https://raw.githubusercontent.com/Strypper/mauisland/main/src/Presentations/Windows/Resources/Images/logos/mauisland_logo.png"
        }
    });
}
    #endregion


}
