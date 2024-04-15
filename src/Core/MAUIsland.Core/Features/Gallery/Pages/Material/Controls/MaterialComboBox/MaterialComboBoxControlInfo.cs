using Material.Components.Maui;

namespace MAUIsland.Core;
class MaterialComboBoxControlInfo : IMaterialUIGalleryCardInfo
{
    public string ControlName => nameof(ComboBox);
    public string ControlRoute => "MAUIsland.MaterialComboBoxPage";
    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_caret_down_24_regular
    };
    public string ControlDetail => "ComboBox displays a short list of items, from which the user can select an item.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Material/Controls/MaterialComboBox";
    public string DocumentUrl => $"https://mdc-maui.github.io/combo-box";
    public string GroupName => ControlGroupInfo.MaterialComponent;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();

    public string MaterialIcon => IconPacks.IconKind.Material.ArrowDropDown;
}