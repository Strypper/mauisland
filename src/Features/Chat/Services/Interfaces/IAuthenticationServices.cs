namespace MAUIsland;

public interface IAuthenticationServices
{
    Task Authenticate(string username, string password);
    Task AuthenticateWithPhoneNumber(string phoneNumer, string password);
    Task SignUp(string phoneNumber, string userName, string email, string password, string firstName, string lastName, string profilePicUrl);
}
