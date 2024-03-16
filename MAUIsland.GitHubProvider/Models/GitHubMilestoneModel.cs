namespace MAUIsland.GitHubProvider;

public partial class GitHubMilestoneModel : GitHubBaseModel
{

    [ObservableProperty]
    string url;

    [ObservableProperty]
    string htmlUrl;

    [ObservableProperty]
    long id;

    [ObservableProperty]
    int number;

    [ObservableProperty]
    string nodeId;

    [ObservableProperty]
    string state;

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    GitHubAuthorModel creator;

    [ObservableProperty]
    int openIssues;

    [ObservableProperty]
    int closedIssues;

    [ObservableProperty]
    DateTimeOffset createdAt;

    [ObservableProperty]
    DateTimeOffset? dueOn;

    [ObservableProperty]
    DateTimeOffset? closedAt;

    [ObservableProperty]
    DateTimeOffset? updatedAt;
}
