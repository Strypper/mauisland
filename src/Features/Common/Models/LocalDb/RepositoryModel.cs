using SQLite;

namespace MAUIsland;

[Table("RepositoryModel")]
public class RepositoryModel : BaseLocalEntity
{
    #region [ CTor ]
    public RepositoryModel() {

    }
    #endregion

    #region [ Properties ]
    [Column("name")]
    public string Name { get; set; }

    [Column("full_name")]
    public string FullName { get; set; }

    [Column("svn_url")]
    public string SvnUrl { get; set; }

    [Column("owner_url")]
    public string OwnerUrl { get; set; }

    [Column("owner_avatar_url")]
    public string OwnerAvatarUrl { get; set; }

    [Column("forks_count")]
    public int ForksCount { get; set; }

    [Column("stargazers_count")]
    public int StargazersCount { get; set; }

    [Column("open_issues_count")]
    public int OpenIssuesCount { get; set; }

    [Column("license_name")]
    public string LicenseName { get; set; }

    [Column("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }
    #endregion
}
