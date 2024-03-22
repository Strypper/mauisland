using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class CheckBoxPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public CheckBoxPageViewModel(IAppNavigator appNavigator,
                                 IGitHubService gitHubService)
                                    : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
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

    #region [ Properties ]

    [ObservableProperty]
    bool isChecked;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    [ObservableProperty]
    string currentColor = "F2F1F1";

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    string standardCheckBoxXamlCode = "<CheckBox />";

    [ObservableProperty]
    string checkBoxWithColorXamlCode = "<CheckBox Color=\"#FFFFFF\"/>";

    [ObservableProperty]
    string checkBoxTrueByDefaultXamlCode = "<CheckBox IsChecked=\"True\"/>";

    [ObservableProperty]
    string checkBoxWithBindingXamlCode = "<CheckBox IsChecked=\"{x:Binding IsChecked, Mode=TwoWay}\"\r\nColor=\"{x:Binding CurrentColor, Mode=OneWay}\"/>";

    [ObservableProperty]
    string checkBoxWithLabelXamlCode = "<HorizontalStackLayout HorizontalOptions=\"Start\" VerticalOptions=\"Center\">\r\n                            <Label\r\n                                FontAttributes=\"Bold\"\r\n                                FontSize=\"Default\"\r\n                                Text=\"CheckBox 1\" />\r\n                            <CheckBox x:Name=\"checkBox1\" />\r\n                        </HorizontalStackLayout>";
    #endregion
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

        var items = await gitHubService.GetGitHubIssuesByLabels(ControlInformation.GitHubAuthorIssueName,
                                                                ControlInformation.GitHubRepositoryIssueName,
                                                                ControlInformation.GitHubIssueLabels);


        IsBusy = false;

        if (ControlIssues is null || forced)
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
    #endregion
}
