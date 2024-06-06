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

    [ObservableProperty]
    string installPluginHeader = "Install Plugin";

    [ObservableProperty]
    string mauiNugetLink = "https://www.nuget.org/packages/Plugin.Maui.OCR/";

    [ObservableProperty]
    string xamarinNugetLink = "https://www.nuget.org/packages/Plugin.Xamarin.OCR/";

    [ObservableProperty]
    string dotNetMauiInstallNugetCLICommand = "dotnet add package Plugin.Maui.OCR";

    [ObservableProperty]
    string xamarinInstallNugetCLICommand = "dotnet add package Plugin.Xamarin.OCR";

    [ObservableProperty]
    string mauiSetupAndUsageHeader = "MAUI Setup and Usage";

    [ObservableProperty]
    string mauiSetupAndUsage = "For MAUI, to initialize make sure you use the MauiAppBuilder extension UseOcr() like so:";

    [ObservableProperty]
    string mauiProgramSetupCSharpCode = "public static class MauiProgram\r\n{\r\n\tpublic static MauiApp CreateMauiApp()\r\n\t{\r\n\t\tvar builder = MauiApp.CreateBuilder();\r\n\t\tbuilder\r\n\t\t\t.UseMauiApp<App>()\r\n\t\t\t.ConfigureFonts(fonts =>\r\n\t\t\t{\r\n\t\t\t\tfonts.AddFont(\"OpenSans-Regular.ttf\", \"OpenSansRegular\");\r\n\t\t\t\tfonts.AddFont(\"OpenSans-Semibold.ttf\", \"OpenSansSemibold\");\r\n\t\t\t}).\r\n\t\t\tUseOcr();  // <-- add this line\r\n\r\n\t\treturn builder.Build();\r\n\t}\r\n}";

    [ObservableProperty]
    string mauiSetupAndUsage1 = "And then you can just inject IOcrService into your classes and use it like so:";

    [ObservableProperty]
    string mauiSetupAndUsageCSharpCode = "/// <summary>\r\n/// Takes a photo and processes it using the OCR service.\r\n/// </summary>\r\n/// <param name=\"photo\">The photo to process.</param>\r\n/// <returns>The OCR result.</returns>\r\nprivate async Task<OcrResult> ProcessPhoto(FileResult photo)\r\n{\r\n    // Open a stream to the photo\r\n    using var sourceStream = await photo.OpenReadAsync();\r\n\r\n    // Create a byte array to hold the image data\r\n    var imageData = new byte[sourceStream.Length];\r\n\r\n    // Read the stream into the byte array\r\n    await sourceStream.ReadAsync(imageData);\r\n\r\n    // Process the image data using the OCR service\r\n    return await _ocr.RecognizeTextAsync(imageData);\r\n}";

    [ObservableProperty]
    string permissionsHeader = "Permissions";

    [ObservableProperty]
    string permissions = "Before you can start using Feature, you will need to request the proper permissions on each platform.";

    [ObservableProperty]
    string permissions1 = "IOS";

    [ObservableProperty]
    string permissions2 = "If you're handling camera, you'll need the usual permissions for that.";

    [ObservableProperty]
    string permissions3 = "Android";

    [ObservableProperty]
    string permissions4 = "If you're handling camera, you'll need the usual permissions for that. The only extra part you'll want in the AndroidManifest.xml is the following:";

    [ObservableProperty]
    string permissionsXMLCode = "<application ..>\r\n  <meta-data android:name=\"com.google.mlkit.vision.DEPENDENCIES\" android:value=\"ocr\" />\r\n</application>";

    [ObservableProperty]
    string permissions5 = "This will cause the model necessary to be installed when the application is installed.";

    [ObservableProperty]
    string patternMatchingHeader = "Pattern Matching";

    [ObservableProperty]
    string patternMatching = "One of the more common things I do with OCR is recognize a text pattern. For example, I might want to read a date, a phone number or an email address. This is where the OcrPatternConfig class comes in.";

    [ObservableProperty]
    string patternMatching1 = "Let's say you want to recognize an Ontario Health Card Number (HCN) in the text of your image. Numbers of those types have some specific qualities that make it easy to match.";

    [ObservableProperty]
    List<string> patternMatchingList = new()
    {
        "An Ontario HCN is 10 digits long.",
        "The number must be Luhn valid (meaning it has a check digit and it's correct)."
    };

    [ObservableProperty]
    string patternMatching2 = "To do this, you can create an OcrPatternConfig object like so:";

    [ObservableProperty]
    string patternMatchinCSharpCode = "bool IsValidLuhn(string number)\r\n{\r\n    // Convert the string to an array of digits\r\n    int[] digits = number.Select(d => int.Parse(d.ToString())).ToArray();\r\n    int checkDigit = 0;\r\n\r\n    // Luhn algorithm implementation\r\n    for (int i = digits.Length - 2; i >= 0; i--)\r\n    {\r\n        int currentDigit = digits[i];\r\n        if ((digits.Length - 2 - i) % 2 == 0) // check if it's an even index from the right\r\n        {\r\n            currentDigit *= 2;\r\n            if (currentDigit > 9)\r\n            {\r\n                currentDigit -= 9;\r\n            }\r\n        }\r\n        checkDigit += currentDigit;\r\n    }\r\n\r\n    return (10 - (checkDigit % 10)) % 10 == digits.Last();\r\n}\r\n\r\nvar ohipPattern = new OcrPatternConfig(@\"\\d{10}\", IsLuhnValid);\r\n\r\nvar options = new OcrOptions.Builder().SetTryHard(true).SetPatternConfig(ohipPattern).Build();\r\n\r\nvar result = await OcrPlugin.Default.RecognizeTextAsync(imageData, options);\r\n\r\nvar patientHcn = result.MatchedValues.FirstOrDefault(); // This will be the HCN (and only the HCN) if it's found";
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
        //await AppNavigator.ShowSnackbarAsync("Code copied to clipboard", null, null);
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