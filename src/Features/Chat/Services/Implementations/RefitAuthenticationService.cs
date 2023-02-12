using System.Net;

namespace MAUIsland;

public class RefitAuthenticationService : IAuthenticationServices
{
    private readonly ITotechsIdentityAuthenticationRefit totechsIdentityAuthenticationRefit;
    private readonly IUserServices userServices;
    private readonly IAppNavigator appNavigator;
    #region [CTor]
    public RefitAuthenticationService(ITotechsIdentityAuthenticationRefit totechsIdentityAuthenticationRefit, IUserServices userServices, IAppNavigator appNavigator)
    {
        this.totechsIdentityAuthenticationRefit = totechsIdentityAuthenticationRefit;
        this.userServices = userServices;
        this.appNavigator = appNavigator;
    }
    #endregion

    #region [Methods]


    public async Task<string> Authenticate(string username, string password)
    {
        var response = await this.totechsIdentityAuthenticationRefit.Login(username, password);
        return response.AccessToken;
    }

    public async Task<string> AuthenticateWithPhoneNumber(string phoneNumer, string password)
    {
        var response = await this.totechsIdentityAuthenticationRefit.LoginWithPhoneNumber(new PhoneNumberLoginDTO(phoneNumer, password));
        return response.AccessToken;
    }

    public async Task<string> CreatePrincipleUserInfo(string phoneNumber, string userName, string email, string password, string firstName, string lastName, string profilePicUrl)
    {
        var response = await this.totechsIdentityAuthenticationRefit.Register(userName, password, firstName, lastName, email, phoneNumber, profilePicUrl, new string[] { "", "" });
        if (response == HttpStatusCode.NoContent)
        {
            return string.Empty;
        }
        else return string.Empty;
    }

    public Task<PrincipalUserModel> GetPrincipleUserInfo(string userGuid, string authenticateAccessToken)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceUserInfo> GetServiceUserInfo(string userGuid, string authenticateAccessToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> SignUp(string authenticateAccessToken, string avatarUrl, string userName)
    {
        throw new NotImplementedException();
    }
    #endregion
}
