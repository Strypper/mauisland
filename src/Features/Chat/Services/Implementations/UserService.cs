using CommunityToolkit.Diagnostics;

namespace MAUIsland;

public class UserService : IUserServices
{
    #region [Fields]
    private readonly IIntranetUserRefit _intranetUserRefit;
    private readonly ISecureStorageService _secureStorageService;
    #endregion

    #region [CTor]
    public UserService(IIntranetUserRefit intranetUserRefit,
                       ISecureStorageService secureStorageService)
    {
        _intranetUserRefit = intranetUserRefit;
        _secureStorageService = secureStorageService;
    }
    #endregion

    #region [Methods]

    public async Task<UserModel> GetCurrentUser()
    {
        var accessToken = await _secureStorageService.ReadValueAsync("accesstoken");
        Guard.IsNotNullOrEmpty(accessToken);

        var refitUserInfoDTO = await _intranetUserRefit.GetCurrentUser(accessToken);
        Guard.IsNotNull(refitUserInfoDTO);

        return new UserModel()
        {
            UserName = refitUserInfoDTO.userName,
            Email = refitUserInfoDTO.email,
            PhoneNumber = refitUserInfoDTO.phoneNumber,
            AvatarUrl = refitUserInfoDTO.profilePic
        };
    }

    public Task<UserModel> GetUserByguid(string guid)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel> GetUserInfo()
    {
        var accessToken = await _secureStorageService.ReadValueAsync("accesstoken");
        Guard.IsNotNullOrEmpty(accessToken);

        var refitUserInfoDTO = await _intranetUserRefit.GetCurrentUser(accessToken);
        Guard.IsNotNull(refitUserInfoDTO);

        return new UserModel()
        {
            UserName = refitUserInfoDTO.userName,
            Email = refitUserInfoDTO.email,
            PhoneNumber = refitUserInfoDTO.phoneNumber,
            AvatarUrl = refitUserInfoDTO.profilePic
        };
    }

    public Task SaveUserToLocalAsync(UserModel user)
    {
        return Task.Run(() => null);
    }
    #endregion
}
