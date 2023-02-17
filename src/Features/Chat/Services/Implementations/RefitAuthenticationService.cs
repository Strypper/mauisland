using CommunityToolkit.Diagnostics;

namespace MAUIsland;

public class RefitAuthenticationService : IAuthenticationServices
{
    #region [Fields]
    private readonly IIntranetAuthenticationRefit intranetAuthenticationRefit;
    private readonly ISecureStorageService secureStorageService;
    private readonly IUserServices userServices;
    private readonly IAppNavigator appNavigator;
    #endregion

    #region [CTor]
    public RefitAuthenticationService(IIntranetAuthenticationRefit intranetAuthenticationRefit,
                                      ISecureStorageService secureStorageService,
                                      IUserServices userServices,
                                      IAppNavigator appNavigator)
    {
        this.intranetAuthenticationRefit = intranetAuthenticationRefit;
        this.secureStorageService = secureStorageService;
        this.userServices = userServices;
        this.appNavigator = appNavigator;
    }
    #endregion

    #region [Methods]

    public async Task Authenticate(string username, string password)
    {
        var authenticationResponseDTO = await this.intranetAuthenticationRefit.Login(new UserNameLoginDTO(username, password));

        Guard.IsNotNull(authenticationResponseDTO);

        await SaveToSecureStorageAsync(authenticationResponseDTO);

    }

    public async Task AuthenticateWithPhoneNumber(string phonenumber, string password)
    {
        var authenticationResponseDTO = await this.intranetAuthenticationRefit.LoginWithPhoneNumber(new PhoneNumberLoginDTO(phonenumber, password));

        Guard.IsNotNull(authenticationResponseDTO);

        await SaveToSecureStorageAsync(authenticationResponseDTO);
    }


    public Task SignUp(string phoneNumber, string userName, string email, string password, string firstName, string lastName, string profilePicUrl)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region [Private methods]
    async Task SaveToSecureStorageAsync(AuthenticationResponseDTO dto)
    {
        await this.secureStorageService.RemoveAllValueAsync();
        await this.secureStorageService.WriteValueAsync("accesstoken", dto.accessToken);
        await this.secureStorageService.WriteValueAsync("requestat", dto.requestAt.ToString());
        await this.secureStorageService.WriteValueAsync("expirein", dto.expireIn.ToString());
        await this.secureStorageService.WriteValueAsync("guid", dto.id);
    }
    #endregion
}
