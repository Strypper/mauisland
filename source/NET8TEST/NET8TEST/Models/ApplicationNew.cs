using CommunityToolkit.Mvvm.ComponentModel;

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
    IGalleryCardInfo? component;

    [ObservableProperty]
    NewActivity activity;

    [ObservableProperty]
    string newLog;
}

public enum NewActivity
{
    AddFeature, Enhancement
}
