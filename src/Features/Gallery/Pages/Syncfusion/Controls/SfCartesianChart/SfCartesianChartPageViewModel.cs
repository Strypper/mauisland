namespace MAUIsland;
public partial class SfCartesianChartPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfCartesianChartPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartPersonModel> persons;

    [ObservableProperty]
    ControlGroupInfo controlGroup;

    [ObservableProperty]
    List<Brush> palletBrushes;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    string basicSfCartesianChartXamlCode = "<Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\">\r\n                <VerticalStackLayout Spacing=\"10\">\r\n                    <charts:SfCartesianChart>\r\n                        <charts:SfCartesianChart.XAxes>\r\n                            <charts:CategoryAxis>\r\n                                <charts:CategoryAxis.Title>\r\n                                    <charts:ChartAxisTitle Text=\"Name\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n                                </charts:CategoryAxis.Title>\r\n                            </charts:CategoryAxis>\r\n                        </charts:SfCartesianChart.XAxes>\r\n                        <charts:SfCartesianChart.YAxes>\r\n                            <charts:NumericalAxis>\r\n                                <charts:NumericalAxis.Title>\r\n                                    <charts:ChartAxisTitle Text=\"Exp\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n                                </charts:NumericalAxis.Title>\r\n                            </charts:NumericalAxis>\r\n                        </charts:SfCartesianChart.YAxes>\r\n\r\n                        <charts:ColumnSeries\r\n                            EnableAnimation=\"True\"\r\n                            ItemsSource=\"{x:Binding Persons}\"\r\n                            PaletteBrushes=\"{x:Binding PalletBrushes,\r\n                                                       Mode=OneWay}\"\r\n                            SelectionBehavior=\"{x:StaticResource SfCartesianChartSelectionBrush}\"\r\n                            XBindingPath=\"Name\"\r\n                            YBindingPath=\"Exp\" />\r\n                    </charts:SfCartesianChart>\r\n                    <app:SourceCodeExpander Code=\"{x:Binding BasicSfCartesianChartXamlCode}\" />\r\n                </VerticalStackLayout>\r\n            </Frame>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();

        LoadDataAsync(true)
            .FireAndForget();
    }
    #endregion

    #region [Methods]
    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var persons = new ObservableCollection<SfCartesianChartPersonModel>();
        persons.Add(new SfCartesianChartPersonModel() { Name = "Strypper", Exp = 100 });
        persons.Add(new SfCartesianChartPersonModel() { Name = "Tan", Exp = 50 });
        persons.Add(new SfCartesianChartPersonModel() { Name = "Hung", Exp = 40 });
        persons.Add(new SfCartesianChartPersonModel() { Name = "Long", Exp = 20 });

        var gradients = new List<Brush>(createGradientPalletBrushes());

        IsBusy = false;

        Persons = new(persons);
        PalletBrushes = new(gradients);

        if (forced)
        {
            Persons.Clear();
            PalletBrushes.Clear();
        }

        foreach (var item in persons)
        {
            Persons.Add(item);
        }

        foreach (var item in gradients)
        {
            PalletBrushes.Add(item);
        }
    }

    List<Brush> createGradientPalletBrushes()
    {
        LinearGradientBrush gradientColor1 = new();
        gradientColor1.GradientStops = new()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(255, 231, 199) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 182, 159) }
            };

        LinearGradientBrush gradientColor2 = new();
        gradientColor2.GradientStops = new()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(250, 221, 125) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 204, 45) }
            };

        LinearGradientBrush gradientColor3 = new();
        gradientColor3.GradientStops = new()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(255, 231, 199) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(252, 182, 159) }
            };

        LinearGradientBrush gradientColor4 = new LinearGradientBrush();
        gradientColor4.GradientStops = new GradientStopCollection()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(221, 214, 243) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(250, 172, 168) }
            };

        LinearGradientBrush gradientColor5 = new LinearGradientBrush();
        gradientColor5.GradientStops = new GradientStopCollection()
            {
                new GradientStop() { Offset = 1, Color = Color.FromRgb(168, 234, 238) },
                new GradientStop() { Offset = 0, Color = Color.FromRgb(123, 176, 249) }
            };

        List<Brush> brushes = new();
        brushes.Add(gradientColor1);
        brushes.Add(gradientColor2);
        brushes.Add(gradientColor3);
        brushes.Add(gradientColor4);
        brushes.Add(gradientColor5);

        return brushes;

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion

}