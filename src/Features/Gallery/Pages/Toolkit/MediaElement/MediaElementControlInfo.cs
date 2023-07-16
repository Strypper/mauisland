using CommunityToolkit.Maui.Views;

namespace MAUIsland;

class MediaElementControlInfo : IControlInfo
{
    public string ControlName => nameof(MediaElement);
    public string ControlRoute => "MAUIsland.MediaElementPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_video_clip_24_regular
    };
    public string ControlDetail => "MediaElement is a control for playing video and audio.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/{ControlName}";
    public string DocumentUrl => "https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/mediaelement";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
}