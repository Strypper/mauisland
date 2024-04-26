namespace MAUIsland.Core;

public partial class SfAvatarViewTestUserModel : BaseModel
{
    [ObservableProperty]
    string avatarUrl;

    [ObservableProperty]
    string name;
}
