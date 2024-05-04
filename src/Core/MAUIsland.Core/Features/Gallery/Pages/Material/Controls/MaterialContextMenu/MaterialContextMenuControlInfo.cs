using Material.Components.Maui;

namespace MAUIsland.Core;
public class MaterialContextMenuControlInfo : IMaterialUIGalleryCardInfo
{
    public string ControlName => nameof(ContextMenu);
    public string ControlRoute => "MAUIsland.MaterialContextMenuPage";
    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_list_24_regular
    };
    public string ControlDetail => "ContextMenu display a list of choices on a temporary surface, It can be included in the component that has the touch event.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Material/Controls/MaterialContextMenu";
    public string DocumentUrl => $"https://mdc-maui.github.io/context-menu";
    public string GroupName => ControlGroupInfo.MaterialComponent;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();

    public string MaterialIcon => IconPacks.IconKind.Material.List;
}