using CommunityToolkit.Diagnostics;
using Refit;

namespace MAUIsland;

public class RefitIntranetUserService : IUserServices
{
    #region [Services]
    private readonly IAppNavigator _appNavigator;
    private readonly IIntranetUserRefit _intranetUserRefit;
    private readonly ISecureStorageService _secureStorageService;
    #endregion

    #region [CTor]
    public RefitIntranetUserService(IAppNavigator appNavigator,
                                    IIntranetUserRefit intranetUserRefit,
                                    ISecureStorageService secureStorageService)
    {
        _appNavigator = appNavigator;
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

    public async Task UploadCurrentUserAvatar(FileResult file)
    {
        Guard.IsNotNull(file);

        var accessToken = await _secureStorageService.ReadValueAsync("accesstoken");

        Guard.IsNotNullOrEmpty(accessToken);

        var fileStream = File.OpenRead(file.FullPath);

        var stream = new StreamPart(fileStream, file.FileName, file.ContentType);

        try
        {
            var result = await _intranetUserRefit.UpdateAvatar(accessToken, stream);
            if (result.IsSuccessStatusCode)
            {
                await _appNavigator.ShowSnackbarAsync("Save success !!!");
            }
            else
            {
                await _appNavigator.ShowSnackbarAsync($"Something wrong !!! {result.StatusCode}");
            }
        }
        catch (ApiException ex)
        {

            throw;
        }
    }
    #endregion
}
