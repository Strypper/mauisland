namespace MAUIsland;



public partial class RefreshViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public RefreshViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    bool isBusy;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        IsBusy = true;
        await AppNavigator.ShowSnackbarAsync("You triggered refresh", null, "Ok");
        IsBusy = false;
    }
    #endregion
}
