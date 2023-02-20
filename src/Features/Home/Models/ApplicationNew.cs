namespace MAUIsland;

public partial class ApplicationNew : BaseModel
{
    [ObservableProperty]
    string authorName;

    [ObservableProperty]
    ImageSource authorImageUrl;

    [ObservableProperty]
    DateTime date;

    [ObservableProperty]
    IControlInfo? component;

    [ObservableProperty]
    NewActivity activity;

    [ObservableProperty]
    string newLog;
}

public enum NewActivity
{
    AddFeature, Enhancement
}
