namespace MAUIsland;

public record PrincipalUserModel
(
    Guid guid,
    string userName,
    string firstName,
    string lastName,
    string profilePicUrl,
    string email,
    string phoneNumber,
    string country,
    bool gender,
    List<string> roles
);
