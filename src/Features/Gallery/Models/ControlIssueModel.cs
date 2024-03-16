﻿namespace MAUIsland;

public partial class ControlIssueModel : BaseModel
{
    [ObservableProperty]
    long issueId;

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string issueLinkUrl;

    [ObservableProperty]
    string mileStone;

    [ObservableProperty]
    string ownerName;

    [ObservableProperty]
    DateTime createdDate;

    [ObservableProperty]
    DateTime lastUpdated;

}
