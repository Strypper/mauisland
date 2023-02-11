namespace MAUIsland;

public class BogusAuthenticationService : IAuthenticationServices
{
    public Task<string> SignIn(string userName, string password)
    {
        return Task.Run(() =>
        {
            return string.Empty;
        });
    }

    public Task<string> SignInWithPhoneNumber(string phoneNumer, string password)
    {
        return Task.Run(() =>
        {
            var faker = new Faker();
            return faker.System.ApplePushToken();
        });
    }

    public Task<string> SignUp(string phoneNumber, string userName, string email, string password)
    {
        return Task.Run(() =>
        {
            return string.Empty;
        });
    }
}
