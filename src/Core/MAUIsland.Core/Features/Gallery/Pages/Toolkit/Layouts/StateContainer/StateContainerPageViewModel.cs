using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class StateContainerPageViewModel : BaseToolkitPageControlViewModel
{
    #region [ CTor ]

    public StateContainerPageViewModel(IAppNavigator appNavigator,
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
    bool canStateChange = true;

    [ObservableProperty]
    string currentState = "Loading";

    [ObservableProperty]
    string xamlStateContainerLayout =
        "<VerticalStackLayout toolkit:StateContainer.CanStateChange=\"{Binding CanStateChange}\" toolkit:StateContainer.CurrentState=\"{Binding CurrentState}\">\r\n" +
        "    <toolkit:StateContainer.StateViews>\r\n" +
        "        <VerticalStackLayout toolkit:StateView.StateKey=\"Loading\">\r\n" +
        "            <ActivityIndicator IsRunning=\"True\" />\r\n" +
        "            <Label Text=\"Loading Content...\" />\r\n" +
        "        </VerticalStackLayout>\r\n" +
        "        <Label toolkit:StateView.StateKey=\"Success\" Text=\"Success!\" />\r\n" +
        "    </toolkit:StateContainer.StateViews>\r\n" +
        "\r\n" +
        "    <Label Text=\"Default Content\" />\r\n" +
        "    <Button Command=\"{Binding ChangeStateCommand}\" Text=\"Change State\" />\r\n" +
        "\r\n" +
        "</VerticalStackLayout>";

    [ObservableProperty]
    string csharpStateContainerLayout =
    "[ObservableProperty]\r\n" +
    "bool canStateChange = true;\r\n" +
    "\r\n" +
    "[ObservableProperty]\r\n" +
    "string currentState = \"Loading\";\r\n" +
    "[RelayCommand(CanExecute = nameof(CanStateChange))]\r\n" +
    "void ChangeState()\r\n" +
    "{\r\n" +
    "    CurrentState = CurrentState == \"Success\"\r\n" +
    "                            ?\r\n" +
    "                            \"Loading\"\r\n" +
    "                            :\r\n" +
    "                            \"Success\";\r\n" +
    "}";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<ICommunityToolkitGalleryCardInfo>();
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
    }

    [RelayCommand(CanExecute = nameof(CanStateChange))]
    void ChangeState()
    {
        CurrentState = CurrentState == "Success"
                                ?
                                "Loading"
                                :
                                "Success";
    }
    #endregion
}
