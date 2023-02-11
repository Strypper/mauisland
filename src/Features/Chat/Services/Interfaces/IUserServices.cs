namespace MAUIsland;

public interface IUserServices
{
    Task<UserModel> GetCurrentUser();

    Task<UserModel> GetUserByguid(string guid);

    Task<UserModel> GetUserByAccessToken(string accesToken);

    Task SaveUserToLocalAsync(UserModel user);
}
