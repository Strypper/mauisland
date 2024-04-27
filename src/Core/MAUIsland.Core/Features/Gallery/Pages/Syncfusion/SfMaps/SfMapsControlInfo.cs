using Syncfusion.Maui.Maps;

namespace MAUIsland.Core;
class SfMapsControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfMaps);
    public string ControlRoute => $"MAUIsland.{ControlName}ViewPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_map_24_regular
    };
    public string ControlDetail => "Maps is a powerful data visualization component that displays statistical informationfor a geographical area. It has highly interactive and customizable featuressuch as selection, tooltip, legends, markers, bubbles, and color mapping. Userscan generate maps for population density, sales, political boundaries, weather,elections, and routes";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Syncfusion/Controls/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/maps/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}