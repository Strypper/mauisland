using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.Messaging;

namespace MAUIsland;

public partial class AuthenticatePopupViewModel : BaseViewModel
{
    #region [Services]
    private readonly IUserServices userServices;
    private readonly IAuthenticationServices authenticationServices;
    #endregion
    #region [CTor]
    public AuthenticatePopupViewModel(IAppNavigator appNavigator,
                                IUserServices userServices,
                                IAuthenticationServices authenticationServices)
        : base(appNavigator)
    {
        this.userServices = userServices;
        this.authenticationServices = authenticationServices;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    string userName;

    [ObservableProperty]
    string password = "Welkom112!!@";

    [ObservableProperty]
    string phoneNumber = "0348164682";

    [ObservableProperty]
    string email = "ocgrb.strypperjason115@gmail.com";

    [ObservableProperty]
    string avatarUrl;
    #endregion

    #region [Relay Commands]

    [RelayCommand]
    Task NavigateBack() => AppNavigator.GoBackAsync();

    [RelayCommand]
    async Task LoginAsync()
    {
        try
        {
            var authenticationToken = await this.authenticationServices.AuthenticateWithPhoneNumber(PhoneNumber, Password);
            Guard.IsNotNullOrWhiteSpace(authenticationToken);

            var userInfo = await this.userServices.GetUserInfo(authenticationToken);
            Guard.IsNotNull(userInfo);

            await this.userServices.SaveUserToLocalAsync(userInfo);
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
    async Task SignUpAsync()
    {
        try
        {
            var authenticationAccessToken = await this.authenticationServices.CreatePrincipleUserInfo(PhoneNumber, UserName, Email, Password, "", "", "");
            Guard.IsNotNullOrWhiteSpace(authenticationAccessToken);

            var userInfo = await this.userServices.GetUserInfo(authenticationAccessToken);
            Guard.IsNotNull(userInfo);

            await this.userServices.SaveUserToLocalAsync(userInfo);
            WeakReferenceMessenger.Default.Send(new LoginMessage(userInfo));
            await AppNavigator.GoBackAsync();
        }
        catch (Exception ex)
        {
            await AppNavigator.ShowSnackbarAsync(ex.Message);
            throw;
        }
    }

    #endregion
}
