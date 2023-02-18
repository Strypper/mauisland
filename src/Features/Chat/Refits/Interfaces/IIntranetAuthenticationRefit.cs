using Refit;
using System.Net;

namespace MAUIsland;

public interface IIntranetAuthenticationRefit
{
    [Post("/Authentication/Create")]
    Task<HttpStatusCode> Register(string userName,
                  string password,
                  string firstName,
                  string lastName,
                  string email,
                  string phoneNumber,
                  string profilePicUrl,
                  string[] roles);

    [Post("/Authentication/Login")]
    Task<AuthenticationResponseDTO> Login(UserNameLoginDTO dto);

    [Post("/Authentication/LoginWithPhoneNumber")]
    Task<AuthenticationResponseDTO> LoginWithPhoneNumber(PhoneNumberLoginDTO dto);
}
