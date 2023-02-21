using ZXing.Net.Maui;

namespace MAUIsland;
public partial class ZXingNetMauiPage : IControlPage
{
    #region [CTor]
    public ZXingNetMauiPage(ZXingNetMauiPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = true
        };
    }
    #endregion

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach (var barcode in e.Results)
            Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
    }
}