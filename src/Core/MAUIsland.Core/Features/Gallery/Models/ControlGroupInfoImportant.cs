namespace MAUIsland.Core;

public partial class ControlGroupInfoImportant : BaseModel
{
    [ObservableProperty]
    string content;

    [ObservableProperty]
    ImageSource? attachImage;

    [ObservableProperty]
    ControlGroupInfoImportantLevel level;

    [ObservableProperty]
    string additionalLink;
}

