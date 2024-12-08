using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIsland.Features.LocalDbFeatures.GitHub;

[Table("IssueModel")]
public class GitHubIssueLocalDbModel : BaseLocalEntity
{
    #region [ CTor ]

    public GitHubIssueLocalDbModel()
    {

    }
    #endregion

    #region [ Properties ]
    [Column("control_name")]
    public string ControlName { get; set; } //Because of this prop, this class should be renamed to GitHubControlIssueLocalDbModel

    [Column("issue_id")]
    public long IssueId { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("is_open")]
    public bool IsOpen { get; set; }

    [Column("issue_link_url")]
    public string IssueLinkUrl { get; set; }

    [Column("mile_stone")]
    public string MileStone { get; set; }

    [Column("owner_name")]
    public string OwnerName { get; set; }

    [Column("user_avatar_url")]
    public string UserAvatarUrl { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("last_updated")]
    public DateTime LastUpdated { get; set; }

    /// <summary>
    /// Serialized list of labels of this issue
    /// </summary>
    [Column("labels")]
    public string Labels { get; set; }
    #endregion
}
