namespace MAUIsland.GitHubFeatures;

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

    public async Task<GitHubAuthorModel> GetAuthor(string owner)
    {
        var author = await this.gitClient.User.Get(owner);
        return new GitHubAuthorModel
        {
            AvatarUrl = author.AvatarUrl,
            Bio = author.Bio,
            Blog = author.Blog,
            Company = author.Company,
            CreatedAt = author.CreatedAt.Date,
            Email = author.Email,
            Followers = author.Followers,
            Following = author.Following,
            Hireable = author.Hireable,
            HtmlUrl = author.HtmlUrl,
            OwnerId = author.Id,
            Location = author.Location,
            Login = author.Login,
            Name = author.Name,
            Url = author.Url
        };
    }

    public async Task<GitHubIssueModel> GetGitHubIssueByNo(string owner, string repository, int issueNumber)
    {
        var issue = await this.gitClient.Issue.Get(owner, repository, issueNumber);
        return new GitHubIssueModel
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
            Labels = issue.Labels.Any() ? issue.Labels.Select(label => new GitHubLabelModel
            {
                Id = label.Id,
                Name = label.Name,
                Color = label.Color,
                Description = label.Description,
                IsDefault = label.Default
            }).ToList() : new List<GitHubLabelModel>(),
            Assignee = issue.Assignee is not null ? new GitHubAuthorModel
            {
                Id = issue.Assignee.Id,
                Login = issue.Assignee.Login,
                AvatarUrl = issue.Assignee.AvatarUrl,
                Url = issue.Assignee.Url,
                HtmlUrl = issue.Assignee.HtmlUrl
            } : null,
            Assignees = issue.Assignees.Any() ? issue.Assignees.Select(assignee => new GitHubAuthorModel
            {
                Id = assignee.Id,
                Login = assignee.Login,
                AvatarUrl = assignee.AvatarUrl,
                Url = assignee.Url,
                HtmlUrl = assignee.HtmlUrl
            }).ToList() : new List<GitHubAuthorModel>(),
            Milestone = issue.Milestone is not null ? new GitHubMilestoneModel
            {
                Id = issue.Milestone.Id,
                Number = issue.Milestone.Number,
                Title = issue.Milestone.Title,
                Description = issue.Milestone.Description,
                State = issue.Milestone.State.StringValue,
                CreatedAt = issue.Milestone.CreatedAt,
                UpdatedAt = issue.Milestone.UpdatedAt,
                ClosedAt = issue.Milestone.ClosedAt
            } : null,
            Locked = issue.Locked,
            Comments = issue.Comments,
            ClosedAt = issue.ClosedAt,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
        };
    }

    public async Task<IEnumerable<GitHubIssueModel>> GetGitHubIssues(string owner, string repository)
    {
        var issues = await this.gitClient.Issue.GetAllForRepository(owner, repository);
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
            Labels = issue.Labels.Any() ? issue.Labels.Select(label => new GitHubLabelModel
            {
                Id = label.Id,
                Name = label.Name,
                Color = label.Color,
                Description = label.Description,
                IsDefault = label.Default
            }).ToList() : new List<GitHubLabelModel>(),
            Assignee = issue.Assignee is not null ? new GitHubAuthorModel
            {
                Id = issue.Assignee.Id,
                Login = issue.Assignee.Login,
                AvatarUrl = issue.Assignee.AvatarUrl,
                Url = issue.Assignee.Url,
                HtmlUrl = issue.Assignee.HtmlUrl
            } : null,
            Assignees = issue.Assignees.Any() ? issue.Assignees.Select(assignee => new GitHubAuthorModel
            {
                Id = assignee.Id,
                Login = assignee.Login,
                AvatarUrl = assignee.AvatarUrl,
                Url = assignee.Url,
                HtmlUrl = assignee.HtmlUrl
            }).ToList() : new List<GitHubAuthorModel>(),
            Milestone = issue.Milestone is not null ? new GitHubMilestoneModel
            {
                Id = issue.Milestone.Id,
                Number = issue.Milestone.Number,
                Title = issue.Milestone.Title,
                Description = issue.Milestone.Description,
                State = issue.Milestone.State.StringValue,
                CreatedAt = issue.Milestone.CreatedAt,
                UpdatedAt = issue.Milestone.UpdatedAt,
                ClosedAt = issue.Milestone.ClosedAt
            } : null,
            Locked = issue.Locked,
            Comments = issue.Comments,
            ClosedAt = issue.ClosedAt,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
        });
    }

    public async Task<IEnumerable<GitHubIssueModel>> GetGitHubIssuesByLabels(string owner, string repository, IEnumerable<string> labels)
    {
        var request = new RepositoryIssueRequest
        {
            State = ItemStateFilter.All,
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
                Name = issue.User.Name,
                Bio = issue.User.Bio,
                Email = issue.User.Email,
                Location = issue.User.Location,
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
            Assignee = issue.Assignee is not null ? new GitHubAuthorModel
            {
                Id = issue.Assignee.Id,
                Login = issue.Assignee.Login,
                AvatarUrl = issue.Assignee.AvatarUrl,
                Url = issue.Assignee.Url,
                HtmlUrl = issue.Assignee.HtmlUrl
            } : null,
            Assignees = issue.Assignees.Any() ? issue.Assignees.Select(assignee => new GitHubAuthorModel
            {
                Id = assignee.Id,
                Login = assignee.Login,
                AvatarUrl = assignee.AvatarUrl,
                Url = assignee.Url,
                HtmlUrl = assignee.HtmlUrl
            }).ToList() : new List<GitHubAuthorModel>(),
            Milestone = issue.Milestone is not null ? new GitHubMilestoneModel
            {
                Id = issue.Milestone.Id,
                Number = issue.Milestone.Number,
                Title = issue.Milestone.Title,
                Description = issue.Milestone.Description,
                State = issue.Milestone.State.StringValue,
                CreatedAt = issue.Milestone.CreatedAt,
                UpdatedAt = issue.Milestone.UpdatedAt,
                ClosedAt = issue.Milestone.ClosedAt
            } : null,
            Locked = issue.Locked,
            Comments = issue.Comments,
            ClosedAt = issue.ClosedAt,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
        });
    }

    public async Task<GitHubRepositoryModel> GetRepository(string owner, string repository)
    {
        var repo = await this.gitClient.Repository.Get(owner, repository);
        return new GitHubRepositoryModel
        {
            GitHubId = repo.Id,
            Name = repo.Name,
            Url = repo.Url,
            CloneUrl = repo.CloneUrl,
            GitUrl = repo.GitUrl,
            SvnUrl = repo.SvnUrl,
            Description = repo.Description,
        };
    }
    #endregion
}
