using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;


public partial class IndicatorViewPageViewModel : BaseBuiltInPageControlViewModel
{

    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public IndicatorViewPageViewModel(IAppNavigator appNavigator,
                                      IGitHubService gitHubService,
                                      IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                        : base(appNavigator,
                                                gitHubService,
                                                gitHubIssueLocalDbService)
    {
    }
    #endregion


    #region [Properties]

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    string standardIndicatorViewXamlCode = "<StackLayout HorizontalOptions=\"Start\">\r\n    <CarouselView ItemsSource=\"{Binding Cats}\"\r\n                  WidthRequest=\"120\"\r\n                  HorizontalScrollBarVisibility=\"Never\"\r\n                  IndicatorView=\"indicatorView1\"\r\n                  Loop=\"False\"\r\n                  ItemTemplate=\"{x:StaticResource CarouseViewTemplate1}\"/>\r\n    <IndicatorView x:Name=\"indicatorView1\"\r\n                   IndicatorColor=\"LightGray\"\r\n                   SelectedIndicatorColor=\"DarkGray\"/>\r\n</StackLayout>";

    [ObservableProperty]
    List<Cats> cats = new List<Cats>()
    {
        new Cats()
        {
            Name = "Polydactyl",
            Description = "Cat1"
        },
        new Cats()
        {
            Name = "Snowshoe",
            Description = "Cat2"
        },new Cats()
        {
            Name = "British Shorthair",
            Description = "Cat3"
        },new Cats()
        {
            Name = "Gray Tabby",
            Description = "Cat4"
        }
    };
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
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}

