using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class SliderPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion


    #region [ CTor ]
    public SliderPageViewModel(IAppNavigator appNavigator,
                               IGitHubService gitHubService,
                               IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                : base(appNavigator,
                                        gitHubService,
                                        gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    string simpleCreateSliderXamlCode = "<Slider />";

    [ObservableProperty]
    string sliderWithCustomColorsXamlCode =
        "<Slider\r\n" +
        "    MaximumTrackColor=\"Red\"\r\n" +
        "    MinimumTrackColor=\"Blue\"\r\n" +
        "    ThumbColor=\"Green\" />";

    [ObservableProperty]
    string sliderWithCustomThumbImageXamlCode =
        "<Slider\r\n" +
        "    MinimumTrackColor=\"#6e50db\"\r\n" +
        "    ThumbImageSource=\"dotnet_bot.png\" />";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]

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


