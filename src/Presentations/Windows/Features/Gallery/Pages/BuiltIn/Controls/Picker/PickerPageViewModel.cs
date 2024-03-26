using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;


public partial class PickerPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public PickerPageViewModel(IAppNavigator appNavigator,
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
    string memberPickerXamlCode =
        "<VerticalStackLayout Spacing=\"10\">\r\n" +
        "    <Label Style=\"{x:StaticResource DocumentSectionTitleStyle}\" Text=\"A simple Picker for selecting MAUIsland members\" />\r\n" +
        "    <Picker\r\n" +
        "        x:Name=\"picker\"\r\n" +
        "        Title=\"Select a MAUIsland members\"\r\n" +
        "        ItemsSource=\"{x:StaticResource MAUIMembers}\"\r\n" +
        "        SelectedIndex=\"3\" />\r\n" +
        "    <Button BackgroundColor=\"Black\"\r\n" +
        "        HorizontalOptions=\"Start\"\r\n" +
        "        Text=\"{x:Binding Source={x:Reference picker},\r\n" +
        "                     Path=SelectedItem}\"\r\n" +
        "        TextColor=\"{x:StaticResource White}\" />\r\n" +
        "    <core:SourceCodeExpander Code=\"{x:Binding MemberPickerXamlCode}\" />\r\n" +
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
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
