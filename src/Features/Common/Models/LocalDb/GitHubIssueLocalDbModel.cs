﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIsland;

[Table("IssueModel")]
public class GitHubIssueLocalDbModel : BaseLocalEntity
{
    #region [ CTor ]

    public GitHubIssueLocalDbModel()
    {

    }
    #endregion

    #region [ Properties ]

    // control name

    [Column("issue_id")]
    public long IssueId { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("issue_link_url")]
    public string IssueLinkUrl { get; set; }

    [Column("mile_stone")]
    public string MileStone { get; set; }

    [Column("owner_name")]
    public string OwnerName { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("last_updated")]
    public DateTime LastUpdated { get; set; }
    #endregion
}
