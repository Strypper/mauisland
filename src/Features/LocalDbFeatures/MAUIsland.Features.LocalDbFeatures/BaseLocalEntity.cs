namespace MAUIsland.Features.LocalDbFeatures;

public class BaseLocalEntity
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]
    public int Id { get; set; }
}
