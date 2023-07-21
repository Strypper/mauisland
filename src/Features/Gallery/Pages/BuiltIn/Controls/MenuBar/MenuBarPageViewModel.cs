namespace MAUIsland;

public partial class MenuBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public MenuBarPageViewModel(IAppNavigator appNavigator)
                                : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;
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
