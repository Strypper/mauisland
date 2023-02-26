using CommunityToolkit.Diagnostics;

namespace MAUIsland;

public partial class SettingsPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]

    private readonly IFilePicker _filePicker;
    private readonly IUserServices _userService;

    #endregion

    #region [CTor]

    public SettingsPageViewModel(IAppNavigator appNavigator,
                                 IUserServices userService,
                                 IFilePicker filePicker) : base(appNavigator)
    {
        _filePicker = filePicker;
        _userService = userService;
    }

    #endregion

    #region [Overrides]

    protected override void OnInit(IDictionary<string, object> query)
    {
        GetCurrentUser().FireAndForget();
    }
    #endregion

    #region [Properties]

    [ObservableProperty]
    ImageSource avatarImageSource;

    [ObservableProperty]
    UserModel currentUser;

    [ObservableProperty]
    FileResult file;

    #endregion

    #region [Relay Commands]

    [RelayCommand]
    private async Task OpenFileAsync()
    {
        File = await _filePicker.OpenMediaPickerAsync();
        var imagefile = await _filePicker.UploadImageFile(File);
        AvatarImageSource = ImageSource.FromStream(() =>
            _filePicker.ByteArrayToStream(_filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        Guard.IsNotNull(File);

        await _userService.UploadCurrentUserAvatar(File);
    }

    #endregion

    #region [Methods]
    async Task GetCurrentUser()
    {
        CurrentUser = await _userService.GetCurrentUser();
        AvatarImageSource = CurrentUser.AvatarUrl;
    }
    #endregion
}