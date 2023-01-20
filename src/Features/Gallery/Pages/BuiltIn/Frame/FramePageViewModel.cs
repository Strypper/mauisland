namespace MAUIsland;
public partial class FramePageViewModel : NavigationAwareBaseViewModel
{

    #region [CTor]
    public FramePageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string standardCreateFrameXamlCode = "<Frame>\r\n                        <Label Text=\"Frame wrapped around a Label\" />\r\n                    </Frame>";

    [ObservableProperty]
    string createTheSecondFrameXamlCode = "<Frame\r\n                        BackgroundColor=\"DimGrey\"\r\n                        BorderColor=\"Grey\"\r\n                        CornerRadius=\"10\">\r\n                        <Label Text=\"Frame wrapped around a Label\" />\r\n                    </Frame>";
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