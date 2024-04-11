namespace MAUIsland.Core;
public partial class DataGridPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]
    private readonly IControlsService MauiControlsService;
    private readonly IGitHubRepositorySyncService GitHubRepositorySyncService;
    #endregion

    #region [ CTor ]
    public DataGridPageViewModel(IAppNavigator appNavigator,
                                 IControlsService controlsService,
                                 IGitHubRepositorySyncService gitHubRepositorySyncService)
        : base(appNavigator)
    {
        this.MauiControlsService = controlsService;
        this.GitHubRepositorySyncService = gitHubRepositorySyncService;
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    IGalleryCardInfo selectedControl;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList = new();


    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupListEmtyList = new();

    [ObservableProperty]
    GitHubRepositoryLocalDbModel selectedGithubControl;

    [ObservableProperty]
    ObservableCollection<GitHubRepositoryLocalDbModel> githubControlGroupList = new();

    [ObservableProperty]
    string normalDataGridTip =
        "A tip when using the DataGrid, data from the ItemsSource is passed to each column. Each DataGridColumn has a property named ‘PropertyName’. This property should be assigned the name of the property from the ItemsSource model that you want to bind to the column. Once this is done, the ‘{x:Binding}’ expression can be used in the CellTemplate to bind to that specific property";

    [ObservableProperty]
    string xamlNormalDataGridTemplate =
        "<DataTemplate x:Key=\"DataGridItemColumnTemplate\">\r\n" +
        "   <Label Text=\"{x:Binding}\" \r\n" +
        "          TextColor=\"Black\" \r\n" +
        "          VerticalOptions=\"Center\" \r\n" +
        "          HorizontalOptions=\"Center\"/>\r\n" +
        "</DataTemplate>";

    [ObservableProperty]
    string xamlNormalDataGrid =
        "<datagird:DataGrid ItemsSource=\"{x:Binding ControlGroupList}\" \r\n" +
        "                   SelectedItem=\"{x:Binding SelectedControl}\"\r\n" +
        "                   IsRefreshing=\"{x:Binding IsRefreshing}\"\r\n" +
        "                   RowHeight=\"80\" \r\n" +
        "                   HeaderHeight=\"50\"\r\n" +
        "                   HeaderBackground=\"#35abc3\"\r\n" +
        "                   BorderColor=\"Gray\">\r\n" +
        "   <datagird:DataGrid.Columns>\r\n" +
        "       <datagird:DataGridColumn Title=\"Control\" \r\n" +
        "                                PropertyName=\"ControlIcon\" \r\n" +
        "                                Width=\"80\" \r\n" +
        "                                SortingEnabled=\"True\">\r\n" +
        "           <datagird:DataGridColumn.CellTemplate>\r\n" +
        "               <DataTemplate>\r\n" +
        "                   <Frame BackgroundColor=\"#35abc3\"\r\n" +
        "                          BorderColor=\"Transparent\"\r\n" +
        "                          HeightRequest=\"60\"\r\n" +
        "                          WidthRequest=\"60\"\r\n" +
        "                          VerticalOptions=\"Center\" \r\n" +
        "                          HorizontalOptions=\"Center\">\r\n" +
        "                       <Image Source=\"{x:Binding}\" \r\n" +
        "                              VerticalOptions=\"CenterAndExpand\" \r\n" +
        "                              HorizontalOptions=\"CenterAndExpand\"/>\r\n" +
        "                   </Frame>\r\n" +
        "               </DataTemplate>\r\n" +
        "           </datagird:DataGridColumn.CellTemplate>\r\n" +
        "       </datagird:DataGridColumn>\r\n" +
        "       <datagird:DataGridColumn Title=\"Name\" \r\n" +
        "                                PropertyName=\"ControlName\" \r\n" +
        "                                Width=\"140\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Type\" \r\n" +
        "                                PropertyName=\"CardType\" \r\n" +
        "                                Width=\"120\" \r\n" +
        "                                SortingEnabled=\"True\">\r\n" +
        "           <datagird:DataGridColumn.CellTemplate>\r\n" +
        "               <DataTemplate>\r\n" +
        "                   <Frame BackgroundColor=\"ForestGreen\"\r\n" +
        "                          BorderColor=\"LightGreen\"\r\n" +
        "                          VerticalOptions=\"Center\" \r\n" +
        "                          HorizontalOptions=\"Center\">\r\n" +
        "                       <Label Text=\"{x:Binding}\" \r\n" +
        "                              VerticalOptions=\"Center\" \r\n" +
        "                              HorizontalOptions=\"Center\"/>\r\n" +
        "                   </Frame>\r\n" +
        "               </DataTemplate>\r\n" +
        "           </datagird:DataGridColumn.CellTemplate>\r\n" +
        "       </datagird:DataGridColumn>\r\n" +
        "       <datagird:DataGridColumn Title=\"Detail\" \r\n" +
        "                                PropertyName=\"ControlDetail\" \r\n" +
        "                                Width=\"650\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "   </datagird:DataGrid.Columns>\r\n" +
        "</datagird:DataGrid>";

    [ObservableProperty]
    string cSharpNormalDataGrid =
        "[ObservableProperty]\r\n" +
        "IGalleryCardInfo selectedControl;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "ObservableCollection<IGalleryCardInfo> controlGroupList = new();";

    [ObservableProperty]
    string xamlRowsColorDataGrid =
        "<datagird:DataGrid ItemsSource=\"{x:Binding GithubControlGroupList}\" \r\n" +
        "                   SelectedItem=\"{x:Binding SelectedGithubControl}\"\r\n" +
        "                   IsRefreshing=\"{x:Binding IsRefreshing}\"\r\n" +
        "                   RowHeight=\"80\" \r\n" +
        "                   HeaderHeight=\"50\" \r\n" +
        "                   HeaderBackground=\"#e0e6f7\">\r\n" +
        "   <datagird:DataGrid.RowsBackgroundColorPalette>\r\n" +
        "       <datagird:PaletteCollection>\r\n" +
        "           <Color>#F2F2F2</Color>\r\n" +
        "           <Color>#FFFFFF</Color>\r\n" +
        "       </datagird:PaletteCollection>\r\n" +
        "   </datagird:DataGrid.RowsBackgroundColorPalette>\r\n" +
        "   <datagird:DataGrid.Columns>\r\n" +
        "       <datagird:DataGridColumn Title=\"Avatar\" \r\n" +
        "                                PropertyName=\"OwnerAvatarUrl\" \r\n" +
        "                                Width=\"80\" \r\n" +
        "                                SortingEnabled=\"True\">\r\n" +
        "           <datagird:DataGridColumn.CellTemplate>\r\n" +
        "               <DataTemplate>\r\n" +
        "                   <Image Source=\"{x:Binding}\" \r\n" +
        "                          VerticalOptions=\"Center\" \r\n" +
        "                          HorizontalOptions=\"Center\"/>\r\n" +
        "               </DataTemplate>\r\n" +
        "           </datagird:DataGridColumn.CellTemplate>\r\n" +
        "       </datagird:DataGridColumn>\r\n" +
        "       <datagird:DataGridColumn Title=\"Name\" \r\n" +
        "                                PropertyName=\"Name\" \r\n" +
        "                                Width=\"140\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Forks Count\" \r\n" +
        "                                PropertyName=\"ForksCount\" \r\n" +
        "                                Width=\"100\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Stargazers Count\" \r\n" +
        "                                PropertyName=\"StargazersCount\" \r\n" +
        "                                Width=\"120\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Issues Count\" \r\n" +
        "                                PropertyName=\"OpenIssuesCount\" \r\n" +
        "                                Width=\"100\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"License\" \r\n" +
        "                                PropertyName=\"LicenseName\" \r\n" +
        "                                Width=\"100\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Link\" \r\n" +
        "                                PropertyName=\"SvnUrl\" \r\n" +
        "                                Width=\"350\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "   </datagird:DataGrid.Columns>\r\n" +
        "</datagird:DataGrid>";

    [ObservableProperty]
    string cSharpRowsColorDataGrid =
        "[ObservableProperty]\r\n" +
        "GitHubRepositoryLocalDbModel selectedGithubControl;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "ObservableCollection<GitHubRepositoryLocalDbModel> githubControlGroupList = new();";

    [ObservableProperty]
    string xamlEmptyListDataGrid =
        "<datagird:DataGrid ItemsSource=\"{x:Binding ControlGroupListEmtyList}\"\r\n" +
        "                   IsRefreshing=\"{x:Binding IsRefreshing}\"\r\n" +
        "                   RowHeight=\"80\" \r\n" +
        "                   HeaderHeight=\"50\" \r\n" +
        "                   HeaderBackground=\"#e0e6f7\">\r\n" +
        "   <datagird:DataGrid.NoDataView>\r\n" +
        "       <ContentView>\r\n" +
        "           <Label Text=\"Nothing to see here!\" \r\n" +
        "                  VerticalOptions=\"Center\" \r\n" +
        "                  HorizontalOptions=\"Center\"\r\n" +
        "                  SemanticProperties.HeadingLevel=\"Level1\"/>\r\n" +
        "       </ContentView>\r\n" +
        "   </datagird:DataGrid.NoDataView>\r\n" +
        "   <datagird:DataGrid.Columns>\r\n" +
        "       <datagird:DataGridColumn Title=\"Control Name\" \r\n" +
        "                                PropertyName=\"ControlName\" \r\n" +
        "                                Width=\"140\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Type\" \r\n" +
        "                                PropertyName=\"CardType\" \r\n" +
        "                                Width=\"120\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Group Name\" \r\n" +
        "                                PropertyName=\"GroupName\" \r\n" +
        "                                Width=\"140\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "       <datagird:DataGridColumn Title=\"Control Detail\" \r\n" +
        "                                PropertyName=\"ControlDetail\" \r\n" +
        "                                Width=\"600\" \r\n" +
        "                                SortingEnabled=\"True\"\r\n" +
        "                                CellTemplate=\"{x:StaticResource DataGridItemColumnTemplate}\"/>\r\n" +
        "   </datagird:DataGrid.Columns>\r\n" +
        "</datagird:DataGrid>";

    [ObservableProperty]
    string cSharpEmptyListDataGrid =
        "[ObservableProperty]\r\n" +
        "ObservableCollection<IGalleryCardInfo> controlGroupListEmtyList = new();";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync().FireAndForget();

    }
    #endregion

    #region [ Relay commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
        IsRefreshing = true;

        ControlGroupList.Clear();
        GithubControlGroupList.Clear();

        var controls = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);
        foreach (var item in controls)
        {
            ControlGroupList.Add(item);
        }

        var githubControls = await GitHubRepositorySyncService.GetAllAsync();
        foreach (var item in githubControls)
        {
            GithubControlGroupList.Add(item);
        }

        IsRefreshing = false;
    }
    #endregion
}