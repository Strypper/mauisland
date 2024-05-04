using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.Messaging;

namespace MAUIsland;

public partial class AuthenticatePopupViewModel : BaseViewModel
{
    #region [ Services ]
    private readonly Core.IFilePicker filePicker;
    private readonly IUserServices userServices;
    private readonly IAuthenticationServices authenticationServices;
    #endregion

    #region [ CTor ]
    public AuthenticatePopupViewModel(IAppNavigator appNavigator,
                                      Core.IFilePicker filePicker,
                                      IUserServices userServices,
                                      IAuthenticationServices authenticationServices)
        : base(appNavigator)
    {
        this.filePicker = filePicker;
        this.userServices = userServices;
        this.authenticationServices = authenticationServices;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    FileResult file;

    [ObservableProperty]
    ImageSource avatarImageSource;

    [ObservableProperty]
    string viewMode = "Login";

    [ObservableProperty]
    bool isLogin = true;
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task NavigateBack() => AppNavigator.GoBackAsync();

    [RelayCommand]
    async Task LoginAsync(UserNameLoginDTO dto)
    {
        try
        {
            await authenticationServices.Authenticate(dto.username, dto.password);

            var userInfo = await userServices.GetUserInfo();
            Guard.IsNotNull(userInfo);

            //await userServices.SaveUserToLocalAsync(userInfo);

            WeakReferenceMessenger.Default.Send(new LoginMessage(userInfo));
            await AppNavigator.GoBackAsync();
        }
        catch (Exception e)
        {
            await AppNavigator.ShowSnackbarAsync(e.Message);
            throw;
        }
    }

    [RelayCommand]
    async Task SignUpAsync(RegisterDTO dto)
    {
        try
        {
            await authenticationServices.SignUp(dto.phonenumber,
                                                dto.username,
                                                dto.email,
                                                dto.password,
                                                dto.firstname,
                                                dto.lastname,
                                                File);
            await authenticationServices.Authenticate(dto.username, dto.password);

            var userInfo = await userServices.GetUserInfo();
            Guard.IsNotNull(userInfo);
            WeakReferenceMessenger.Default.Send(new LoginMessage(userInfo));
            await AppNavigator.GoBackAsync();
        }
        catch (Exception ex)
        {
            await AppNavigator.ShowSnackbarAsync(ex.Message);
            throw;
        }
    }

    [RelayCommand]
    private async Task OpenFileAsync()
    {
        File = await this.filePicker.OpenMediaPickerAsync();
        var imagefile = await this.filePicker.UploadImageFile(File);
        AvatarImageSource = ImageSource.FromStream(() =>
            this.filePicker.ByteArrayToStream(this.filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
    }

    #endregion

    #region [ Methods ]
    #endregion
}
