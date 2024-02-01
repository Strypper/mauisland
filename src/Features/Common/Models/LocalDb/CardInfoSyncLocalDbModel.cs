using SQLite;

namespace MAUIsland;

[Table($"CardInfoSync")]
public class CardInfoSyncLocalDbModel : BaseLocalEntity
{

    [Column("application_last_update")]
    public DateTime ApplicationLastUpdate { get; set; }
}
