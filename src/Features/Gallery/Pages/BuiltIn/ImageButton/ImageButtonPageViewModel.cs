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
    IControlInfo controlInformation;

    [ObservableProperty]

    ImageSource imageSourceSample;


    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

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
    }

    #endregion
}
