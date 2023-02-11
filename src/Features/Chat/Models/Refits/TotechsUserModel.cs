namespace MAUIsland;

public class TotechsUserModel
{
    public string Guid { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePicUrl { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public object Country { get; set; }
    public List<string> Roles { get; set; }
}
