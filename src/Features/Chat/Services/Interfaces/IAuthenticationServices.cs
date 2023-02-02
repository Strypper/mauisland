namespace MAUIsland;

public interface IAuthenticationServices
{
    Task<string> SignUp(string phoneNumber, string userName, string email, string password);
    Task<string> SignIn(string userName, string password);
    Task<string> SignInWithPhoneNumber(string phoneNumer, string password);
}
