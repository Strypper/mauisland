namespace MAUIsland;

public partial class ControlGroupInfo : BaseModel
{
    public string Name { get; set; }
    public string ProviderUrl { get; set; }
    public string IconUrl { get; set; }

    public const string MauiBuiltInControls = nameof(MauiBuiltInControls);
    public const string SyncfusionControls = nameof(SyncfusionControls);
}
