using Syncfusion.Maui.Barcode;

namespace MAUIsland.Gallery.Syncfusion;
class SfBarcodeGeneratorControlInfo : IControlInfo 
{
    public string ControlName => nameof(SfBarcodeGenerator);
    public string ControlRoute => typeof(SfBarcodeGeneratorPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The Syncfusion .NET MAUI Barcode Generator is a data visualization control used to generate and display data in a machine-readable format. It provides a perfect approach to encode text using supported symbology types.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/barcode-generator/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}