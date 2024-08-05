using OneOf;

namespace MAUIsland.GitHubFeatures;

public class OctokitGitHubClient : IGitHubService
{
    #region [ Fields ]

    private readonly GitHubClient gitClient;
    private readonly string httpHeader = "totechs-corp";
    #endregion

    #region [ CTor ]

    public OctokitGitHubClient(FeatureSettings featureSettings)
    {
        this.gitClient = new GitHubClient(new ProductHeaderValue(httpHeader));


        var tokenAuth = new Credentials(featureSettings.AccessToken);
        this.gitClient.Credentials = tokenAuth;
    }
    #endregion

    #region [ Methods ]

    public async Task<OneOf<ServiceSuccess, SerivceError>> GetAuthor(string owner)
    {
        try
        {
            var author = await this.gitClient.User.Get(owner);
            var attachedData = new GitHubAuthorModel
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
            return new ServiceSuccess(Constants.GetAuthorSuccess,
                                      Constants.NotAvailable,
                                      nameof(OctokitGitHubClient),
                                      nameof(GetAuthor),
                                      Constants.NotAvailable,
                                      DateTime.UtcNow,
                                      attachedData);

        }
        catch (Exception e)
        {
            return new SerivceError(Constants.GetAuthorFailure,
                                    Constants.NotAvailable,
                                    nameof(OctokitGitHubClient),
                                    nameof(GetAuthor),
                                    Constants.NotAvailable,
                                    e.Message,
                                    DateTime.UtcNow);
        }
    }

    public async Task<OneOf<ServiceSuccess, SerivceError>> GetLatestRelease(string owner, string repository)
    {
        try
        {
            var releases = await this.gitClient.Repository.Release.GetAll(owner, repository);
            var latestRelease = releases.FirstOrDefault();

            if (latestRelease is null)
                return new ServiceSuccess(Constants.GetAuthorSuccess,
                                          Constants.NotAvailable,
                                          nameof(OctokitGitHubClient),
                                          nameof(GetLatestRelease),
                                          Constants.NotAvailable,
                                          DateTime.UtcNow,
                                          new List<GitHubRepositoryReleaseModel>());

            var attachedData = new GitHubRepositoryReleaseModel()
            {
                Id = latestRelease.Id,
                Url = latestRelease.Url,
                HtmlUrl = latestRelease.HtmlUrl,
                AssetsUrl = latestRelease.AssetsUrl,
                UploadUrl = latestRelease.UploadUrl,
                NodeId = latestRelease.NodeId,
                TagName = latestRelease.TagName,
                TargetCommitish = latestRelease.TargetCommitish,
                Name = latestRelease.Name,
                Body = latestRelease.Body,
                Draft = latestRelease.Draft,
                Author = latestRelease.Author is not null ? new GitHubAuthorModel()
                {
                    AvatarUrl = latestRelease.Author.AvatarUrl,
                    HtmlUrl = latestRelease.Author.HtmlUrl,
                    OwnerId = latestRelease.Author.Id,
                    Login = latestRelease.Author.Login,
                    Url = latestRelease.Author.Url
                } : null,
                Prerelease = latestRelease.Prerelease,
                CreatedAt = latestRelease.CreatedAt,
                PublishedAt = latestRelease.PublishedAt,
                TarballUrl = latestRelease.TarballUrl,
                ZipballUrl = latestRelease.ZipballUrl,
                Assets = latestRelease.Assets,
            };
            return new ServiceSuccess(Constants.GetAuthorSuccess,
                                      Constants.NotAvailable,
                                      nameof(OctokitGitHubClient),
                                      nameof(GetLatestRelease),
                                      Constants.NotAvailable,
                                      DateTime.UtcNow,
                                      attachedData);
        }
        catch (Exception e)
        {
            return new SerivceError(Constants.GetAuthorFailure,
                                    Constants.NotAvailable,
                                    nameof(OctokitGitHubClient),
                                    nameof(GetLatestRelease),
                                    Constants.NotAvailable,
                                    e.Message,
                                    DateTime.UtcNow);
        }
    }

    public async Task<OneOf<ServiceSuccess, SerivceError>> GetGitHubIssueByNo(string owner, string repository, int issueNumber)
    {
        try
        {
            var issue = await this.gitClient.Issue.Get(owner, repository, issueNumber);
            var attachedData = new GitHubIssueModel
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
            return new ServiceSuccess(Constants.GetGitHubIssueByNoSuccess,
                                      Constants.NotAvailable,
                                      nameof(OctokitGitHubClient),
                                      nameof(GetGitHubIssueByNo),
                                      Constants.NotAvailable,
                                      DateTime.UtcNow,
                                      attachedData);
        }
        catch (Exception e)
        {
            return new SerivceError(Constants.GetGitHubIssueByNoFailure,
                                    Constants.NotAvailable,
                                    nameof(OctokitGitHubClient),
                                    nameof(GetGitHubIssueByNo),
                                    Constants.NotAvailable,
                                    e.Message,
                                    DateTime.UtcNow);
        }
    }

    public async Task<OneOf<ServiceSuccess, SerivceError>> GetGitHubIssues(string owner, string repository)
    {
        try
        {
            var issues = await this.gitClient.Issue.GetAllForRepository(owner, repository);
            var attachedData = issues.Select(issue => new GitHubIssueModel
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
                IsOpen = issue.ClosedAt is null ? true : false,
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
            return new ServiceSuccess(Constants.GetGitHubIssuesSuccess,
                                      Constants.NotAvailable,
                                      nameof(OctokitGitHubClient),
                                      nameof(GetGitHubIssues),
                                      Constants.NotAvailable,
                                      DateTime.UtcNow,
                                      attachedData);
        }
        catch (Exception e)
        {
            return new SerivceError(Constants.GetGitHubIssuesFailure,
                                    Constants.NotAvailable,
                                    nameof(OctokitGitHubClient),
                                    nameof(GetGitHubIssues),
                                    Constants.NotAvailable,
                                    e.Message,
                                    DateTime.UtcNow);
        }
    }

    public async Task<OneOf<ServiceSuccess, SerivceError>> GetGitHubIssuesByLabels(string owner, string repository, IEnumerable<string> labels)
    {
        try
        {
            var request = new RepositoryIssueRequest
            {
                State = ItemStateFilter.Open,
            };
            foreach (var label in labels)
            {
                request.Labels.Add(label);
            }

            var issues = await this.gitClient.Issue.GetAllForRepository(owner, repository, request);
            var attachedData = issues.Select(issue => new GitHubIssueModel
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
                IsOpen = issue.State == ItemState.Open ? true : false,
                Comments = issue.Comments,
                ClosedAt = issue.ClosedAt,
                CreatedAt = issue.CreatedAt,
                UpdatedAt = issue.UpdatedAt,
            });
            return new ServiceSuccess(Constants.GetGitHubIssuesByLabelsSuccess,
                                      Constants.NotAvailable,
                                      nameof(OctokitGitHubClient),
                                      nameof(GetGitHubIssuesByLabels),
                                      Constants.NotAvailable,
                                      DateTime.UtcNow,
                                      attachedData);
        }
        catch (Exception e)
        {
            return new SerivceError(Constants.GetGitHubIssuesByLabelsFailure,
                                    Constants.NotAvailable,
                                    nameof(OctokitGitHubClient),
                                    nameof(GetGitHubIssuesByLabels),
                                    Constants.NotAvailable,
                                    e.Message,
                                    DateTime.UtcNow);
        }
    }

    public async Task<OneOf<ServiceSuccess, SerivceError>> GetRepository(string owner, string repository)
    {
        try
        {
            var repo = await this.gitClient.Repository.Get(owner, repository);
            var attachedData = new GitHubRepositoryModel
            {
                GitHubId = repo.Id,
                Name = repo.Name,
                Url = repo.Url,
                CloneUrl = repo.CloneUrl,
                GitUrl = repo.GitUrl,
                SvnUrl = repo.SvnUrl,
                Description = repo.Description,
                AuthorName = repo.Owner.Name,
                AuthorUrl = repo.Owner.Url,
                AuthorAvatarUrl = repo.Owner.AvatarUrl,
                StarCount = repo.StargazersCount
            };
            return new ServiceSuccess(Constants.GetRepositorySuccess,
                                      Constants.NotAvailable,
                                      nameof(OctokitGitHubClient),
                                      nameof(GetRepository),
                                      Constants.NotAvailable,
                                      DateTime.UtcNow,
                                      attachedData);
        }
        catch (Exception e)
        {
            return new SerivceError(Constants.GetRepositoryFailure,
                                    Constants.NotAvailable,
                                    nameof(OctokitGitHubClient),
                                    nameof(GetRepository),
                                    Constants.NotAvailable,
                                    e.Message,
                                    DateTime.UtcNow);
        }
    }
    #endregion
}
