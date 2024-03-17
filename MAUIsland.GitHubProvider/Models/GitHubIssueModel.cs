namespace MAUIsland.GitHubProvider;

public partial class GitHubIssueModel : GitHubBaseModel
{
    [ObservableProperty]
    long id;

    [ObservableProperty]
    string url;

    [ObservableProperty]
    string repositoryUrl;

    [ObservableProperty]
    string commentsUrl;

    [ObservableProperty]
    string eventsUrl;

    [ObservableProperty]
    string htmlUrl;

    [ObservableProperty]
    int number;

    [ObservableProperty]
    string state;

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string body;

    [ObservableProperty]
    GitHubAuthorModel user;

    [ObservableProperty]
    IReadOnlyList<GitHubLabelModel> labels;

    [ObservableProperty]
    GitHubAuthorModel assignee;

    [ObservableProperty]
    IReadOnlyList<GitHubAuthorModel> assignees;

    [ObservableProperty]
    GitHubMilestoneModel milestone;

    [ObservableProperty]
    bool locked;

    [ObservableProperty]
    int comments;

    [ObservableProperty]
    DateTimeOffset? closedAt;

    [ObservableProperty]
    DateTimeOffset createdAt;

    [ObservableProperty]
    DateTimeOffset? updatedAt;
}
