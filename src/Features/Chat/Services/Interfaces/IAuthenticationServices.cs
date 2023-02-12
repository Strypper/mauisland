namespace MAUIsland;

public interface IAuthenticationServices
{
    Task<string> Authenticate(string username, string password);
    Task<string> CreatePrincipleUserInfo(string phoneNumber, string userName, string email, string password, string firstName, string lastName, string profilePicUrl);
    Task<PrincipalUserModel> GetPrincipleUserInfo(string userGuid, string authenticateAccessToken);
    Task<ServiceUserInfo> GetServiceUserInfo(string userGuid, string authenticateAccessToken);
    Task<string> SignUp(string authenticateAccessToken, string avatarUrl, string userName);
    Task<string> AuthenticateWithPhoneNumber(string phoneNumer, string password);
}
