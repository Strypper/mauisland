using Refit;

namespace MAUIsland;

public partial class SettingsPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]

    private readonly IFilePicker filePicker;
    private readonly IIntranetUserRefit intranetUserRefit;

    #endregion [Services]

    #region [CTor]

    public SettingsPageViewModel(IAppNavigator appNavigator,
                                 IIntranetUserRefit intranetUserRefit,
                                 IFilePicker filePicker) : base(appNavigator)
    {
        this.filePicker = filePicker;
        this.intranetUserRefit = intranetUserRefit;
    }

    #endregion [CTor]

    #region [Fields]

    private FileResult _file;

    #endregion [Fields]

    #region [Properties]

    [ObservableProperty]
    private ImageSource avatarImageSource;

    #endregion [Properties]

    #region [Relay Commands]

    [RelayCommand]
    private async Task OpenFileAsync()
    {
        _file = await filePicker.OpenMediaPickerAsync();
        var imagefile = await filePicker.UploadImageFile(_file);
        AvatarImageSource = ImageSource.FromStream(() =>
            filePicker.ByteArrayToStream(filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        using var imageStream = File.OpenRead(_file.FullPath);
        var imageByteArray = await File.ReadAllBytesAsync(_file.FullPath);

        var imageFromStream = new StreamPart(imageStream, _file.FileName);
        var imageFromByteArray = new ByteArrayPart(imageByteArray, _file.FileName);

        await intranetUserRefit.TestUpload1(imageFromStream);
        await intranetUserRefit.TestUpload2(imageFromStream);

        //// Error timeout
        //var streamPartDTO = new TestUploadStreamPartDTO
        //{
        //    File = imageFromStream,
        //};
        //await intranetUserRefit.TestUpload2(streamPartDTO);

        var byteArrayPartDTO = new TestUploadByteArrayPartDTO
        {
            File = imageFromByteArray,
        };
        await intranetUserRefit.TestUpload2(byteArrayPartDTO);

        await intranetUserRefit.TestUpload3(88, imageFromStream);
    }

    #endregion [Relay Commands]
}