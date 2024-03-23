﻿using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class EditorPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public EditorPageViewModel(IAppNavigator appNavigator,
                               IGitHubService gitHubService)
                                    : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string emptyViewText = "No issues found for this control";

    [ObservableProperty]
    string gitHubAPIRateLimit = "https://docs.github.com/en/rest/using-the-rest-api/rate-limits-for-the-rest-api?apiVersion=2022-11-28";


    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    [ObservableProperty]
    string title = "Welcome to Editor";

    [ObservableProperty]
    string simpleEditXamlCode =
        "<Editor x:Name=\"editor\"\r\n" +
        "        Placeholder=\"Enter your response here\"\r\n" +
        "        HeightRequest=\"250\"\r\n" +
        "        TextChanged=\"OnEditorTextChanged\"\r\n" +
        "        Completed=\"OnEditorCompleted\" />";

    [ObservableProperty]
    string controlTextInEditorXamlCode =
    "<VerticalStackLayout Spacing=\"10\">\r\n" +
    "    <Label Style=\"{x:StaticResource DocumentSectionTitleStyle}\" Text=\"Set character spacing\" />\r\n" +
    "    <Slider\r\n" +
    "        x:Name=\"EditorCharacterSpacingSlider\"\r\n" +
    "        Maximum=\"50\"\r\n" +
    "        Minimum=\"0\" />\r\n" +
    "\r\n" +
    "    <Picker\r\n" +
    "        x:Name=\"EditorColorPicker\"\r\n" +
    "        Title=\"Change Text Color\"\r\n" +
    "        BackgroundColor=\"#512bd4\"\r\n" +
    "        ItemsSource=\"{x:StaticResource LabelColorResource}\" />\r\n" +
    "    <Editor\r\n" +
    "        x:Name=\"CharacterSpacingEditor\"\r\n" +
    "        CharacterSpacing=\"{x:Binding Source={x:Reference EditorCharacterSpacingSlider},\r\n" +
    "                                     Path=Value,\r\n" +
    "                                     Mode=TwoWay}\"\r\n" +
    "        TextColor=\"{x:Binding Source={x:Reference EditorColorPicker},\r\n" +
    "                              Path=SelectedItem,\r\n" +
    "                              Converter={x:StaticResource StringToColorConverter}}\" />\r\n" +
    "</VerticalStackLayout>";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        await RefreshControlIssues(true);
    }
    #endregion


    #region [ Methods ]

    async Task RefreshControlIssues(bool forced)
    {
        if (IsBusy)
            return;

        IsBusy = true;

        var result = await gitHubService.GetGitHubIssuesByLabels(ControlInformation.GitHubAuthorIssueName,
                                                                 ControlInformation.GitHubRepositoryIssueName,
                                                                 ControlInformation.GitHubIssueLabels);

        IsBusy = false;

        if (result.IsT0) // Check if result is ServiceSuccess
        {
            var items = result.AsT0.AttachedData as IEnumerable<GitHubIssueModel>;

            if (ControlIssues is null || forced)
            {
                ControlIssues = new(items.Select(x => new ControlIssueModel()
                {
                    IssueId = x.Id,
                    Title = x.Title,
                    IssueLinkUrl = x.HtmlUrl,
                    MileStone = x.Milestone is null ? "No mile stone" : x.Milestone.Title,
                    OwnerName = x.User.Login,
                    AvatarUrl = x.User.AvatarUrl,
                    CreatedDate = x.CreatedAt.DateTime,
                    LastUpdated = x.UpdatedAt is null ? x.CreatedAt.DateTime : x.UpdatedAt.Value.DateTime
                }));
            }
        }
        else
        {
            var error = result.AsT1;
            EmptyViewText = error.ErrorDetail;
            await AppNavigator.ShowSnackbarAsync(error.ErrorDetail,
                                                 async () =>
                                                 {
                                                     await AppNavigator.OpenUrlAsync(GitHubAPIRateLimit);
                                                 },
                                                 "Visit GitHub API Rate Limits Policies");
        }
    }
    #endregion
}
