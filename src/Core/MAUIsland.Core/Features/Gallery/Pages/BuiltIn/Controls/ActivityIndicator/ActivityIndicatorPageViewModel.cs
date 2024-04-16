using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class ActivityIndicatorPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public ActivityIndicatorPageViewModel(IAppNavigator appNavigator,
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
    string groupOfActivityIndicators =
    "<HorizontalStackLayout HorizontalOptions=\"Start\" Spacing=\"10\">\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" Color=\"Green\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" Color=\"Red\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"true\" Color=\"Aqua\" />\r\n" +
    "</HorizontalStackLayout>";


    [ObservableProperty]
    string bindingActivityIndicators =
    "<VerticalStackLayout Spacing=\"5\">\r\n" +
    "    <HorizontalStackLayout Spacing=\"10\">\r\n" +
    "        <Picker\r\n" +
    "            x:Name=\"ActivityIndicatorColorPicker\"\r\n" +
    "            Title=\"Choose Color\"\r\n" +
    "            BackgroundColor=\"#512bd4\"\r\n" +
    "            ItemsSource=\"{x:StaticResource ActivityIndicatorColorResource}\"\r\n" +
    "            VerticalOptions=\"Center\" />\r\n" +
    "        <Switch\r\n" +
    "            x:Name=\"ActivityIndicatorSwitch\"\r\n" +
    "            IsToggled=\"True\"\r\n" +
    "            VerticalOptions=\"End\" />\r\n" +
    "    </HorizontalStackLayout>\r\n" +
    "    <ActivityIndicator\r\n" +
    "        HorizontalOptions=\"Start\"\r\n" +
    "        IsRunning=\"{x:Binding Source={x:Reference ActivityIndicatorSwitch},\r\n" +
    "                              Path=IsToggled}\"\r\n" +
    "        Color=\"{x:Binding Source={x:Reference ActivityIndicatorColorPicker},\r\n" +
    "                          Path=SelectedItem,\r\n" +
    "                          Converter={x:StaticResource StringToColorConverter}}\" />\r\n" +
    "    <core:SourceCodeExpander Code=\"{x:Binding BindingActivityIndicators}\" />\r\n" +
    "</VerticalStackLayout>";

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
