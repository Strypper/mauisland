namespace MAUIsland;


public partial class TimePickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public TimePickerPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    string dumbassText = "Bruh";

    [ObservableProperty]
    IControlInfo controlInformation;

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
    #endregion

    #region [Methods]
    #endregion
}
