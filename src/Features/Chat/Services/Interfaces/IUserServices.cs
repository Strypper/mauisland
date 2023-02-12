namespace MAUIsland;

public interface IUserServices
{
    Task<UserModel> GetCurrentUser();

    Task<UserModel> GetUserByguid(string guid, string authenticationToken);

    Task<UserModel> GetUserInfo(string authenticationToken);

    Task SaveUserToLocalAsync(UserModel user);
}
