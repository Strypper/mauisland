namespace MAUIsland;

public partial class ControlGroupInfo : BaseModel
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string ProviderUrl { get; set; }
    public ImageSource IconUrl { get; set; }

    public const string BuiltInControls = nameof(BuiltInControls);
    public const string SyncfusionControls = nameof(SyncfusionControls);
}
