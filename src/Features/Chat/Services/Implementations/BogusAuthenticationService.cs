namespace MAUIsland;

public class BogusAuthenticationService : IAuthenticationServices
{
    #region [CTor]
    public BogusAuthenticationService()
    {

    }
    #endregion

    #region [Methods]
    public Task Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task AuthenticateWithPhoneNumber(string phoneNumer, string password)
    {
        throw new NotImplementedException();
    }

    public Task SignUp(string phoneNumber, string userName, string email, string password, string firstName, string lastName, FileResult profilePicUrl)
    {
        throw new NotImplementedException();
    }
    #endregion
}
