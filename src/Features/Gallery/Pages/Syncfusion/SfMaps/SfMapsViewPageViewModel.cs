namespace MAUIsland;
public partial class SfMapsViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfMapsViewPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
        Data = new ObservableCollection<Model>();
        Data.Add(new Model("New South Wales", "New\nSouth Wales", 1));
        Data.Add(new Model("Queensland", "Queensland", 2));
        Data.Add(new Model("Northern Territory", "Northern\nTerritory", 3));
        Data.Add(new Model("Victoria", "Victoria", 4));
        Data.Add(new Model("Tasmania", "Tasmania", 5));
        Data.Add(new Model("Western Australia", "Western Australia", 6));
        Data.Add(new Model("South Australia", "South Australia", 7));

        DataSize = new ObservableCollection<MapTooltipData>();
        DataSize.Add(new MapTooltipData("New South Wales",  1));
        DataSize.Add(new MapTooltipData("Queensland",  2));
        DataSize.Add(new MapTooltipData("Northern Territory",  3));
        DataSize.Add(new MapTooltipData("Victoria",  4));
        DataSize.Add(new MapTooltipData("Tasmania",  5));
        DataSize.Add(new MapTooltipData("Western Australia",  6));
        DataSize.Add(new MapTooltipData("South Australia",  7));
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    public ObservableCollection<Model> data;

    [ObservableProperty]
    public ObservableCollection<MapTooltipData> dataSize;

    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string shapeLayerMapsElementsSource = "<Grid>\r\n    <Grid.BindingContext>\r\n        <local:ViewModel />\r\n    </Grid.BindingContext>\r\n\r\n    <map:SfMaps>\r\n        <map:SfMaps.Layer>\r\n            <map:MapShapeLayer x:Name=\"layer\"\r\n                               ShapesSource=\"https://cdn.syncfusion.com/maps/map-data/australia.json\"\r\n                               ShapeDataField=\"STATE_NAME\"\r\n                               DataSource=\"{Binding Data}\"\r\n                               PrimaryValuePath=\"State\" \r\n                               ShowDataLabels=\"True\"\r\n                               ShowShapeTooltip=\"True\"\r\n                               ShapeColorValuePath=\"ID\">\r\n\r\n                <!--Set Data Label-->\r\n                <map:MapShapeLayer.DataLabelSettings>\r\n                    <map:MapDataLabelSettings DataLabelPath=\"StateCode\" />\r\n                </map:MapShapeLayer.DataLabelSettings>\r\n                \r\n                <!--Set Color mapping-->\r\n                <map:MapShapeLayer.ColorMappings>\r\n                    <map:EqualColorMapping Color=\"#d0b800\"\r\n                                           Value=\"1\"\r\n                                           Text=\"NSW\" />\r\n                    <map:EqualColorMapping Color=\"#00d5cf\"\r\n                                           Value=\"2\"\r\n                                           Text=\"Queensland\" />\r\n                    <map:EqualColorMapping Color=\"#cf4eee\"\r\n                                           Value=\"3\"\r\n                                           Text=\"Victoria\" />\r\n                    <map:EqualColorMapping Color=\"#4f93d8\"\r\n                                           Value=\"4\"\r\n                                           Text=\"Tasmania\" />\r\n                    <map:EqualColorMapping Color=\"#8b6adf\"\r\n                                           Value=\"5\"\r\n                                           Text=\"WA\" />\r\n                    <map:EqualColorMapping Color=\"#7bff67\"\r\n                                           Value=\"6\"\r\n                                           Text=\"SA\" />\r\n                    <map:EqualColorMapping Color=\"#ff4e42\"\r\n                                           Value=\"7\"\r\n                                           Text=\"NT\" />\r\n                </map:MapShapeLayer.ColorMappings>\r\n\r\n                <!--Set Markers-->\r\n                <map:MapShapeLayer.Markers>\r\n                    <map:MapMarkerCollection>\r\n                        <map:MapMarker x:Name=\"Adelaide\"\r\n                                       IconWidth=\"20\"\r\n                                       IconHeight=\"20\"\r\n                                       IconType=\"Triangle\"\r\n                                       IconFill=\"Red\"\r\n                                       IconStroke=\"Black\"\r\n                                       Latitude=\"-34.928497\"\r\n                                       Longitude=\"138.600739\" />\r\n                    </map:MapMarkerCollection>\r\n                </map:MapShapeLayer.Markers>\r\n                \r\n                <!--Set Legend-->\r\n                <map:MapShapeLayer.Legend>\r\n                    <map:MapLegend SourceType=\"Shape\"\r\n                                   Placement=\"Bottom\" />\r\n                </map:MapShapeLayer.Legend>\r\n            </map:MapShapeLayer>\r\n        </map:SfMaps.Layer>\r\n    </map:SfMaps>\r\n</Grid>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<IControlInfo>();
    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}

public class Model
{
    public string State { get; set; }
    public string StateCode { get; set; }
    public int ID { get; set; }

    public Model(string state, string stateCode, int id)
    {
        State = state;
        StateCode = stateCode;
        ID = id;
    }
}

public class MapTooltipData
{
    public string State { get; set; }
    public int Size { get; set; }

    public MapTooltipData(string state, int size)
    {
        State = state;
        Size = size;
    }
}