using Refit;
using System.Net;

namespace MAUIsland;

public interface IIntranetAuthenticationRefit
{
    [Post("/Authentication/Register")]
    Task<ApiResponse<HttpStatusCode>> Register(RegisterDTO dto);

    [Post("/Authentication/Login")]
    Task<AuthenticationResponseDTO> Login(UserNameLoginDTO dto);

    [Post("/Authentication/LoginWithPhoneNumber")]
    Task<AuthenticationResponseDTO> LoginWithPhoneNumber(PhoneNumberLoginDTO dto);
}
