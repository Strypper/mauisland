namespace MAUIsland;

public class BogusUserServices : IUserServices
{
    #region [Services]
    private readonly ISecureStorageService secureStorageService;
    #endregion
    #region [CTor]
    public BogusUserServices(ISecureStorageService secureStorageService)
    {
        this.secureStorageService = secureStorageService;
    }
    #endregion

    #region [Methods]
    public Task<UserModel> GetCurrentUser()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetUserByguid(string guid)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetUserInfo()
    {
        throw new NotImplementedException();
    }

    public Task SaveUserToLocalAsync(UserModel user)
    {
        throw new NotImplementedException();
    }
    #endregion
}
