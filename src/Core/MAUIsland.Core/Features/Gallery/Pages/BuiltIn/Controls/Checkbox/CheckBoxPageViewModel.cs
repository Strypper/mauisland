using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class CheckBoxPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public CheckBoxPageViewModel(IAppNavigator appNavigator,
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

    #region [ Properties ]

    [ObservableProperty]
    bool isChecked;

    [ObservableProperty]
    Color currentColor = new Color(242, 241, 241, 255);

    [ObservableProperty]
    string standardCheckBoxXamlCode = "<CheckBox />";

    [ObservableProperty]
    string checkBoxWithColorXamlCode = "<CheckBox Color=\"#FFFFFF\"/>";

    [ObservableProperty]
    string checkBoxTrueByDefaultXamlCode = "<CheckBox IsChecked=\"True\"/>";

    [ObservableProperty]
    string checkBoxWithBindingXamlCode =
    "<CheckBox IsChecked=\"{Binding IsChecked, Mode=TwoWay}\" " +
               "Color=\"{Binding CurrentColor, Mode=OneWay}\"/>";

    [ObservableProperty]
    string checkBoxWithLabelXamlCode =
    "<HorizontalStackLayout HorizontalOptions=\"Start\" VerticalOptions=\"Center\">\n" +
    "    <Label\n" +
    "        FontAttributes=\"Bold\"\n" +
    "        FontSize=\"Default\"\n" +
    "        Text=\"CheckBox 1\" />\n" +
    "    <CheckBox x:Name=\"checkBox1\" />\n" +
    "</HorizontalStackLayout>";

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
