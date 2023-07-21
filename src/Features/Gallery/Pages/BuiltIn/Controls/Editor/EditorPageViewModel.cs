namespace MAUIsland;

public partial class EditorPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public EditorPageViewModel(IAppNavigator appNavigator)
                                : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string title = "Welcome to Editor";

    [ObservableProperty]
    string simpleEditXamlCode = "<Editor x:Name=\"editor\"\r\n        Placeholder=\"Enter your response here\"\r\n        HeightRequest=\"250\"\r\n        TextChanged=\"OnEditorTextChanged\"\r\n        Completed=\"OnEditorCompleted\" />";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
