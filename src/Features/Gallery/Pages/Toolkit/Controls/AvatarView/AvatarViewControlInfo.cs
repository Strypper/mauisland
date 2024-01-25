using CommunityToolkit.Maui.Views;

namespace MAUIsland;

class AvatarViewControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(AvatarView);
    public string ControlRoute => typeof(AvatarViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_person_circle_24_regular,
    };
    public string ControlDetail => "AvatarView is a control for displaying a user's avatar image or their initials. Avatars can be text, image, colored, shaped and supports shadow and gestures.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/Controls/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/avatarview";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
