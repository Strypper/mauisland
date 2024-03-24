using MAUIsland.GitHubFeatures;

namespace MAUIsland;
public partial class GridPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public GridPageViewModel(IAppNavigator appNavigator,
                             IGitHubService gitHubService)
                                    : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string emptyViewText = "Fetching issues";

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
    string gridWithOneRowOneColumnXamlCode =
    "<Grid Margin=\"20,35,20,20\">\r\n" +
    "    <Label Text=\"By default, a Grid contains one row and one column.\" />\r\n" +
    "</Grid>";

    [ObservableProperty]
    string gridWithThreeRowsTwoColumsXamlCode =
        "<Grid>\r\n" +
        "    <Grid.RowDefinitions>\r\n" +
        "        <RowDefinition Height=\"2*\" />\r\n" +
        "        <RowDefinition Height=\"*\" />\r\n" +
        "        <RowDefinition Height=\"100\" />\r\n" +
        "    </Grid.RowDefinitions>\r\n" +
        "    <Grid.ColumnDefinitions>\r\n" +
        "        <ColumnDefinition Width=\"*\" />\r\n" +
        "        <ColumnDefinition Width=\"*\" />\r\n" +
        "    </Grid.ColumnDefinitions>\r\n" +
        "</Grid>";

    [ObservableProperty]
    string gridCellsXamlCode =
        "<Grid>\r\n" +
        "    <Grid.RowDefinitions>\r\n" +
        "        <RowDefinition Height=\"2*\" />\r\n" +
        "        <RowDefinition />\r\n" +
        "        <RowDefinition Height=\"300\" />\r\n" +
        "    </Grid.RowDefinitions>\r\n" +
        "    <Grid.ColumnDefinitions>\r\n" +
        "        <ColumnDefinition />\r\n" +
        "        <ColumnDefinition />\r\n" +
        "    </Grid.ColumnDefinitions>\r\n" +
        "    <!-- Rest of your XAML code here -->\r\n" +
        "</Grid>";

    [ObservableProperty]
    string gridCellsCSharpCode = "public class BasicGridPage : ContentPage\r\n{\r\n    public BasicGridPage()\r\n    {\r\n        Grid grid = new Grid\r\n        {\r\n            RowDefinitions =\r\n            {\r\n                new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },\r\n                new RowDefinition(),\r\n                new RowDefinition { Height = new GridLength(100) }\r\n            },\r\n            ColumnDefinitions =\r\n            {\r\n                new ColumnDefinition(),\r\n                new ColumnDefinition()\r\n            }\r\n        };\r\n\r\n        // Row 0\r\n        // The BoxView and Label are in row 0 and column 0, and so only need to be added to the\r\n        // Grid to obtain the default row and column settings.\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.Green\r\n        });\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Row 0, Column 0\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.Center\r\n        });\r\n\r\n        // This BoxView and Label are in row 0 and column 1, which are specified as arguments\r\n        // to the Add method.\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.Blue\r\n        }, 1, 0);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Row 0, Column 1\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.Center\r\n        }, 1, 0);\r\n\r\n        // Row 1\r\n        // This BoxView and Label are in row 1 and column 0, which are specified as arguments\r\n        // to the Add method overload.\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.Teal\r\n        }, 0, 1);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Row 1, Column 0\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.Center\r\n        }, 0, 1);\r\n\r\n        // This BoxView and Label are in row 1 and column 1, which are specified as arguments\r\n        // to the Add method overload.\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.Purple\r\n        }, 1, 1);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Row1, Column 1\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.Center\r\n        }, 1, 1);\r\n\r\n        // Row 2\r\n        // Alternatively, the BoxView and Label can be positioned in cells with the Grid.SetRow\r\n        // and Grid.SetColumn methods.\r\n        BoxView boxView = new BoxView { Color = Colors.Red };\r\n        Grid.SetRow(boxView, 2);\r\n        Grid.SetColumnSpan(boxView, 2);\r\n        Label label = new Label\r\n        {\r\n            Text = \"Row 2, Column 0 and 1\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.Center\r\n        };\r\n        Grid.SetRow(label, 2);\r\n        Grid.SetColumnSpan(label, 2);\r\n\r\n        grid.Add(boxView);\r\n        grid.Add(label);\r\n\r\n        Title = \"Basic Grid demo\";\r\n        Content = grid;\r\n    }\r\n}";


    [ObservableProperty]
    string gridWithFiveRowsFourColumnsXamlCode =
        "<Grid RowDefinitions=\"1*, Auto, 25, 14, 20\"\r\n" +
        "      ColumnDefinitions=\"*, 2*, Auto, 300\">\r\n" +
        "    ...\r\n" +
        "</Grid>";

    [ObservableProperty]
    string gridSpaceBetweenRowColumnXamlCode =
        "<Grid ColumnSpacing=\"8\" RowSpacing=\"8\">\r\n" +
        "    <Grid.RowDefinitions>\r\n" +
        "        <RowDefinition Height=\"2*\" />\r\n" +
        "        <RowDefinition />\r\n" +
        "        <RowDefinition Height=\"300\" />\r\n" +
        "    </Grid.RowDefinitions>\r\n" +
        "    <Grid.ColumnDefinitions>\r\n" +
        "        <ColumnDefinition />\r\n" +
        "        <ColumnDefinition />\r\n" +
        "    </Grid.ColumnDefinitions>\r\n" +
        "    <!-- Rest of your XAML code here -->\r\n" +
        "</Grid>";

    [ObservableProperty]
    string gridSpaceBetweenRowColumnCSharpCode = "public class GridSpacingPage : ContentPage\r\n{\r\n    public GridSpacingPage()\r\n    {\r\n        Grid grid = new Grid\r\n        {\r\n            RowSpacing = 6,\r\n            ColumnSpacing = 6,\r\n            ...\r\n        };\r\n        ...\r\n\r\n        Content = grid;\r\n    }\r\n}";


    [ObservableProperty]
    string gridWithNineCellsXamlCode =
    "<Grid>\r\n" +
    "    <Grid.RowDefinitions>\r\n" +
    "        <RowDefinition />\r\n" +
    "        <RowDefinition />\r\n" +
    "        <RowDefinition />\r\n" +
    "    </Grid.RowDefinitions>\r\n" +
    "    <Grid.ColumnDefinitions>\r\n" +
    "        <ColumnDefinition />\r\n" +
    "        <ColumnDefinition />\r\n" +
    "        <ColumnDefinition />\r\n" +
    "    </Grid.ColumnDefinitions>\r\n" +
    "    <!-- Rest of your XAML code here -->\r\n" +
    "</Grid>";

    [ObservableProperty]
    string gridWithNineCellsCSharpCode = "public class GridAlignmentPage : ContentPage\r\n{\r\n    public GridAlignmentPage()\r\n    {\r\n        Grid grid = new Grid\r\n        {\r\n            RowDefinitions =\r\n            {\r\n                new RowDefinition(),\r\n                new RowDefinition(),\r\n                new RowDefinition()\r\n            },\r\n            ColumnDefinitions =\r\n            {\r\n                new ColumnDefinition(),\r\n                new ColumnDefinition(),\r\n                new ColumnDefinition()\r\n            }\r\n        };\r\n\r\n        // Row 0\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.AliceBlue\r\n        });\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Upper left\",\r\n            HorizontalOptions = LayoutOptions.Start,\r\n            VerticalOptions = LayoutOptions.Start\r\n        });\r\n\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.LightSkyBlue\r\n        }, 1, 0);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Upper center\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.Start\r\n        }, 1, 0);\r\n\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.CadetBlue\r\n        }, 2, 0);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Upper right\",\r\n            HorizontalOptions = LayoutOptions.End,\r\n            VerticalOptions = LayoutOptions.Start\r\n        }, 2, 0);\r\n\r\n        // Row 1\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.CornflowerBlue\r\n        }, 0, 1);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Center left\",\r\n            HorizontalOptions = LayoutOptions.Start,\r\n            VerticalOptions = LayoutOptions.Center\r\n        }, 0, 1);\r\n\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.DodgerBlue\r\n        }, 1, 1);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Center center\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.Center\r\n        }, 1, 1);\r\n\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.DarkSlateBlue\r\n        }, 2, 1);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Center right\",\r\n            HorizontalOptions = LayoutOptions.End,\r\n            VerticalOptions = LayoutOptions.Center\r\n        }, 2, 1);\r\n\r\n        // Row 2\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.SteelBlue\r\n        }, 0, 2);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Lower left\",\r\n            HorizontalOptions = LayoutOptions.Start,\r\n            VerticalOptions = LayoutOptions.End\r\n        }, 0, 2);\r\n\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.LightBlue\r\n        }, 1, 2);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Lower center\",\r\n            HorizontalOptions = LayoutOptions.Center,\r\n            VerticalOptions = LayoutOptions.End\r\n        }, 1, 2);\r\n\r\n        grid.Add(new BoxView\r\n        {\r\n            Color = Colors.BlueViolet\r\n        }, 2, 2);\r\n        grid.Add(new Label\r\n        {\r\n            Text = \"Lower right\",\r\n            HorizontalOptions = LayoutOptions.End,\r\n            VerticalOptions = LayoutOptions.End\r\n        }, 2, 2);\r\n\r\n        Title = \"Grid alignment demo\";\r\n        Content = grid;\r\n    }\r\n}";

    [ObservableProperty]
    string gridObjectXamlCode =
    "<Grid>\r\n" +
    "    <Grid.RowDefinitions>\r\n" +
    "        <RowDefinition Height=\"500\" />\r\n" +
    "        <RowDefinition Height=\"Auto\" />\r\n" +
    "    </Grid.RowDefinitions>\r\n" +
    "    <!-- Rest of your XAML code here -->\r\n" +
    "</Grid>";

    [ObservableProperty]
    string gridObjectCSharpCode = "public class ColorSlidersGridPage : ContentPage\r\n{\r\n    BoxView boxView;\r\n    Slider redSlider;\r\n    Slider greenSlider;\r\n    Slider blueSlider;\r\n\r\n    public ColorSlidersGridPage()\r\n    {\r\n        // Create an implicit style for the Labels\r\n        Style labelStyle = new Style(typeof(Label))\r\n        {\r\n            Setters =\r\n            {\r\n                new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Center }\r\n            }\r\n        };\r\n        Resources.Add(labelStyle);\r\n\r\n        // Root page layout\r\n        Grid rootGrid = new Grid\r\n        {\r\n            RowDefinitions =\r\n            {\r\n                new RowDefinition { HeightRequest = 500 },\r\n                new RowDefinition()\r\n            }\r\n        };\r\n\r\n        boxView = new BoxView { Color = Colors.Black };\r\n        rootGrid.Add(boxView);\r\n\r\n        // Child page layout\r\n        Grid childGrid = new Grid\r\n        {\r\n            Margin = new Thickness(20),\r\n            RowDefinitions =\r\n            {\r\n                new RowDefinition(),\r\n                new RowDefinition(),\r\n                new RowDefinition(),\r\n                new RowDefinition(),\r\n                new RowDefinition(),\r\n                new RowDefinition()\r\n            }\r\n        };\r\n\r\n        DoubleToIntConverter doubleToInt = new DoubleToIntConverter();\r\n\r\n        redSlider = new Slider();\r\n        redSlider.ValueChanged += OnSliderValueChanged;\r\n        childGrid.Add(redSlider);\r\n\r\n        Label redLabel = new Label();\r\n        redLabel.SetBinding(Label.TextProperty, new Binding(\"Value\", converter: doubleToInt, converterParameter: \"255\", stringFormat: \"Red = {0}\", source: redSlider));\r\n        Grid.SetRow(redLabel, 1);\r\n        childGrid.Add(redLabel);\r\n\r\n        greenSlider = new Slider();\r\n        greenSlider.ValueChanged += OnSliderValueChanged;\r\n        Grid.SetRow(greenSlider, 2);\r\n        childGrid.Add(greenSlider);\r\n\r\n        Label greenLabel = new Label();\r\n        greenLabel.SetBinding(Label.TextProperty, new Binding(\"Value\", converter: doubleToInt, converterParameter: \"255\", stringFormat: \"Green = {0}\", source: greenSlider));\r\n        Grid.SetRow(greenLabel, 3);\r\n        childGrid.Add(greenLabel);\r\n\r\n        blueSlider = new Slider();\r\n        blueSlider.ValueChanged += OnSliderValueChanged;\r\n        Grid.SetRow(blueSlider, 4);\r\n        childGrid.Add(blueSlider);\r\n\r\n        Label blueLabel = new Label();\r\n        blueLabel.SetBinding(Label.TextProperty, new Binding(\"Value\", converter: doubleToInt, converterParameter: \"255\", stringFormat: \"Blue = {0}\", source: blueSlider));\r\n        Grid.SetRow(blueLabel, 5);\r\n        childGrid.Add(blueLabel);\r\n\r\n        // Place the child Grid in the root Grid\r\n        rootGrid.Add(childGrid, 0, 1);\r\n\r\n        Title = \"Nested Grids demo\";\r\n        Content = rootGrid;\r\n    }\r\n\r\n    void OnSliderValueChanged(object sender, ValueChangedEventArgs e)\r\n    {\r\n        boxView.Color = new Color(redSlider.Value, greenSlider.Value, blueSlider.Value);\r\n    }\r\n}";

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