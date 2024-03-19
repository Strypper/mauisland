namespace MAUIsland;

public interface IAuthenticationServices
{
    #region [ Services ]
    Task Authenticate(string username, string password);
    Task AuthenticateWithPhoneNumber(string phoneNumer, string password);
    Task SignUp(string phoneNumber, string userName, string email, string password, string firstName, string lastName, FileResult profilePicUrl);  
    #endregion
}
