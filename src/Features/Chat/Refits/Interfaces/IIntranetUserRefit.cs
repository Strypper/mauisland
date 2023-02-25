using Refit;

namespace MAUIsland;

public interface IIntranetUserRefit
{
    [Get("/User/GetCurrentUser")]
    Task<RefitUserInfoResponseModel> GetCurrentUser([Authorize("Bearer")] string token);

    [Multipart]
    [Put("/User/UploadTestImage")]
    Task UploadTestImage(TestUploadImageDTO);
}
