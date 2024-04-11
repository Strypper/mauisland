using CommunityToolkit.Maui.Views;

namespace MAUIsland.Core;

class MediaElementControlInfo : ICommunityToolkitGalleryCardInfo
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
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/Controls/{ControlName}";
    public string DocumentUrl => "https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/mediaelement";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}