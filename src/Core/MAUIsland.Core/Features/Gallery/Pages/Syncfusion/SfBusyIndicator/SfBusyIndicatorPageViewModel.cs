namespace MAUIsland.Core;
public partial class SfBusyIndicatorPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public SfBusyIndicatorPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string simpleBusyIndicator = "<core:SfBusyIndicator x:Name=\"busyindicator\"\r\n                      AnimationType=\"CircularMaterial\"\r\n                      IsRunning=\"false\" />";
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