using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class CheckBoxPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public CheckBoxPageViewModel(IAppNavigator appNavigator,
                                 IGitHubService gitHubService,
                                 IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                : base(appNavigator,
                                       gitHubService,
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
    string currentColor = "F2F1F1";

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

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
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
