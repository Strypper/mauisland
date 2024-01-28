using SQLite;

namespace MAUIsland;

[Table("CardInfo")]
public class CardInfoLocalDbModel : BaseLocalEntity
{
    [Column("control_icon")]
    public string ControlIcon { get; set; }

    [Column("control_name")]
    public string ControlName { get; set; }

    [Column("control_detail")]
    public string ControlDetail { get; set; }

    [Column("control_route")]
    public string ControlRoute { get; set; }

    [Column("control_github")]
    public string GitHubUrl { get; set; }

    [Column("document_url")]
    public string DocumentUrl { get; set; }

    [Column("group_name")]
    public string GroupName { get; set; }

    [Column("card_type")]
    public int CardType { get; set; }

    [Column("card_status")]
    public int CardStatus { get; set; }

    [Column("last_update")]
    public DateTime LastUpdate { get; set; }
}
