namespace MAUIsland;

public partial class ImageButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IFilePicker filePicker;
    #endregion

    #region [CTor]
    public ImageButtonPageViewModel(IAppNavigator appNavigator,
                                    IFilePicker filePicker)
                                : base(appNavigator)
    {
        this.filePicker = filePicker;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    int imageButtonClickCount;

    [ObservableProperty]
    ImageSource imageSourceSample;

    [ObservableProperty]
    string imageButtonClickedCheck = "No Image To Click";

    [ObservableProperty]
    string xamlBasicImageButton =
        "<ImageButton CornerRadius=\"5\"\r\n" +
        "             HeightRequest=\"50\"\r\n" +
        "             VerticalOptions=\"Center\"\r\n" +
        "             Source=\"androidlogo.png\"\r\n" +
        "             Padding=\"5\"/>";

    [ObservableProperty]
    string xamlImageButtonWithEventHandler=
        "<Border Padding=\"5\"\r\n" +
        "        BackgroundColor=\"DarkGray\"\r\n" +
        "        x:Name=\"ImageButtonWithEvent\">\r\n" +
        "   <Border.StrokeShape>\r\n" +
        "       <RoundRectangle CornerRadius=\"5\" StrokeThickness=\"1\"/>\r\n" +
        "   </Border.StrokeShape>\r\n" +
        "   <HorizontalStackLayout Spacing=\"10\">\r\n" +
        "       <ImageButton HeightRequest=\"50\"\r\n" +
        "                    VerticalOptions=\"Center\"\r\n" +
        "                    Source=\"androidlogo.png\"\r\n" +
        "                    Clicked=\"ImageButtonEventHandlerClicked\"/>\r\n" +
        "       <Label x:Name=\"ImageButtonWithEventLabel\" \r\n" +
        "              Text=\"ImageButton with Click Event\"\r\n" +
        "              VerticalOptions=\"Center\"/>\r\n" +
        "   </HorizontalStackLayout>\r\n" +
        "</Border>";

    [ObservableProperty]
    string cSharpImageButtonWithEventHandlerCodeBehind =
        "private bool IsPressed = true;\r\n" +
        "private void ImageButtonEventHandlerClicked(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    if (IsPressed)\r\n" +
        "    {\r\n" +
        "        ImageButtonWithEvent.BackgroundColor = Colors.Blue;\r\n" +
        "        ImageButtonWithEventLabel.TextColor = Colors.White;\r\n" +
        "        IsPressed = false;\r\n" +
        "    }\r\n" +
        "    else\r\n" +
        "    {\r\n" +
        "        ImageButtonWithEvent.BackgroundColor = Colors.DarkGray;\r\n" +
        "        ImageButtonWithEventLabel.TextColor = Colors.Black;\r\n" +
        "        IsPressed = true;\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string xamlImageButtonWithCommand =
        "<HorizontalStackLayout Spacing=\"10\">\r\n" +
        "   <ImageButton CornerRadius=\"10\"\r\n" +
        "                HeightRequest=\"50\"\r\n" +
        "                VerticalOptions=\"Center\"\r\n" +
        "                Source=\"androidlogo.png\"\r\n" +
        "                Command=\"{x:Binding ClickedCountCommand}\"/>\r\n" +
        "   <Label VerticalOptions=\"Center\">\r\n" +
        "       <Label.FormattedText>\r\n" +
        "           <FormattedString>\r\n" +
        "               <Span Text=\"You just click the button: \"/>\r\n" +
        "               <Span Text=\"{x:Binding ImageButtonClickCount}\"/>\r\n" +
        "           </FormattedString>\r\n" +
        "       </Label.FormattedText>\r\n" +
        "   </Label>\r\n" +
        "</HorizontalStackLayout>";

    [ObservableProperty]
    string cSharpImageButtonWithCommandViewModel =
        "[ObservableProperty]\r\n" +
        "int imageButtonClickCount;\r\n" +
        "[RelayCommand]\r\n" +
        "void ClickedCount()\r\n" +
        "   => ImageButtonClickCount += 1;";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task OpenFileAsync()
    {
        var pickedImage = await filePicker.OpenMediaPickerAsync();

        var imagefile = await filePicker.UploadImageFile(pickedImage);

        ImageSourceSample = ImageSource.FromStream(() =>
            filePicker.ByteArrayToStream(filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
        ImageButtonClickedCheck = "Image Loaded";
    }

    [RelayCommand]
    void ClickedCheck()
        => ImageButtonClickedCheck = "You Clicked the Image";


    [RelayCommand]
    void ClickedCount()
        => ImageButtonClickCount += 1;
    #endregion
}
