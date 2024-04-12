using SQLite;

namespace MAUIsland.Core;

public class BaseLocalEntity
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
}
