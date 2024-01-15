using Syncfusion.Maui.Barcode;

namespace MAUIsland.Gallery.Syncfusion;
class SfBarcodeGeneratorControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfBarcodeGenerator);
    public string ControlRoute => typeof(SfBarcodeGeneratorPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_barcode_scanner_24_regular
    };
    public string ControlDetail => "The Syncfusion .NET MAUI Barcode Generator is a data visualization control used to generate and display data in a machine-readable format. It provides a perfect approach to encode text using supported symbology types.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/Controls/SfRadialGauge";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/barcode-generator/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}