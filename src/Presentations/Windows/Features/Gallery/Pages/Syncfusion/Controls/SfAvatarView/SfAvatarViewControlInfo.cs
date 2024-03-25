using Syncfusion.Maui.Core;

namespace MAUIsland;
class SfAvatarViewControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfAvatarView);
    public string ControlRoute => typeof(SfAvatarViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_person_32_regular
    };
    public string ControlDetail => "The .NET MAUI Avatar View control provides a graphical representation of user image that allows you to customize the view by adding image, background color, icon, text, etc.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Syncfusion/Controls/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/avatar-view/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}