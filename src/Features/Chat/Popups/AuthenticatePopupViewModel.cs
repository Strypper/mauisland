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
    bool canStateChange = true;

    [ObservableProperty]
    string viewMode = "Login";
    #endregion

    #region [Relay Commands]

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
    async Task SignUpAsync()
    {
        try
        {
            //await this.authenticationServices.SignUp(PhoneNumber, UserName, Email, Password, "", "", "");

            //var userInfo = await this.userServices.GetUserInfo();
            //Guard.IsNotNull(userInfo);

            //await this.userServices.SaveUserToLocalAsync(userInfo);
            //WeakReferenceMessenger.Default.Send(new LoginMessage(userInfo));
            //await AppNavigator.GoBackAsync();
        }
        catch (Exception ex)
        {
            await AppNavigator.ShowSnackbarAsync(ex.Message);
            throw;
        }
    }

    #endregion

    #region [Methods]
    async Task CompletedLogin()
    {
        //try
        //{
        //    var authenticationToken = await this.authenticationServices.AuthenticateWithPhoneNumber(PhoneNumber, Password);
        //    Guard.IsNotNullOrWhiteSpace(authenticationToken);

        //    var userInfo = await this.userServices.GetUserInfo(authenticationToken);
        //    Guard.IsNotNull(userInfo);

        //    await this.userServices.SaveUserToLocalAsync(userInfo);
        //    WeakReferenceMessenger.Default.Send(new LoginMessage(userInfo));
        //    await AppNavigator.GoBackAsync();
        //}
        //catch (Exception ex)
        //{
        //    await AppNavigator.ShowSnackbarAsync(ex.Message);
        //    throw;
        //}
    }
    #endregion
}
