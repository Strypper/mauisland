using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class BlazorWebViewPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ CTor ]
    public BlazorWebViewPageViewModel(IAppNavigator appNavigator,
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

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        if (ControlInformation is null)
            return;

        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
