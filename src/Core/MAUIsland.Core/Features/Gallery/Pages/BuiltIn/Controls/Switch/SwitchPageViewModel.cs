using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;
public partial class SwitchPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public SwitchPageViewModel(IAppNavigator appNavigator,
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
    string standardSwitchXamlCode =
        "<Switch IsToggled=\"True\"\r\n" +
        "        OnColor=\"Pink\"\r\n" +
        "        ThumbColor=\"ForestGreen\"/>";

    [ObservableProperty]
    string advanceSwitchXamlCode =
        "Data bind\r\n\r\n" +
        "<Label Margin=\"0,10,0,5\"\r\n" +
        "       FontSize=\"15\">\r\n" +
        "    <Label.Triggers>\r\n" +
        "        <DataTrigger TargetType=\"Label\"\r\n" +
        "                     Binding=\"{Binding Source={x:Reference switch2}, Path=IsToggled}\"\r\n" +
        "                     Value=\"True\">\r\n" +
        "            <Setter Property=\"Text\"\r\n" +
        "                    Value=\"The light is on 😊\"/>\r\n" +
        "            <Setter Property=\"TextColor\"\r\n" +
        "                    Value=\"Yellow\"/>\r\n" +
        "        </DataTrigger>\r\n" +
        "        <DataTrigger TargetType=\"Label\"\r\n" +
        "                     Binding=\"{Binding Source={x:Reference switch2}, Path=IsToggled}\"\r\n" +
        "                     Value=\"False\">\r\n" +
        "            <Setter Property=\"Text\"\r\n" +
        "                    Value=\"The light is off 😭\"/>\r\n" +
        "            <Setter Property=\"TextColor\"\r\n" +
        "                    Value=\"Gray\"/>\r\n" +
        "        </DataTrigger>\r\n" +
        "    </Label.Triggers>\r\n" +
        "</Label>\r\n\r\n" +
        "Visual States\r\n\r\n" +
        "<Switch x:Name=\"switch2\"\r\n" +
        "        OnColor=\"CadetBlue\">\r\n" +
        "    <VisualStateManager.VisualStateGroups>\r\n" +
        "        <VisualStateGroupList>\r\n" +
        "            <VisualStateGroup x:Name=\"SwitchCommonStates\">\r\n" +
        "                <VisualState x:Name=\"On\">\r\n" +
        "                    <VisualState.Setters>\r\n" +
        "                        <Setter Property=\"ThumbColor\"\r\n" +
        "                                Value=\"MediumSpringGreen\" />\r\n" +
        "                    </VisualState.Setters>\r\n" +
        "                </VisualState>\r\n" +
        "                <VisualState x:Name=\"Off\">\r\n" +
        "                    <VisualState.Setters>\r\n" +
        "                        <Setter Property=\"ThumbColor\"\r\n" +
        "                                Value=\"Red\" />\r\n" +
        "                    </VisualState.Setters>\r\n" +
        "                </VisualState>\r\n" +
        "            </VisualStateGroup>\r\n" +
        "        </VisualStateGroupList>\r\n" +
        "    </VisualStateManager.VisualStateGroups>\r\n" +
        "</Switch>";
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
