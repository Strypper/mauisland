namespace MAUIsland;
public partial class SfBarcodeGeneratorPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfBarcodeGeneratorPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    [ObservableProperty]
    string basicSfBarcodeGeneratorXamlCode = "<barcode:SfBarcodeGenerator Value=\"Welcome to MAUIsland!\"\r\n                                                 HeightRequest=\"100\"\r\n                                                 WidthRequest=\"300\"\r\n                                                 BackgroundColor=\"White\"/>";

    [ObservableProperty]
    string qrSfBarcodeGeneratorXamlCode = "<barcode:SfBarcodeGenerator Value=\"Welcome to MAUIsland!\"\r\n                                                HeightRequest=\"100\"\r\n                                                WidthRequest=\"300\"\r\n                                                BackgroundColor=\"White\">\r\n                        <barcode:SfBarcodeGenerator.Symbology>\r\n                            <barcode:QRCode />\r\n                        </barcode:SfBarcodeGenerator.Symbology>\r\n</barcode:SfBarcodeGenerator>";

    [ObservableProperty]
    string customSfBarcodeGeneratorXamlCode = "<barcode:SfBarcodeGenerator Value=\"Welcome to MAUIsland!\"\r\n                                                HeightRequest=\"100\"\r\n                                                WidthRequest=\"300\"\r\n                                                ShowText=\"True\"\r\n                                                ForegroundColor=\"Purple\"\r\n                                                BackgroundColor=\"LightCyan\">\r\n                        <barcode:SfBarcodeGenerator.TextStyle>\r\n                            <barcode:BarcodeTextStyle FontAttributes=\"Italic\" \r\n                                              FontSize=\"16\" \r\n                                              TextColor=\"Red\"/>\r\n                        </barcode:SfBarcodeGenerator.TextStyle>\r\n</barcode:SfBarcodeGenerator>";
}