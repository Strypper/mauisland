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
        return Task.Run(() =>
        {

            return new Faker<UserModel>()
                    .RuleFor(u => u.Gender, f => f.PickRandom<bool>())
                    .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
                    .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName())
                    .Generate();
        });
    }

    public Task<UserModel> GetUserByguid(string guid, string authenticationToken)
    {
        return Task.Run(() =>
        {
            return new Faker<UserModel>()
                    .RuleFor(u => u.Gender, f => f.PickRandom<bool>())
                    .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
                    .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName())
                    .Generate();
        });
    }

    public Task<UserModel> GetUserInfo(string authenticationToken)
    {
        return Task.Run(() =>
        {

            return new Faker<UserModel>()
                    //.RuleFor(u => u.Gender, f => f.PickRandom<bool>())
                    .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
                    .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName())
                    .Generate();
        });
    }

    public Task SaveUserToLocalAsync(UserModel user)
    {
        return Task.Run(() =>
        {
            return new Faker<UserModel>()
        //.RuleFor(u => u.Gender, f => f.PickRandom<bool>())
        .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
        .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName())
        .Generate();
        });
    }
    #endregion
}
