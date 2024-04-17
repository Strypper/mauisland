using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;
public partial class TabbedPagePageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ CTor ]
    public TabbedPagePageViewModel(IAppNavigator appNavigator,
                                   IGitHubService gitHubService,
                                   DiscordRpcClient discordRpcClient,
                                   IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                    : base(appNavigator,
                                            gitHubService,
                                            discordRpcClient,
                                            gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}