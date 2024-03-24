namespace MAUIsland;

public partial class ApplicationNew : BaseModel
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string authorName;

    [ObservableProperty]
    string newLog;

    [ObservableProperty]
    string newsRoute;

    [ObservableProperty]
    object? arg;

    [ObservableProperty]
    ImageSource authorImageUrl;

    [ObservableProperty]
    ImageSource secondImage;

    [ObservableProperty]
    DateTime date;

    [ObservableProperty]
    NewActivity activity;

}

public enum NewActivity
{
    AddFeature, Enhancement
}
