namespace MAUIsland.ResumesTemplate;

public partial class ResumeDetailPageViewModel(IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    #region [ Properties ]

    [ObservableProperty]
    string blazorWebViewStartPath = "/resumes-template/dotnet-template";

    [ObservableProperty]
    Dictionary<int, string> pages;

    [ObservableProperty]
    int previousSelectedPageIndex = 0;

    [ObservableProperty]
    int selectedPageIndex = 0;

    [ObservableProperty]
    string title = string.Empty;

    [ObservableProperty]
    string displayName = string.Empty;

    [ObservableProperty]
    string bio = string.Empty;

    [ObservableProperty]
    ObservableCollection<WorkHistoryModel> worksHistory;

    [ObservableProperty]
    WorkHistoryModel selectedWorksHistory;

    [ObservableProperty]
    int selectedIndexWorksHistory;
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        LoadDataAsync()
            .FireAndForget();
    }
    #endregion

    #region [ Methods ]

    async Task LoadDataAsync()
    {
        Pages = new Dictionary<int, string>
        {
            { 0, "#home" }, 
            { 1, "#education" }, 
            { 2, "#services" }, 
            { 3, "#contact" } 
        };

        WorksHistory = new()
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "iDealogic",
                    Description = "Full stack .NET Developer",
                    StartDate = new DateTime(2019, 8, 15),
                    EndDate = new DateTime(2024, 11, 01)
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Tech Innovators",
                    Description = "Senior Software Engineer",
                    StartDate = new DateTime(2017, 5, 1),
                    EndDate = new DateTime(2019, 7, 31)
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Web Solutions",
                    Description = "Software Engineer",
                    StartDate = new DateTime(2015, 3, 15),
                    EndDate = new DateTime(2017, 4, 30)
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Code Creators",
                    Description = "Junior Developer",
                    StartDate = new DateTime(2013, 1, 10),
                    EndDate = new DateTime(2015, 3, 14)
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Startup Hub",
                    Description = "Intern Developer",
                    StartDate = new DateTime(2012, 6, 1),
                    EndDate = new DateTime(2012, 12, 31)
                }
            };
    }

    #endregion

    #region [ Relay commands ]

    [RelayCommand]
    void AddWorkHistory()
        => WorksHistory.Add(new()
        {
            Id = Guid.NewGuid().ToString(),
            Title = string.Empty,
            Description = string.Empty,
            StartDate = DateTime.Now
        });

    [RelayCommand]
    void RemoveWorkHistory(string id)
    {
        var removeWork = WorksHistory.FirstOrDefault(x => x.Id == id);
        if (removeWork is null)
            return;

        WorksHistory.Remove(removeWork);
    }

    [RelayCommand]
    void UpdatePageIndex(int index)
    {
        PreviousSelectedPageIndex = SelectedPageIndex;
        SelectedPageIndex = index;
    }

    [RelayCommand]
    void UpdateWorkHistorySelectedItem(WorkHistoryModel work)
    {
        SelectedWorksHistory = work;
        SelectedIndexWorksHistory = WorksHistory.IndexOf(work);
    }
    #endregion
}
