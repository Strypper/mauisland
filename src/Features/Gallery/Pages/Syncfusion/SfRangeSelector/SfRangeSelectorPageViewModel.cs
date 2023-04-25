namespace MAUIsland;
public partial class SfRangeSelectorPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfRangeSelectorPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]

    [ObservableProperty]
    DateTime rangeStart = new(2005, 01, 01);

    [ObservableProperty]
    DateTime rangeEnd = new(2008, 01, 01);

    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<SfRangeSelectorDemoChart> source;

    [ObservableProperty]
    string simpleRangeSelectorXamlCode = "<sliders:SfRangeSelector />";

    [ObservableProperty]
    string contentRangeSelectorXamlCode = "<ContentPage \r\n             ...\r\n             xmlns:sliders=\"clr-namespace:Syncfusion.Maui.Sliders;assembly=Syncfusion.Maui.Sliders\"\r\n             xmlns:charts=\"clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts\"\r\n             xmlns:local=\"clr-namespace:SliderTestbedSample.RangeSelector\">\r\n    \r\n    <ContentPage.BindingContext>\r\n        <local:ViewModel />\r\n    </ContentPage.BindingContext>\r\n\r\n    <sliders:SfRangeSelector Minimum=\"10\"\r\n                             Maximum=\"20\"\r\n                             RangeStart=\"13\"\r\n                             RangeEnd=\"17\">\r\n        <charts:SfCartesianChart>\r\n\r\n            <charts:SfCartesianChart.XAxes>\r\n                <charts:DateTimeAxis IsVisible=\"False\"\r\n                                    ShowMajorGridLines=\"False\" />\r\n            </charts:SfCartesianChart.XAxes>\r\n\r\n            <charts:SfCartesianChart.YAxes>\r\n                <charts:NumericalAxis IsVisible=\"False\"\r\n                                     ShowMajorGridLines=\"False\" />\r\n            </charts:SfCartesianChart.YAxes>\r\n\r\n            <charts:SfCartesianChart.Series>\r\n                <charts:SplineAreaSeries ItemsSource=\"{Binding Source}\"\r\n                                        XBindingPath=\"X\"\r\n                                        YBindingPath=\"Y\">\r\n                </charts:SplineAreaSeries>\r\n\r\n            </charts:SfCartesianChart.Series>\r\n        \r\n        </charts:SfCartesianChart>\r\n    \r\n    </sliders:SfRangeSelector>\r\n</ContentPage>";

    [ObservableProperty]
    string contentRangeSelectorWithLabelXamlCode = "<ContentPage \r\n             ...\r\n             xmlns:sliders=\"clr-namespace:Syncfusion.Maui.Sliders;assembly=Syncfusion.Maui.Sliders\"\r\n             xmlns:charts=\"clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts\">\r\n\r\n    <sliders:SfRangeSelector Minimum=\"0\" \r\n                             Maximum=\"10\" \r\n                             RangeStart=\"2\" \r\n                             RangeEnd=\"8\"\r\n                             Interval=\"2\" \r\n                             ShowLabels=\"True\">\r\n\r\n        <charts:SfCartesianChart>\r\n            ...\r\n        </charts:SfCartesianChart>\r\n\r\n    </sliders:SfRangeSelector>\r\n</ContentPage>";

    [ObservableProperty]
    string contentRangeSelectorWithTickXamlCode = "<ContentPage \r\n             ...\r\n             xmlns:sliders=\"clr-namespace:Syncfusion.Maui.Sliders;assembly=Syncfusion.Maui.Sliders\"\r\n             xmlns:charts=\"clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts\">\r\n    \r\n    <sliders:SfRangeSelector Minimum=\"0\" \r\n                             Maximum=\"10\" \r\n                             RangeStart=\"2\" \r\n                             RangeEnd=\"8\"                       \r\n                             Interval=\"2\" \r\n                             ShowLabels=\"True\"\r\n                             ShowTicks=\"True\" \r\n                             MinorTicksPerInterval=\"1\">\r\n        \r\n        <charts:SfCartesianChart>\r\n            ...\r\n        </charts:SfCartesianChart>\r\n    \r\n    </sliders:SfRangeSelector>\r\n</ContentPage>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

        Source = new ObservableCollection<SfRangeSelectorDemoChart>
            {
                new SfRangeSelectorDemoChart(new DateTime(2002, 01, 01), 2.2),
                new SfRangeSelectorDemoChart(new DateTime(2003, 01, 01), 3.4),
                new SfRangeSelectorDemoChart(new DateTime(2004, 01, 01), 2.8),
                new SfRangeSelectorDemoChart(new DateTime(2005, 01, 01), 1.6),
                new SfRangeSelectorDemoChart(new DateTime(2006, 01, 01), 2.3),
                new SfRangeSelectorDemoChart(new DateTime(2007, 01, 01), 2.5),
                new SfRangeSelectorDemoChart(new DateTime(2008, 01, 01), 2.9),
                new SfRangeSelectorDemoChart(new DateTime(2009, 01, 01), 3.8),
                new SfRangeSelectorDemoChart(new DateTime(2010, 01, 01), 1.4),
                new SfRangeSelectorDemoChart(new DateTime(2011, 01, 01), 3.1),
            };

    }
    #endregion
}

public class SfRangeSelectorDemoChart
{
    public DateTime X { get; set; }
    public double Y { get; set; }

    public SfRangeSelectorDemoChart(DateTime date, double value)
    {
        X = date;
        Y = value;
    }
}