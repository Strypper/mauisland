namespace MAUIsland.Gallery.DevExpress;
class DevExpressButtonControlInfo : IGalleryCardInfo 
{
    public string ControlName => "Simple Button";
    public string ControlRoute => typeof(DevExpressButtonPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The DevExpress Mobile UI for .NET MAUI suite contains the SimpleButton component that allows users to trigger actions. You can assign an icon to the button, specify the background color, shape, and much more.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/DevExpress/{ControlName}";
    public string DocumentUrl => $"https://docs.devexpress.com/MAUI/403983/button-chips-and-checkbox/index";
    public string GroupName => ControlGroupInfo.DevExpressControls;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => GalleryCardStatus.Completed;

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}