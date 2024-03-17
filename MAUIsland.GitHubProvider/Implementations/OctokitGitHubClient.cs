
using Octokit;


namespace MAUIsland.GitHubProvider;

public class OctokitGitHubClient : IGitHubService
{
    #region [ Fields ]

    private readonly GitHubClient gitClient;
    private readonly string httpHeader = "totechs-corp";
    #endregion

    #region [ CTor ]

    public OctokitGitHubClient()
    {
        this.gitClient = new GitHubClient(new ProductHeaderValue(httpHeader));
    }
    #endregion

    #region [ Methods ]

    public Task<GitHubAuthorModel> GetAuthor(string owner)
    {
        throw new NotImplementedException();
    }

    public Task<GitHubIssueModel> GetGitHubIssueById(string owner, string repository, string issueNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GitHubIssueModel>> GetGitHubIssues(string owner, string repository)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<GitHubIssueModel>> GetGitHubIssuesByLabels(string owner, string repository, IEnumerable<string> labels)
    {
        var request = new RepositoryIssueRequest
        {
            State = ItemStateFilter.All,
            //Labels = labels
        };
        foreach (var label in labels)
        {
            request.Labels.Add(label);
        }

        var issues = await this.gitClient.Issue.GetAllForRepository(owner, repository, request);
        return issues.Select(issue => new GitHubIssueModel
        {
            Id = issue.Id,
            Url = issue.Url,
            RepositoryUrl = issue.Url,
            CommentsUrl = issue.CommentsUrl,
            EventsUrl = issue.EventsUrl,
            HtmlUrl = issue.HtmlUrl,
            Number = issue.Number,
            State = issue.State.StringValue,
            Title = issue.Title,
            Body = issue.Body,
            User = new GitHubAuthorModel
            {
                Id = issue.User.Id,
                Login = issue.User.Login,
                AvatarUrl = issue.User.AvatarUrl,
                Url = issue.User.Url,
                HtmlUrl = issue.User.HtmlUrl
            },           
            Labels = issue.Labels.Select(label => new GitHubLabelModel
            {
                Id = label.Id,
                Name = label.Name,
                Color = label.Color,
                Description = label.Description,
                IsDefault = label.Default
            }).ToList(),
            Assignee = new GitHubAuthorModel
            {
                Id = issue.Assignee.Id,
                Login = issue.Assignee.Login,
                AvatarUrl = issue.Assignee.AvatarUrl,
                Url = issue.Assignee.Url,
                HtmlUrl = issue.Assignee.HtmlUrl
            },
            Assignees = issue.Assignees.Select(assignee => new GitHubAuthorModel
            {
                Id = assignee.Id,
                Login = assignee.Login,
                AvatarUrl = assignee.AvatarUrl,
                Url = assignee.Url,
                HtmlUrl = assignee.HtmlUrl
            }).ToList(),
            Milestone = new GitHubMilestoneModel
            {
                Id = issue.Milestone.Id,
                Number = issue.Milestone.Number,
                Title = issue.Milestone.Title,
                Description = issue.Milestone.Description,
                State = issue.Milestone.State.StringValue,
                CreatedAt = issue.Milestone.CreatedAt,
                UpdatedAt = issue.Milestone.UpdatedAt,
                ClosedAt = issue.Milestone.ClosedAt
            },
            Locked = issue.Locked,
            Comments = issue.Comments,
            ClosedAt = issue.ClosedAt,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
        });
    }

    public Task<GitHubRepositoryModel> GetRepository(string owner, string repository)
    {
        throw new NotImplementedException();
    }
    #endregion
}
