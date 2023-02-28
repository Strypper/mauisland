using Refit;
using System.Net;

namespace MAUIsland;

public interface IIntranetAuthenticationRefit
{
    [Multipart]
    [Post("/Authentication/Register")]
    Task<ApiResponse<HttpStatusCode>> Register([AliasAs("username")] string username,
                                               [AliasAs("firstname")] string firstname,
                                               [AliasAs("lastname")] string lastname,
                                               [AliasAs("phonenumber")] string phonenumber,
                                               [AliasAs("email")] string email,
                                               [AliasAs("password")] string password,
                                               [AliasAs("avatarfile")] StreamPart profilepic);

    [Post("/Authentication/Login")]
    Task<AuthenticationResponseDTO> Login(UserNameLoginDTO dto);

    [Post("/Authentication/LoginWithPhoneNumber")]
    Task<AuthenticationResponseDTO> LoginWithPhoneNumber(PhoneNumberLoginDTO dto);
}
