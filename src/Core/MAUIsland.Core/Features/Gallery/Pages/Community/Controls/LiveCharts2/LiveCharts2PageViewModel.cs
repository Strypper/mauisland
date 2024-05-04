using LiveChartsCore;
using LiveChartsCore.ConditionalDraw;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.Themes;
using SkiaSharp;

namespace MAUIsland.Core;
public partial class LiveCharts2PageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]


    private readonly Random _r = new();
    private PilotInfo[] _racingData;
    #endregion

    #region [ CTor ]
    public LiveCharts2PageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
        InitRacingBars();
    }
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }

    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    #region [ Basic Bars ]

    [ObservableProperty]
    string basicBarsTitle = "Basic Bars";

    [ObservableProperty]
    string basicBarsCSharpCode =
    "public ISeries[] BasicBarsSeries { get; set; } =\r\n" +
    "{\r\n" +
    "        new ColumnSeries<double>\r\n" +
    "        {\r\n" +
    "            Name = \"Mary\",\r\n" +
    "            Values = new double[] { 2, 5, 4 }\r\n" +
    "        },\r\n" +
    "        new ColumnSeries<double>\r\n" +
    "        {\r\n" +
    "            Name = \"Ana\",\r\n" +
    "            Values = new double[] { 3, 1, 6 }\r\n" +
    "        }\r\n" +
    "};\r\n" +
    "\r\n" +
    "public Axis[] BasicBarsXAxes { get; set; } =\r\n" +
    "{\r\n" +
    "    new Axis\r\n" +
    "    {\r\n" +
    "        Labels = new string[] { \"Category 1\", \"Category 2\", \"Category 3\" },\r\n" +
    "        LabelsRotation = 0,\r\n" +
    "        LabelsPaint = new SolidColorPaint(SKColors.White),\r\n" +
    "        SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),\r\n" +
    "        SeparatorsAtCenter = false,\r\n" +
    "        TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),\r\n" +
    "        TicksAtCenter = true,\r\n" +
    "        ForceStepToMin = true,\r\n" +
    "        MinStep = 1\r\n" +
    "    }\r\n" +
    "};\r\n" +
    "\r\n" +
    "public Axis[] BasicBarsYAxes { get; set; } =\r\n" +
    "{\r\n" +
    "    new Axis\r\n" +
    "    {\r\n" +
    "       LabelsPaint = new SolidColorPaint(SKColors.White),\r\n" +
    "    }\r\n" +
    "};\r\n" +
    "\r\n" +
    "public SolidColorPaint LegendTextPaint { get; set; } =\r\n" +
    "    new SolidColorPaint\r\n" +
    "    {\r\n" +
    "        Color = new SKColor(255, 255, 255),\r\n" +
    "        SKTypeface = SKTypeface.FromFamilyName(\"Courier New\")\r\n" +
    "    };\r\n" +
    "\r\n" +
    "public SolidColorPaint LegendBackgroundPaint { get; set; } =\r\n" +
    "    new SolidColorPaint(new SKColor(146, 228, 146));";


    [ObservableProperty]
    string basicBarsXamlCode =
    "<lvc:CartesianChart\r\n" +
    "    HeightRequest=\"300\"\r\n" +
    "    LegendPosition=\"Right\"\r\n" +
    "    Series=\"{Binding BasicBarsSeries}\"\r\n" +
    "    XAxes=\"{Binding BasicBarsXAxes}\"\r\n" +
    "    YAxes=\"{Binding BasicBarsYAxes}\"\r\n" +
    "    LegendBackgroundPaint=\"{Binding LegendBackgroundPaint}\"\r\n" +
    "    LegendTextPaint=\"{Binding LegendTextPaint}\" />";


    public ISeries[] BasicBarsSeries { get; set; } =
    {
            new ColumnSeries<double>
            {
                Name = "Mary",
                Values = new double[] { 2, 5, 4 }
            },
            new ColumnSeries<double>
            {
                Name = "Ana",
                Values = new double[] { 3, 1, 6 }
            }
        };

    public Axis[] BasicBarsXAxes { get; set; } =
    {
        new Axis
        {
            Labels = new string[] { "Category 1", "Category 2", "Category 3" },
            LabelsRotation = 0,
            LabelsPaint = new SolidColorPaint(SKColors.White),
            SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
            SeparatorsAtCenter = false,
            TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
            TicksAtCenter = true,
            ForceStepToMin = true,
            MinStep = 1
        }
    };

    public Axis[] BasicBarsYAxes { get; set; } =
    {
        new Axis
        {
           LabelsPaint = new SolidColorPaint(SKColors.White),
        }
    };

    public SolidColorPaint LegendTextPaint { get; set; } =
        new SolidColorPaint
        {
            Color = new SKColor(255, 255, 255),
            SKTypeface = SKTypeface.FromFamilyName("Courier New")
        };

    public SolidColorPaint LegendBackgroundPaint { get; set; } =
        new SolidColorPaint(new SKColor(146, 228, 146));

    #endregion

    #region [ Bars With Background ]

    [ObservableProperty]
    string barsWithBackgroundTitle = "Bars With Background";

    [ObservableProperty]
    string barsWithBackgroundCSharpCode =
    "public ISeries[] BarsWithBackgroundSeries { get; set; } =\r\n" +
    "{\r\n" +
    "    new ColumnSeries<double>\r\n" +
    "    {\r\n" +
    "        IsHoverable = false, // disables the series from the tooltips \r\n" +
    "        Values = new double[] { 10, 10, 10, 10, 10, 10, 10 },\r\n" +
    "        Stroke = null,\r\n" +
    "        Fill = new SolidColorPaint(new SKColor(30, 30, 30, 30)),\r\n" +
    "        IgnoresBarPosition = true\r\n" +
    "    },\r\n" +
    "    new ColumnSeries<double>\r\n" +
    "    {\r\n" +
    "        Values = new double[] { 3, 10, 5, 3, 7, 3, 8 },\r\n" +
    "        Stroke = null,\r\n" +
    "        Fill = new SolidColorPaint(SKColors.CornflowerBlue),\r\n" +
    "        IgnoresBarPosition = true\r\n" +
    "    }\r\n" +
    "};\r\n" +
    "\r\n" +
    "public Axis[] BarsWithBackgroundYAxes { get; set; } =\r\n" +
    "{\r\n" +
    "    new Axis \r\n" +
    "    { \r\n" +
    "        MinLimit = 0, \r\n" +
    "        MaxLimit = 10,\r\n" +
    "        LabelsPaint = new SolidColorPaint(SKColors.White), \r\n" +
    "    }\r\n" +
    "};\r\n" +
    "\r\n" +
    "public Axis[] BarsWithBackgroundXAxes { get; set; } =\r\n" +
    "{\r\n" +
    "    new Axis\r\n" +
    "    {\r\n" +
    "        LabelsPaint = new SolidColorPaint(SKColors.White),\r\n" +
    "    }\r\n" +
    "};";


    [ObservableProperty]
    string barsWithBackgroundXamlCode =
    "<lvc:CartesianChart\r\n" +
    "    HeightRequest=\"300\"\r\n" +
    "    Series=\"{Binding BarsWithBackgroundSeries}\"\r\n" +
    "    XAxes=\"{Binding BarsWithBackgroundXAxes}\"\r\n" +
    "    YAxes=\"{Binding BarsWithBackgroundYAxes}\" />";


    public ISeries[] BarsWithBackgroundSeries { get; set; } =
{
            new ColumnSeries<double>
            {
                IsHoverable = false, // disables the series from the tooltips 
                Values = new double[] { 10, 10, 10, 10, 10, 10, 10 },
                Stroke = null,
                Fill = new SolidColorPaint(new SKColor(30, 30, 30, 30)),
                IgnoresBarPosition = true
            },
            new ColumnSeries<double>
            {
                Values = new double[] { 3, 10, 5, 3, 7, 3, 8 },
                Stroke = null,
                Fill = new SolidColorPaint(SKColors.CornflowerBlue),
                IgnoresBarPosition = true
            }
        };

    public Axis[] BarsWithBackgroundYAxes { get; set; } =
    {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 10,
                LabelsPaint = new SolidColorPaint(SKColors.White),
            }
        };


    public Axis[] BarsWithBackgroundXAxes { get; set; } =
    {
            new Axis
            {
                LabelsPaint = new SolidColorPaint(SKColors.White),
            }
    };
    #endregion

    #region [ Racing Bars ]

    [ObservableProperty]
    string racingBarsTitle = "Racing Bars";

    [ObservableProperty]
    string racingBarsCSharpCode = "[ObservableProperty]\r\n    ISeries[] racingSeries;\r\n\r\n    [ObservableProperty]\r\n    Axis[] xRacingAxes = { new Axis { SeparatorsPaint = new SolidColorPaint(new SKColor(220, 220, 220)) } };\r\n\r\n    [ObservableProperty]\r\n    Axis[] yRacingAxes = { new Axis { IsVisible = false } };\r\n\r\n    public bool IsReading { get; set; } = true; void InitRacingBars()\r\n    {\r\n\r\n        // generate some paints for each pilot:\r\n        var paints = Enumerable.Range(0, 7)\r\n            .Select(i => new SolidColorPaint(ColorPalletes.MaterialDesign500[i].AsSKColor()))\r\n            .ToArray();\r\n\r\n        // generate some data for each pilot:\r\n        _racingData = new PilotInfo[]\r\n        {\r\n            new(\"Tsunoda\",   500,  paints[0]),\r\n            new(\"Sainz\",     450,  paints[1]),\r\n            new(\"Riccardo\",  520,  paints[2]),\r\n            new(\"Bottas\",    550,  paints[3]),\r\n            new(\"Perez\",     660,  paints[4]),\r\n            new(\"Verstapen\", 920,  paints[5]),\r\n            new(\"Hamilton\",  1000, paints[6])\r\n        };\r\n\r\n        var rowSeries = new RowSeries<PilotInfo>\r\n        {\r\n            Values = _racingData.OrderBy(x => x.Value).ToArray(),\r\n            DataLabelsPaint = new SolidColorPaint(new SKColor(245, 245, 245)),\r\n            DataLabelsPosition = DataLabelsPosition.End,\r\n            DataLabelsTranslate = new(-1, 0),\r\n            DataLabelsFormatter = point => $\"{point.Model!.Name} {point.Coordinate.PrimaryValue}\",\r\n            MaxBarWidth = 50,\r\n            Padding = 10,\r\n        }.OnPointMeasured(point =>\r\n        {\r\n            // assign a different color to each point\r\n            if (point.Visual is null) return;\r\n            point.Visual.Fill = point.Model!.Paint;\r\n        });\r\n\r\n        RacingSeries = new[] { rowSeries };\r\n\r\n        StartRace().FireAndForget();\r\n    }\r\n\r\n    async Task StartRace()\r\n    {\r\n        await Task.Delay(1000);\r\n\r\n\r\n        while (IsReading)\r\n        {\r\n            // do a random change to the data\r\n            foreach (var item in _racingData)\r\n                item.Value += _r.Next(0, 100);\r\n\r\n            RacingSeries[0].Values =\r\n                _racingData.OrderBy(x => x.Value).ToArray();\r\n\r\n            await Task.Delay(100);\r\n        }\r\n    }";

    [ObservableProperty]
    string racingBarsXamlCode = "<lvc:CartesianChart\r\n                        HeightRequest=\"300\"\r\n                        Series=\"{Binding RacingSeries}\"\r\n                        TooltipPosition=\"Hidden\"\r\n                        XAxes=\"{Binding XRacingAxes}\"\r\n                        YAxes=\"{Binding YRacingAxes}\" />";

    [ObservableProperty]
    ISeries[] racingSeries;

    [ObservableProperty]
    Axis[] xRacingAxes =
    {
        new Axis
        {
            LabelsPaint = new SolidColorPaint(SKColors.White),
            SeparatorsPaint = new SolidColorPaint(new SKColor(220, 220, 220))
        }
    };

    [ObservableProperty]
    Axis[] yRacingAxes = { new Axis { IsVisible = false } };

    public bool IsReading { get; set; } = true;
    #endregion

    #region [ Line Series ]

    [ObservableProperty]
    string lineSeriesTitle = "Line Series";

    [ObservableProperty]
    string lineSeriesCSharpCode = "public ISeries[] LineSeries { get; set; } =\r\n    {\r\n        new LineSeries<double>\r\n        {\r\n            Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },\r\n            Fill = null\r\n        }\r\n    };\r\n\r\n    public LabelVisual LineSeriesVisualTitle { get; set; } =\r\n        new LabelVisual\r\n        {\r\n            Text = \"My chart title\",\r\n            TextSize = 25,\r\n            Padding = new LiveChartsCore.Drawing.Padding(15),\r\n            Paint = new SolidColorPaint(SKColors.DarkSlateGray)\r\n        };";

    [ObservableProperty]
    string lineSeriesXamlCode = "<lvc:CartesianChart\r\n                        Title=\"{Binding LineSeriesVisualTitle}\"\r\n                        HeightRequest=\"300\"\r\n                        Series=\"{Binding LineSeries}\" />";

    public ISeries[] LineSeries { get; set; } =
    {
        new LineSeries<double>
        {
            Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
            Fill = null
        }
    };

    public LabelVisual LineSeriesVisualTitle { get; set; } =
        new LabelVisual
        {
            Text = "Line chart title",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.White)
        };
    #endregion

    #region [ Stacked Column Bars ]

    [ObservableProperty]
    string stackedBarsTitle = "Stacked Column Bars";

    [ObservableProperty]
    string stackBarsCSharpCode = "public ISeries[] StackedSeries { get; set; } =\r\n    {\r\n        new StackedColumnSeries<int>\r\n        {\r\n            Values = new List<int> { 3, 5, -3, 2, 5, -4, -2 },\r\n            Stroke = null,\r\n            DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),\r\n            DataLabelsSize = 14,\r\n            DataLabelsPosition = DataLabelsPosition.Middle\r\n        },\r\n        new StackedColumnSeries<int>\r\n        {\r\n            Values = new List<int> { 4, 2, -3, 2, 3, 4, -2 },\r\n            Stroke = null,\r\n            DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),\r\n            DataLabelsSize = 14,\r\n            DataLabelsPosition = DataLabelsPosition.Middle\r\n        },\r\n        new StackedColumnSeries<int>\r\n        {\r\n            Values = new List<int> { -2, 6, 6, 5, 4, 3, -2 },\r\n            Stroke = null,\r\n            DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),\r\n            DataLabelsSize = 14,\r\n            DataLabelsPosition = DataLabelsPosition.Middle\r\n        }\r\n    };";

    [ObservableProperty]
    string stackBarsXamlCode = "<lvc:CartesianChart HeightRequest=\"300\" Series=\"{Binding StackedSeries}\" />";

    public ISeries[] StackedSeries { get; set; } =
    {
        new StackedColumnSeries<int>
        {
            Values = new List<int> { 3, 5, -3, 2, 5, -4, -2 },
            Stroke = null,
            DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
            DataLabelsSize = 14,
            DataLabelsPosition = DataLabelsPosition.Middle
        },
        new StackedColumnSeries<int>
        {
            Values = new List<int> { 4, 2, -3, 2, 3, 4, -2 },
            Stroke = null,
            DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
            DataLabelsSize = 14,
            DataLabelsPosition = DataLabelsPosition.Middle
        },
        new StackedColumnSeries<int>
        {
            Values = new List<int> { -2, 6, 6, 5, 4, 3, -2 },
            Stroke = null,
            DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
            DataLabelsSize = 14,
            DataLabelsPosition = DataLabelsPosition.Middle
        }
    };
    #endregion

    #region [ Pie Chart ]

    [ObservableProperty]
    string pieChartTitle = "Pie Chart";

    [ObservableProperty]
    string pieChartXamlCode = @"
<Grid ColumnDefinitions=""*,*,*"">
    <lvc:PieChart
        Title=""{x:Binding PieChartVisualTitle}""
        HeightRequest=""300""
        HorizontalOptions=""Center""
        Series=""{Binding PieSeries}""
        WidthRequest=""300"" />
    <lvc:PieChart
        Title=""{x:Binding DoughnutPieChartVisualTitle}""
        Grid.Column=""1""
        HeightRequest=""300""
        Series=""{Binding PieSeries2}""
        WidthRequest=""300"" />
    <lvc:PieChart
        Title=""{x:Binding PushoutPieChartVisualTitle}""
        Grid.Column=""2""
        HeightRequest=""300""
        Series=""{Binding PieSeries3}""
        WidthRequest=""300"" />
</Grid>";

    [ObservableProperty]
    string pieChartCSharpCode = @"
// You can create pie series collections easily:
public IEnumerable<ISeries> PieSeries { get; set; } =
    new[] { 2, 4, 1, 4, 3 }.AsPieSeries();

// This collection allows customizing the series:
public IEnumerable<ISeries> PieSeries2 { get; set; } =
    new[] { 2, 4, 1, 4, 3 }.AsPieSeries((value, series) =>
    {
        series.MaxRadialColumnWidth = 60;
    });

// Here's another pie series with a push-out feature:
public IEnumerable<ISeries> PieSeries3 { get; set; } =
    new[] { 6, 5, 4, 3, 2 }.AsPieSeries((value, series) =>
    {
        // Pushes out the slice with the value of 6.
        if (value == 6)
        {
            series.Pushout = 30;
        }
    });

// Titles for the pie charts.
public LabelVisual PieChartVisualTitle { get; set; } =
    new LabelVisual
    {
        Text = ""My pie chart title"",
        TextSize = 25,
        Padding = new LiveChartsCore.Drawing.Padding(15),
        Paint = new SolidColorPaint(SKColors.DarkSlateGray)
    };

public LabelVisual DoughnutPieChartVisualTitle { get; set; } =
    new LabelVisual
    {
        Text = ""My doughnut chart title"",
        TextSize = 25,
        Padding = new LiveChartsCore.Drawing.Padding(15),
        Paint = new SolidColorPaint(SKColors.DarkSlateGray)
    };

public LabelVisual PushoutPieChartVisualTitle { get; set; } =
    new LabelVisual
    {
        Text = ""My push-out style chart title"",
        TextSize = 25,
        Padding = new LiveChartsCore.Drawing.Padding(15),
        Paint = new SolidColorPaint(SKColors.DarkSlateGray)
    };
";

    // you can convert any array, list or IEnumerable<T> to a pie series collection:
    public IEnumerable<ISeries> PieSeries { get; set; } =
        new[] { 2, 4, 1, 4, 3 }.AsPieSeries();

    // the expression above is equivalent to the next series collection:
    public IEnumerable<ISeries> PieSeries2 { get; set; } =
        new[] { 2, 4, 1, 4, 3 }.AsPieSeries((value, series) =>
        {
            series.MaxRadialColumnWidth = 60;
        });

    public IEnumerable<ISeries> PieSeries3 { get; set; } =
    new[] { 6, 5, 4, 3, 2 }.AsPieSeries((value, series) =>
    {
        // pushes out the slice with the value of 6 to 30 pixels.
        if (value != 6) return;

        series.Pushout = 30;
    });

    public LabelVisual PieChartVisualTitle { get; set; } =
        new LabelVisual
        {
            Text = "My pie chart title",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.White)
        };

    public LabelVisual DoughnutPieChartVisualTitle { get; set; } =
    new LabelVisual
    {
        Text = "My doughnut chart title",
        TextSize = 25,
        Padding = new LiveChartsCore.Drawing.Padding(15),
        Paint = new SolidColorPaint(SKColors.White)
    };
    public LabelVisual PushoutPieChartVisualTitle { get; set; } =
    new LabelVisual
    {
        Text = "My push out style chart title",
        TextSize = 25,
        Padding = new LiveChartsCore.Drawing.Padding(15),
        Paint = new SolidColorPaint(SKColors.White)
    };
    #endregion

    #region [ Radial Area ]

    [ObservableProperty]
    string radialAreaTitle = "Radial Area";

    public ISeries[] Series { get; set; } =
    {
        new PolarLineSeries<int>
        {
            Values = new[] { 7, 9, 2, 2, 9 },
            LineSmoothness = 0,
            GeometrySize= 0,
            Name = "C#",
            Fill = new SolidColorPaint(SKColors.Blue)
        },
        new PolarLineSeries<int>
        {
            Values = new[] { 5, 9, 8, 4, 3 },
            LineSmoothness = 0,
            GeometrySize = 0,
            Name = "Java",
            Fill = new SolidColorPaint(SKColors.Red)
        }
    };

    public PolarAxis[] AngleAxes { get; set; } =
    {
        new PolarAxis
        {
            LabelsRotation = LiveCharts.TangentAngle,
            Labels = new[] { "Desktop", "Web", "Mobile", "AL/ML", "Game" }
        }
    };
    [ObservableProperty]
    string radialAreaCSharpCode =
    "public ISeries[] Series { get; set; } =\r\n" +
    "{\r\n" +
    "    new PolarLineSeries<int>\r\n" +
    "    {\r\n" +
    "        Values = new[] { 7, 5, 7, 5, 6 },\r\n" +
    "        LineSmoothness = 0,\r\n" +
    "        GeometrySize= 0,\r\n" +
    "        Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(90))\r\n" +
    "    },\r\n" +
    "    new PolarLineSeries<int>\r\n" +
    "    {\r\n" +
    "        Values = new[] { 2, 7, 5, 9, 7 },\r\n" +
    "        LineSmoothness = 0,\r\n" +
    "        GeometrySize = 0,\r\n" +
    "        Fill = new SolidColorPaint(SKColors.Red.WithAlpha(90))\r\n" +
    "    }\r\n" +
    "};\r\n\r\n" +
    "public PolarAxis[] AngleAxes { get; set; } =\r\n" +
    "{\r\n" +
    "    new PolarAxis\r\n" +
    "    {\r\n" +
    "        LabelsRotation = LiveCharts.TangentAngle,\r\n" +
    "        Labels = new[] { \"Desktop\", \"Web\", \"Mobile\", \"AL/ML\", \"Game\" }\r\n" +
    "    }\r\n" +
    "};";

    [ObservableProperty]
    string radialAreaXamlCode =
    "<lvc:PolarChart\r\n" +
    "    AngleAxes=\"{Binding AngleAxes}\"\r\n" +
    "    HeightRequest=\"400\"\r\n" +
    "    InitialRotation=\"-45\"\r\n" +
    "    Series=\"{Binding Series}\" />";

    #endregion

    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    #endregion

    #region [ Methods ]

    void InitRacingBars()
    {

        // generate some paints for each pilot:
        var paints = Enumerable.Range(0, 7)
            .Select(i => new SolidColorPaint(ColorPalletes.MaterialDesign500[i].AsSKColor()))
            .ToArray();

        // generate some data for each pilot:
        _racingData = new PilotInfo[]
        {
            new("Tsunoda",   500,  paints[0]),
            new("Sainz",     450,  paints[1]),
            new("Riccardo",  520,  paints[2]),
            new("Bottas",    550,  paints[3]),
            new("Perez",     660,  paints[4]),
            new("Verstapen", 920,  paints[5]),
            new("Hamilton",  1000, paints[6])
        };

        var rowSeries = new RowSeries<PilotInfo>
        {
            Values = _racingData.OrderBy(x => x.Value).ToArray(),
            DataLabelsPaint = new SolidColorPaint(new SKColor(245, 245, 245)),
            DataLabelsPosition = DataLabelsPosition.End,
            DataLabelsTranslate = new(-1, 0),
            DataLabelsFormatter = point => $"{point.Model!.Name} {point.Coordinate.PrimaryValue}",
            MaxBarWidth = 50,
            Padding = 10,
        }.OnPointMeasured(point =>
        {
            // assign a different color to each point
            if (point.Visual is null) return;
            point.Visual.Fill = point.Model!.Paint;
        });

        RacingSeries = new[] { rowSeries };

        StartRace().FireAndForget();
    }

    async Task StartRace()
    {
        await Task.Delay(1000);


        while (IsReading)
        {
            // do a random change to the data
            foreach (var item in _racingData)
                item.Value += _r.Next(0, 100);

            RacingSeries[0].Values =
                _racingData.OrderBy(x => x.Value).ToArray();

            await Task.Delay(100);
        }
    }
    #endregion
}