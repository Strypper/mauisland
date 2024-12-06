using Syncfusion.Maui.Data;
using Syncfusion.Maui.Toolkit.Charts;
using System.Diagnostics.Metrics;

namespace MAUIsland.Core;
public partial class SfCartesianChartPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public SfCartesianChartPageViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation = default!;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> crossingAxis;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> annotation;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> area;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> rangeArea;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> stackingArea;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> bar;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> rangeBar;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> stackingBar;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> column;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> rangeColumn;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> stackingColumn;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> firstLine;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> secondLine;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> thirdLine;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> fastLine;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> firstScatter;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> secondScatter;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> bubble;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> box;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> histogram;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> financial;

    [ObservableProperty]
    ObservableCollection<SfCartesianChartModel> waterfall;

    [ObservableProperty]
    ObservableCollection<string> chartOptions;

    [ObservableProperty]
    ObservableCollection<string> areaChartOptions;

    [ObservableProperty]
    ObservableCollection<string> barChartOptions;

    [ObservableProperty]
    ObservableCollection<string> columnChartOptions;

    [ObservableProperty]
    ObservableCollection<string> lineChartOptions;

    [ObservableProperty]
    ObservableCollection<string> scatterChartOptions;

    [ObservableProperty]
    ObservableCollection<string> histogramChartOptions;

    [ObservableProperty]
    ObservableCollection<string> boxPlotChartOptions;

    [ObservableProperty]
    ObservableCollection<string> bubbleChartOptions;

    [ObservableProperty]
    ObservableCollection<string> financialChartOptions;

    [ObservableProperty]
    ObservableCollection<string> waterfallChartOptions;

    [ObservableProperty]
    ObservableCollection<string> errorBarTypes;

    [ObservableProperty]
    ObservableCollection<string> errorBarModes;

    [ObservableProperty]
    ObservableCollection<string> errorBarDirections;

    [ObservableProperty]
    string chartsSelectedOption;

    [ObservableProperty]
    string areaSelectedOption;

    [ObservableProperty]
    string columnBarSelectedOption;

    [ObservableProperty]
    string lineSelectedOption;

    [ObservableProperty]
    string scatterSelectedOption;

    [ObservableProperty]
    string histogramSelectedOption;

    [ObservableProperty]
    string boxPlotSelectedOption;

    [ObservableProperty]
    string bubbleSelectedOption;

    [ObservableProperty]
    string financialSelectedOption;

    [ObservableProperty]
    string waterfallSelectedOption;

    [ObservableProperty]
    ControlGroupInfo controlGroup;

    [ObservableProperty]
    List<Brush> coldPalletBrushes;

    [ObservableProperty]
    List<Brush> rainbowPalletBrushes;

    [ObservableProperty]
    bool isRefreshing;

    #region [ String Properties ]
    [ObservableProperty]
    string xamlNamespace =
        "xmlns:toolkit=\"http://schemas.syncfusion.com/maui/toolkit\"";

    [ObservableProperty]
    string cartesianCategoryAxisXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Category Axis Column Sample Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis IsVisible=\"False\" ShowMajorGridLines=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries ShowDataLabels=\"True\" EnableAnimation=\"True\" \r\n" +
        "                              ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Value\">\r\n" +
        "            <toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings LabelPlacement=\"Inner\">\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianNumericalAxisXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Numerical Axis Column Sample Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Center\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"CenterAndExpand\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:NumericalAxis Interval=\"1\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" Minimum=\"0\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries ShowDataLabels=\"True\" EnableAnimation=\"True\" Label=\"Data 1\" Spacing=\"0.075\" \r\n" +
        "                                ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\" \r\n" +
        "                                XBindingPath=\"Number\" YBindingPath=\"Exp\">\r\n" +
        "            <toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings>\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle Margin=\"0\" FontSize=\"10\"/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "        <toolkit:ColumnSeries ShowDataLabels=\"True\" EnableAnimation=\"True\" Label=\"Data 2\" Spacing=\"0.075\" \r\n" +
        "                                ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\" \r\n" +
        "                                XBindingPath=\"Number\" YBindingPath=\"Exp\">\r\n" +
        "            <toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings>\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle Margin=\"0\" FontSize=\"10\"/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianDateTimeAxisXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"DateTime Axis Line Sample Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis EdgeLabelsDrawingMode=\"Shift\" ZoomFactor=\"0.7\" ZoomPosition=\"0.4\" >\r\n" +
        "            <toolkit:DateTimeAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"DateTime Axis\"/>\r\n" +
        "            </toolkit:DateTimeAxis.Title>\r\n" +
        "        </toolkit:DateTimeAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis>\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Numerical Axis\"/>\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior x:Name=\"zooming1\" EnablePinchZooming=\"False\" EnableDoubleTap=\"False\" EnablePanning=\"False\" ZoomMode=\"X\" />\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:FastLineSeries EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                                ItemsSource=\"{x:Binding FastLine}\" \r\n" +
        "                                XBindingPath=\"Date\" YBindingPath=\"Value\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianMultipleAxesXamlCode =
        "<toolkit:SfCartesianChart>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\"/>\r\n" +
        "        <toolkit:NumericalAxis Name=\"ColumnYAxis2\" CrossesAt=\"{Static x:Double.MaxValue}\" ShowMajorGridLines=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:ColumnSeries ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                          XBindingPath=\"Name\" YBindingPath=\"Value\" YAxisName=\"ColumnYAxis2\"/>\r\n" +
        "    <toolkit:SplineSeries ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                          XBindingPath=\"Name\" YBindingPath=\"Exp\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianCrossingAxisXamlCode =
        "<toolkit:SfCartesianChart x:Name=\"axisCrossingChart\">\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:NumericalAxis CrossesAt=\"0\" Minimum=\"-10\" Maximum=\"10\" \r\n" +
        "                               EdgeLabelsDrawingMode=\"Shift\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis CrossesAt=\"0\" Minimum=\"-10\" Maximum=\"10\"  \r\n" +
        "                               EdgeLabelsDrawingMode=\"Shift\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:SplineSeries ItemsSource=\"{x:Binding CrossingAxis}\" \r\n" +
        "                              XBindingPath=\"Value\" YBindingPath=\"Size\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAnnotationXamlCode =
        "<toolkit:SfCartesianChart VerticalOptions=\"FillAndExpand\" Margin=\"0,0,5,0\" x:Name=\"Chart\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Annotations Demo\" Margin=\"0,2,0,10\"\r\n" +
        "               HorizontalOptions=\"Center\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"CenterAndExpand\"\r\n" +
        "               FontSize=\"16\" LineBreakMode=\"WordWrap\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"4\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"20\" Maximum=\"70\" Interval=\"10\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Annotations>\r\n" +
        "        <toolkit:VerticalLineAnnotation X1=\"2\" LineCap=\"Arrow\" Text=\"Vertical Line\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:VerticalLineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle VerticalTextAlignment=\"Start\" HorizontalTextAlignment=\"Start\" FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:VerticalLineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:VerticalLineAnnotation>\r\n\r\n" +
        "        <toolkit:HorizontalLineAnnotation Y1=\"45\" LineCap=\"Arrow\" Text=\"Horizontal Line\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle VerticalTextAlignment=\"Start\" HorizontalTextAlignment=\"End\" FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:HorizontalLineAnnotation>\r\n\r\n" +
        "        <toolkit:LineAnnotation X1=\"2.5\" X2=\"3.5\" Y1=\"52\" Y2=\"63\" LineCap=\"Arrow\" Text=\"Random Line\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:LineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:LineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:LineAnnotation>\r\n\r\n" +
        "        <toolkit:RectangleAnnotation X1=\"0.5\" X2=\"1.5\" Y1=\"25\" Y2=\"35\" Text=\"Rectangle\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:RectangleAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:RectangleAnnotation.LabelStyle>\r\n" +
        "        </toolkit:RectangleAnnotation>\r\n\r\n" +
        "        <toolkit:EllipseAnnotation X1=\"2.5\" X2=\"3.5\" Y1=\"25\" Y2=\"35\" Text=\"Ellipse\" HorizontalAlignment=\"End\" VerticalAlignment=\"End\" Stroke=\"Orange\">\r\n" +
        "            <toolkit:EllipseAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:EllipseAnnotation.LabelStyle>\r\n" +
        "        </toolkit:EllipseAnnotation>\r\n\r\n" +
        "        <toolkit:TextAnnotation X1=\"1\" Y1=\"57.5\" Text=\"Text Annotation\">\r\n" +
        "            <toolkit:TextAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle FontAttributes=\"Bold\" FontSize=\"13\" TextColor=\"Orange\"/>\r\n" +
        "            </toolkit:TextAnnotation.LabelStyle>\r\n" +
        "        </toolkit:TextAnnotation>\r\n\r\n" +
        "        <toolkit:ViewAnnotation X1=\"2.15\" Y1=\"35\">\r\n" +
        "            <toolkit:ViewAnnotation.View>\r\n" +
        "                <Image>\r\n" +
        "                    <Image.Source>\r\n" +
        "                        <FontImageSource Glyph=\"{x:Static core:FluentUIIcon.Ic_fluent_data_histogram_24_regular}\" \r\n" +
        "                                            FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\" \r\n" +
        "                                            Size =\"50\"\r\n" +
        "                                            Color=\"Orange\"/>\r\n" +
        "                    </Image.Source>\r\n" +
        "                </Image>\r\n" +
        "            </toolkit:ViewAnnotation.View>\r\n" +
        "        </toolkit:ViewAnnotation>\r\n" +
        "    </toolkit:SfCartesianChart.Annotations>\r\n\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Value Comparison\" FontSize=\"16\" \r\n" +
        "               HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Fill\"  VerticalOptions=\"Center\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"5\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"6\" Interval=\"1\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Value in Millions\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'M\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:AreaSeries Label=\"Product A\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            StrokeWidth=\"1\" LegendIcon=\"SeriesType\" \r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"High\" />\r\n" +
        "        <toolkit:AreaSeries Label=\"Product B\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            StrokeWidth=\"1\" LegendIcon=\"SeriesType\" \r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Low\" />\r\n" +
        "        <toolkit:AreaSeries Label=\"Product C\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            StrokeWidth=\"1\" LegendIcon=\"SeriesType\"\r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Value\" />\r\n" +
        "        <toolkit:AreaSeries Label=\"Product D\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                            StrokeWidth=\"1\" LegendIcon=\"SeriesType\"\r\n" +
        "                            ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Size\" />\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianSplineAreaChartXamlCode =

        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Value Comparison\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\" ShowMajorGridLines=\"false\">\r\n" +
        "           <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"5\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"6\" Interval=\"1\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Value in Millions\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'M\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product A\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                  ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"High\"\r\n" +
        "                                  LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product B\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                  ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Low\"\r\n" +
        "                                  LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product C\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                  ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                  LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:SplineAreaSeries Label=\"Product D\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                  ItemsSource=\"{Binding Area}\" XBindingPath=\"Name\" YBindingPath=\"Size\"\r\n" +
        "                                  LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStepAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Step Area Chart\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"5\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"6\" Interval=\"1\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Value in Millions\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'M\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StepAreaSeries Label=\"Product A\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                ItemsSource=\"{Binding Area}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"High\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:StepAreaSeries Label=\"Product B\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                ItemsSource=\"{Binding Area}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Low\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:StepAreaSeries Label=\"Product C\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                ItemsSource=\"{Binding Area}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:StepAreaSeries Label=\"Product D\" EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\"\r\n" +
        "                                ItemsSource=\"{Binding Area}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Size\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRangeAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnablePinchZooming=\"False\" EnableDoubleTap=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Range Area Chart\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis Interval=\"5\" ShowMajorGridLines=\"false\" AutoScrollingMode=\"Start\" AutoScrollingDeltaType=\"Days\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" Minimum=\"0\" Maximum=\"50\" Interval=\"10\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;C\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:RangeAreaSeries ItemsSource=\"{Binding RangeArea}\" \r\n" +
        "                                 XBindingPath=\"Date\" High=\"High\" Low=\"Low\" LegendIcon=\"SeriesType\"\r\n" +
        "                                 EnableAnimation=\"True\" EnableTooltip=\"True\" StrokeWidth=\"1\" />\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>" + "";

    [ObservableProperty]
    string cartesianSplineRangeAreaChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnablePinchZooming=\"False\" EnableDoubleTap=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Spline Range Area Chart\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis Interval=\"5\" ShowMajorGridLines=\"false\" AutoScrollingMode=\"Start\" AutoScrollingDeltaType=\"Days\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" Minimum=\"0\" Maximum=\"50\" Interval=\"10\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;c\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SplineRangeAreaSeries ItemsSource=\"{x:Binding RangeArea}\" \r\n" +
        "                                   XBindingPath=\"Date\" High=\"High\" Low=\"Low\" LegendIcon=\"SeriesType\"\r\n" +
        "                                   EnableAnimation=\"True\" EnableTooltip=\"True\" ShowTrackballLabel=\"True\" StrokeWidth=\"1\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingAreaChartXamlCode = 
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Area Chart\" LineBreakMode=\"WordWrap\" Margin=\"2,0,2,0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis IsVisible=\"True\" ShowMajorGridLines=\"False\" Interval=\"2\" EdgeLabelsDrawingMode=\"Shift\" PlotOffsetEnd=\"5\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"7\" Interval=\"1\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'B\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\"\r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"High\"\r\n" +
        "                                Label=\"Organic\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\"\r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"Low\"\r\n" +
        "                                Label=\"Fairtrade\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"Value\"\r\n" +
        "                                Label=\"Veg Alternatives\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "    <toolkit:StackingAreaSeries ItemsSource=\"{x:Binding StackingArea}\"\r\n" +
        "                                XBindingPath=\"Year\" YBindingPath=\"Size\"\r\n" +
        "                                Label=\"Others\" LegendIcon=\"SeriesType\" EnableAnimation=\"True\"\r\n" +
        "                                EnableTooltip=\"True\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingArea100ChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"StackingArea100 Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis IsVisible=\"True\" ShowMajorGridLines=\"False\" Interval=\"2\" EdgeLabelsDrawingMode=\"Shift\">\r\n" +
        "            <toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle/>\r\n" +
        "            </toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"100\" Interval=\"20\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"False\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                   XBindingPath=\"Year\" YBindingPath=\"High\"\r\n" +
        "                                   Label=\"Product 1\" LegendIcon=\"SeriesType\"\r\n" +
        "                                   EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                   XBindingPath=\"Year\" YBindingPath=\"Low\" \r\n" +
        "                                   Label=\"Product 2\" LegendIcon=\"SeriesType\"\r\n" +
        "                                   EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                   XBindingPath=\"Year\" YBindingPath=\"Value\" \r\n" +
        "                                   Label=\"Product 3\" LegendIcon=\"SeriesType\"\r\n" +
        "                                   EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "    <toolkit:StackingArea100Series ItemsSource=\"{x:Binding StackingArea}\" \r\n" +
        "                                   XBindingPath=\"Year\" YBindingPath=\"Size\" \r\n" +
        "                                   Label=\"Product 4\" LegendIcon=\"SeriesType\"\r\n" +
        "                                   EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Bar Chart\" LineBreakMode=\"WordWrap\" Margin=\"2,0,2,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"false\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Interval=\"10\" IsVisible=\"False\" EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"8\">\r\n" +
        "                </toolkit:ChartAxisTickStyle>\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\" ItemsSource=\"{x:Binding Bar}\" XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings LabelPlacement=\"Inner\">\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle LabelFormat=\"0.## Exp\"/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianCustomBarChartCSharpCode = 
        "using Syncfusion.Maui.Toolkit.Charts;\r\n\r\n" +
        "public class CustomBarChart : ColumnSeries\r\n" +
        "{\r\n" +
        "    protected override ChartSegment CreateSegment()\r\n" +
        "    {\r\n" +
        "        return new BarSegment();\r\n" +
        "    }\r\n\r\n" +
        "    public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(\r\n" +
        "        nameof(TrackColor), \r\n" +
        "        typeof(SolidColorBrush), \r\n" +
        "        typeof(ColumnSeries), \r\n" +
        "        new SolidColorBrush(Color.FromArgb(\"#E7E0EC\"))\r\n" +
        "    );\r\n\r\n" +
        "    public SolidColorBrush TrackColor\r\n" +
        "    {\r\n" +
        "        get { return (SolidColorBrush)GetValue(TrackColorProperty); }\r\n" +
        "        set { SetValue(TrackColorProperty, value); }\r\n" +
        "    }\r\n" +
        "}\r\n\r\n" +
        "public class BarSegment : ColumnSegment\r\n" +
        "{\r\n" +
        "    RectF trackRect = RectF.Zero;\r\n\r\n" +
        "    protected override void OnLayout()\r\n" +
        "    {\r\n" +
        "        base.OnLayout();\r\n" +
        "        if (Series is CartesianSeries series && series.ActualYAxis is NumericalAxis yAxis)\r\n" +
        "        {\r\n" +
        "            var top = yAxis.ValueToPoint(Convert.ToDouble(yAxis.Maximum ?? double.NaN));\r\n" +
        "            trackRect = new RectF() { Left = Left, Top = Top, Right = top, Bottom = Bottom };\r\n" +
        "        }\r\n" +
        "    }\r\n\r\n" +
        "    protected override void Draw(ICanvas canvas)\r\n" +
        "    {\r\n" +
        "        if (Series is not CustomBarChart series) return;\r\n\r\n" +
        "        canvas.SetFillPaint(series.TrackColor, trackRect);\r\n" +
        "        canvas.FillRoundedRectangle(trackRect, 25);\r\n\r\n" +
        "        base.Draw(canvas);\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string cartesianCustomBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Custom Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:CategoryAxis.AxisLineStyle>\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" ShowMajorGridLines=\"False\" IsVisible=\"False\" EdgeLabelsDrawingMode=\"Shift\" ShowMinorGridLines=\"false\">\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <core:CustomBarChart ShowDataLabels=\"True\" Width=\"0.5\" \r\n" +
        "                             EnableAnimation=\"True\" CornerRadius=\"25\"  \r\n" +
        "                             ItemsSource=\"{x:Binding Bar}\" \r\n" +
        "                             XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <core:CustomBarChart.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"True\" LabelPlacement=\"Inner\">\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle LabelFormat=\"#.##\" />\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </core:CustomBarChart.DataLabelSettings>\r\n" +
        "        </core:CustomBarChart>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianDoubleBarChartXamlCode = 
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Double Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\">\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Food\" />\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis IsVisible=\"false\" EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"8\">\r\n" +
        "                </toolkit:ChartAxisTickStyle>\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Imports\" Width=\"0.8\" EnableTooltip=\"True\" Spacing=\"0.1\" \r\n" +
        "                              ItemsSource=\"{x:Binding Bar}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Exp\" EnableAnimation=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Exports\" Width=\"0.8\" EnableTooltip=\"True\" Spacing=\"0.1\" \r\n" +
        "                              ItemsSource=\"{x:Binding Bar}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Exp\" EnableAnimation=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianErrorBarChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\" >\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Error Bar Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\" >\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"10\"/>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" Minimum=\"0\" Maximum=\"120\" >\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries ItemsSource=\"{x:Binding Bar}\"   \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Exp\" Fill=\"#95DB9C\"/>\r\n" +
        "        <toolkit:ErrorBarSeries ItemsSource=\"{x:Binding Bar}\"  \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Exp\"  \r\n" +
        "                                Mode=\"Vertical\" Type=\"Custom\" VerticalDirection=\"Both\"\r\n" +
        "                                HorizontalErrorPath=\"Low\" VerticalErrorPath=\"High\"\r\n" +
        "                                HorizontalErrorValue=\"1\" VerticalErrorValue=\"25\">\r\n" +
        "            <toolkit:ErrorBarSeries.VerticalLineStyle>\r\n" +
        "                <toolkit:ErrorBarLineStyle StrokeWidth=\"2\" Stroke=\"Red\"/>\r\n" +
        "            </toolkit:ErrorBarSeries.VerticalLineStyle>\r\n" +
        "            <toolkit:ErrorBarSeries.VerticalCapLineStyle>\r\n" +
        "                <toolkit:ErrorBarCapLineStyle StrokeWidth=\"2\" Stroke=\"Red\"/>\r\n" +
        "            </toolkit:ErrorBarSeries.VerticalCapLineStyle>\r\n" +
        "        </toolkit:ErrorBarSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianCustomErrorBarChartXamlCode =
    "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
    "                            Margin=\"0, 0, 20, 0\">\r\n" +
    "    <toolkit:SfCartesianChart.Title>\r\n" +
    "        <Label Text=\"Custom Error Bar Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
    "    </toolkit:SfCartesianChart.Title>\r\n" +
    "    <toolkit:SfCartesianChart.XAxes >\r\n" +
    "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" EdgeLabelsDrawingMode=\"Shift\" Interval=\"1\"  >\r\n" +
    "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
    "                <toolkit:ChartAxisTickStyle TickSize=\"10\"/>\r\n" +
    "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
    "        </toolkit:CategoryAxis>\r\n" +
    "    </toolkit:SfCartesianChart.XAxes>\r\n" +
    "    <toolkit:SfCartesianChart.YAxes>\r\n" +
    "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\"/>\r\n" +
    "    </toolkit:SfCartesianChart.YAxes>\r\n" +
    "    <toolkit:SfCartesianChart.Series>\r\n" +
    "        <toolkit:ScatterSeries ItemsSource=\"{x:Binding Bar}\" \r\n" +
    "                                XBindingPath=\"Name\" YBindingPath=\"Exp\" PointHeight=\"10\" PointWidth=\"10\"/>\r\n" +
    "        <toolkit:ErrorBarSeries x:Name=\"CustomErrorSeries\" ItemsSource=\"{x:Binding Bar}\" \r\n" +
    "                                XBindingPath=\"Name\" YBindingPath=\"Exp\"   \r\n" +
    "                                HorizontalErrorValue=\"1\" VerticalErrorValue=\"10\" \r\n" +
    "                                Type=\"Fixed\" Mode=\"Vertical\"\r\n" +
    "                                HorizontalDirection=\"Both\" VerticalDirection=\"Both\">\r\n" +
    "            <toolkit:ErrorBarSeries.VerticalLineStyle>\r\n" +
    "                <toolkit:ErrorBarLineStyle StrokeWidth=\"2\" Stroke=\"Red\"/>\r\n" +
    "            </toolkit:ErrorBarSeries.VerticalLineStyle>\r\n" +
    "            <toolkit:ErrorBarSeries.HorizontalLineStyle>\r\n" +
    "                <toolkit:ErrorBarLineStyle StrokeWidth=\"2\" Stroke=\"Red\"/>\r\n" +
    "            </toolkit:ErrorBarSeries.HorizontalLineStyle>\r\n" +
    "            <toolkit:ErrorBarSeries.VerticalCapLineStyle>\r\n" +
    "                <toolkit:ErrorBarCapLineStyle StrokeWidth=\"2\" Stroke=\"Red\"/>\r\n" +
    "            </toolkit:ErrorBarSeries.VerticalCapLineStyle>\r\n" +
    "            <toolkit:ErrorBarSeries.HorizontalCapLineStyle>\r\n" +
    "                <toolkit:ErrorBarCapLineStyle StrokeWidth=\"2\" Stroke=\"Red\"/>\r\n" +
    "            </toolkit:ErrorBarSeries.HorizontalCapLineStyle>\r\n" +
    "        </toolkit:ErrorBarSeries>\r\n" +
    "        <toolkit:ScatterSeries ItemsSource=\"{x:Binding Bar}\" \r\n" +
    "                                XBindingPath=\"Name\" YBindingPath=\"Exp\" PointHeight=\"10\" PointWidth=\"10\"/>\r\n" +
    "    </toolkit:SfCartesianChart.Series>\r\n" +
    "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRangeBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\" HeightRequest=\"500\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Range Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnableDoubleTap=\"False\" EnablePinchZooming=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis Interval=\"1\" EdgeLabelsDrawingMode=\"Shift\" LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"False\" AutoScrollingMode=\"End\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" EdgeLabelsDrawingMode=\"Shift\" ShowMajorGridLines=\"false\" ShowMinorGridLines=\"false\" Interval=\"5\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;C\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:RangeColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\"\r\n" +
        "                               ItemsSource=\"{x:Binding RangeBar}\"\r\n" +
        "                               XBindingPath=\"Name\" High=\"High\" Low=\"Low\">\r\n" +
        "        <toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "            <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"False\">\r\n" +
        "                <toolkit:CartesianDataLabelSettings.LabelStyle >\r\n" +
        "                    <toolkit:ChartDataLabelStyle TextColor=\"White\" LabelFormat= \"0.#&#186;C\" />\r\n" +
        "                </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "            </toolkit:CartesianDataLabelSettings>\r\n" +
        "        </toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "    </toolkit:RangeColumnSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingBarChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Bar Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" >\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Product\"/>\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"-20\" Maximum=\"48\" Interval=\"10\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle  LabelFormat=\"$###,##0.##K\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"High\"\r\n" +
        "                                  Label=\"Zone 1\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                  ItemsSource=\"{x:Binding StackingBar}\" />\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"Low\" \r\n" +
        "                                  Label=\"Zone 2\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                  ItemsSource=\"{x:Binding StackingBar}\" />\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                  Label=\"Zone 3\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                  ItemsSource=\"{x:Binding StackingBar}\" />\r\n" +
        "    <toolkit:StackingColumnSeries XBindingPath=\"Name\" YBindingPath=\"Size\"\r\n" +
        "                                  Label=\"Zone 4\" EnableTooltip=\"True\" LegendIcon=\"SeriesType\"\r\n" +
        "                                  ItemsSource=\"{x:Binding StackingBar}\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingBar100ChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" IsTransposed=\"True\" \r\n" +
        "                        Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Bar 100 Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Interval=\"20\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"True\" RangePadding=\"None\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 1\" LegendIcon=\"Rectangle\"\r\n" +
        "                                         ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                         XBindingPath=\"Name\" YBindingPath=\"High\" \r\n" +
        "                                         EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 2\" LegendIcon=\"Rectangle\"\r\n" +
        "                                         ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                         XBindingPath=\"Name\" YBindingPath=\"Low\" \r\n" +
        "                                         EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 3\" LegendIcon=\"Rectangle\"\r\n" +
        "                                         ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                         XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                         EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 4\" LegendIcon=\"Rectangle\"\r\n" +
        "                                         ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                         XBindingPath=\"Name\" YBindingPath=\"Size\" \r\n" +
        "                                         EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" >\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0 Exp\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle Stroke=\"Transparent\" StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\"  \r\n" +
        "                              ItemsSource=\"{x:Binding ComponentData,Source={x:Reference root}}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings >\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle FontSize=\"12\" LabelFormat='0 Exp'/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:ColumnSeries.DataLabelSettings>\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianTripleColumnChartXamlCode =
        "<toolkit:SfCartesianChart x:Name=\"Chart2\" PaletteBrushes=\"{Binding OlympicColorModel}\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\" />\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" LabelPlacement=\"BetweenTicks\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" Minimum=\"0\">\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Aqua\" EnableTooltip=\"True\" EnableAnimation=\"True\" Width=\"0.8\" Spacing=\"0.2\" \r\n" +
        "                              ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Exp\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Gray\" EnableTooltip=\"True\" EnableAnimation=\"True\" Width=\"0.8\" Spacing=\"0.2\" \r\n" +
        "                              ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Value\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:ColumnSeries Label=\"Blue\" EnableTooltip=\"True\" EnableAnimation=\"True\" Width=\"0.8\" Spacing=\"0.2\" \r\n" +
        "                              ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                              XBindingPath=\"Name\" YBindingPath=\"Size\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRoundedColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                            Margin=\"20, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Column Chart with Rounded Conner\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis IsVisible=\"False\" Minimum=\"0\" Maximum=\"120\" Interval=\"20\" ShowMajorGridLines=\"True\" >\r\n" +
        "            <toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"10\" StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:NumericalAxis.MinorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ColumnSeries EnableAnimation=\"True\" EnableTooltip=\"True\" CornerRadius=\"10\" \r\n" +
        "                              ItemsSource=\"{x:Binding Column}\" XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "        </toolkit:ColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "    <toolkit:SfCartesianChart.Annotations>\r\n" +
        "        <toolkit:HorizontalLineAnnotation Y1=\"90\" Stroke=\"#E75A6E\" StrokeWidth=\"2\" StrokeDashArray=\"15, 6, 5, 3\" Text=\"Overflow\">\r\n" +
        "            <toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "                <toolkit:ChartAnnotationLabelStyle TextColor=\"#E75A6E\" HorizontalTextAlignment=\"Start\" VerticalTextAlignment=\"Start\" FontSize=\"15\"/>\r\n" +
        "            </toolkit:HorizontalLineAnnotation.LabelStyle>\r\n" +
        "        </toolkit:HorizontalLineAnnotation>\r\n" +
        "    </toolkit:SfCartesianChart.Annotations>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianCustomColumnChartCSharpCode =
        "public class CustomColumnSeries : ColumnSeries\r\n" +
        "{\r\n" +
        "    protected override ChartSegment CreateSegment()\r\n" +
        "    {\r\n" +
        "        return new CustomColumnSegment();\r\n" +
        "    }\r\n\r\n" +
        "    public static readonly BindableProperty TrackColorProperty =BindableProperty.Create(\r\n" +
        "        nameof(TrackColor), \r\n" +
        "        typeof(SolidColorBrush), \r\n" +
        "        typeof(CustomColumnSeries), \r\n" +
        "        new SolidColorBrush(Color.FromArgb(\"#E7E0EC\"))\r\n" +
        "    );\r\n\r\n" +
        "    public SolidColorBrush TrackColor\r\n" +
        "    {\r\n" +
        "        get { return (SolidColorBrush)GetValue(TrackColorProperty); }\r\n" +
        "        set { SetValue(TrackColorProperty, value); }\r\n" +
        "    }\r\n\r\n" +
        "    protected override void DrawDataLabel(ICanvas canvas, Brush? fillcolor, string label, PointF point, int index)\r\n" +
        "    {\r\n" +
        "        var items = ItemsSource as ObservableCollection<SfCartesianChartModel>;\r\n" +
        "        if (items != null)\r\n" +
        "        {\r\n" +
        "            var text = items[index].Name ?? \"\";\r\n" +
        "            base.DrawDataLabel(canvas, new SolidColorBrush(Colors.Transparent), label, point, index);\r\n" +
        "            base.DrawDataLabel(canvas, new SolidColorBrush(Colors.Transparent), text, new PointF(point.X, point.Y - 30), index);\r\n" +
        "        }\r\n" +
        "    }\r\n}\r\n\r\n" +
        "public class CustomColumnSegment : ColumnSegment\r\n" +
        "{\r\n" +
        "    float curveHeight;\r\n" +
        "    float curveXGape = 30;\r\n" +
        "    float curveYGape = 20;\r\n\r\n" +
        "    protected override void Draw(ICanvas canvas)\r\n" +
        "    {\r\n" +
        "        base.Draw(canvas);\r\n\r\n" +
        "        if (Series is CartesianSeries series && series.ActualYAxis is NumericalAxis yAxis)\r\n" +
        "        {\r\n" +
        "            var top = yAxis.ValueToPoint(Convert.ToDouble(yAxis.Maximum ?? double.NaN));\r\n\r\n" +
        "            var trackRect = new RectF() { Left = Left, Top = top, Right = Right, Bottom = Bottom };\r\n" +
        "            curveHeight = trackRect.Height / curveYGape;\r\n" +
        "            var width = trackRect.Width + (float)Math.Sqrt((trackRect.Width * trackRect.Width) + (trackRect.Height * trackRect.Height));\r\n" +
        "            var waveLeft = trackRect.Left;\r\n" +
        "            var waveRight = waveLeft + width;\r\n" +
        "            var waveTop = trackRect.Bottom;\r\n" +
        "            var waveBottom = trackRect.Bottom + trackRect.Height;\r\n\r\n" +
        "            var waveRect = new Rect() { Left = waveLeft, Top = waveTop, Right = waveRight, Bottom = waveBottom };\r\n\r\n" +
        "            float freq = trackRect.Bottom - Top;\r\n\r\n" +
        "            canvas.CanvasSaveState();\r\n\r\n" +
        "            DrawTrackPath(canvas, trackRect);\r\n\r\n" +
        "            var color = (Fill is SolidColorBrush brush) ? brush.Color : Colors.Transparent;\r\n\r\n" +
        "            canvas.SetFillPaint(new SolidColorBrush(color.MultiplyAlpha(0.6f)), waveRect);\r\n" +
        "            DrawWave(canvas, new Rect(new Point(waveLeft - curveXGape - freq, waveTop - freq), waveRect.Size));\r\n\r\n" +
        "            canvas.SetFillPaint(Fill, waveRect);\r\n" +
        "            DrawWave(canvas, new Rect(new Point(waveLeft - freq, waveTop - freq), waveRect.Size));\r\n\r\n" +
        "            canvas.CanvasRestoreState();\r\n" +
        "        }\r\n" +
        "    }\r\n\r\n" +
        "    private void DrawTrackPath(ICanvas canvas, RectF trackRect)\r\n" +
        "    {\r\n" +
        "        if (Series is not CustomColumnSeries series) return;\r\n" +
        "        PathF path = new();\r\n" +
        "        path.MoveTo(trackRect.Left, trackRect.Bottom);\r\n" +
        "        path.LineTo(trackRect.Left, trackRect.Top);\r\n" +
        "        path.LineTo(trackRect.Right, trackRect.Top);\r\n" +
        "        path.LineTo(trackRect.Right, trackRect.Bottom);\r\n\r\n" +
        "        path.Close();\r\n" +
        "        canvas.ClipPath(path);\r\n\r\n" +
        "        canvas.SetFillPaint(series.TrackColor, trackRect);\r\n" +
        "        canvas.FillPath(path);\r\n" +
        "    }\r\n\r\n" +
        "    private void DrawWave(ICanvas canvas, RectF rectangle)\r\n" +
        "    {\r\n" +
        "        PathF path = new();\r\n\r\n" +
        "        path.MoveTo(rectangle.Left, rectangle.Bottom);\r\n" +
        "        path.LineTo(rectangle.Left, rectangle.Top);\r\n\r\n" +
        "        var top = rectangle.Top;\r\n" +
        "        var start = rectangle.Left;\r\n" +
        "        var split = rectangle.Width / 5;\r\n" +
        "        do\r\n" +
        "        {\r\n" +
        "            var next = start + split;\r\n\r\n" +
        "            var crX = start + (split / 2);\r\n" +
        "            var crY = top - curveHeight;\r\n" +
        "            var crY2 = top + curveHeight;\r\n\r\n" +
        "            path.CurveTo(crX, crY, crX, crY2, next, top);\r\n\r\n" +
        "            start = next;\r\n" +
        "        } while (start <= rectangle.Right);\r\n\r\n" +
        "        path.LineTo(rectangle.Right, rectangle.Bottom);\r\n" +
        "        path.Close();\r\n" +
        "        canvas.FillPath(path);\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string cartesianCustomColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Custom Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis IsVisible=\"False\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" IsVisible=\"False\" Maximum=\"150\" Minimum=\"0\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <core:CustomColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\"\r\n" +
        "                                        ItemsSource=\"{x:Binding Column}\" \r\n" +
        "                                        XBindingPath=\"Name\" YBindingPath=\"Exp\">\r\n" +
        "            <core:CustomColumnSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"False\" LabelPlacement=\"Outer\">\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle FontSize=\"16\" LabelFormat=\"0.00'M\"/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </core:CustomColumnSeries.DataLabelSettings>\r\n" +
        "        </core:CustomColumnSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRangeColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\" HeightRequest=\"500\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Range Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnableDoubleTap=\"False\" EnablePinchZooming=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" Interval=\"1\" ShowMajorGridLines=\"false\" AutoScrollingMode=\"Start\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" Interval=\"5\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat= \"0.#&#186;C\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:RangeColumnSeries EnableAnimation=\"True\" ShowDataLabels=\"True\"\r\n" +
        "                               Fill=\"{x:AppThemeBinding Light={x:StaticResource series1Light}, Dark={x:StaticResource series1Dark}}\"\r\n" +
        "                               ItemsSource=\"{x:Binding RangeColumn}\"\r\n" +
        "                               XBindingPath=\"Name\" High=\"High\" Low=\"Low\">\r\n" +
        "        <toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "            <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"False\">\r\n" +
        "                <toolkit:CartesianDataLabelSettings.LabelStyle >\r\n" +
        "                    <toolkit:ChartDataLabelStyle TextColor=\"White\" LabelFormat= \"0.#&#186;C\"/>\r\n" +
        "                </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "            </toolkit:CartesianDataLabelSettings>\r\n" +
        "        </toolkit:RangeColumnSeries.DataLabelSettings>\r\n" +
        "    </toolkit:RangeColumnSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingColumnChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Column Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"True\" ShowMinorGridLines=\"false\" Minimum=\"0\" Maximum=\"60\" Interval=\"10\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n\r\n" +
        "    <toolkit:StackingColumnSeries Label=\"Zone 1\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                    ItemsSource=\"{x:Binding StackingColumn}\"\r\n" +
        "                                    EnableAnimation=\"True\" ShowDataLabels=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    <toolkit:StackingColumnSeries Label=\"Zone 2\" XBindingPath=\"Name\" YBindingPath=\"High\"\r\n" +
        "                                    ItemsSource=\"{x:Binding StackingColumn}\"\r\n" +
        "                                    EnableAnimation=\"True\" ShowDataLabels=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    <toolkit:StackingColumnSeries Label=\"Zone 3\" XBindingPath=\"Name\" YBindingPath=\"Low\"\r\n" +
        "                                    ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                    EnableAnimation=\"True\" ShowDataLabels=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingColumn100ChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" IsTransposed=\"True\" \r\n" +
        "                        Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Column 100 Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"False\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Interval=\"20\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"True\" RangePadding=\"None\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 1\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"High\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 2\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"Low\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 3\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "        <toolkit:StackingColumn100Series Label=\"Quarter 4\" LegendIcon=\"Rectangle\"\r\n" +
        "                                            ItemsSource=\"{x:Binding StackingColumn}\" \r\n" +
        "                                            XBindingPath=\"Name\" YBindingPath=\"Size\" \r\n" +
        "                                            EnableAnimation=\"True\" ShowDataLabels=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianLineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Line Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"false\" Interval=\"2\" PlotOffsetStart=\"10\" PlotOffsetEnd=\"10\" AxisLineOffset=\"10\">\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"10\">\r\n" +
        "                </toolkit:ChartAxisTickStyle>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" Minimum=\"0\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:LineSeries Label=\"Line 1\" EnableTooltip=\"True\" EnableAnimation=\"True\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{x:Binding FirstLine}\" \r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                            ShowMarkers=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "        <toolkit:LineSeries Label=\"Line 2\" EnableTooltip=\"True\" EnableAnimation=\"True\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{x:Binding SecondLine}\" \r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                            ShowMarkers=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianDashedLineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\">\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <DoubleCollection x:Key=\"DashArray\">\r\n" +
        "            <x:Double>6</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "        </DoubleCollection>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Dashed Line Chart\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"false\" Interval=\"2\" PlotOffsetStart=\"10\" PlotOffsetEnd=\"10\" AxisLineOffset=\"10\">\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"10\">\r\n" +
        "                </toolkit:ChartAxisTickStyle>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Interval=\"20\" Maximum=\"100\" Minimum=\"0\" >\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:LineSeries Label=\"Line 1\" StrokeDashArray=\"{x:StaticResource DashArray}\" LegendIcon=\"SeriesType\"\r\n" +
        "                        EnableTooltip=\"True\" EnableAnimation=\"True\" StrokeWidth=\"1\" ShowMarkers=\"True\"\r\n" +
        "                        ItemsSource=\"{x:Binding FirstLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"/>\r\n" +
        "        <toolkit:LineSeries Label=\"Line 2\" StrokeDashArray=\"{x:StaticResource DashArray}\" LegendIcon=\"SeriesType\"\r\n" +
        "                        EnableTooltip=\"True\" EnableAnimation=\"True\" StrokeWidth=\"1\" ShowMarkers=\"True\"\r\n" +
        "                        ItemsSource=\"{x:Binding SecondLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianSplineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Spline Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"false\" PlotOffsetStart=\"10\" PlotOffsetEnd=\"10\" AxisLineOffset=\"10\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" Minimum=\"0\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'F\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:SplineSeries Label=\"High\" LegendIcon=\"SeriesType\" StrokeWidth=\"1\"\r\n" +
        "                              ItemsSource=\"{x:Binding FirstLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                              EnableTooltip=\"True\" EnableAnimation=\"True\" ShowMarkers=\"True\"/>\r\n" +
        "        <toolkit:SplineSeries Label=\"Low\" StrokeWidth=\"1\" LegendIcon=\"SeriesType\"\r\n" +
        "                              ItemsSource=\"{x:Binding SecondLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                              EnableTooltip=\"True\" EnableAnimation=\"True\" ShowMarkers=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianDashedSplineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <DoubleCollection x:Key=\"DashArray\">\r\n" +
        "            <x:Double>6</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "        </DoubleCollection>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Dashed Spline Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"false\" PlotOffsetStart=\"10\" PlotOffsetEnd=\"10\" AxisLineOffset=\"10\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" Minimum=\"0\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:SplineSeries Label=\"Line 1\" StrokeDashArray=\"{x:StaticResource DashArray}\" StrokeWidth=\"1\" LegendIcon=\"SeriesType\"\r\n" +
        "                              EnableTooltip=\"True\" EnableAnimation=\"True\" ShowMarkers=\"True\"\r\n" +
        "                              ItemsSource=\"{x:Binding FirstLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\" />\r\n" +
        "        <toolkit:SplineSeries Label=\"Line 2\" StrokeDashArray=\"{x:StaticResource DashArray}\" StrokeWidth=\"1\" LegendIcon=\"SeriesType\"\r\n" +
        "                              EnableTooltip=\"True\" EnableAnimation=\"True\" ShowMarkers=\"True\"\r\n" +
        "                              ItemsSource=\"{x:Binding SecondLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\" />\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStepLineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Step Line Chart\" MaxLines=\"2\" LineBreakMode=\"WordWrap\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" PlotOffsetEnd=\"10\" PlotOffsetStart=\"10\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"100\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StepLineSeries Label=\"Line 1\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding FirstLine}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                EnableAnimation=\"True\" EnableTooltip=\"True\" ShowMarkers=\"True\">\r\n" +
        "            <toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "                <toolkit:ChartMarkerSettings StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "        </toolkit:StepLineSeries>\r\n" +
        "        <toolkit:StepLineSeries Label=\"Line 2\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding SecondLine}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                EnableAnimation=\"True\" EnableTooltip=\"True\" ShowMarkers=\"True\">\r\n" +
        "            <toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "                <toolkit:ChartMarkerSettings StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "        </toolkit:StepLineSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianDashedStepLineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Dashed Step Line\" MaxLines=\"2\" LineBreakMode=\"WordWrap\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <DoubleCollection x:Key=\"DashArray\">\r\n" +
        "            <x:Double>6</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "            <x:Double>3</x:Double>\r\n" +
        "        </DoubleCollection>\r\n" +
        "        <ResourceDictionary>\r\n" +
        "            <DataTemplate x:Key=\"TooltipTemplate\">\r\n" +
        "                <StackLayout>\r\n" +
        "                    <Label Text=\"Grades\" HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Center\" VerticalTextAlignment=\"Center\" \r\n" +
        "                            FontAttributes=\"Bold\" FontFamily=\"Helvetica\" Margin=\"0,2,0,2\" FontSize=\"12\" />\r\n" +
        "                    <BoxView HeightRequest=\"1\" WidthRequest=\"100\"/>\r\n" +
        "                    <StackLayout Orientation=\"Horizontal\" VerticalOptions=\"Fill\" Spacing=\"0\" Padding=\"3\" Margin=\"0\">\r\n" +
        "                        <Ellipse TranslationY=\"-1\" StrokeThickness=\"2\" \r\n" +
        "                                    HeightRequest=\"10\" WidthRequest=\"10\" Fill=\"#04ABC1\" Margin=\"0,3,3,0\"/>\r\n" +
        "                        <Label Text=\"{x:Binding Item.Name,StringFormat='{0:MMM-dd}'}\" \r\n" +
        "                                VerticalTextAlignment=\"Center\" HorizontalOptions=\"Start\" \r\n" +
        "                                FontFamily=\"Helvetica\" FontSize=\"12\" Margin=\"3,0,3,0\"/>\r\n" +
        "                        <Label Text=\"{x:Binding Item.Value,StringFormat=' :  {0}'}\" \r\n" +
        "                                VerticalTextAlignment=\"Center\" HorizontalOptions=\"End\" \r\n" +
        "                                FontFamily=\"Helvetica\" Margin=\"0,0,3,0\" FontSize=\"12\"/>\r\n" +
        "                    </StackLayout>\r\n" +
        "                </StackLayout>\r\n" +
        "            </DataTemplate>\r\n" +
        "        </ResourceDictionary>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior ZoomMode=\"X\" EnableDoubleTap=\"False\" EnablePinchZooming=\"False\" EnablePanning=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" PlotOffsetEnd=\"10\" PlotOffsetStart=\"10\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis EdgeLabelsDrawingMode=\"Fit\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StepLineSeries Label=\"Line 1\" LegendIcon=\"SeriesType\"\r\n" +
        "                                StrokeDashArray=\"{x:StaticResource DashArray}\" \r\n" +
        "                                ItemsSource=\"{x:Binding FirstLine}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                ShowMarkers=\"True\" EnableAnimation=\"True\" EnableTooltip=\"True\"  \r\n" +
        "                                TooltipTemplate=\"{x:StaticResource TooltipTemplate}\" >\r\n" +
        "            <toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "                <toolkit:ChartMarkerSettings StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "        </toolkit:StepLineSeries>\r\n" +
        "        <toolkit:StepLineSeries Label=\"Line 2\" LegendIcon=\"SeriesType\"\r\n" +
        "                                StrokeDashArray=\"{x:StaticResource DashArray}\" \r\n" +
        "                                ItemsSource=\"{x:Binding SecondLine}\" \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                ShowMarkers=\"True\" EnableAnimation=\"True\" EnableTooltip=\"True\"  \r\n" +
        "                                TooltipTemplate=\"{x:StaticResource TooltipTemplate}\" >\r\n" +
        "            <toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "                <toolkit:ChartMarkerSettings StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "        </toolkit:StepLineSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianVerticalStepLineChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Vertical Step Line\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <ResourceDictionary>\r\n" +
        "            <DataTemplate x:Key=\"TooltipTemplateVerticalLine\">\r\n" +
        "                <StackLayout>\r\n" +
        "                    <Label Text=\"Grades\" HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Center\" VerticalTextAlignment=\"Center\" \r\n" +
        "                           FontAttributes=\"Bold\" FontFamily=\"Helvetica\" Margin=\"0,2\" FontSize=\"12\" />\r\n" +
        "                    <BoxView HeightRequest=\"1\" WidthRequest=\"100\" />\r\n" +
        "                    <StackLayout Orientation=\"Horizontal\" VerticalOptions=\"Fill\" Padding=\"3\" >\r\n" +
        "                        <Ellipse TranslationY=\"-1\" StrokeThickness=\"2\" \r\n" +
        "                                 HeightRequest=\"10\" WidthRequest=\"10\" Fill=\"#04ABC1\" Margin=\"0,3,3,0\"/>\r\n" +
        "                        <Label Text=\"{x:Binding Item.Name}\"  VerticalTextAlignment=\"Center\" HorizontalOptions=\"Start\"  \r\n" +
        "                               FontFamily=\"Helvetica\" FontSize=\"12\" Margin=\"3,0,3,0\"/>\r\n" +
        "                        <Label Text=\"{x:Binding Item.Value,StringFormat=' :  {0} %'}\" VerticalTextAlignment=\"Center\" HorizontalOptions=\"End\" \r\n" +
        "                               FontFamily=\"Helvetica\" Margin=\"0,0,3,0\" FontSize=\"12\"/>\r\n" +
        "                    </StackLayout>\r\n" +
        "                </StackLayout>\r\n" +
        "            </DataTemplate>\r\n" +
        "        </ResourceDictionary>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" LabelPlacement=\"BetweenTicks\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"100\" Interval=\"20\" ShowMajorGridLines=\"True\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:StepLineSeries Label=\"Line 1\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding FirstLine}\"  \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                ShowMarkers=\"True\" EnableAnimation=\"True\" EnableTooltip=\"True\" \r\n" +
        "                                TooltipTemplate=\"{StaticResource TooltipTemplateVerticalLine}\">\r\n" +
        "            <toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "                <toolkit:ChartMarkerSettings StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "        </toolkit:StepLineSeries>\r\n" +
        "        <toolkit:StepLineSeries Label=\"Line 2\" LegendIcon=\"SeriesType\"\r\n" +
        "                                ItemsSource=\"{x:Binding SecondLine}\"  \r\n" +
        "                                XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                                ShowMarkers=\"True\" EnableAnimation=\"True\" EnableTooltip=\"True\"  \r\n" +
        "                                TooltipTemplate=\"{StaticResource TooltipTemplateVerticalLine}\">\r\n" +
        "            <toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "                <toolkit:ChartMarkerSettings StrokeWidth=\"1\"/>\r\n" +
        "            </toolkit:StepLineSeries.MarkerSettings>\r\n" +
        "        </toolkit:StepLineSeries>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingLineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <ResourceDictionary>\r\n" +
        "            <DataTemplate x:Key=\"TooltipTemplate\">\r\n" +
        "                <StackLayout>\r\n" +
        "                    <Label Text=\"Grades\" HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Center\" VerticalTextAlignment=\"Center\" \r\n" +
        "                           FontAttributes=\"Bold\" FontFamily=\"Helvetica\" Margin=\"0,2,0,2\" FontSize=\"13\"/>\r\n" +
        "                    <BoxView HeightRequest=\"1\" WidthRequest=\"80\" />\r\n" +
        "                    <StackLayout Orientation=\"Horizontal\" VerticalOptions=\"Fill\" Spacing=\"0\" Padding=\"3\" Margin=\"0\" HorizontalOptions=\"Center\">\r\n" +
        "                        <Ellipse TranslationY=\"-1\" StrokeThickness=\"2\" \r\n" +
        "                                 HeightRequest=\"10\" WidthRequest=\"10\" Fill=\"#04ABC1\" Margin=\"0,3,3,0\"/>\r\n" +
        "                        <Label Text=\"{Binding Item.Name}\"  VerticalTextAlignment=\"Center\" \r\n" +
        "                            HorizontalOptions=\"Start\"  FontFamily=\"Helvetica\" FontSize=\"12\" Margin=\"3,0,3,0\"/>\r\n" +
        "                        <Label Text=\"{Binding Item.Value,StringFormat=' :  {0}'}\" VerticalTextAlignment=\"Center\" \r\n" +
        "                            HorizontalOptions=\"End\" FontFamily=\"Helvetica\" Margin=\"0,0,3,0\" FontSize=\"12\" />\r\n" +
        "                    </StackLayout>\r\n" +
        "                </StackLayout>\r\n" +
        "            </DataTemplate>\r\n" +
        "        </ResourceDictionary>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Stacking Line Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" LabelPlacement=\"BetweenTicks\">\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Year\"/>\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"300\" Interval=\"50\" ShowMajorGridLines=\"True\"\r\n" +
        "                            EdgeLabelsDrawingMode=\"Center\" PlotOffsetEnd=\"10\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:StackingLineSeries Label=\"Line 1\" LegendIcon=\"SeriesType\"\r\n" +
        "                            ItemsSource=\"{x:Binding FirstLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                            EnableAnimation=\"True\" ShowMarkers=\"True\" StrokeWidth=\"2\" \r\n" +
        "                            EnableTooltip=\"True\" TooltipTemplate=\"{x:StaticResource TooltipTemplate}\">\r\n" +
        "        <toolkit:StackingLineSeries.MarkerSettings>\r\n" +
        "            <toolkit:ChartMarkerSettings Width=\"10\" Height=\"10\" StrokeWidth=\"2\"/>\r\n" +
        "        </toolkit:StackingLineSeries.MarkerSettings>\r\n" +
        "    </toolkit:StackingLineSeries>\r\n" +
        "    <toolkit:StackingLineSeries Label=\"Line 2\" LegendIcon=\"SeriesType\" \r\n" +
        "                            ItemsSource=\"{x:Binding SecondLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                            EnableAnimation=\"True\" ShowMarkers=\"True\" StrokeWidth=\"2\" \r\n" +
        "                            EnableTooltip=\"True\" TooltipTemplate=\"{x:StaticResource TooltipTemplate}\">\r\n" +
        "        <toolkit:StackingLineSeries.MarkerSettings>\r\n" +
        "            <toolkit:ChartMarkerSettings Width=\"10\" Height=\"10\" StrokeWidth=\"2\"/>\r\n" +
        "        </toolkit:StackingLineSeries.MarkerSettings>\r\n" +
        "    </toolkit:StackingLineSeries>\r\n" +
        "    <toolkit:StackingLineSeries Label=\"Line 3\" LegendIcon=\"SeriesType\" \r\n" +
        "                            ItemsSource=\"{x:Binding ThirdLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                            EnableAnimation=\"True\" ShowMarkers=\"True\" StrokeWidth=\"2\"\r\n" +
        "                            EnableTooltip=\"True\" TooltipTemplate=\"{x:StaticResource TooltipTemplate}\">\r\n" +
        "        <toolkit:StackingLineSeries.MarkerSettings>\r\n" +
        "            <toolkit:ChartMarkerSettings Width=\"10\" Height=\"10\" StrokeWidth=\"2\"/>\r\n" +
        "        </toolkit:StackingLineSeries.MarkerSettings>\r\n" +
        "    </toolkit:StackingLineSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianStackingLine100ChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" \r\n" +
        "                        Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <ResourceDictionary>\r\n" +
        "            <DataTemplate x:Key=\"TooltipTemplate\">\r\n" +
        "                <StackLayout Orientation=\"Horizontal\">\r\n" +
        "                    <Rectangle HeightRequest=\"35\" WidthRequest=\"8\"/>\r\n" +
        "                    <StackLayout Orientation=\"Vertical\">\r\n" +
        "                        <Label Text=\"{Binding Item.Name}\" FontSize=\"13\" Padding=\"5,0,0,0\"/>\r\n" +
        "                        <Label FontSize=\"12\" Padding=\"5,0,0,0\" Margin=\"0,0,3,0\">\r\n" +
        "                            <Label.FormattedText>\r\n" +
        "                                <FormattedString>\r\n" +
        "                                    <Span Text=\"Grades\" FontAttributes=\"Bold\" />\r\n" +
        "                                    <Span Text=\"{Binding Item.Value, StringFormat=' : {0}%'}\" />\r\n" +
        "                                </FormattedString>\r\n" +
        "                            </Label.FormattedText>\r\n" +
        "                        </Label>\r\n" +
        "                    </StackLayout>\r\n" +
        "                </StackLayout>\r\n" +
        "            </DataTemplate>\r\n" +
        "        </ResourceDictionary>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Blood Type Distribution Among Population\"  LineBreakMode=\"WordWrap\"  Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis IsVisible=\"True\" ShowMajorGridLines=\"False\" LabelPlacement=\"BetweenTicks\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes >\r\n" +
        "        <toolkit:NumericalAxis Minimum=\"0\" Maximum=\"100\" Interval=\"20\" ShowMajorGridLines=\"True\" ShowMinorGridLines=\"False\" \r\n" +
        "                            EdgeLabelsDrawingMode=\"Center\" PlotOffsetEnd=\"10\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:StackingLine100Series Label=\"Line 1\" LegendIcon=\"SeriesType\" \r\n" +
        "                                ItemsSource=\"{x:Binding FirstLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                EnableAnimation=\"True\" ShowMarkers=\"True\" StrokeWidth=\"2\" \r\n" +
        "                                EnableTooltip=\"True\" TooltipTemplate=\"{x:StaticResource TooltipTemplate}\">\r\n" +
        "        <toolkit:StackingLine100Series.MarkerSettings>\r\n" +
        "            <toolkit:ChartMarkerSettings Width=\"10\" Height=\"10\" StrokeWidth=\"2\"/>\r\n" +
        "        </toolkit:StackingLine100Series.MarkerSettings>\r\n" +
        "    </toolkit:StackingLine100Series>\r\n" +
        "    <toolkit:StackingLine100Series Label=\"Line 2\" LegendIcon=\"SeriesType\" \r\n" +
        "                                ItemsSource=\"{x:Binding SecondLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                EnableAnimation=\"True\" ShowMarkers=\"True\" StrokeWidth=\"2\" \r\n" +
        "                                EnableTooltip=\"True\" TooltipTemplate=\"{x:StaticResource TooltipTemplate}\">\r\n" +
        "        <toolkit:StackingLine100Series.MarkerSettings>\r\n" +
        "            <toolkit:ChartMarkerSettings Width=\"10\" Height=\"10\" StrokeWidth=\"2\"/>\r\n" +
        "        </toolkit:StackingLine100Series.MarkerSettings>\r\n" +
        "    </toolkit:StackingLine100Series>\r\n" +
        "    <toolkit:StackingLine100Series Label=\"Line 3\" LegendIcon=\"SeriesType\" \r\n" +
        "                                ItemsSource=\"{x:Binding ThirdLine}\" XBindingPath=\"Name\" YBindingPath=\"Value\"\r\n" +
        "                                EnableAnimation=\"True\"  ShowMarkers=\"True\" StrokeWidth=\"2\" \r\n" +
        "                                EnableTooltip=\"True\" TooltipTemplate=\"{x:StaticResource TooltipTemplate}\">\r\n" +
        "        <toolkit:StackingLine100Series.MarkerSettings>\r\n" +
        "            <toolkit:ChartMarkerSettings Width=\"10\" Height=\"10\" StrokeWidth=\"2\"/>\r\n" +
        "        </toolkit:StackingLine100Series.MarkerSettings>\r\n" +
        "    </toolkit:StackingLine100Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianFastLineChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Fast Line Chart\" Margin=\"0,0,0,5\" \r\n" +
        "                HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" \r\n" +
        "                VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis ShowMinorGridLines=\"False\" ShowMajorGridLines=\"False\" \r\n" +
        "                            IntervalType=\"Years\" Interval=\"15\">\r\n" +
        "            <toolkit:DateTimeAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"X-Axis\"/>\r\n" +
        "            </toolkit:DateTimeAxis.Title>\r\n" +
        "            <toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"yyyy\"/>\r\n" +
        "            </toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "        </toolkit:DateTimeAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis>\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Y-Axis\"/>\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior EnablePinchZooming=\"True\" EnableDoubleTap=\"True\" \r\n" +
        "                                        EnablePanning=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:FastLineSeries ItemsSource=\"{x:Binding FastLine}\"\r\n" +
        "                                EnableAntiAliasing=\"True\"\r\n" +
        "                                XBindingPath=\"Date\" YBindingPath=\"Value\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianScatterChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\" \r\n" +
        "                        Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Height vs Weight\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" EdgeLabelsDrawingMode=\"Shift\" Minimum=\"100\" Maximum=\"220\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Margin=\"5,10,5,2\" Text=\"Centimeter\"/>\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" Minimum=\"50\" Maximum=\"80\" Interval=\"5\">\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Kilogram\"/>\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:ScatterSeries Label=\"Scatter 1\" EnableTooltip=\"True\" EnableAnimation=\"True\" Opacity=\"0.6\" PointWidth=\"8\" PointHeight=\"8\" \r\n" +
        "                            ItemsSource=\"{Binding FirstScatter}\" XBindingPath=\"Value\" YBindingPath=\"Size\"/>\r\n" +
        "        <toolkit:ScatterSeries Label=\"Scatter 2\" EnableTooltip=\"True\" EnableAnimation=\"True\" Opacity=\"0.6\" PointWidth=\"8\" PointHeight=\"8\" \r\n" +
        "                            ItemsSource=\"{Binding SecondScatter}\" XBindingPath=\"Value\" YBindingPath=\"Size\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianBubbleChartXamlCode =
        "<toolkit:SfCartesianChart VerticalOptions=\"FillAndExpand\" HorizontalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <DataTemplate x:Key=\"Rooltiptemplate\">\r\n" +
        "            <Grid RowDefinitions=\"auto, auto, auto\">\r\n" +
        "                <Label Grid.Row=\"0\" Text=\"{Binding Item.Name,StringFormat='{0}'}\" \r\n" +
        "                        HorizontalTextAlignment=\"Center\" VerticalTextAlignment=\"Center\" \r\n" +
        "                        Margin=\"0,0,0,2\" HorizontalOptions=\"Center\" FontFamily=\"Helvetica\" FontAttributes=\"Bold\" FontSize=\"10\"/>\r\n" +
        "                <BoxView Grid.Row=\"1\" VerticalOptions=\"Center\" HeightRequest=\"1\" />\r\n" +
        "                <StackLayout Grid.Row=\"2\" Orientation=\"Vertical\"  VerticalOptions=\"Fill\" Spacing=\"0\" Padding=\"2\" Margin=\"0\">\r\n" +
        "                    <Label Text=\"{x:Binding Item.Value,StringFormat='Literacy rate         : {0}%'}\" \r\n" +
        "                            VerticalTextAlignment=\"Center\" HorizontalOptions=\"Start\" FontFamily=\"Helvetica\" FontSize=\"10\" />\r\n" +
        "                    <Label Text=\"{x:Binding Item.High,StringFormat='GDP growth rate : {0}'}\" \r\n" +
        "                            VerticalTextAlignment=\"Center\" HorizontalOptions=\"Start\" FontFamily=\"Helvetica\" FontSize=\"10\" />\r\n" +
        "                    <Label Text=\"{x:Binding Item.Low,StringFormat='Population           : {0}B'}\" \r\n" +
        "                            VerticalTextAlignment=\"Center\" HorizontalOptions=\"Start\" FontFamily=\"Helvetica\" FontSize=\"10\" />\r\n" +
        "                </StackLayout>\r\n" +
        "            </Grid>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Bubble Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" RangePadding=\"Additional\" EdgeLabelsDrawingMode=\"Fit\">\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis LabelCreated=\"LabelCreated\" Minimum=\"0\" RangePadding=\"Additional\" EdgeLabelsDrawingMode=\"Fit\">\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:BubbleSeries EnableAnimation=\"True\" TooltipTemplate=\"{StaticResource Tooltiptemplate}\"\r\n" +
        "                            ItemsSource=\"{x:Binding Bubble}\" \r\n" +
        "                            EnableTooltip=\"True\" ShowDataLabels=\"False\" \r\n" +
        "                            XBindingPath=\"Exp\" YBindingPath=\"High\" SizeValuePath=\"Low\" Opacity=\"1\"/>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianCustomBubbleChartXamlCode =
        "<toolkit:SfCartesianChart VerticalOptions=\"FillAndExpand\" HorizontalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Resources>\r\n" +
        "        <DataTemplate x:Key=\"CustomTooltiptemplate\">\r\n" +
        "            <Grid RowDefinitions=\"auto, auto\">\r\n" +
        "                <Label Grid.Row=\"0\" LineBreakMode=\"WordWrap\" MaximumWidthRequest=\"100\" \r\n" +
        "                        Text=\"{x:Binding Item.Name,StringFormat='{0}'}\" HorizontalTextAlignment=\"Center\" \r\n" +
        "                        HorizontalOptions=\"Center\" VerticalTextAlignment=\"Center\" \r\n" +
        "                        FontFamily=\"Helvetica\" FontAttributes=\"Bold\" Margin=\"0,2,0,2\" FontSize=\"10\"/>\r\n" +
        "                <BoxView Grid.Row=\"1\" VerticalOptions=\"Center\" HeightRequest=\"1\" />\r\n" +
        "                <StackLayout Grid.Row=\"2\" Orientation=\"Vertical\" VerticalOptions=\"Fill\" Spacing=\"0\" Padding=\"3\" Margin=\"0\">\r\n" +
        "                    <Label Text=\"{x:Binding Item.High,StringFormat='Budget   : ${0}M'}\" \r\n" +
        "                            VerticalTextAlignment=\"Center\" HorizontalOptions=\"Start\" \r\n" +
        "                            FontFamily=\"Helvetica\" Margin=\"0,0,3,0\" FontSize=\"10\"/>\r\n" +
        "                    <Label Text=\"{x:Binding Item.Low,StringFormat='Revenue : ${0}M'}\" \r\n" +
        "                            VerticalTextAlignment=\"Center\" HorizontalOptions=\"Start\" \r\n" +
        "                            FontFamily=\"Helvetica\" Margin=\"0,0,3,0\" FontSize=\"10\"/>\r\n" +
        "                </StackLayout>\r\n" +
        "            </Grid>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </toolkit:SfCartesianChart.Resources>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Custom Bubble Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:NumericalAxis RangePadding=\"Additional\" ShowMajorGridLines=\"False\" EdgeLabelsDrawingMode=\"Fit\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis LabelCreated=\"LabelCreated\" Minimum=\"0\" RangePadding=\"Additional\" EdgeLabelsDrawingMode=\"Fit\"/>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:BubbleSeries EnableTooltip=\"True\" TooltipTemplate=\"{x:StaticResource CustomTooltiptemplate}\"\r\n" +
        "                            ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\" \r\n" +
        "                            EnableAnimation=\"True\" ShowDataLabels=\"False\"\r\n" +
        "                            XBindingPath=\"Exp\" YBindingPath=\"High\" SizeValuePath=\"Low\" Opacity=\"1\">\r\n" +
        "        <toolkit:BubbleSeries.Fill>\r\n" +
        "            <RadialGradientBrush Center=\"0.35,0.35\" Radius=\"0.5\">\r\n" +
        "                <GradientStop Offset=\"0\" Color=\"#EAEAEA\" />\r\n" +
        "                <GradientStop Offset=\"1\" Color=\"#EC9329\" />\r\n" +
        "            </RadialGradientBrush>\r\n" +
        "        </toolkit:BubbleSeries.Fill>\r\n" +
        "    </toolkit:BubbleSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianBoxAndWhiskerChartXamlCode =
        "<toolkit:SfCartesianChart VerticalOptions=\"FillAndExpand\" HorizontalOptions=\"Fill\"\r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Box And Whisker Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\"/>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis />\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:BoxAndWhiskerSeries ItemsSource=\"{x:Binding Box}\"\r\n" +
        "                                 XBindingPath=\"Name\" YBindingPath=\"Values\"\r\n" +
        "                                 ShowOutlier=\"True\" ShowMedian=\"True\" \r\n" +
        "                                 EnableTooltip=\"True\" \r\n" +
        "                                 Fill=\"BlueViolet\" Stroke=\"White\">\r\n" +
        "    </toolkit:BoxAndWhiskerSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianHistogramChartXamlCode =
        "<VerticalStackLayout Spacing=\"10\">\r\n" +
        "    <HorizontalStackLayout HorizontalOptions=\"End\">\r\n" +
        "        <Label Text=\"Show distribution line\" VerticalTextAlignment=\"Center\"/>\r\n" +
        "        <CheckBox x:Name=\"CheckBox\" IsChecked=\"True\" VerticalOptions=\"Start\" Margin=\"30,0,0,0\"/>\r\n" +
        "    </HorizontalStackLayout>\r\n" +
        "    <toolkit:SfCartesianChart VerticalOptions=\"FillAndExpand\">\r\n" +
        "        <toolkit:SfCartesianChart.Title>\r\n" +
        "            <Label Text=\"Histogram Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\"/>\r\n" +
        "        </toolkit:SfCartesianChart.Title>\r\n" +
        "        <toolkit:SfCartesianChart.XAxes>\r\n" +
        "            <toolkit:NumericalAxis />\r\n" +
        "        </toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:SfCartesianChart.YAxes>\r\n" +
        "            <toolkit:NumericalAxis />\r\n" +
        "        </toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:HistogramSeries ItemsSource=\"{x:Binding Candle}\"\r\n" +
        "                            XBindingPath=\"Value\" YBindingPath=\"Size\"\r\n" +
        "                            ShowNormalDistributionCurve=\"{x:Binding Source={x:Reference CheckBox},Path=IsChecked}\"\r\n" +
        "                            HistogramInterval=\"20\" StrokeWidth=\"1.5\" ShowDataLabels=\"True\"\r\n" +
        "                            EnableTooltip=\"True\">\r\n" +
        "            <toolkit:HistogramSeries.CurveStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeDashArray=\"12, 3, 3, 3\" StrokeWidth=\"2\"/>\r\n" +
        "            </toolkit:HistogramSeries.CurveStyle>\r\n" +
        "            <toolkit:HistogramSeries.DataLabelSettings>\r\n" +
        "                <toolkit:CartesianDataLabelSettings UseSeriesPalette=\"False\">\r\n" +
        "                    <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                        <toolkit:ChartDataLabelStyle TextColor=\"Aqua\"/>\r\n" +
        "                    </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                </toolkit:CartesianDataLabelSettings>\r\n" +
        "            </toolkit:HistogramSeries.DataLabelSettings>\r\n" +
        "        </toolkit:HistogramSeries>\r\n" +
        "    </toolkit:SfCartesianChart>\r\n\r\n" +
        "    <core:SourceCodeExpander Code=\"{x:Binding CodeDescription, Source={x:Reference root}}\"  CodeType=\"Xaml\"/>\r\n" +
        "</VerticalStackLayout>";

    [ObservableProperty]
    string cartesianCandleChartXamlCode =
        "<VerticalStackLayout Spacing=\"10\">\r\n" +
        "    <HorizontalStackLayout HorizontalOptions=\"End\">\r\n" +
        "        <Label Text=\"Enable Solid Candles\" VerticalTextAlignment=\"Center\"/>\r\n" +
        "        <CheckBox x:Name=\"CheckBox\" IsChecked=\"False\" VerticalOptions=\"Start\" Margin=\"30,0,0,0\" />\r\n" +
        "    </HorizontalStackLayout>\r\n\r\n" +
        "    <toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\" Margin=\"0, 0, 20, 0\">\r\n" +
        "        <toolkit:SfCartesianChart.Title>\r\n" +
        "            <Label Text=\"Candle Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "        </toolkit:SfCartesianChart.Title>\r\n" +
        "        <toolkit:SfCartesianChart.XAxes>\r\n" +
        "            <toolkit:DateTimeAxis AutoScrollingMode=\"End\" AutoScrollingDeltaType=\"Months\" LabelCreated=\"LabelCreated\" ShowMajorGridLines=\"False\" >\r\n" +
        "                <toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "                    <toolkit:ChartAxisLabelStyle LabelFormat=\"MMM-dd\"/>\r\n" +
        "                </toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "            </toolkit:DateTimeAxis>\r\n" +
        "        </toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:SfCartesianChart.YAxes>\r\n" +
        "            <toolkit:NumericalAxis ShowMinorGridLines=\"True\" Maximum=\"110\" IsVisible=\"True\">\r\n" +
        "                <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                    <toolkit:ChartLineStyle StrokeWidth=\"0\"/>\r\n" +
        "                </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                    <toolkit:ChartAxisLabelStyle LabelFormat=\"$0\"/>\r\n" +
        "                </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            </toolkit:NumericalAxis>\r\n" +
        "        </toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:CandleSeries ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\"\r\n" +
        "                        XBindingPath=\"Date\" Open=\"Value\" High=\"High\" Low=\"Low\" Close=\"Size\"\r\n" +
        "                        EnableTooltip=\"True\" EnableAnimation=\"True\"\r\n" +
        "                        EnableSolidCandle=\"{x:Binding Source={x:Reference CheckBox},Path=IsChecked}\">\r\n" +
        "        </toolkit:CandleSeries>\r\n" +
        "        <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "            <toolkit:ChartZoomPanBehavior ZoomMode=\"X\" EnableDoubleTap=\"False\" EnablePanning=\"True\" EnablePinchZooming=\"True\"/>\r\n" +
        "        </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "    </toolkit:SfCartesianChart>\r\n" +
        "</VerticalStackLayout>";

    [ObservableProperty]
    string cartesianOHLCChartXamlCode =
        "<toolkit:SfCartesianChart  HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"OHLC Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis  AutoScrollingMode=\"End\" AutoScrollingDeltaType=\"Months\" LabelCreated=\"LabelCreated\" ShowMajorGridLines=\"False\" >\r\n" +
        "            <toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"MMM-dd\"/>\r\n" +
        "            </toolkit:DateTimeAxis.LabelStyle>\r\n" +
        "        </toolkit:DateTimeAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMinorGridLines=\"True\" Maximum=\"110\" x:Name=\"YAxis\" IsVisible=\"True\">\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\"/>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"$##.##\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:HiLoOpenCloseSeries ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\"\r\n" +
        "                                    XBindingPath=\"Date\" Open=\"Value\" High=\"High\" Low=\"Low\" Close=\"Size\"\r\n" +
        "                                    EnableAnimation=\"True\" EnableTooltip=\"True\"/>\r\n" +
        "    <toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "        <toolkit:ChartZoomPanBehavior x:Name=\"ZoomPan\" ZoomMode=\"X\" EnableDoubleTap=\"False\" EnablePanning=\"True\" EnablePinchZooming=\"True\"></toolkit:ChartZoomPanBehavior>\r\n" +
        "    </toolkit:SfCartesianChart.ZoomPanBehavior>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianWaterfallChartXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Waterfall Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes >\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"False\" LabelPlacement=\"BetweenTicks\">\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" >\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'B\" />\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:WaterfallSeries ItemsSource=\"{x:Binding Waterfall}\" \r\n" +
        "                                AllowAutoSum=\"True\" XBindingPath=\"Name\" YBindingPath=\"Value\" SummaryBindingPath=\"IsSummary\"\r\n" +
        "                                Fill=\"#95DB9C\" NegativePointsBrush=\"#B95375\" SummaryPointsBrush=\"#327DBE\" \r\n" +
        "                                EnableAnimation=\"True\">\r\n" +
        "        <toolkit:WaterfallSeries.DataLabelSettings>\r\n" +
        "            <toolkit:CartesianDataLabelSettings >\r\n" +
        "                <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                    <toolkit:ChartDataLabelStyle LabelFormat=\"0'B\"/>\r\n" +
        "                </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "            </toolkit:CartesianDataLabelSettings>\r\n" +
        "        </toolkit:WaterfallSeries.DataLabelSettings>\r\n" +
        "    </toolkit:WaterfallSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianVerticalWaterfallChartXamlCode =
        "<toolkit:SfCartesianChart IsTransposed=\"True\" HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\" >\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Vertical Waterfall Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" ShowMajorGridLines=\"False\" >\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis ShowMajorGridLines=\"False\" IsVisible=\"False\">\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:WaterfallSeries ItemsSource=\"{x:Binding ComponentData, Source={x:Reference root}}\" \r\n" +
        "                                AllowAutoSum=\"True\" XBindingPath=\"Name\" YBindingPath=\"Value\" SummaryBindingPath=\"IsSummary\" \r\n" +
        "                                Fill=\"#95DB9C\" NegativePointsBrush=\"#B95375\" SummaryPointsBrush=\"#327DBE\" \r\n" +
        "                                EnableAnimation=\"True\" EnableTooltip=\"True\">\r\n" +
        "        <toolkit:WaterfallSeries.DataLabelSettings >\r\n" +
        "            <toolkit:CartesianDataLabelSettings BarAlignment=\"Middle\">\r\n" +
        "                <toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "                    <toolkit:ChartDataLabelStyle LabelFormat=\"0'M\"/>\r\n" +
        "                </toolkit:CartesianDataLabelSettings.LabelStyle>\r\n" +
        "            </toolkit:CartesianDataLabelSettings>\r\n" +
        "        </toolkit:WaterfallSeries.DataLabelSettings>\r\n" +
        "    </toolkit:WaterfallSeries>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAppearanceChartXamlCode =
        "<toolkit:SfCartesianChart PaletteBrushes=\"{x:Binding ColdPalletBrushes}\" HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Simple Sample Chart\" FontSize=\"16\" \r\n" +
        "               HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Fill\"  VerticalOptions=\"Center\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis>\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Name\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis>\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:ColumnSeries EnableAnimation=\"True\"\r\n" +
        "                          ItemsSource=\"{x:Binding Column}\"\r\n" +
        "                          SelectionBehavior=\"{x:StaticResource SfCartesianChartSelectionBrush}\"\r\n" +
        "                          XBindingPath=\"Name\" YBindingPath=\"Exp\" />\r\n" +
        "    <toolkit:ColumnSeries EnableAnimation=\"True\"\r\n" +
        "                          ItemsSource=\"{x:Binding Column}\"\r\n" +
        "                          SelectionBehavior=\"{x:StaticResource SfCartesianChartSelectionBrush}\"\r\n" +
        "                          XBindingPath=\"Name\" YBindingPath=\"Value\" />\r\n" +
        "    <toolkit:ColumnSeries EnableAnimation=\"True\"\r\n" +
        "                          ItemsSource=\"{x:Binding Column}\"\r\n" +
        "                          SelectionBehavior=\"{x:StaticResource SfCartesianChartSelectionBrush}\"\r\n" +
        "                          XBindingPath=\"Name\" YBindingPath=\"Size\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAppearanceSeriesLinearXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Simple Sample Chart\" FontSize=\"16\" \r\n" +
        "                HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Fill\"  VerticalOptions=\"Center\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis>\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Name\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis>\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Exp\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:ColumnSeries EnableAnimation=\"True\"\r\n" +
        "                            ItemsSource=\"{x:Binding Column}\"\r\n" +
        "                            PaletteBrushes=\"{x:Binding ColdPalletBrushes}\"\r\n" +
        "                            SelectionBehavior=\"{x:StaticResource SfCartesianChartSelectionBrush}\"\r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Exp\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAppearanceSeriesLinearCSharpCode =
        "[ObservableProperty]\r\n" +
        "List<Brush> coldPalletBrushes;\r\n\r\n" +
        "List<Brush> CreateColdGradientPalletBrushes(int count)\r\n" +
        "{\r\n" +
        "    var allBrushes = new List<LinearGradientBrush>\r\n" +
        "    {\r\n" +
        "        new LinearGradientBrush\r\n" +
        "        {\r\n" +
        "            GradientStops = new GradientStopCollection\r\n" +
        "            {\r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(0, 255, 255) },\r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(0, 191, 255) }\r\n" +
        "            }\r\n" +
        "        },\r\n" +
        "        new LinearGradientBrush\r\n" +
        "        {\r\n" +
        "            GradientStops = new GradientStopCollection\r\n" +
        "            {\r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(0, 191, 255) },\r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(0, 128, 255) }\r\n" +
        "            }\r\n" +
        "        },\r\n" +
        "        new LinearGradientBrush\r\n" +
        "        {\r\n" +
        "            GradientStops = new GradientStopCollection\r\n" +
        "            {\r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(0, 128, 255) },\r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(0, 64, 255) }\r\n" +
        "            }\r\n" +
        "        },\r\n" +
        "        new LinearGradientBrush\r\n" +
        "        {\r\n" +
        "            GradientStops = new GradientStopCollection\r\n" +
        "            {\r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(0, 64, 255) },\r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(0, 0, 255) }\r\n" +
        "            }\r\n" +
        "        },\r\n" +
        "        new LinearGradientBrush\r\n" +
        "        {\r\n" +
        "            GradientStops = new GradientStopCollection\r\n" +
        "            {\r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(0, 0, 255) },\r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(0, 0, 191) }\r\n" +
        "            }\r\n" +
        "        }\r\n" +
        "    };\r\n\r\n" +
        "    var brush = new List<Brush>();\r\n" +
        "    allBrushes.Take(count).ToList().ForEach(item => { brush.Add(item); });\r\n\r\n" +
        "    return brush;\r\n" +
        "}";

    [ObservableProperty]
    string cartesianAppearanceSeriesGradientXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"FillAndExpand\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Simple Sample Chart\" FontSize=\"16\" \r\n" +
        "                HorizontalTextAlignment=\"Center\" HorizontalOptions=\"Fill\"  VerticalOptions=\"Center\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis>\r\n" +
        "            <toolkit:CategoryAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Name\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:CategoryAxis.Title>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis>\r\n" +
        "            <toolkit:NumericalAxis.Title>\r\n" +
        "                <toolkit:ChartAxisTitle Text=\"Exp\" TextColor=\"{x:AppThemeBinding Dark={x:StaticResource White}, Light={x:StaticResource Black}}\" />\r\n" +
        "            </toolkit:NumericalAxis.Title>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n\r\n" +
        "    <toolkit:ColumnSeries EnableAnimation=\"True\"\r\n" +
        "                            ItemsSource=\"{x:Binding Column}\"\r\n" +
        "                            PaletteBrushes=\"{x:Binding RainbowPalletBrushes}\"\r\n" +
        "                            SelectionBehavior=\"{x:StaticResource SfCartesianChartSelectionBrush}\"\r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Exp\" />\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianAppearanceSeriesGradientCSharpCode =
        "[ObservableProperty]\r\n" +
        "List<Brush> rainbowPalletBrushes;\r\n\r\n" +
        "List<Brush> createRainbowGradientPalletBrushes(int count)\r\n" +
        "{\r\n" +
        "    var allBrushes = new List<RadialGradientBrush> \r\n" +
        "    { \r\n" +
        "        new RadialGradientBrush\r\n" +
        "        { \r\n" +
        "            GradientStops = new GradientStopCollection \r\n" +
        "            { \r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(255, 231, 199) }, \r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(252, 182, 159) } \r\n" +
        "            } \r\n" +
        "        }, \r\n" +
        "        new RadialGradientBrush\r\n" +
        "        { \r\n" +
        "            GradientStops = new GradientStopCollection \r\n" +
        "            { \r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(250, 221, 125) }, \r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(252, 204, 45) } \r\n" +
        "            } \r\n" +
        "        }, \r\n" +
        "        new RadialGradientBrush\r\n" +
        "        { \r\n" +
        "            GradientStops = new GradientStopCollection \r\n" +
        "            { \r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(255, 231, 199) }, \r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(252, 182, 159) } \r\n" +
        "            } \r\n" +
        "        }, \r\n" +
        "        new RadialGradientBrush\r\n" +
        "        { \r\n" +
        "            GradientStops = new GradientStopCollection \r\n" +
        "            { \r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(221, 214, 243) }, \r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(250, 172, 168) } \r\n" +
        "            } \r\n" +
        "        }, \r\n" +
        "        new RadialGradientBrush\r\n" +
        "        { \r\n" +
        "            GradientStops = new GradientStopCollection \r\n" +
        "            { \r\n" +
        "                new GradientStop { Offset = 1, Color = Color.FromRgb(168, 234, 238) }, \r\n" +
        "                new GradientStop { Offset = 0, Color = Color.FromRgb(123, 176, 249) } \r\n" +
        "            } \r\n" +
        "        },\r\n" +
        "    };\r\n\r\n" +
        "    var brush = new List<Brush>();\r\n" +
        "    allBrushes.Take(count).ToList().ForEach(item => { brush.Add(item); });\r\n\r\n" +
        "    return brush;\r\n" +
        "}";

    [ObservableProperty]
    string cartesianPlottingCustomizationXamlCode =
        "<toolkit:SfCartesianChart>\r\n" +
        "    <toolkit:SfCartesianChart.PlotAreaBackgroundView>\r\n" +
        "        <AbsoluteLayout>\r\n" +
        "            <Label Text=\"Copyright @ 2001 - 2022 Syncfusion Inc\"\r\n" +
        "                    FontSize=\"18\" AbsoluteLayout.LayoutBounds=\"1,1,-1,-1\"\r\n" +
        "                    AbsoluteLayout.LayoutFlags=\"PositionProportional\"\r\n" +
        "                    Opacity=\"0.4\"/>\r\n" +
        "            <Label Text=\"CONFIDENTIAL\"\r\n" +
        "                    Rotation=\"340\"\r\n" +
        "                    FontSize=\"80\"\r\n" +
        "                    FontAttributes=\"Bold,Italic\"\r\n" +
        "                    TextColor=\"Gray\"\r\n" +
        "                    Margin=\"10,0,0,0\"\r\n" +
        "                    AbsoluteLayout.LayoutBounds=\"0.5,0.5,-1,-1\"\r\n" +
        "                    AbsoluteLayout.LayoutFlags=\"PositionProportional\"\r\n" +
        "                    Opacity=\"0.3\"/>\r\n" +
        "        </AbsoluteLayout>\r\n" +
        "    </toolkit:SfCartesianChart.PlotAreaBackgroundView>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianNumericalPlotBandXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Line Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis ShowMajorGridLines=\"false\" Interval=\"2\" PlotOffsetStart=\"10\" PlotOffsetEnd=\"10\" AxisLineOffset=\"10\">\r\n" +
        "            <toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"10\">\r\n" +
        "                </toolkit:ChartAxisTickStyle>\r\n" +
        "            </toolkit:CategoryAxis.MajorTickStyle>\r\n" +
        "        </toolkit:CategoryAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" Minimum=\"0\" Interval=\"20\">\r\n" +
        "            <toolkit:NumericalAxis.LabelStyle>\r\n" +
        "                <toolkit:ChartAxisLabelStyle LabelFormat=\"0'%\"/>\r\n" +
        "            </toolkit:NumericalAxis.LabelStyle>\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.PlotBands>\r\n" +
        "                <toolkit:NumericalPlotBandCollection>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"25\" End=\"40\" Fill=\"Orange\"/>\r\n" +
        "                </toolkit:NumericalPlotBandCollection>\r\n" +
        "            </toolkit:NumericalAxis.PlotBands>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:LineSeries Label=\"Line 1\" EnableTooltip=\"True\" EnableAnimation=\"True\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{x:Binding FirstLine}\" \r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Value\" \r\n" +
        "                            ShowMarkers=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianDateTimePlotBandXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                            Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Legend>\r\n" +
        "        <toolkit:ChartLegend ToggleSeriesVisibility=\"True\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Legend>\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Line Chart\" Margin=\"0\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:DateTimeAxis>\r\n" +
        "            <toolkit:DateTimeAxis.PlotBands>\r\n" +
        "                <toolkit:DateTimePlotBandCollection>\r\n" +
        "                    <toolkit:DateTimePlotBand Start=\"2022-05-04\" End=\"2022-05-06\" Fill=\"Orange\"/>\r\n" +
        "                </toolkit:DateTimePlotBandCollection>\r\n" +
        "            </toolkit:DateTimeAxis.PlotBands>\r\n" +
        "        </toolkit:DateTimeAxis>\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"40\" Minimum=\"20\" Interval=\"5\">\r\n" +
        "            <toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "                <toolkit:ChartLineStyle StrokeWidth=\"0\">\r\n" +
        "                </toolkit:ChartLineStyle>\r\n" +
        "            </toolkit:NumericalAxis.AxisLineStyle>\r\n" +
        "            <toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "                <toolkit:ChartAxisTickStyle TickSize=\"0\" />\r\n" +
        "            </toolkit:NumericalAxis.MajorTickStyle>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:LineSeries Label=\"Line 1\" EnableTooltip=\"True\" EnableAnimation=\"True\" StrokeWidth=\"1\" \r\n" +
        "                            ItemsSource=\"{x:Binding ComponentData,Source={x:Reference root}}\" \r\n" +
        "                            XBindingPath=\"Date\" YBindingPath=\"High\" \r\n" +
        "                            ShowMarkers=\"True\" LegendIcon=\"SeriesType\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianRecursivePlotBandXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Recursive Plot Band Column Sample Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" Minimum=\"0\">\r\n" +
        "            <toolkit:NumericalAxis.PlotBands>\r\n" +
        "                <toolkit:NumericalPlotBandCollection>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"0\" End=\"10\" IsRepeatable=\"True\"\r\n" +
        "                                               RepeatUntil=\"100\" RepeatEvery=\"20\" Fill=\"LightGray\"/>\r\n" +
        "                </toolkit:NumericalPlotBandCollection>\r\n" +
        "            </toolkit:NumericalAxis.PlotBands>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:LineSeries EnableAnimation=\"True\" ShowMarkers=\"True\"\r\n" +
        "                            ItemsSource=\"{x:Binding FirstLine}\" \r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Value\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianSegmentedPlotBandXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Segmented Plot Band Column Sample Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" Minimum=\"0\">\r\n" +
        "            <toolkit:NumericalAxis.PlotBands>\r\n" +
        "                <toolkit:NumericalPlotBandCollection>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"0\" End=\"25\" AssociatedAxisEnd=\"0.5\"\r\n" +
        "                                               Fill=\"#B300E190\" Text=\"Low\"/>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"35\" End=\"65\" AssociatedAxisStart=\"2.5\" AssociatedAxisEnd=\"4\"\r\n" +
        "                                               Fill=\"#B3FCD404\" Text=\"Average\"/>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"75\" End=\"100\" AssociatedAxisStart=\"5.5\"\r\n" +
        "                                                Fill=\"#B3FF4E4E\" Text=\"High\"/>\r\n" +
        "                </toolkit:NumericalPlotBandCollection>\r\n" +
        "            </toolkit:NumericalAxis.PlotBands>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:LineSeries EnableAnimation=\"True\" ShowMarkers=\"True\"\r\n" +
        "                            ItemsSource=\"{x:Binding FirstLine}\" \r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Value\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";

    [ObservableProperty]
    string cartesianPlotLineXamlCode =
        "<toolkit:SfCartesianChart HorizontalOptions=\"Fill\" VerticalOptions=\"Fill\"\r\n" +
        "                          Margin=\"0, 0, 20, 0\">\r\n" +
        "    <toolkit:SfCartesianChart.Title>\r\n" +
        "        <Label Text=\"Plot Line Column Sample Chart\" Margin=\"0,0,0,5\" HorizontalOptions=\"Fill\" HorizontalTextAlignment=\"Center\" VerticalOptions=\"Center\" FontSize=\"16\" />\r\n" +
        "    </toolkit:SfCartesianChart.Title>\r\n" +
        "    <toolkit:SfCartesianChart.XAxes>\r\n" +
        "        <toolkit:CategoryAxis LabelPlacement=\"BetweenTicks\" IsVisible=\"true\" ShowMajorGridLines=\"false\" />\r\n" +
        "    </toolkit:SfCartesianChart.XAxes>\r\n" +
        "    <toolkit:SfCartesianChart.YAxes>\r\n" +
        "        <toolkit:NumericalAxis Maximum=\"100\" Minimum=\"0\">\r\n" +
        "            <toolkit:NumericalAxis.PlotBands>\r\n" +
        "                <toolkit:NumericalPlotBandCollection>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"20\" End=\"20\"\r\n" +
        "                                               Fill=\"#B300E190\" Stroke=\"#B300E190\"\r\n" +
        "                                               StrokeWidth=\"2\"/>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"40\" End=\"40\" \r\n" +
        "                                               Fill=\"#FCD404\" Stroke=\"#FCD404\"\r\n" +
        "                                               StrokeWidth=\"2\"/>\r\n" +
        "                    <toolkit:NumericalPlotBand Start=\"70\" End=\"70\" \r\n" +
        "                                               Fill=\"#FF4E4E\" Stroke=\"#FF4E4E\"\r\n" +
        "                                               StrokeWidth=\"2\"/>\r\n" +
        "                </toolkit:NumericalPlotBandCollection>\r\n" +
        "            </toolkit:NumericalAxis.PlotBands>\r\n" +
        "        </toolkit:NumericalAxis>\r\n" +
        "    </toolkit:SfCartesianChart.YAxes>\r\n" +
        "    <toolkit:SfCartesianChart.Series>\r\n" +
        "        <toolkit:LineSeries EnableAnimation=\"True\" ShowMarkers=\"True\"\r\n" +
        "                            ItemsSource=\"{x:Binding FirstLine}\" \r\n" +
        "                            XBindingPath=\"Name\" YBindingPath=\"Value\"/>\r\n" +
        "    </toolkit:SfCartesianChart.Series>\r\n" +
        "</toolkit:SfCartesianChart>";
    #endregion
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        IsRefreshing = true;

        LoadDataAsync().FireAndForget();

        IsRefreshing = false;
    }

    [RelayCommand]
    async Task LoadChartOption()
    {
        if (ChartOptions != null)
        {
            if (string.IsNullOrEmpty(ChartsSelectedOption))
            {
                ChartsSelectedOption = ChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadAreaDefaultChartOption()
    {
        if (AreaChartOptions != null)
        {
            if (string.IsNullOrEmpty(AreaSelectedOption))
            {
                AreaSelectedOption = AreaChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadColumnBarDefaultChartOption()
    {
        if (BarChartOptions != null || ColumnChartOptions != null)
        {
            if (string.IsNullOrEmpty(ColumnBarSelectedOption))
            {
                ColumnBarSelectedOption = BarChartOptions!.FirstOrDefault()! ?? ColumnChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadLineDefaultChartOption()
    {
        if (LineChartOptions != null)
        {
            if (string.IsNullOrEmpty(LineSelectedOption))
            {
                LineSelectedOption = LineChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadScatterDefaultChartOption()
    {
        if (ScatterChartOptions != null)
        {
            if (string.IsNullOrEmpty(ScatterSelectedOption))
            {
                ScatterSelectedOption = ScatterChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadHistogramDefaultChartOption()
    {
        if (HistogramChartOptions != null)
        {
            if (string.IsNullOrEmpty(HistogramSelectedOption))
            {
                HistogramSelectedOption = HistogramChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadBoxPlotDefaultChartOption()
    {
        if (BoxPlotChartOptions != null)
        {
            if (string.IsNullOrEmpty(BoxPlotSelectedOption))
            {
                BoxPlotSelectedOption = BoxPlotChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadBubbleDefaultChartOption()
    {
        if (BubbleChartOptions != null)
        {
            if (string.IsNullOrEmpty(BubbleSelectedOption))
            {
                BubbleSelectedOption = BubbleChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadFinancialDefaultChartOption()
    {
        if (FinancialChartOptions != null)
        {
            if (string.IsNullOrEmpty(FinancialSelectedOption))
            {
                FinancialSelectedOption = FinancialChartOptions.FirstOrDefault()!;
            }
        }
    }

    [RelayCommand]
    async Task LoadWaterfallDefaultChartOption()
    {
        if (WaterfallChartOptions != null)
        {
            if (string.IsNullOrEmpty(WaterfallSelectedOption))
            {
                WaterfallSelectedOption = WaterfallChartOptions.FirstOrDefault()!;
            }
        }
    }
    #endregion

    #region [ Methods ]
    private async Task LoadDataAsync()
    {
        CrossingAxis = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Value = -7, Size = -3 },
            new SfCartesianChartModel() { Value = -4.5, Size = -2 },
            new SfCartesianChartModel() { Value = -3.5, Size = 0 },
            new SfCartesianChartModel() { Value = -3, Size = 2 },
            new SfCartesianChartModel() { Value = 0, Size = 7 },
            new SfCartesianChartModel() { Value =3, Size = 2 },
            new SfCartesianChartModel() { Value =3.5, Size = 0 },
            new SfCartesianChartModel() { Value =4.5, Size = -2 },
            new SfCartesianChartModel() { Value = 7, Size = -3 },
        };

        Annotation = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 02), Size = 350, Value = 100 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 09), Size = 470, Value = 200 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 16), Size = 500, Value = 400 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 03, 23), Size = 530, Value = 600 }
        };

        Area = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Strypper", High = 4.17, Low = 0.72, Size = 2.48, Value = 1.23 },
            new SfCartesianChartModel() { Name = "Tan", High = 3.51, Low = 1.64, Size = 2.43, Value = 4.17 },
            new SfCartesianChartModel() { Name = "Hung", High = 2.01, Low = 2.71, Size = 3.47, Value = 3.17 },
            new SfCartesianChartModel() { Name = "Long", High = 1.95, Low = 3.63, Size = 2.41, Value = 3.20 },
            new SfCartesianChartModel() { Name = "Dat", High = 3.95, Low = 2.63, Size = 0.41, Value = 1.20 }
        };

        RangeArea = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 01).Date, High = 36, Low = 13, Value = 24.5},
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 02).Date, High = 33, Low = 16, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 03).Date, High = 33, Low = 15, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 04).Date, High = 32, Low = 12, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 05).Date, High = 38, Low = 11, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 06).Date, High = 37, Low = 11, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 07).Date, High = 36, Low = 13, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 08).Date, High = 35, Low = 14, Value = 24.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 09).Date, High = 39, Low = 14, Value = 26.5 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 10).Date, High = 37, Low = 15, Value = 26 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 11).Date, High = 36, Low = 16, Value = 26 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 12).Date, High = 35, Low = 17, Value = 26 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 13).Date, High = 35, Low = 13, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 14).Date, High = 36, Low = 12, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 15).Date, High = 37, Low = 11, Value = 24 },
            new SfCartesianChartModel() { Date = new DateTime(2022, 05, 16).Date, High = 31, Low = 15, Value = 23 }
        };

        StackingArea = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { High = 0.61, Low = 0.03, Value = 0.48, Size = 0.23, Year = "2001"},
            new SfCartesianChartModel() { High = 0.81, Low = 0.05, Value = 0.53, Size = 0.17, Year = "2002" },
            new SfCartesianChartModel() { High = 0.91, Low = 0.06, Value = 0.57, Size = 0.17, Year = "2003" },
            new SfCartesianChartModel() { High = 1.00, Low = 0.09, Value = 0.61, Size = 0.20, Year = "2004" },
            new SfCartesianChartModel() { High = 1.19, Low = 0.14, Value = 0.63, Size = 0.23, Year = "2005" },
            new SfCartesianChartModel() { High = 1.47, Low = 0.20, Value = 0.64, Size = 0.36, Year = "2006" },
            new SfCartesianChartModel() { High = 1.74, Low = 0.29, Value = 0.66, Size = 0.43, Year = "2007" },
            new SfCartesianChartModel() { High = 1.98, Low = 0.46, Value = 0.76, Size = 0.52, Year = "2008" },
            new SfCartesianChartModel() { High = 1.99, Low = 0.64, Value = 0.77, Size = 0.72, Year = "2009" },
            new SfCartesianChartModel() { High = 1.70, Low = 0.75, Value = 0.55, Size = 1.29, Year = "2010" },
            new SfCartesianChartModel() { High = 1.48, Low = 1.06, Value = 0.54, Size = 1.38, Year = "2011" },
            new SfCartesianChartModel() { High = 1.38, Low = 1.25, Value = 0.57, Size = 1.82, Year = "2012" }
        };

        Bar = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Strypper", Exp = 100, High = 10, Low = 1 },
            new SfCartesianChartModel() { Name = "Tan", Exp = 50, High = 15, Low = 1 },
            new SfCartesianChartModel() { Name = "Hung", Exp = 40, High = 10, Low = 1 },
            new SfCartesianChartModel() { Name = "Long", Exp = 20, High = 15, Low = 1 },
            new SfCartesianChartModel() { Name = "Dat", Exp = 30, High = 10, Low = 1 }
        };

        RangeBar = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "January", High = 7, Low = 3 },
            new SfCartesianChartModel() { Name = "February", High = 8, Low = 3 },
            new SfCartesianChartModel() { Name = "March", High = 12, Low = 5 },
            new SfCartesianChartModel() { Name = "April", High = 16, Low = 7 },
            new SfCartesianChartModel() { Name = "May", High = 20, Low = 11 },
            new SfCartesianChartModel() { Name = "June", High = 23, Low = 14 },
            new SfCartesianChartModel() { Name = "July", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "August", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "September", High = 21, Low = 13 },
            new SfCartesianChartModel() { Name = "October", High = 16, Low = 10 },
            new SfCartesianChartModel() { Name = "November", High = 11, Low = 6 },
            new SfCartesianChartModel() { Name = "December", High = 8, Low = 3 }
        };

        StackingBar = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Product 1", High = 3.932, Low = -3.987, Value = -5.067, Size = 13.012 },
            new SfCartesianChartModel() { Name = "Product 2", High = -5.432, Low = 3.417, Value = 15.067, Size = 12.321 },
            new SfCartesianChartModel() { Name = "Product 3", High = -4.229, Low = -4.376, Value = -3.504, Size = 12.814 },
            new SfCartesianChartModel() { Name = "Product 4", High = -9.256, Low = 4.376, Value = 9.054, Size = 8.814},
            new SfCartesianChartModel() { Name = "Product 5", High = 5.221, Low = -3.574, Value = -7.004, Size = 11.624}
        };

        Column = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Strypper", Exp = 100, Value = 80, Size = 60, Number = 1 },
            new SfCartesianChartModel() { Name = "Tan", Exp = 50, Value = 70, Size = 90, Number = 2 },
            new SfCartesianChartModel() { Name = "Hung", Exp = 40, Value = 80, Size = 60, Number = 3 },
            new SfCartesianChartModel() { Name = "Long", Exp = 20, Value = 40, Size = 80, Number = 4},
            new SfCartesianChartModel() { Name = "Dat", Exp = 30, Value = 60, Size = 90, Number = 5}
        };

        RangeColumn = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "January", High = 7, Low = 3 },
            new SfCartesianChartModel() { Name = "February", High = 8, Low = 3 },
            new SfCartesianChartModel() { Name = "March", High = 12, Low = 5 },
            new SfCartesianChartModel() { Name = "April", High = 16, Low = 7 },
            new SfCartesianChartModel() { Name = "May", High = 20, Low = 11 },
            new SfCartesianChartModel() { Name = "June", High = 23, Low = 14 },
            new SfCartesianChartModel() { Name = "July", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "August", High = 25, Low = 16 },
            new SfCartesianChartModel() { Name = "September", High = 21, Low = 13 },
            new SfCartesianChartModel() { Name = "October", High = 16, Low = 10 },
            new SfCartesianChartModel() { Name = "November", High = 11, Low = 6 },
            new SfCartesianChartModel() { Name = "December", High = 8, Low = 3 }
        };

        StackingColumn = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "Product 1", High = 15.767, Low = 9.726, Value = 24.769 },
            new SfCartesianChartModel() { Name = "Product 2", High = 17.471, Low = 10.206, Value = 24.790 },
            new SfCartesianChartModel() { Name = "Product 3", High = 18.097, Low = 11.057, Value = 26.170 },
            new SfCartesianChartModel() { Name = "Product 4", High = 20.056, Low = 10.946, Value = 24.795 },
            new SfCartesianChartModel() { Name = "Product 5", High = 19.739, Low = 11.164, Value = 23.533 }
        };

        FirstLine = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "2005", Value = 21 },
            new SfCartesianChartModel() { Name = "2006", Value = 24 },
            new SfCartesianChartModel() { Name = "2007", Value = 36 },
            new SfCartesianChartModel() { Name = "2008", Value = 38 },
            new SfCartesianChartModel() { Name = "2009", Value = 54 },
            new SfCartesianChartModel() { Name = "2010", Value = 57 },
            new SfCartesianChartModel() { Name = "2011", Value = 70 }
        };

        SecondLine = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "2005", Value = 28 },
            new SfCartesianChartModel() { Name = "2006", Value = 44 },
            new SfCartesianChartModel() { Name = "2007", Value = 48 },
            new SfCartesianChartModel() { Name = "2008", Value = 50 },
            new SfCartesianChartModel() { Name = "2009", Value = 66 },
            new SfCartesianChartModel() { Name = "2010", Value = 78 },
            new SfCartesianChartModel() { Name = "2011", Value = 84 }
        };

        ThirdLine = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "2005", Value = 32 },
            new SfCartesianChartModel() { Name = "2006", Value = 44 },
            new SfCartesianChartModel() { Name = "2007", Value = 52 },
            new SfCartesianChartModel() { Name = "2008", Value = 55 },
            new SfCartesianChartModel() { Name = "2009", Value = 70 },
            new SfCartesianChartModel() { Name = "2010", Value = 78 },
            new SfCartesianChartModel() { Name = "2011", Value = 90 }
        };

        var randomNumber = new Random();
        FastLine = new ObservableCollection<SfCartesianChartModel>(
            Enumerable.Range(0, 500).Select(item => 
            { 
                var date = new DateTime(1900, 1, 1).AddHours(6 * item); 
                var value = 100 + Enumerable.Range(0, item).Sum(j => randomNumber.NextDouble() * (randomNumber.NextDouble() > 0.5 ? 1 : -1));
                return new SfCartesianChartModel { Date = date, Value = Math.Round(value, 2) }; 
            }));

        FirstScatter = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Value = 161, Size = 65 }, new SfCartesianChartModel() { Value = 150, Size = 65 }, new SfCartesianChartModel() { Value = 155, Size = 65 },
            new SfCartesianChartModel() { Value = 160, Size = 65 }, new SfCartesianChartModel() { Value = 148, Size = 66 }, new SfCartesianChartModel() { Value = 145, Size = 66 },
            new SfCartesianChartModel() { Value = 137, Size = 66 }, new SfCartesianChartModel() { Value = 138, Size = 66 }, new SfCartesianChartModel() { Value = 162, Size = 66 },
            new SfCartesianChartModel() { Value = 166, Size = 66 }, new SfCartesianChartModel() { Value = 159, Size = 66 }, new SfCartesianChartModel() { Value = 151, Size = 66 },
            new SfCartesianChartModel() { Value = 180, Size = 66 }, new SfCartesianChartModel() { Value = 181, Size = 66 }, new SfCartesianChartModel() { Value = 174, Size = 66 },
            new SfCartesianChartModel() { Value = 159, Size = 66 }, new SfCartesianChartModel() { Value = 151, Size = 67 }, new SfCartesianChartModel() { Value = 148, Size = 67 },
            new SfCartesianChartModel() { Value = 141, Size = 67 }, new SfCartesianChartModel() { Value = 145, Size = 67 }, new SfCartesianChartModel() { Value = 165, Size = 67 },
            new SfCartesianChartModel() { Value = 168, Size = 67 }, new SfCartesianChartModel() { Value = 159, Size = 67 }, new SfCartesianChartModel() { Value = 183, Size = 67 },
            new SfCartesianChartModel() { Value = 188, Size = 67 }, new SfCartesianChartModel() { Value = 187, Size = 67 }, new SfCartesianChartModel() { Value = 172, Size = 67 },
            new SfCartesianChartModel() { Value = 193, Size = 67 }, new SfCartesianChartModel() { Value = 153, Size = 68 }, new SfCartesianChartModel() { Value = 153, Size = 68 },
            new SfCartesianChartModel() { Value = 147, Size = 68 }, new SfCartesianChartModel() { Value = 163, Size = 68 }, new SfCartesianChartModel() { Value = 174, Size = 68 },
            new SfCartesianChartModel() { Value = 173, Size = 68 }, new SfCartesianChartModel() { Value = 160, Size = 68 }, new SfCartesianChartModel() { Value = 191, Size = 68 },
            new SfCartesianChartModel() { Value = 131, Size = 62 }, new SfCartesianChartModel() { Value = 140, Size = 62 }, new SfCartesianChartModel() { Value = 149, Size = 62 },
            new SfCartesianChartModel() { Value = 115, Size = 62 }, new SfCartesianChartModel() { Value = 164, Size = 63 }, new SfCartesianChartModel() { Value = 162, Size = 63 },
            new SfCartesianChartModel() { Value = 167, Size = 63 }, new SfCartesianChartModel() { Value = 146, Size = 63 }, new SfCartesianChartModel() { Value = 150, Size = 64 },
            new SfCartesianChartModel() { Value = 141, Size = 64 }, new SfCartesianChartModel() { Value = 142, Size = 64 }, new SfCartesianChartModel() { Value = 129, Size = 64 },
            new SfCartesianChartModel() { Value = 159, Size = 64 }, new SfCartesianChartModel() { Value = 158, Size = 64 }, new SfCartesianChartModel() { Value = 162, Size = 64 },
            new SfCartesianChartModel() { Value = 136, Size = 64 }, new SfCartesianChartModel() { Value = 176, Size = 64 }, new SfCartesianChartModel() { Value = 170, Size = 64 },
            new SfCartesianChartModel() { Value = 167, Size = 64 }, new SfCartesianChartModel() { Value = 144, Size = 64 }, new SfCartesianChartModel() { Value = 143, Size = 65 },
            new SfCartesianChartModel() { Value = 137, Size = 65 }, new SfCartesianChartModel() { Value = 137, Size = 65 }, new SfCartesianChartModel() { Value = 140, Size = 65 },
        };

        SecondScatter = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Value = 115, Size = 57 }, new SfCartesianChartModel() { Value = 138, Size = 57 }, new SfCartesianChartModel() { Value = 166, Size = 57 },
            new SfCartesianChartModel() { Value = 122, Size = 57 }, new SfCartesianChartModel() { Value = 126, Size = 57 }, new SfCartesianChartModel() { Value = 130, Size = 57 },
            new SfCartesianChartModel() { Value = 125, Size = 57 }, new SfCartesianChartModel() { Value = 144, Size = 57 }, new SfCartesianChartModel() { Value = 150, Size = 57 },
            new SfCartesianChartModel() { Value = 120, Size = 57 }, new SfCartesianChartModel() { Value = 125, Size = 57 }, new SfCartesianChartModel() { Value = 130, Size = 57 },
            new SfCartesianChartModel() { Value = 103, Size = 58 }, new SfCartesianChartModel() { Value = 116, Size = 58 }, new SfCartesianChartModel() { Value = 130, Size = 58 },
            new SfCartesianChartModel() { Value = 126, Size = 58 }, new SfCartesianChartModel() { Value = 136, Size = 58 }, new SfCartesianChartModel() { Value = 148, Size = 58 },
            new SfCartesianChartModel() { Value = 119, Size = 58 }, new SfCartesianChartModel() { Value = 141, Size = 58 }, new SfCartesianChartModel() { Value = 159, Size = 58 },
            new SfCartesianChartModel() { Value = 120, Size = 58 }, new SfCartesianChartModel() { Value = 135, Size = 58 }, new SfCartesianChartModel() { Value = 163, Size = 58 },
            new SfCartesianChartModel() { Value = 119, Size = 59 }, new SfCartesianChartModel() { Value = 131, Size = 59 }, new SfCartesianChartModel() { Value = 148, Size = 59 },
            new SfCartesianChartModel() { Value = 123, Size = 59 }, new SfCartesianChartModel() { Value = 137, Size = 59 }, new SfCartesianChartModel() { Value = 149, Size = 59 },
            new SfCartesianChartModel() { Value = 121, Size = 59 }, new SfCartesianChartModel() { Value = 142, Size = 59 }, new SfCartesianChartModel() { Value = 160, Size = 59 },
            new SfCartesianChartModel() { Value = 118, Size = 59 }, new SfCartesianChartModel() { Value = 130, Size = 59 }, new SfCartesianChartModel() { Value = 146, Size = 59 },
            new SfCartesianChartModel() { Value = 119, Size = 60 }, new SfCartesianChartModel() { Value = 133, Size = 60 }, new SfCartesianChartModel() { Value = 150, Size = 60 },
            new SfCartesianChartModel() { Value = 133, Size = 60 }, new SfCartesianChartModel() { Value = 149, Size = 60 }, new SfCartesianChartModel() { Value = 165, Size = 60 },
            new SfCartesianChartModel() { Value = 130, Size = 60 }, new SfCartesianChartModel() { Value = 139, Size = 60 }, new SfCartesianChartModel() { Value = 154, Size = 60 },
            new SfCartesianChartModel() { Value = 118, Size = 60 }, new SfCartesianChartModel() { Value = 152, Size = 60 }, new SfCartesianChartModel() { Value = 154, Size = 60 },
            new SfCartesianChartModel() { Value = 130, Size = 61 }, new SfCartesianChartModel() { Value = 145, Size = 61 }, new SfCartesianChartModel() { Value = 166, Size = 61 },
            new SfCartesianChartModel() { Value = 131, Size = 61 }, new SfCartesianChartModel() { Value = 143, Size = 61 }, new SfCartesianChartModel() { Value = 162, Size = 61 },
            new SfCartesianChartModel() { Value = 131, Size = 61 }, new SfCartesianChartModel() { Value = 145, Size = 61 }, new SfCartesianChartModel() { Value = 162, Size = 61 },
            new SfCartesianChartModel() { Value = 115, Size = 61 }, new SfCartesianChartModel() { Value = 149, Size = 61 }, new SfCartesianChartModel() { Value = 183, Size = 61 },
        };

        Bubble = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "2000", Exp = 100, High = 15000, Low = 5.50 },
            new SfCartesianChartModel() { Name = "2001", Exp = 75, High = 6500, Low = 3.30 },
            new SfCartesianChartModel() { Name = "2002", Exp = 95, High = 11000, Low = 2.20 },
            new SfCartesianChartModel() { Name = "2003", Exp = 105, High = 42000, Low = 2.10 },
            new SfCartesianChartModel() { Name = "2004", Exp = 95, High = 27000, Low = 5.10 },
            new SfCartesianChartModel() { Name = "2005", Exp = 105, High = 28000, Low = 2.20 },
            new SfCartesianChartModel() { Name = "2006", Exp = 85, High = 26000, Low = 2.70 },
            new SfCartesianChartModel() { Name = "2007", Exp = 75, High = 20000, Low = 5.10 },
            new SfCartesianChartModel() { Name = "2008", Exp = 60, High = 2000, Low = 2.10 },
            new SfCartesianChartModel() { Name = "2009", Exp = 85, High = 5000, Low = 3.10 },
            new SfCartesianChartModel() { Name = "2010", Exp = 105, High = 11000, Low = 1.20 },
            new SfCartesianChartModel() { Name = "2011", Exp = 100, High = 29000, Low = 2.70 },
            new SfCartesianChartModel() { Name = "2012", Exp = 65, High = 30000, Low = 6.30 },
            new SfCartesianChartModel() { Name = "2013", Exp = 70, High = 15000, Low = 4.50 },
            new SfCartesianChartModel() { Name = "2014", Exp = 110, High = 8000, Low = 3.60 },
            new SfCartesianChartModel() { Name = "2015", Exp = 80, High = 5000, Low = 3.20 },
            new SfCartesianChartModel() { Name = "2016", Exp = 90, High = 11000, Low = 3.10 },
            new SfCartesianChartModel() { Name = "2017", Exp = 65, High = 17000, Low = 2.10 },
        };

        Box = new ObservableCollection<SfCartesianChartModel> 
        { 
            new SfCartesianChartModel() { Name = "1", Values = new List<double> { 67.4, 65.5, 72.0, 73.6, 65.2, 67.0, 66.3, 67.9, 65.8, 69.9, 64.5, 66.0, 66.8, 67.0, 69.9, 70.1, 69.7, 68.3, 67.0, 68.2, 65.0, 66.6, 65.4, 68.1 } }, 
            new SfCartesianChartModel() { Name = "2", Values = new List<double> { 69.0, 66.2, 70.0, 68.5, 66.0, 67.5, 68.5, 66.5, 73.0, 69.0, 69.0, 74.5, 68.0, 68.5, 67.5, 70.0, 69.0, 72.5, 68.0, 69.0, 69.0, 71.0, 68.0, 75.0, 67.0 } }, 
            new SfCartesianChartModel() { Name = "3", Values = new List<double> { 73.0, 78.9, 75.0, 72.3, 72.4, 74.1, 72.0, 72.0, 70.9, 74.5, 72.0, 72.5, 72.4, 74.0, 75.0, 70.9, 70.9, 76.6, 74.2, 69.5, 68.8, 68.5, 70.1, 73.0, 70.9 } }, 
            new SfCartesianChartModel() { Name = "4", Values = new List<double> { 67.6, 64.2, 65.9, 65.9, 68.2, 71.1, 67.6, 71.6, 72.8, 68.2, 67.6, 67.1, 67.1, 68.2, 65.4, 66.5, 67.6, 67.1, 71.1, 67.1, 65.4, 67.6, 67.6, 70.5, 70.5 } }, 
        };

        Histogram = new ObservableCollection<SfCartesianChartModel>
        {
            new SfCartesianChartModel() { Value = 5.250, Size = 0 }, new SfCartesianChartModel() { Value = 7.750, Size = 0 },
            new SfCartesianChartModel() { Value = 0, Size = 0 }, new SfCartesianChartModel() { Value = 8.275, Size = 0 },
            new SfCartesianChartModel() { Value = 9.750, Size = 0 }, new SfCartesianChartModel() { Value = 7.750, Size = 0 },
            new SfCartesianChartModel() { Value = 8.275, Size = 0 }, new SfCartesianChartModel() { Value = 6.250, Size = 0 },
            new SfCartesianChartModel() { Value = 5.750, Size = 0 }, new SfCartesianChartModel() { Value = 5.250, Size = 0 },
            new SfCartesianChartModel() { Value = 23.000, Size = 0 }, new SfCartesianChartModel() { Value = 26.500, Size = 0 },
            new SfCartesianChartModel() { Value = 27.750, Size = 0 }, new SfCartesianChartModel() { Value = 25.025, Size = 0 },
            new SfCartesianChartModel() { Value = 26.500, Size = 0 }, new SfCartesianChartModel() { Value = 26.500, Size = 0 },
            new SfCartesianChartModel() { Value = 28.025, Size = 0 }, new SfCartesianChartModel() { Value = 29.250, Size = 0 },
            new SfCartesianChartModel() { Value = 26.750, Size = 0 }, new SfCartesianChartModel() { Value = 27.250, Size = 0 },
            new SfCartesianChartModel() { Value = 26.250, Size = 0 }, new SfCartesianChartModel() { Value = 25.250, Size = 0 },
            new SfCartesianChartModel() { Value = 34.500, Size = 0 }, new SfCartesianChartModel() { Value = 25.625, Size = 0 },
            new SfCartesianChartModel() { Value = 25.500, Size = 0 }, new SfCartesianChartModel() { Value = 26.625, Size = 0 },
            new SfCartesianChartModel() { Value = 36.275, Size = 0 }, new SfCartesianChartModel() { Value = 36.250, Size = 0 },
            new SfCartesianChartModel() { Value = 26.875, Size = 0 }, new SfCartesianChartModel() { Value = 45.000, Size = 0 },
            new SfCartesianChartModel() { Value = 43.000, Size = 0 }, new SfCartesianChartModel() { Value = 46.500, Size = 0 },
            new SfCartesianChartModel() { Value = 47.750, Size = 0 }, new SfCartesianChartModel() { Value = 45.025, Size = 0 },
            new SfCartesianChartModel() { Value = 56.500, Size = 0 }, new SfCartesianChartModel() { Value = 56.500, Size = 0 },
            new SfCartesianChartModel() { Value = 58.025, Size = 0 }, new SfCartesianChartModel() { Value = 59.250, Size = 0 },
            new SfCartesianChartModel() { Value = 56.750, Size = 0 }, new SfCartesianChartModel() { Value = 57.250, Size = 0 },
            new SfCartesianChartModel() { Value = 46.250, Size = 0 }, new SfCartesianChartModel() { Value = 55.250, Size = 0 },
            new SfCartesianChartModel() { Value = 44.500, Size = 0 }, new SfCartesianChartModel() { Value = 45.500, Size = 0 },
            new SfCartesianChartModel() { Value = 55.500, Size = 0 }, new SfCartesianChartModel() { Value = 45.625, Size = 0 },
            new SfCartesianChartModel() { Value = 55.500, Size = 0 }, new SfCartesianChartModel() { Value = 56.250, Size = 0 },
            new SfCartesianChartModel() { Value = 46.875, Size = 0 }, new SfCartesianChartModel() { Value = 43.000, Size = 0 },
            new SfCartesianChartModel() { Value = 46.250, Size = 0 }, new SfCartesianChartModel() { Value = 55.250, Size = 0 },
            new SfCartesianChartModel() { Value = 44.500, Size = 0 }, new SfCartesianChartModel() { Value = 45.425, Size = 0 },
            new SfCartesianChartModel() { Value = 56.625, Size = 0 }, new SfCartesianChartModel() { Value = 46.275, Size = 0 },
            new SfCartesianChartModel() { Value = 56.250, Size = 0 }, new SfCartesianChartModel() { Value = 46.875, Size = 0 },
            new SfCartesianChartModel() { Value = 43.000, Size = 0 }, new SfCartesianChartModel() { Value = 46.250, Size = 0 },
            new SfCartesianChartModel() { Value = 55.250, Size = 0 }, new SfCartesianChartModel() { Value = 44.500, Size = 0 },
            new SfCartesianChartModel() { Value = 45.425, Size = 0 }, new SfCartesianChartModel() { Value = 55.500, Size = 0 },
            new SfCartesianChartModel() { Value = 46.625, Size = 0 }, new SfCartesianChartModel() { Value = 56.275, Size = 0 },
            new SfCartesianChartModel() { Value = 46.250, Size = 0 }, new SfCartesianChartModel() { Value = 56.250, Size = 0 },
            new SfCartesianChartModel() { Value = 42.000, Size = 0 }, new SfCartesianChartModel() { Value = 41.000, Size = 0 },
            new SfCartesianChartModel() { Value = 63.000, Size = 0 }, new SfCartesianChartModel() { Value = 66.500, Size = 0 },
            new SfCartesianChartModel() { Value = 67.750, Size = 0 }, new SfCartesianChartModel() { Value = 65.025, Size = 0 },
            new SfCartesianChartModel() { Value = 66.500, Size = 0 }, new SfCartesianChartModel() { Value = 76.500, Size = 0 },
            new SfCartesianChartModel() { Value = 78.025, Size = 0 }, new SfCartesianChartModel() { Value = 79.250, Size = 0 },
            new SfCartesianChartModel() { Value = 76.750, Size = 0 }, new SfCartesianChartModel() { Value = 77.250, Size = 0 },
            new SfCartesianChartModel() { Value = 66.250, Size = 0 }, new SfCartesianChartModel() { Value = 75.250, Size = 0 },
            new SfCartesianChartModel() { Value = 74.500, Size = 0 }, new SfCartesianChartModel() { Value = 65.625, Size = 0 },
            new SfCartesianChartModel() { Value = 75.500, Size = 0 }, new SfCartesianChartModel() { Value = 76.625, Size = 0 },
            new SfCartesianChartModel() { Value = 76.275, Size = 0 }, new SfCartesianChartModel() { Value = 66.250, Size = 0 },
            new SfCartesianChartModel() { Value = 66.875, Size = 0 }, new SfCartesianChartModel() { Value = 82.000, Size = 0 },
            new SfCartesianChartModel() { Value = 85.250, Size = 0 }, new SfCartesianChartModel() { Value = 87.750, Size = 0 },
            new SfCartesianChartModel() { Value = 92.000, Size = 0 }, new SfCartesianChartModel() { Value = 85.250, Size = 0 },
            new SfCartesianChartModel() { Value = 87.750, Size = 0 }, new SfCartesianChartModel() { Value = 89.000, Size = 0 },
            new SfCartesianChartModel() { Value = 88.275, Size = 0 }, new SfCartesianChartModel() { Value = 89.750, Size = 0 },
            new SfCartesianChartModel() { Value = 95.750, Size = 0 }, new SfCartesianChartModel() { Value = 95.250, Size = 0 }
        };

        Financial = new ObservableCollection<SfCartesianChartModel>
        {
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 31), High = 97.87, Low = 95.78, Value = 97.07, Size = 96.97 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 30), High = 98.66, Low = 96.55, Value = 96.95, Size = 97.18 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 29), High = 98.87, Low = 94.70, Value = 98.87, Size = 95.25 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 28), High = 100.97, Low = 98.20, Value = 100.03, Size = 98.31 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 24), High = 98.93, Low = 97.11, Value = 98.69, Size = 98.90 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 23), High = 99.60, Low = 97.08, Value = 98.12, Size = 97.18 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 22), High = 99.66, Low = 97.64, Value = 98.35, Size = 97.94 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 21), High = 98.46, Low = 96.40, Value = 97.22, Size = 97.56 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 18), High = 101.73, Low = 98.12, Value = 101.22, Size = 98.79 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 17), High = 102.04, Low = 98.91, Value = 101.29, Size = 100.62 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 16), High = 101.60, Low = 98.12, Value = 101.20, Size = 100.05 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 15), High = 104.41, Low = 99.85, Value = 104.41, Size = 100.49 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 14), High = 101.55, Low = 98.92, Value = 99.57, Size = 100.83 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 11), High = 99.60, Low = 96.00, Value = 96.81, Size = 98.11 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 10), High = 97.89, Low = 95.64, Value = 96.74, Size = 97.63 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 9), High = 104.43, Low = 96.43, Value = 103.16, Size = 97.41 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 8), High = 102.65, Low = 99.68, Value = 99.71, Size = 102.33 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 7), High = 101.97, Low = 99.83, Value = 101.49, Size = 100.17 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 4), High = 101.87, Low = 98.08, Value = 98.08, Size = 100.92 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 3), High = 101.37, Low = 97.66, Value = 100.57, Size = 97.91 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 2), High = 100.05, Low = 98.12, Value = 100.00, Size = 99.99 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 12, 1), High = 100.73, Low = 97.25, Value = 97.54, Size = 99.75 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 30), High = 97.89, Low = 95.42, Value = 97.38, Size = 96.46 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 27), High = 97.63, Low = 94.50, Value = 94.50, Size = 97.38 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 25), High = 98.65, Low = 94.20, Value = 97.40, Size = 94.40 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 24), High = 97.71, Low = 94.24, Value = 95.85, Size = 96.22 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 23), High = 94.71, Low = 90.80, Value = 91.03, Size = 94.48 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 20), High = 91.31, Low = 89.00, Value = 89.08, Size = 90.09 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 19), High = 90.06, Low = 88.17, Value = 88.35, Size = 89.95 },
            new SfCartesianChartModel() { Date = new DateTime(2020, 11, 18), High = 90.32, Low = 88.09, Value = 89.31, Size = 88.52 }
        };

        Waterfall = new ObservableCollection<SfCartesianChartModel>()
        {
            new SfCartesianChartModel() { Name = "January", Value = 25 },
            new SfCartesianChartModel() { Name = "February", Value = 22.5 },
            new SfCartesianChartModel() { Name = "March", Value = -10 },
            new SfCartesianChartModel() { Name = "April", Value = 23 },
            new SfCartesianChartModel() { Name = "May", Value = 7 },
            new SfCartesianChartModel() { Name = "June", Value = -15 },
            new SfCartesianChartModel() { Name = "July", Value = -8 },
            new SfCartesianChartModel() { Name = "August", Value = -6 },
            new SfCartesianChartModel() { Name = "September", Value = -9 },
            new SfCartesianChartModel() { Name = "October", Value = 22.5 },
            new SfCartesianChartModel() { Name = "November", Value = 12 },
            new SfCartesianChartModel() { Name = "December", Value = -30 },
            new SfCartesianChartModel() { Name = "Total", Value = 34, IsSummary = true }
        };

        ColdPalletBrushes = new List<Brush>(CreateColdGradientPalletBrushes(5));

        RainbowPalletBrushes = new List<Brush>(CreateRainbowGradientPalletBrushes(5));

        ChartOptions = new ObservableCollection<string>
        {
            "Area", "Column", "Line", "Scatter", "Histogram", "Box Plot", "Bubble", "Financial", "Waterfall"
        };

        AreaChartOptions = new ObservableCollection<string>
        {
            "Area", "Spline Area", "Step Area", "Range Area", "Spline Range Area", "Stacking Area", "100% Stacking Area"
        };

        BarChartOptions = new ObservableCollection<string>
        {
            "Bar", "Error Bar", "Range Bar", "Stacking Bar", "Stacking Bar 100"
        };

        ColumnChartOptions = new ObservableCollection<string>
        {
            "Column", "Range Column", "Stacking Column", "Stacking Column 100"
        };

        LineChartOptions = new ObservableCollection<string>
        {
            "Line", "Spline", "Step Line", "Stacking Line", "Stacking Line 100", "Fast Line"
        };

        ScatterChartOptions = new ObservableCollection<string>
        {
            "Scatter",
        };

        HistogramChartOptions = new ObservableCollection<string>
        {
            "Histogram",
        };

        BoxPlotChartOptions = new ObservableCollection<string>
        {
            "Box And Whisker",
        };

        BubbleChartOptions = new ObservableCollection<string>
        {
            "Bubble",
        };

        FinancialChartOptions = new ObservableCollection<string>
        {
            "Candle", "OHLC"
        };

        WaterfallChartOptions = new ObservableCollection<string>
        {
            "Waterfall",
        };


        ErrorBarTypes = new();
        ErrorBarModes = new();
        ErrorBarDirections = new();

        ErrorBarTypes = Enum.GetNames(typeof(ErrorBarType)).ToObservableCollection();
        ErrorBarModes = Enum.GetNames(typeof(ErrorBarMode)).ToObservableCollection();
        ErrorBarDirections = Enum.GetNames(typeof(ErrorBarDirection)).ToObservableCollection();
    }

    List<Brush> CreateRainbowGradientPalletBrushes(int count)
    {
        var allBrushes = new List<RadialGradientBrush> 
        { 
            new RadialGradientBrush
            { 
                GradientStops = new GradientStopCollection 
                { 
                    new GradientStop { Offset = 1, Color = Color.FromRgb(255, 231, 199) }, 
                    new GradientStop { Offset = 0, Color = Color.FromRgb(252, 182, 159) } 
                } 
            }, 
            new RadialGradientBrush
            { 
                GradientStops = new GradientStopCollection 
                { 
                    new GradientStop { Offset = 1, Color = Color.FromRgb(250, 221, 125) }, 
                    new GradientStop { Offset = 0, Color = Color.FromRgb(252, 204, 45) } 
                } 
            }, 
            new RadialGradientBrush
            { 
                GradientStops = new GradientStopCollection 
                { 
                    new GradientStop { Offset = 1, Color = Color.FromRgb(255, 231, 199) }, 
                    new GradientStop { Offset = 0, Color = Color.FromRgb(252, 182, 159) } 
                } 
            }, 
            new RadialGradientBrush
            { 
                GradientStops = new GradientStopCollection 
                { 
                    new GradientStop { Offset = 1, Color = Color.FromRgb(221, 214, 243) }, 
                    new GradientStop { Offset = 0, Color = Color.FromRgb(250, 172, 168) } 
                } 
            }, 
            new RadialGradientBrush
            { 
                GradientStops = new GradientStopCollection 
                { 
                    new GradientStop { Offset = 1, Color = Color.FromRgb(168, 234, 238) }, 
                    new GradientStop { Offset = 0, Color = Color.FromRgb(123, 176, 249) } 
                } 
            },
        };

        var brush = new List<Brush>();
        allBrushes.Take(count).ToList().ForEach(item => { brush.Add(item); });

        return brush;
    }

    List<Brush> CreateColdGradientPalletBrushes(int count)
    {
        var allBrushes = new List<LinearGradientBrush>
        {
            new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop { Offset = 1, Color = Color.FromRgb(0, 255, 255) },
                    new GradientStop { Offset = 0, Color = Color.FromRgb(0, 191, 255) }
                }
            },
            new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop { Offset = 1, Color = Color.FromRgb(0, 191, 255) },
                    new GradientStop { Offset = 0, Color = Color.FromRgb(0, 128, 255) }
                }
            },
            new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop { Offset = 1, Color = Color.FromRgb(0, 128, 255) },
                    new GradientStop { Offset = 0, Color = Color.FromRgb(0, 64, 255) }
                }
            },
            new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop { Offset = 1, Color = Color.FromRgb(0, 64, 255) },
                    new GradientStop { Offset = 0, Color = Color.FromRgb(0, 0, 255) }
                }
            },
            new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop { Offset = 1, Color = Color.FromRgb(0, 0, 255) },
                    new GradientStop { Offset = 0, Color = Color.FromRgb(0, 0, 191) }
                }
            }
        };

        var brush = new List<Brush>();
        allBrushes.Take(count).ToList().ForEach(item => { brush.Add(item); });

        return brush;
    }
    #endregion
}