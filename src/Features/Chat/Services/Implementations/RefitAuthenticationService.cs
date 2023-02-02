using Refit;

namespace MAUIsland;

public class RefitAuthenticationService : IAuthenticationServices
{
    private readonly ITotechsIdentityAuthentication totechsIdentityAuthentication;
    private readonly IAppNavigator appNavigator;
    #region [CTor]
    public RefitAuthenticationService(ITotechsIdentityAuthentication totechsIdentityAuthentication, IAppNavigator appNavigator)
    {
        this.totechsIdentityAuthentication = totechsIdentityAuthentication;
        this.appNavigator = appNavigator;
    }
    #endregion
    public Task<string> SignIn(string userName, string password)
    {
        return Task.Run(() =>
            { 
               return string.Empty;
            }
        );
    }

    public async Task<string> SignInWithPhoneNumber(string phoneNumber, string password)
    {
        try
        {
            var totechsIdentityInfo = await this.totechsIdentityAuthentication.LoginWithPhoneNumber(new PhoneNumberLoginDTO(phoneNumber, password));

            return string.Empty;
        }
        catch (ApiException ex)
        {
            await this.appNavigator.ShowSnackbarAsync(ex.Message);
            throw;
        }
    }

    public Task<string> SignUp(string phoneNumber, string userName, string email, string password)
    {
        throw new NotImplementedException();
    }
}
