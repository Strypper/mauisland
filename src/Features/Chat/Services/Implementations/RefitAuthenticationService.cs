using CommunityToolkit.Diagnostics;
using Newtonsoft.Json;
using Refit;

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
        Guard.IsNotNullOrEmpty(username);
        Guard.IsNotNullOrEmpty(password);

        try
        {
            var authenticationResponseDTO = await this.intranetAuthenticationRefit.Login(new UserNameLoginDTO(username, password));

            Guard.IsNotNull(authenticationResponseDTO);

            await SaveToSecureStorageAsync(authenticationResponseDTO);
        }
        catch (ApiException ex)
        {
            throw new Exception(ex.Message);
        }


    }

    public async Task AuthenticateWithPhoneNumber(string phonenumber, string password)
    {
        Guard.IsNotNullOrEmpty(phonenumber);
        Guard.IsNotNullOrEmpty(password);

        try
        {
            var authenticationResponseDTO = await this.intranetAuthenticationRefit.LoginWithPhoneNumber(new PhoneNumberLoginDTO(phonenumber, password));

            Guard.IsNotNull(authenticationResponseDTO);

            await SaveToSecureStorageAsync(authenticationResponseDTO);
        }
        catch (ApiException ex)
        {

            throw new Exception(ex.Message);
        }

    }


    public async Task SignUp(string phoneNumber, string userName, string email, string password, string firstName, string lastName, FileResult? profilePicUrl)
    {
        Guard.IsNotNullOrEmpty(phoneNumber);
        Guard.IsNotNullOrEmpty(userName);
        Guard.IsNotNullOrEmpty(email);
        Guard.IsNotNullOrEmpty(password);
        Guard.IsNotNullOrEmpty(firstName);
        //Guard.IsNotNull(profilePicUrl);

        StreamPart stream = null;

        if (profilePicUrl is not null)
        {
            using var fileStream = File.OpenRead(profilePicUrl.FullPath);

            stream = new StreamPart(fileStream, profilePicUrl.FileName, profilePicUrl.ContentType);
        }

        try
        {
            var response = await this.intranetAuthenticationRefit.Register(userName,
                                                                           firstName,
                                                                           lastName,
                                                                           phoneNumber,
                                                                           email,
                                                                           password,
                                                                           stream ?? null);
            if (!response.IsSuccessStatusCode)
            {
                var errorContentJson = JsonConvert.DeserializeObject<RefitErrorMessageModel>(response.Error.Content);
                throw new Exception(errorContentJson.title);
            }
        }
        catch (ApiException ex)
        {
            throw new Exception(ex.Message);
        }
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
