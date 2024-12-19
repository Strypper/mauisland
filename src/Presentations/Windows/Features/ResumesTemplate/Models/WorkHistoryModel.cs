namespace MAUIsland.ResumesTemplate;

public partial class WorkHistoryModel : BaseModel
{
    [ObservableProperty]
    string title;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    DateTime startDate;

    [ObservableProperty]
    DateTime endDate;
}
