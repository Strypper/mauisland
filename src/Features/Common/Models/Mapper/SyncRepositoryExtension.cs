using Bogus;
using Octokit;

namespace MAUIsland;

public static class SyncRepositoryExtension
{
    #region [ Public Static Methods - Map To Repository ]
    public static Repository ToRepository(this RepositoryModel model) {
        if (model == null) {
            return default;
        }

        var owner = GetUser(model.OwnerUrl, model.OwnerAvatarUrl);
        var license = GetLicense(model.LicenseName);

        var repo = new Faker<Repository>()
            .RuleFor(x => x.SvnUrl, model.SvnUrl)
            .RuleFor(x => x.Owner, owner)
            .RuleFor(x => x.Name, model.Name)
            .RuleFor(x => x.FullName, model.FullName)
            .RuleFor(x => x.ForksCount, model.ForksCount)
            .RuleFor(x => x.StargazersCount, model.StargazersCount)
            .RuleFor(x => x.OpenIssuesCount, model.OpenIssuesCount)
            .RuleFor(x => x.License, license)
            .RuleFor(x => x.UpdatedAt, model.UpdatedAt);

        return repo.Generate();
    }
    #endregion

    #region [ Public Methods - Map To Model ]
    public static RepositoryModel ToRepositoryModel(this Repository repo) {
        if (repo == null) {
            return default;
        }

        var repoModel = new Faker<RepositoryModel>()
            .RuleFor(x => x.SvnUrl, repo.SvnUrl)
            .RuleFor(x => x.OwnerUrl, repo.Owner.Url)
            .RuleFor(x => x.OwnerAvatarUrl, repo.Owner.AvatarUrl)
            .RuleFor(x => x.Name, repo.Name)
            .RuleFor(x => x.FullName, repo.FullName)
            .RuleFor(x => x.ForksCount, repo.ForksCount)
            .RuleFor(x => x.StargazersCount, repo.StargazersCount)
            .RuleFor(x => x.OpenIssuesCount, repo.OpenIssuesCount)
            .RuleFor(x => x.LicenseName, repo.License.Name)
            .RuleFor(x => x.UpdatedAt, repo.UpdatedAt);

        return repoModel.Generate();
    }
    #endregion

    #region [ Private Methods - Initialize Objects ]
    private static User GetUser(string url, string avatarUrl) {
        var user = new Faker<User>()
                        .RuleFor(x => x.Url, url)
                        .RuleFor(x => x.AvatarUrl, avatarUrl);

        return user.Generate();
    }

    private static License GetLicense(string name) {
        var license = new Faker<License>()
                            .RuleFor(x => x.Name, name);

        return license.Generate();
    }
    #endregion
}