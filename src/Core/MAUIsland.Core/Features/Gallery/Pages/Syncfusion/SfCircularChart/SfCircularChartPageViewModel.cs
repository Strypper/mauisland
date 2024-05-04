namespace MAUIsland.Core;
public partial class SfCircularChartPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public SfCircularChartPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    ObservableCollection<SfCircularChartMockData> mockData = default!;

    [ObservableProperty]
    string simplePieSeriesXamlCode = "<chart:SfCircularChart>\r\n                        <chart:PieSeries\r\n                            ItemsSource=\"{x:Binding MockData}\"\r\n                            XBindingPath=\"Product\"\r\n                            YBindingPath=\"SalesRate\" />\r\n                    </chart:SfCircularChart>";

    [ObservableProperty]
    string addTitleToPieSeriesXamlCode = "<chart:SfCircularChart>\r\n    <chart:SfCircularChart.Title>\r\n        <Label Text=\"PRODUCT SALES\"/>\r\n    </chart:SfCircularChart.Title>\r\n    . . .\r\n</chart:SfCircularChart>";

    [ObservableProperty]
    string enableDataLabelXamlCode = "<chart:SfCircularChart>\r\n    . . .\r\n    <chart:PieSeries ShowDataLabels=\"True\"/>\r\n</chart:SfCircularChart>";

    [ObservableProperty]
    string enableLegendXamlCode = "<chart:SfCircularChart>\r\n    . . .\r\n    <chart:SfCircularChart.Legend>\r\n    <chart:ChartLegend/>\r\n    </chart:SfCircularChart.Legend>\r\n</chart:SfCircularChart>";

    [ObservableProperty]
    string enableTooltipXamlCode = "<chart:SfCircularChart>\r\n    . . .\r\n    <chart:PieSeries EnableTooltip=\"True\"/>\r\n</chart:SfCircularChart>";

    [ObservableProperty]
    string doughnutChartXamlCode = "<chart:SfCircularChart>\r\n    <chart:DoughnutSeries ItemsSource=\"{Binding Data}\" \r\n                        XBindingPath=\"Product\" \r\n                        YBindingPath=\"SalesRate\" />\r\n</chart:SfCircularChart>";

    [ObservableProperty]
    string doughnutChartInnerRadiusXamlCode = "<chart:SfCircularChart>\r\n    <chart:DoughnutSeries ItemsSource=\"{Binding Data}\"\r\n\t\t\t\t\t\tInnerRadius=\"0.7\"\t\t  \r\n\t\t\t\t\t\tXBindingPath=\"Product\"\r\n\t\t\t\t\t\tYBindingPath=\"SalesRate\" />\r\n</chart:SfCircularChart>";

    [ObservableProperty]
    string semiDoughnutChartXamlCode = "<chart:SfCircularChart>\r\n    <chart:DoughnutSeries StartAngle=\"180\" EndAngle=\"360\"\r\n                    ItemsSource=\"{Binding Data}\"\r\n                    XBindingPath=\"Product\" \r\n                    YBindingPath=\"SalesRate\" />\r\n</chart:SfCircularChart>";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        MockData = new ObservableCollection<SfCircularChartMockData>()
        {
            new SfCircularChartMockData(){Product = "iPad", SalesRate = 25},
            new SfCircularChartMockData(){Product = "iPhone", SalesRate = 35},
            new SfCircularChartMockData(){Product = "MacBook", SalesRate = 15},
            new SfCircularChartMockData(){Product = "Mac", SalesRate = 5},
            new SfCircularChartMockData(){Product = "Others", SalesRate = 10},
        };
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}


public class SfCircularChartMockData
{
    public string Product { get; set; }
    public double SalesRate { get; set; }
}