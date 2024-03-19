namespace MAUIsland;

public interface IUserServices
{
    Task<UserModel> GetCurrentUser();

    Task<UserModel> GetUserByguid(string guid);

    Task<UserModel> GetUserInfo();

    Task SaveUserToLocalAsync(UserModel user);

    Task UploadCurrentUserAvatar(FileResult file);
}
