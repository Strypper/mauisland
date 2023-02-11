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
    #endregion

    #region [Relay Commands]

    [RelayCommand]
    Task NavigateBack() => AppNavigator.GoBackAsync();

    [RelayCommand]
    async Task LoginAsync()
    {
        try
        {
            var accessToken = await this.authenticationServices.SignInWithPhoneNumber(PhoneNumber, Password);

            Guard.IsNotNullOrWhiteSpace(accessToken);
            var userInfo = await this.userServices.GetUserByAccessToken(accessToken);

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
