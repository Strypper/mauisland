using SQLite;

namespace MAUIsland;

public class BaseLocalEntity
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
}
