using Refit;
using System.Collections.Generic;

namespace MAUIsland;

public interface IIntranetUserRefit
{
    [Get("/User/GetCurrentUser")]
    Task<RefitUserInfoResponseModel> GetCurrentUser([Authorize("Bearer")] string token);

    [Multipart]
    [Put("/User/TestUpload1")]
    Task TestUpload1([AliasAs("file")] StreamPart file);

    [Multipart]
    [Put("/User/TestUpload2")]
    Task TestUpload2([AliasAs("File")] StreamPart file);

    [Multipart]
    [Put("/User/TestUpload2")]
    Task TestUpload2(TestUploadStreamPartDTO dto);

    [Multipart]
    [Put("/User/TestUpload2")]
    Task TestUpload2(TestUploadByteArrayPartDTO dto);

    [Multipart]
    [Put("/User/TestUpload3")]
    Task TestUpload3([AliasAs("Id")] int id, [AliasAs("File")] StreamPart file);
}