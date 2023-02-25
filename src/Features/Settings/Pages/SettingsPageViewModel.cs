namespace MAUIsland;

public partial class SettingsPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IFilePicker filePicker;
    private readonly IIntranetUserRefit intranetUserRefit;
    #endregion

    #region [CTor]
    public SettingsPageViewModel(IAppNavigator appNavigator,
                                 IIntranetUserRefit intranetUserRefit,
                                 IFilePicker filePicker) : base(appNavigator)
    {
        this.filePicker = filePicker;
        this.intranetUserRefit = intranetUserRefit;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    ImageSource avatarImageSource;
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    async Task OpenFileAsync()
    {
        var pickedImage = await filePicker.OpenMediaPickerAsync();

        var imagefile = await filePicker.UploadImageFile(pickedImage);

        AvatarImageSource = ImageSource.FromStream(() =>
            filePicker.ByteArrayToStream(filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
    }

    [RelayCommand]
    async Task SaveAsync()
    {
        //this.intranetUserRefit.UploadTestImage(1, new Refit.StreamPart(ImageSourceSample, "photo.jpg", "image/jpeg"))
    }
    #endregion
}
