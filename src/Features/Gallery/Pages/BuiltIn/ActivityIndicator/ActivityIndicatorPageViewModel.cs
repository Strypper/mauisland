namespace MAUIsland;

public partial class ActivityIndicatorPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public ActivityIndicatorPageViewModel(IAppNavigator appNavigator)
                                                : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string groupOfActivityIndicators = "<HorizontalStackLayout HorizontalOptions=\"Start\" Spacing=\"10\">\r\n                    <ActivityIndicator IsRunning=\"True\" />\r\n\r\n                    <ActivityIndicator IsRunning=\"True\" Color=\"Green\" />\r\n\r\n                    <ActivityIndicator IsRunning=\"True\" Color=\"Red\" />\r\n\r\n                    <ActivityIndicator IsRunning=\"true\" Color=\"Aqua\" />\r\n             </HorizontalStackLayout>";

    [ObservableProperty]
    string bindingActivityIndicators = " <HorizontalStackLayout Spacing=\"10\">\r\n                    <Picker\r\n                        x:Name=\"ActivityIndicatorColorPicker\"\r\n                        Title=\"Choose Color\"\r\n                        ItemsSource=\"{x:StaticResource ActivityIndicatorColorResource}\"\r\n                        VerticalOptions=\"Center\" />\r\n                    <Switch\r\n                        x:Name=\"ActivityIndicatorSwitch\"\r\n                        IsToggled=\"True\"\r\n                        VerticalOptions=\"End\" />\r\n                </HorizontalStackLayout>\r\n                <ActivityIndicator\r\n                    HorizontalOptions=\"Start\"\r\n                    IsRunning=\"{x:Binding Source={x:Reference ActivityIndicatorSwitch},\r\n                                          Path=IsToggled}\"\r\n                    Color=\"{x:Binding Source={x:Reference ActivityIndicatorColorPicker},\r\n                                      Path=SelectedItem,\r\n                                      Converter={x:StaticResource StringToColorConverter}}\" />";
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
}
