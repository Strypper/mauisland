﻿namespace MAUIsland.GitHubFeatures;

public partial class GitHubRepositoryModel : GitHubBaseModel
{

    [ObservableProperty]
    long gitHubId;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string url;

    [ObservableProperty]
    string cloneUrl;

    [ObservableProperty]
    string gitUrl;

    [ObservableProperty]
    string svnUrl;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    int starCount;

    [ObservableProperty]
    string authorName;

    [ObservableProperty]
    string authorUrl;

    [ObservableProperty]
    string authorAvatarUrl;
}
