using CommunityToolkit.Diagnostics;
using System.Reflection;

namespace MAUIsland.Settings;

public partial class SettingsPageViewModel(IAppNavigator appNavigator,
                                             IUserServices userService,
                                             Core.IFilePicker filePicker,
                                             IAppInfo appInfo) : NavigationAwareBaseViewModel(appNavigator)
{
    #region [ Fields ]

    private readonly IAppInfo _appInfo = appInfo;
    private readonly Core.IFilePicker _filePicker = filePicker;
    private readonly IUserServices _userService = userService;

    public TitleBar? TitleBar;
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

    #region [ Properties - Title Bar ]

    [ObservableProperty]
    string title = "MAUIsland";

    [ObservableProperty]
    string subtitle = "Everything about .NET MAUI";

    [ObservableProperty]
    bool isShownTitleBar = true;
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

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

    [RelayCommand]
    private async Task NavigateAsync(string route)
        => await AppNavigator.NavigateAsync(route);

    #endregion

    #region [ Methods ]

    public void InitTitleBar()
    {
        if (TitleBar is null)
            return;

        TitleBar.Icon = "mauisland_logo";
    }

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