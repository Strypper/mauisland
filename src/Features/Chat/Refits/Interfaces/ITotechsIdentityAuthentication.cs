using Refit;

namespace MAUIsland;

public interface ITotechsIdentityAuthentication
{
    [Post("/Access/Register")]
    Task Register(string userName, 
                  string password, 
                  string firstName, 
                  string lastName,
                  string email,
                  string phoneNumber,
                  string profilePicUrl,
                  string[] roles);

    [Post("/Access/Login")]
    Task<LoginSuccessModelRespone> Login(string userName, string password);

    [Post("/Access/LoginWithPhoneNumber")]
    Task<LoginSuccessModelRespone> LoginWithPhoneNumber(PhoneNumberLoginDTO dto);
}
