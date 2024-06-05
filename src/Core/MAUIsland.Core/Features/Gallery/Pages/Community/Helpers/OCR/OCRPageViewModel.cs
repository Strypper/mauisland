using Plugin.Maui.OCR;

namespace MAUIsland.Core;
public partial class OCRPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IFilePicker filePicker;
    #endregion

    #region [ CTor ]
    public OCRPageViewModel(
        IFilePicker filePicker,
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
        this.filePicker = filePicker;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    string headerFeatures = "Key features of the repository include:";

    [ObservableProperty]
    List<string> features = new()
    {
        "Platform Compatibility: The plugin supports iOS, Android, Windows, and macOS across both Xamarin and MAUI platforms, although some features are still a work in progress for certain platforms.",
        "Ease of Use: It simplifies OCR integration by eliminating the need to deal with platform-specific intricacies and external libraries. Developers can use straightforward methods to process images and extract text.",
        "Installation: The plugin can be easily installed via NuGet packages for both MAUI and Xamarin. Instructions for setup and initialization are provided in the repository.",
        "Pattern Matching: The plugin includes advanced features like pattern matching, which can be used to recognize specific text patterns such as dates, phone numbers, or custom formats.",
        "Permissions: Guidance on necessary permissions for iOS and Android is provided, ensuring smooth setup and execution of OCR functionalities."
    };

    [ObservableProperty]
    string uploadAnImageHeader = "Upload an image to extract text";

    [ObservableProperty]
    ImageSource imageSourceSample = default!;

    [ObservableProperty]
    string extractedText = string.Empty;

    [ObservableProperty]
    string extractStatus = string.Empty;

    [ObservableProperty]
    bool isTryHard = false;

    [ObservableProperty]
    string tryHardTip = "The tryhard boolean in OCR libraries, particularly those using Tesseract, is typically a parameter that influences the level of effort or accuracy applied during the text recognition process. When tryhard is set to true, the OCR engine might perform additional processing steps, such as multiple passes over the image, more extensive image preprocessing, or more aggressive error correction, in an attempt to improve the accuracy of the recognized text.";
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


    [RelayCommand]
    async Task CopyToClipboardAsync(string text)
    {
        await Clipboard.Default.SetTextAsync(text);
        await AppNavigator.ShowSnackbarAsync("Code copied to clipboard", null, null);
    }


    [RelayCommand]
    async Task OpenFileAsync()
    {
        var pickedImage = await filePicker.OpenMediaPickerAsync();

        var imagefile = await filePicker.UploadImageFile(pickedImage);

        if (imagefile is null || imagefile.byteBase64 is null)
            return;

        ImageSourceSample = ImageSource.FromStream(() =>
            filePicker.ByteArrayToStream(filePicker.StringToByteBase64(imagefile.byteBase64))
        );

        await ExtractTextAsync(imagefile, IsTryHard);
    }
    #endregion

    #region [ Methods - Private ]

    async Task ExtractTextAsync(ImageFile imageFile, bool isTryHard = false)
    {
        ExtractedText = string.Empty;
        byte[] imageBytes = Convert.FromBase64String(imageFile.byteBase64);
        var ocrResult = await OcrPlugin.Default.RecognizeTextAsync(imageBytes, isTryHard);

        if (!ocrResult.Success)
        {
            ExtractStatus = "Extraction is unsuccess";
            return;
        }

        ExtractedText = ocrResult.AllText;
        ExtractStatus = string.Empty;
    }
    #endregion
}