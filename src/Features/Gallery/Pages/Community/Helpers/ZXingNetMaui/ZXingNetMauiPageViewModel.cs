namespace MAUIsland;
public partial class ZXingNetMauiPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public ZXingNetMauiPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string packageReference = "<PackageReference Include=\"ZXing.Net.Maui.Controls\" Version=\"0.4.0\" />";

    [ObservableProperty]
    string dotnetCLI = "dotnet add package ZXing.Net.Maui.Controls --version 0.4.0";

    [ObservableProperty]
    string serviceRegisterCode = "// Add the using to the top\r\nusing ZXing.Net.Maui;\r\n\r\n// ... other code \r\n\r\npublic static MauiApp Create()\r\n{\r\n\tvar builder = MauiApp.CreateBuilder();\r\n\r\n\tbuilder\r\n\t\t.UseMauiApp<App>()\r\n\t\t.UseBarcodeReader(); // Make sure to add this line\r\n\r\n\treturn builder.Build();\r\n}";

    [ObservableProperty]
    string androidManifest = "<uses-permission android:name=\"android.permission.CAMERA\" />";

    [ObservableProperty]
    string iosInfoPlist = "<key>NSCameraUsageDescription</key>\r\n<string>This app uses barcode scanning to...</string>";

    [ObservableProperty]
    string xamlNameSpace = "xmlns:zxing=\"clr-namespace:ZXing.Net.Maui.Controls;assembly=ZXing.Net.MAUI.Controls\"";

    [ObservableProperty]
    string declareControlCode = "<zxing:CameraBarcodeReaderView\r\n  x:Name=\"cameraBarcodeReaderView\"\r\n  BarcodesDetected=\"BarcodesDetected\" />";

    [ObservableProperty]
    string configReaderOptions = "cameraBarcodeReaderView.Options = new BarcodeReaderOptions\r\n{\r\n  Formats = BarcodeFormats.OneDimensional,\r\n  AutoRotate = true,\r\n  Multiple = true\r\n};";

    [ObservableProperty]
    string toggleTorch = "cameraBarcodeReaderView.IsTorchOn = !cameraBarcodeReaderView.IsTorchOn;";

    [ObservableProperty]
    string flipBetweenRearFrontCamera = "cameraBarcodeReaderView.CameraLocation\r\n  = cameraBarcodeReaderView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;";

    [ObservableProperty]
    string detectBarCode = "protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)\r\n{\r\n  foreach (var barcode in e.Results)\r\n    Console.WriteLine($\"Barcodes: {barcode.Format} -> {barcode.Value}\");\r\n}";

    [ObservableProperty]
    string barCodeGeneratorView = "<zxing:BarcodeGeneratorView\r\n  HeightRequest=\"100\"\r\n  WidthRequest=\"100\"\r\n  ForegroundColor=\"DarkBlue\"\r\n  Value=\"https://dotnet.microsoft.com\"\r\n  Format=\"QrCode\"\r\n  Margin=\"3\" />";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Relay commands ]


    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion
}