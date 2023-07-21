using Syncfusion.Maui.Core;

namespace MAUIsland.Gallery.Syncfusion;
class SfBadgeViewControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfBadgeView);
    public string ControlRoute => typeof(SfBadgeViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_mail_alert_24_regular
    };
    public string ControlDetail => "Badges are used to notify users of new or unread messages, notifications, or the status of something.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/badge-view/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}