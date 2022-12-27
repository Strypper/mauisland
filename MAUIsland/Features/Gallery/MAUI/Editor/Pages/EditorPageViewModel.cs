namespace MAUIsland;

public partial class EditorPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public EditorPageViewModel(IAppNavigator appNavigator)
                                : base(appNavigator)
    {

    }
    #endregion

    #region [Fields]
    [ObservableProperty]
    string title = "Welcome to Editor";

    [ObservableProperty]
    string simpleEditXamlCode = "<Editor x:Name=\"editor\"\r\n        Placeholder=\"Enter your response here\"\r\n        HeightRequest=\"250\"\r\n        TextChanged=\"OnEditorTextChanged\"\r\n        Completed=\"OnEditorCompleted\" />";
    #endregion
}
