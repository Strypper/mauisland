namespace MAUIsland.Core;

public partial class BaseMockUp : BaseModel
{
    [ObservableProperty]
    List<string> mockUps = new List<string>();
}
