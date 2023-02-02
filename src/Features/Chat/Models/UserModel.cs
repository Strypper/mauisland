namespace MAUIsland;

public partial class UserModel : BaseModel
{
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
