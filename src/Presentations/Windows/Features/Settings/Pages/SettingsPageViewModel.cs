using CommunityToolkit.Diagnostics;
using System.Reflection;

namespace MAUIsland;

public partial class SettingsPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IAppInfo _appInfo;
    private readonly IFilePicker _filePicker;
    private readonly IUserServices _userService;

    #endregion

    #region [ CTor ]

    public SettingsPageViewModel(IAppNavigator appNavigator,
                                 IUserServices userService,
                                 IFilePicker filePicker,
                                 IAppInfo appInfo) : base(appNavigator)
    {
        _appInfo = appInfo;
        _filePicker = filePicker;
        _userService = userService;
    }

    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        AppVersion = _appInfo.VersionString;
        MauiVersion = GetMauiVersion();
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ImageSource avatarImageSource;

    [ObservableProperty]
    UserModel currentUser;

    [ObservableProperty]
    FileResult file;

    [ObservableProperty]
    string appVersion = string.Empty;

    [ObservableProperty]
    string mauiVersion = string.Empty;

    #endregion

    #region [ Relay Commands ]

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

    #region [ Methods ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    async Task GetCurrentUser()
    {
        CurrentUser = await _userService.GetCurrentUser();
        AvatarImageSource = CurrentUser.AvatarUrl;
    }

    private string GetMauiVersion()
    {
        var attr = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string versionWithSuffix = attr.InformationalVersion;

        // Split the version string using '+' as delimiter and take the first part
        string[] parts = versionWithSuffix.Split('+');
        string version = parts[0].Trim();

        return version;
    }

    #endregion
}