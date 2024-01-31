using Syncfusion.Maui.Sliders;

namespace MAUIsland.Gallery.Syncfusion;
class SfRangeSelectorControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfRangeSelector);
    public string ControlRoute => typeof(SfRangeSelectorPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_auto_fit_width_24_regular
    };
    public string ControlDetail => "The Syncfusion .NET MAUI Range Selector (SfRangeSelector) is a highly interactive UI control, allowing users to select a range values within a minimum and maximum limit. It provides rich features, such as track, labels, ticks, dividers, and tooltip.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Syncfusion/Controls/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/range-selector/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}