namespace MAUIsland;
public partial class MediaElementPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public MediaElementPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string xamlNamespace = "xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"";

    [ObservableProperty]
    string xamlSimpleMediaElement = "<Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\">\r\n                <toolkit:MediaElement ShouldShowPlaybackControls=\"True\" Source=\"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4\" />\r\n </Frame>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion
}