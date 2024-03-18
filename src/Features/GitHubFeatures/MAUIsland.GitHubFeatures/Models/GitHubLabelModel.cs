namespace MAUIsland.GitHubFeatures;

public partial class GitHubLabelModel : GitHubBaseModel
{
    [ObservableProperty]
    long id;

    [ObservableProperty]
    string url;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string nodeId;

    [ObservableProperty]
    string color;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    bool isDefault;
}
