namespace MAUIsland;

public partial class UserModel : BaseModel
{
    [ObservableProperty]
    string guid;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string userName;

    [ObservableProperty]
    string phoneNumber;

    [ObservableProperty]
    string avatarUrl;

    [ObservableProperty]
    string bio;

    [ObservableProperty]
    bool gender;
}
