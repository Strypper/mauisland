namespace MAUIsland;
public partial class PopupPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public PopupPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string standardPopupCSharpCode = "    private async void Button_Clicked(object sender, EventArgs e)\r\n    {\r\n        await DisplayAlert(\"Sample Popup Alert\", \"You have been alerted\", \"OK\");\r\n    }";
    [ObservableProperty]
    string captureResponsePopupCSharpCode = "    private async void Button_Clicked_1(object sender, EventArgs e)\r\n    {\r\n        bool answer = await DisplayAlert(\"Question?\", \"Would you like to play a game\", \"Yes\",\"No\");\r\n        await DisplayAlert(\"Answer\",$\"Answer is {( answer ? \"yes\" : \"no\")}\" , \"OK\");\r\n    }";
    [ObservableProperty]
    string actionSheetPopupCSharpCode = "    private async void Button_Clicked_2(object sender, EventArgs e)\r\n    {\r\n        string answer = await DisplayActionSheet(\"What game do you wanna play?\", \"Cancel\", null, \"LOL\", \"Halo\", \"Dota2\");\r\n        if (answer != \"Cancel\")\r\n        {\r\n            await DisplayAlert(\"Answer\", $\"{answer} is great!\", \"OK\");\r\n        }\r\n    }";
    [ObservableProperty]
    string promptPopupCSharpCode = "    private async void Button_Clicked_3(object sender, EventArgs e)\r\n    {\r\n        string answer = await DisplayPromptAsync(\"Hello\", \"What's your name?\",placeholder: \"Type your name\");\r\n        if (answer != null) \r\n        {\r\n            await DisplayAlert(\"Welcome\", $\"Hello, {answer}\",\"Cancel\");\r\n        }\r\n    }";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}