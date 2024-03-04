namespace MAUIsland;
class MaterialProgressIndicatorControlInfo : IMaterialUIGalleryCardInfo
{
    public string ControlName => nameof(Material.Components.Maui.ProgressIndicator);
    public string ControlRoute => typeof(MaterialProgressIndicatorPage).FullName;
    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_add_circle_24_regular
    };
    public string ControlDetail => "Progress indicators show the status of a process in real time.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialProgressIndicator";
    public string DocumentUrl => $"https://mdc-maui.github.io/progress-indicator";
    public string GroupName => ControlGroupInfo.MaterialComponent;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();

    public string MaterialIcon => IconPacks.IconKind.Material.PublishedWithChanges;
}