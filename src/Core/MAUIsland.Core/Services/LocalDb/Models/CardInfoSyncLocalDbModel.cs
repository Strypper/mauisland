using SQLite;

namespace MAUIsland.Core;

public class CardInfoSyncLocalDbModel : BaseLocalEntity
{

    [Column("application_last_update")]
    public DateTime ApplicationLastUpdate { get; set; }
}
