using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;

namespace MAUIsland;
public partial class MediaElementPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MediaElementPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    double volume;

    [ObservableProperty]
    MediaElementState currentState;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string setupDescription = 
        "In order to use the toolkit in XAML the following xmlns needs to be added into your page or view:";

    [ObservableProperty]
    string xamlNamespace = 
        "xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"";

    [ObservableProperty]
    string fullNamepaceExampleBefore =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string fullNamepaceExampleAfter = 
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "    xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\">\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string iOSBypassing = "To bypass the Hardware Silent Switch on iOS, add the following lines of code to MauiProgram.cs. This ensures that MediaElement's playback audio will always be audible to the user regardless of their device's Hardware Silent Switch.";

    [ObservableProperty]
    string iOSBypassingSetup =
        "public static class MauiProgram\r\n" +
        "{\r\n" +
        "    public static MauiApp CreateMauiApp()\r\n\t" +
        "    {\r\n" +
        "#if IOS\r\n" +
        "        AVAudioSession.SharedInstance().SetActive(true);\r\n" +
        "        AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);\r\n" +
        "#endif\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string xamlSimpleRemoteMediaElement =
        "<toolkit:MediaElement MinimumHeightRequest=\"200\"\r\n" +
        "                      houldShowPlaybackControls=\"True\"\r\n" +
        "                      Source=\"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4\" />";


    [ObservableProperty]
    string xamlSimpleLocalMediaElement =
        "<toolkit:MediaElement Source = \"embed://MyFile.mp4\"\r\n" +
        "                      ShouldShowPlaybackControls=\"True\" />";
    [ObservableProperty]
    string mediaSourceStaticMethodsExample =
        "// FromFile\r\n" +
        "var mediaSource = MediaSource.FromFile(\"localfile.mp4\");\r\n" +
        "mediaElement.Source = mediaSource;\r\n\r\n " +
        "// FromUri\r\n " +
        "var mediaSource = MediaSource.FromUri(new Uri(\"https://website.com/media.mp4\"));\r\n" +
        "mediaElement.Source = mediaSource;\r\n\r\n" +
        "// FromResource\r\n" +
        "var mediaSource = MediaSource.FromResource(\"YourAppName.Resources.media.mp4\");\r\n" +
        "mediaElement.Source = mediaSource;";

    [ObservableProperty]
    string mediaSourceExample =
        "// UriMediaSource\r\n" +
        "var uriMediaSource = new UriMediaSource { Uri = new Uri(\"https://website.com/media.mp4\") };\r\n" +
        "mediaElement.Source = uriMediaSource;\r\n\r\n" +
        "// FileMediaSource\r\n" +
        "var fileMediaSource = new FileMediaSource { File = \"media.mp4\" };\r\n" +
        "mediaElement.Source = fileMediaSource;\r\n\r\n" +
        "// ResourceMediaSource\r\n" +
        "var resourceMediaSource = new ResourceMediaSource { Resource = \"YourAppName.Resources.media.mp4\" };\r\n" +
        "mediaElement.Source = resourceMediaSource;";

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

    #region [ Load Data ]
    //public Task LoadData()
    //{
    //    var stream = new StreamMediaSource;
    //    var streamMediaSource = new StreamMediaSource { Stream = stream };
    //    mediaElement.Source = streamMediaSource;
    //}
    #endregion
}

public partial class SupportedFormatsTable
{
    public string Platform { get; set; }
    public string Link { get; set; }
    public string Notes { get; set; }
}