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
    #endregion
}
