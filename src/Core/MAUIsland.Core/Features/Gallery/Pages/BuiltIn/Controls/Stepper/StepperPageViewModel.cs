using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class StepperPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public StepperPageViewModel(IAppNavigator appNavigator,
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

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    string xamlStandardStepper =
        "<StackLayout Margin=\"20\">\r\n" +
        "   <Label x:Name=\"RotatingLabel\"\r\n" +
        "          Text=\"ROTATING TEXT\"\r\n" +
        "          FontSize=\"18\"\r\n" +
        "          VerticalOptions=\"Center\"\r\n" +
        "          HorizontalOptions=\"Center\" />\r\n" +
        "   <Stepper HorizontalOptions=\"Center\"\r\n" +
        "            Increment=\"30\"\r\n" +
        "            Maximum=\"360\"\r\n" +
        "            ValueChanged=\"OnStepperValueChanged\" />\r\n" +
        "   <Label x:Name=\"DisplayLabel\"\r\n" +
        "          Text=\"(uninitialized)\"\r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          VerticalOptions=\"Center\" />\r\n" +
        "</StackLayout>";

    [ObservableProperty]
    string csharpStandardStepper =
        "private void OnStepperValueChanged(object sender, ValueChangedEventArgs e) \r\n" +
        "{\r\n" +
        "    double value = e.NewValue;\r\n" +
        "    RotatingLabel.Rotation = value;\r\n" +
        "    DisplayLabel.Text = string.Format(\"The Stepper value is {0}\", value);\r\n" +
        "}";

    [ObservableProperty]
    string xamlDataBindAStepper =
        "<StackLayout Margin=\"20\">\r\n" +
        "   <Label Rotation=\"{Binding Source={x:Reference MyStepper}, Path=Value}\"\r\n" +
        "          Text=\"ROTATING TEXT\"\r\n" +
        "          FontSize=\"18\"\r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          VerticalOptions=\"Center\" />\r\n" +
        "   <Stepper x:Name=\"MyStepper\"\r\n" +
        "            HorizontalOptions=\"Center\"\r\n" +
        "            Increment=\"30\"\r\n" +
        "            Maximum=\"360\" />\r\n" +
        "   <Label Text=\"{Binding Source={x:Reference MyStepper}, Path=Value, StringFormat='The Stepper value is {0:F0}'}\"\r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          VerticalOptions=\"Center\" />\r\n" +
        "</StackLayout>";

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
