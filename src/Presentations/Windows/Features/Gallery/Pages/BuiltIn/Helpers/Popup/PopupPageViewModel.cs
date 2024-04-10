using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;
public partial class PopupPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    private readonly IDialogService dialogService;
    #endregion

    #region [ CTor ]
    public PopupPageViewModel(IAppNavigator appNavigator,
                              IGitHubService gitHubService,
                              IDialogService dialogService,
                              IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                : base(appNavigator,
                                        gitHubService,
                                        gitHubIssueLocalDbService)
    {
        this.dialogService = dialogService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    string standardPopupCSharpCode =
    "private async void Button_Clicked(object sender, EventArgs e)\r\n" +
    "{\r\n" +
    "    await DisplayAlert(\"Sample Popup Alert\", \"You have been alerted\", \"OK\");\r\n" +
    "}";

    [ObservableProperty]
    string captureResponsePopupCSharpCode =
        "private async void Button_Clicked_1(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    bool answer = await DisplayAlert(\"Question?\", \"Would you like to play a game\", \"Yes\",\"No\");\r\n" +
        "    await DisplayAlert(\"Answer\",$\"Answer is {( answer ? \"yes\" : \"no\")}\" , \"OK\");\r\n" +
        "}";

    [ObservableProperty]
    string actionSheetPopupCSharpCode =
        "private async void Button_Clicked_2(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    string answer = await DisplayActionSheet(\"What game do you wanna play?\", \"Cancel\", null, \"LOL\", \"Halo\", \"Dota2\");\r\n" +
        "    if (answer != \"Cancel\")\r\n" +
        "    {\r\n" +
        "        await DisplayAlert(\"Answer\", $\"{answer} is great!\", \"OK\");\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string promptPopupCSharpCode =
        "private async void Button_Clicked_3(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    string answer = await DisplayPromptAsync(\"Hello\", \"What's your name?\",placeholder: \"Type your name\");\r\n" +
        "    if (answer != null) \r\n" +
        "    {\r\n" +
        "        await DisplayAlert(\"Welcome\", $\"Hello, {answer}\",\"Cancel\");\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string viewModelPopUpInterfaceCode =
    "public interface IDialogService\r\n" +
    "{\r\n" +
    "    Task<bool> ShowConfirmationAsync(string title, string message);\r\n" +
    "    Task ShowAlertAsync(string title, string message, string accept, string cancel);\r\n" +
    "    Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons);\r\n" +
    "}\r\n";

    [ObservableProperty]
    string viewModelPopUpCSharpCode =
    "public class DialogService : IDialogService\r\n" +
    "{\r\n" +
    "    public Task<bool> ShowConfirmationAsync(string title, string message)\r\n" +
    "    {\r\n" +
    "        return Application.Current.MainPage.DisplayAlert(title, message, \"Understandable, have a nice day\", \"Cancel\");\r\n" +
    "    }\r\n\r\n" +
    "    public Task ShowAlertAsync(string title, string message, string accept, string cancel)\r\n" +
    "    {\r\n" +
    "        return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);\r\n" +
    "    }\r\n\r\n" +
    "    public Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons)\r\n" +
    "    {\r\n" +
    "        return Application.Current.MainPage.DisplayActionSheet(title, \"Closed\", destruction, buttons);\r\n" +
    "    }\r\n" +
    "}\r\n";

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
    Task TriggerDialogFromViewModelAsync()
    {
        return dialogService.ShowConfirmationAsync("I'm from the Viewmodel", "This dialog was opened from the view model instead of code behind");
    }

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