namespace MAUIsland.GitHubFeatures;

public partial class GitHubAuthorModel : GitHubBaseModel
{
    [ObservableProperty]
    string avatarUrl;

    [ObservableProperty]
    string bio;

    [ObservableProperty]
    string blog;

    [ObservableProperty]
    string company;

    [ObservableProperty]
    DateTime createdAt;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    int followers;

    [ObservableProperty]
    int following;

    [ObservableProperty]
    bool hireable;

    [ObservableProperty]
    string htmlUrl;

    [ObservableProperty]
    long ownerId;

    [ObservableProperty]
    string location;

    [ObservableProperty]
    string login;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string url;

}
