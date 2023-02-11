namespace MAUIsland;

public class BogusAuthenticationService : IAuthenticationServices
{

    public Task<string> AuthenticateWithPhoneNumber(string phoneNumer, string password)
    {
        return Task.Run(() =>
        {
            var faker = new Faker();
            return faker.System.ApplePushToken();
        });
    }

    public Task<string> SignUp(string authenticateAccessToken, string avatarUrl, string userName)
    {
        return Task.Run(() =>
        {
            //Send signup information to Totechs Identity
            //Get accessToken from Totechs Identity
            //Get User info from Totechs Identity using Totechs Identity AccessToken and save down to application data
            //Send signup information to Totechs Intranet signup
            //Get accessToken from Totechs Intranet
            //Get User info from Totechs Intranet using Totechs Intranet AccessToken and save down to application data
            var faker = new Faker();
            return faker.System.ApplePushToken();
        });
    }

    public Task<string> Authenticate(string username, string password)
    {
        return Task.Run(() =>
        {
            var faker = new Faker();
            return faker.System.ApplePushToken();
        });
    }

    public Task<PrincipalUserModel> GetPrincipleUserInfo(string userGuid, string authenticateAccessToken)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceUserInfo> GetServiceUserInfo(string userGuid, string authenticateAccessToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreatePrincipleUserInfo(string phoneNumber, string userName, string email, string password, string firstName, string lastName, string profilePicUrl)
    {
        return Task.Run(() =>
        {
            var faker = new Faker();
            return faker.System.ApplePushToken();
        });
    }
}
