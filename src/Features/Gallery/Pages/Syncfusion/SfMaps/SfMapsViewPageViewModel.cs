using MAUIsland.Gallery.Syncfusion;
using Syncfusion.Maui.Maps;

namespace MAUIsland;
public partial class SfMapsViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfMapsViewPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
        data = new ObservableCollection<Model>
        {
            new Model("New South Wales", "New\nSouth Wales", 1),
            new Model("Queensland", "Queensland", 2),
            new Model("Northern Territory", "Northern\nTerritory", 3),
            new Model("Victoria", "Victoria", 4),
            new Model("Tasmania", "Tasmania", 5),
            new Model("Western Australia", "Western Australia", 6),
            new Model("South Australia", "South Australia", 7)
        };

        dataSize = new ObservableCollection<MapTooltipData>
        {
            new MapTooltipData("New South Wales", 1),
            new MapTooltipData("Queensland", 2),
            new MapTooltipData("Northern Territory", 3),
            new MapTooltipData("Victoria", 4),
            new MapTooltipData("Tasmania", 5),
            new MapTooltipData("Western Australia", 6),
            new MapTooltipData("South Australia", 7)
        };

        stateWiseElectionResult = new ObservableCollection<PopulationDensityDetails>() {
      new PopulationDensityDetails(
          "Washington",
          "DC",
          22,
          116,
          44.8),
      new PopulationDensityDetails(
          "Oregon",
          "OR",
          39,
          44.1,
          17.0),
      new PopulationDensityDetails(
          "Alabama",
          "AL",
          27,
          99.2,
          38.3),
      new PopulationDensityDetails(
          "Alaska",
          "AK",
          50,
          1.3,
          0.5),
      new PopulationDensityDetails(
          "Arizona",
          "AZ",
          33,
          63.0,
          24.3),
      new PopulationDensityDetails(
          "Arkansas",
          "AR",
          34,
          57.9,
          22.3),
      new PopulationDensityDetails(
          "California",
          "CA",
          11,
          254,
          98.0),
      new PopulationDensityDetails(
          "Colorado",
          "CO",
          37,
          54.3,
          21.5),
      new PopulationDensityDetails(
          "Connecticut",
          "CT",
          4,
          745,
          288),
      new PopulationDensityDetails(
          "Delaware",
          "DE",
          6,
          508,
          196),
      new PopulationDensityDetails(
          "Florida",
          "FL",
          8,
          402,
          155),
      new PopulationDensityDetails(
          "Georgia",
          "GA",
          17,
          186,
          71.9),
      new PopulationDensityDetails(
          "Hawaii",
          "HI",
          13,
          227,
          87.5),
      new PopulationDensityDetails(
          "Idaho",
          "ID",
          44,
          22.3,
          8.6),
      new PopulationDensityDetails(
          "Illinois",
          "IL",
          12,
          231,
          89.1),
      new PopulationDensityDetails(
          "Indiana",
          "IN",
          16,
          189,
          73.1),
      new PopulationDensityDetails(
          "Iowa",
          "IA",
          36,
          57.1,
          22.1),
      new PopulationDensityDetails(
          "Kansas",
          "KS",
          41,
          35.9,
          13.9),
      new PopulationDensityDetails(
          "Kentucky",
          "KY",
          23,
          114,
          44.1),
      new PopulationDensityDetails(
          "Louisiana",
          "LA",
          26,
          108,
          41.6),
      new PopulationDensityDetails(
          "Maine",
          "ME",
          38,
          44.2,
          17.1),
      new PopulationDensityDetails(
          "Maryland",
          "MD",
          5,
          636,
          246),
      new PopulationDensityDetails(
          "Massachusetts",
          "MA",
          3,
          901,
          348),
      new PopulationDensityDetails(
          "Michigan",
          "MI",
          18,
          178,
          68.8),
      new PopulationDensityDetails(
          "Minnesota",
          "MN",
          30,
          71.7,
          27.7),
      new PopulationDensityDetails(
          "Mississippi",
          "MS",
          32,
          63.1,
          24.4),
      new PopulationDensityDetails(
          "Missouri",
          "MO",
          28,
          89.5,
          34.6),
      new PopulationDensityDetails(
          "Montana",
          "MT",
          48,
          7.5,
          2.9),
      new PopulationDensityDetails(
          "Nebraska",
          "NE",
          43,
          25.5,
          9.9),
      new PopulationDensityDetails(
          "Nevada",
          "NV",
          42,
          28.3,
          10.9),
      new PopulationDensityDetails(
          "New Hampshire",
          "NH",
          21,
          154,
          59.4),
      new PopulationDensityDetails(
          "New Jersey",
          "NJ",
          1,
          1263,
          488),
      new PopulationDensityDetails(
          "New Mexico",
          "NM",
          45,
          17.5,
          6.7 ),
      new PopulationDensityDetails(
          "New York",
          "NY",
          7,
          429,
          166),
      new PopulationDensityDetails(
          "North Carolina",
          "NC",
          15,
          215,
          82.9),
      new PopulationDensityDetails(
          "North Dakota",
          "ND",
          47,
          11.3,
          4.4),
      new PopulationDensityDetails(
          "Ohio",
          "OH",
          10,
          289,
          111),
      new PopulationDensityDetails(
          "Oklahoma",
          "OK",
          35,
          57.7,
          22.3),
      new PopulationDensityDetails(
          "Pennsylvania",
          "PA",
          9,
          291,
          112),
      new PopulationDensityDetails(
          "Rhode Island",
          "RI",
          2,
          1061,
          410),
      new PopulationDensityDetails(
          "South Carolina",
          "SC",
          19,
          170,
          65.7),
      new PopulationDensityDetails(
          "South Dakota",
          "SD",
          46,
          11.7,
          4.5),
      new PopulationDensityDetails(
          "Tennessee",
          "TN",
          20,
          168,
          64.7),
      new PopulationDensityDetails(
          "Texas",
          "TX",
          24,
          112,
          43.1),
      new PopulationDensityDetails(
          "Utah",
          "UT",
          40,
          39.8,
          15.4),
      new PopulationDensityDetails(
          "Vermont",
          "VT",
          31,
          69.8,
          26.9),
      new PopulationDensityDetails(
          "Virginia",
          "VA",
          14,
          219,
          84.4),
      new PopulationDensityDetails(
          "West Virginia",
          "WV",
          29,
          74.6,
          28.8),
      new PopulationDensityDetails(
          "Wisconsin",
          "WI",
          25,
          109,
          42.0),
      new PopulationDensityDetails(
          "Wyoming",
          "WY",
          49,
          5.9,
          2.3),
        };

        AustraliaData = new ObservableCollection<AustraliaModel>()
        {
            new AustraliaModel("New South Wales",5),
            new AustraliaModel("Queensland",23),
            new AustraliaModel("Northern Territory",56),
            new AustraliaModel("Victoria",16),
            new AustraliaModel("Western Australia",43),
            new AustraliaModel("South Australia",26)
        };
        CreateMarker();
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    public ObservableCollection<Model> data;

    [ObservableProperty]
    public ObservableCollection<MapTooltipData> dataSize;

    [ObservableProperty]
    public ObservableCollection<PopulationDensityDetails> stateWiseElectionResult;

    public ObservableCollection<AustraliaModel> AustraliaData { get; set; }

    public ObservableCollection<CustomMarker> Markers { get; set; }

    [ObservableProperty]
    IControlInfo controlInformation;

    #region Xaml code

    [ObservableProperty]
    string markerLayerSource = "<Grid Margin=\"20\">\r\n                <Grid.RowDefinitions>\r\n                    <RowDefinition Height=\"Auto\" />\r\n                    <RowDefinition />\r\n                </Grid.RowDefinitions>\r\n                <Label Grid.Row=\"0\"\r\n                   HorizontalOptions=\"Center\"\r\n                   Text=\"World Clock\"\r\n                   FontSize=\"Subtitle\"\r\n                   Margin=\"0,0,0,20\" />\r\n                <maps:SfMaps Grid.Row=\"1\">\r\n                    <maps:SfMaps.Layer>\r\n                        <maps:MapShapeLayer x:Name=\"markerLayer\"\r\n                                        ShapeHoverFill=\"Transparent\"\r\n                                        ShapeHoverStroke=\"Transparent\"\r\n                                        ShapeHoverStrokeThickness=\"0\"\r\n                                        ShapeFill=\"#dadadb\"\r\n                                        ShapeStrokeThickness=\"0\"\r\n                                        Markers=\"{Binding Markers}\"\r\n                                        MarkerTemplate=\"{StaticResource markerTemplate}\">\r\n                        </maps:MapShapeLayer>\r\n                    </maps:SfMaps.Layer>\r\n                </maps:SfMaps>\r\n            </Grid>";
        [ObservableProperty]
    string shapeLayerSource = "<Grid Margin=\"20\">\r\n                <Grid.RowDefinitions>\r\n                    <RowDefinition Height=\"Auto\" />\r\n                    <RowDefinition />\r\n                </Grid.RowDefinitions>\r\n\r\n                <Label Grid.ColumnSpan=\"2\"\r\n                   HorizontalOptions=\"Center\"\r\n                   Text=\"Rivers in Australia\"\r\n                   FontSize=\"Subtitle\"\r\n                   Margin=\"0,0,0,20\" />\r\n\r\n                <maps:SfMaps Grid.Row=\"1\">\r\n                    <maps:SfMaps.Layer>\r\n                        <maps:MapShapeLayer x:Name=\"shapeLayer\"\r\n                                        DataSource=\"{Binding AustraliaData}\"\r\n                                        PrimaryValuePath=\"State\"\r\n                                        ShapeDataField=\"STATE_NAME\"\r\n                                        ShapeFill=\"#fef6d6\"\r\n                                        ShapeStroke=\"#DBB589\"\r\n                                        ShapeHoverFill=\"Transparent\"\r\n                                        ShapeHoverStroke=\"Transparent\"\r\n                                        ShowDataLabels=\"True\">\r\n\r\n                            <maps:MapShapeLayer.DataLabelSettings>\r\n                                <maps:MapDataLabelSettings DataLabelPath=\"State\">\r\n                                    <maps:MapDataLabelSettings.DataLabelStyle>\r\n                                        <maps:MapLabelStyle FontSize=\"12\" />\r\n                                    </maps:MapDataLabelSettings.DataLabelStyle>\r\n                                </maps:MapDataLabelSettings>\r\n                            </maps:MapShapeLayer.DataLabelSettings>\r\n\r\n                            <maps:MapShapeLayer.Sublayers>\r\n                                <maps:MapShapeSublayer x:Name=\"sublayer\" \r\n                                                   ShapeStroke=\"#00A7CC\" \r\n                                                   ShapeStrokeThickness=\"2\"/>\r\n                            </maps:MapShapeLayer.Sublayers>\r\n                        </maps:MapShapeLayer>\r\n                    </maps:SfMaps.Layer>\r\n                </maps:SfMaps>\r\n            </Grid>";

    [ObservableProperty]
    string selectionLayerSource = "<Grid Margin=\"20\"\r\n              x:Name=\"sampleGrid\">\r\n                <Grid.RowDefinitions>\r\n                    <RowDefinition Height=\"Auto\" />\r\n                    <RowDefinition Height=\"*\" />\r\n                    <RowDefinition Height=\"160\" />\r\n                </Grid.RowDefinitions>\r\n                <Grid.ColumnDefinitions>\r\n                    <ColumnDefinition Width=\"*\"/>\r\n                    <ColumnDefinition Width=\"Auto\"/>\r\n                </Grid.ColumnDefinitions>\r\n                <Label Grid.Row=\"0\"\r\n                   Grid.ColumnSpan=\"2\"\r\n                   HorizontalOptions=\"Center\"\r\n                   Text=\"2020 US Population Density\"\r\n                   FontSize=\"Subtitle\" \r\n                    Margin=\"0,0,0,20\"/>\r\n                <maps:SfMaps Grid.Row=\"1\" Grid.RowSpan=\"2\" Grid.ColumnSpan=\"2\">\r\n                    <maps:SfMaps.Layer>\r\n                        <maps:MapShapeLayer x:Name=\"selectionLayer\"\r\n                                        DataSource=\"{Binding StateWiseElectionResult}\"\r\n                                        PrimaryValuePath=\"State\"\r\n                                        ShapeDataField=\"STATE_NAME\"\r\n                                        ShapeColorValuePath=\"SquareMiles\"\r\n                                        ShapeStroke=\"White\"\r\n                                        EnableSelection=\"True\"\r\n                                        SelectedShapeFill=\"#fcb100\"\r\n                                        SelectedShapeStroke=\"White\"\r\n                                        SelectedShapeStrokeThickness=\"3\"\r\n                                        ShapeSelected=\"shapeLayer_ShapeSelected\"\r\n                                        ShowDataLabels=\"True\">\r\n                            <maps:MapShapeLayer.ColorMappings>\r\n                                <maps:RangeColorMapping From=\"1600\" To=\"1200\" Color=\"#000000\"/>\r\n                                <maps:RangeColorMapping From=\"800\" To=\"1599\" Color=\"#001330\"/>\r\n                                <maps:RangeColorMapping From=\"400\" To=\"799\" Color=\"#003066\"/>\r\n                                <maps:RangeColorMapping From=\"200\" To=\"399\" Color=\"#004c9a\"/>\r\n                                <maps:RangeColorMapping From=\"100\" To=\"199\" Color=\"#0066cd\"/>\r\n                                <maps:RangeColorMapping From=\"50\" To=\"100\" Color=\"#0081ff\"/>\r\n                                <maps:RangeColorMapping From=\"20\" To=\"49\" Color=\"#4ca7ff\"/>\r\n                                <maps:RangeColorMapping From=\"10\" To=\"19\" Color=\"#8dc7ff\"/>\r\n                                <maps:RangeColorMapping From=\"5\" To=\"9\" Color=\"#b3daff\"/>\r\n                                <maps:RangeColorMapping From=\"0\" To=\"4\" Color=\"#daeeff\"/>\r\n                            </maps:MapShapeLayer.ColorMappings>\r\n                            <maps:MapShapeLayer.DataLabelSettings>\r\n                                <maps:MapDataLabelSettings DataLabelPath=\"StateCode\" OverflowMode=\"Hide\">\r\n                                    <maps:MapDataLabelSettings.DataLabelStyle>\r\n                                        <maps:MapLabelStyle FontSize=\"9\"/>\r\n                                    </maps:MapDataLabelSettings.DataLabelStyle>\r\n                                </maps:MapDataLabelSettings>\r\n                            </maps:MapShapeLayer.DataLabelSettings>\r\n                        </maps:MapShapeLayer>\r\n                    </maps:SfMaps.Layer>\r\n                </maps:SfMaps>\r\n                <Frame x:Name=\"popup\" \r\n                   Grid.Row=\"2\" \r\n                   Grid.Column=\"1\"\r\n                   HorizontalOptions=\"End\"\r\n                   IsClippedToBounds=\"True\" \r\n                   BorderColor=\"#E8E8E8\"\r\n                   BackgroundColor=\"#F8F8F8\"\r\n                   Margin=\"30\"\r\n                   Opacity=\"0.8\"\r\n                   CornerRadius=\"6\">\r\n                    <Grid HorizontalOptions=\"End\" Margin=\"-10\">\r\n                        <Grid.RowDefinitions>\r\n                            <RowDefinition Height=\"Auto\"/>\r\n                            <RowDefinition Height=\"Auto\"/>\r\n                            <RowDefinition Height=\"Auto\"/>\r\n                        </Grid.RowDefinitions>\r\n                        <Label Grid.Row=\"0\" x:Name=\"stateName\" Text=\"\" TextColor=\"Black\" FontAttributes=\"Bold\" FontSize=\"18\" Margin=\"0,0,0,5\"/>\r\n                        <BoxView Grid.Row=\"1\" BackgroundColor=\"#e8e8e8\" HeightRequest=\"1\"/>\r\n                        <Grid Grid.Row=\"2\">\r\n                            <Grid.RowDefinitions>\r\n                                <RowDefinition Height=\"Auto\"/>\r\n                                <RowDefinition Height=\"Auto\"/>\r\n                            </Grid.RowDefinitions>\r\n                            <Grid.ColumnDefinitions>\r\n                                <ColumnDefinition Width=\"Auto\"/>\r\n                                <ColumnDefinition Width=\"Auto\"/>\r\n                            </Grid.ColumnDefinitions>\r\n                            <Label Grid.Row=\"0\" Grid.Column=\"0\" x:Name=\"rankTitle\" Text=\"\" TextColor=\"Black\" FontAttributes=\"Bold\" FontSize=\"13\"  Margin=\"0,5\"/>\r\n                            <Label Grid.Row=\"0\" Grid.Column=\"1\" x:Name=\"rank\" Text=\"\" TextColor=\"Black\" FontSize=\"14\"  Margin=\"0,5\"/>\r\n                            <Label Grid.Row=\"1\" Grid.Column=\"0\" x:Name=\"kmTitle\" Text=\"\" TextColor=\"Black\" FontAttributes=\"Bold\" FontSize=\"13\" Margin=\"0,5,0,0\"/>\r\n                            <Label Grid.Row=\"1\" Grid.Column=\"1\" x:Name=\"kilometer\" Text=\"\" TextColor=\"Black\" FontSize=\"14\" Margin=\"0,5,0,0\"/>\r\n                        </Grid>\r\n                    </Grid>\r\n                </Frame>\r\n            </Grid>";

    [ObservableProperty]
    string basicLayerSource = "<Grid>\r\n    <Grid.BindingContext>\r\n        <local:ViewModel />\r\n    </Grid.BindingContext>\r\n\r\n    <map:SfMaps>\r\n        <map:SfMaps.Layer>\r\n            <map:MapShapeLayer x:Name=\"layer\"\r\n                               ShapesSource=\"https://cdn.syncfusion.com/maps/map-data/australia.json\"\r\n                               ShapeDataField=\"STATE_NAME\"\r\n                               DataSource=\"{Binding Data}\"\r\n                               PrimaryValuePath=\"State\" \r\n                               ShowDataLabels=\"True\"\r\n                               ShowShapeTooltip=\"True\"\r\n                               ShapeColorValuePath=\"ID\">\r\n\r\n                <!--Set Data Label-->\r\n                <map:MapShapeLayer.DataLabelSettings>\r\n                    <map:MapDataLabelSettings DataLabelPath=\"StateCode\" />\r\n                </map:MapShapeLayer.DataLabelSettings>\r\n                \r\n                <!--Set Color mapping-->\r\n                <map:MapShapeLayer.ColorMappings>\r\n                    <map:EqualColorMapping Color=\"#d0b800\"\r\n                                           Value=\"1\"\r\n                                           Text=\"NSW\" />\r\n                    <map:EqualColorMapping Color=\"#00d5cf\"\r\n                                           Value=\"2\"\r\n                                           Text=\"Queensland\" />\r\n                    <map:EqualColorMapping Color=\"#cf4eee\"\r\n                                           Value=\"3\"\r\n                                           Text=\"Victoria\" />\r\n                    <map:EqualColorMapping Color=\"#4f93d8\"\r\n                                           Value=\"4\"\r\n                                           Text=\"Tasmania\" />\r\n                    <map:EqualColorMapping Color=\"#8b6adf\"\r\n                                           Value=\"5\"\r\n                                           Text=\"WA\" />\r\n                    <map:EqualColorMapping Color=\"#7bff67\"\r\n                                           Value=\"6\"\r\n                                           Text=\"SA\" />\r\n                    <map:EqualColorMapping Color=\"#ff4e42\"\r\n                                           Value=\"7\"\r\n                                           Text=\"NT\" />\r\n                </map:MapShapeLayer.ColorMappings>\r\n\r\n                <!--Set Markers-->\r\n                <map:MapShapeLayer.Markers>\r\n                    <map:MapMarkerCollection>\r\n                        <map:MapMarker x:Name=\"Adelaide\"\r\n                                       IconWidth=\"20\"\r\n                                       IconHeight=\"20\"\r\n                                       IconType=\"Triangle\"\r\n                                       IconFill=\"Red\"\r\n                                       IconStroke=\"Black\"\r\n                                       Latitude=\"-34.928497\"\r\n                                       Longitude=\"138.600739\" />\r\n                    </map:MapMarkerCollection>\r\n                </map:MapShapeLayer.Markers>\r\n                \r\n                <!--Set Legend-->\r\n                <map:MapShapeLayer.Legend>\r\n                    <map:MapLegend SourceType=\"Shape\"\r\n                                   Placement=\"Bottom\" />\r\n                </map:MapShapeLayer.Legend>\r\n            </map:MapShapeLayer>\r\n        </map:SfMaps.Layer>\r\n    </map:SfMaps>\r\n</Grid>";
    #endregion

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

    #region private function
    private void CreateMarker()
    {
        this.Markers = new ObservableCollection<CustomMarker>();
        var currentTime = DateTime.UtcNow;
        this.Markers.Add(new CustomMarker()
        {
            Latitude = 47.60621,
            Longitude = -122.332071,
            Name = "Seattle",
            Time = currentTime.Subtract(new TimeSpan(7, 0, 0)).ToLongTimeString(),
            Offset = new Point(0, -4),
            VerticalAlignment = MapAlignment.End,
            IconWidth = 150,
            IconHeight = 150
        });


        this.Markers.Add(new CustomMarker()
        {
            Latitude = -1.455833,
            Longitude = -48.503887,
            Name = "Belem",
            Time = currentTime.Subtract(new TimeSpan(3, 0, 0)).ToLongTimeString(),
            Offset = new Point(0, -4),
            VerticalAlignment = MapAlignment.End,
            IconWidth = 150,
            IconHeight = 150
        });

        this.Markers.Add(new CustomMarker()
        {
            Latitude = 64.10,
            Longitude = -51.44,
            Name = "Nuuk",
            Time = currentTime.Subtract(new TimeSpan(2, 0, 0)).ToLongTimeString(),
            Offset = new Point(0, -4),
            VerticalAlignment = MapAlignment.End,
            IconWidth = 150,
            IconHeight = 150
        });

        this.Markers.Add(new CustomMarker()
        {
            Latitude = 62.035452,
            Longitude = 129.675475,
            Name = "Yakutsk",
            Time = currentTime.Add(new TimeSpan(9, 0, 0)).ToLongTimeString(),
            Offset = new Point(0, -4),
            VerticalAlignment = MapAlignment.End,
            IconWidth = 150,
            IconHeight = 150
        });

        this.Markers.Add(new CustomMarker()
        {
            Latitude = 28.704059,
            Longitude = 77.10249,
            Name = "Delhi",
            Time = currentTime.Add(new TimeSpan(5, 30, 0)).ToLongTimeString(),
            Offset = new Point(0, -4),
            VerticalAlignment = MapAlignment.End,
            IconWidth = 150,
            IconHeight = 150
        });

        this.Markers.Add(new CustomMarker()
        {
            Latitude = -27.469771,
            Longitude = 153.025124,
            Name = "Brisbane",
            Time = currentTime.Add(new TimeSpan(10, 0, 0)).ToLongTimeString(),
            Offset = new Point(0, -4),
            VerticalAlignment = MapAlignment.End,
            IconWidth = 150,
            IconHeight = 150
        });

        this.Markers.Add(new CustomMarker()
        {
            Latitude = -17.825166,
            Longitude = 31.03351,
            Name = "Harare",
            Time = currentTime.Add(new TimeSpan(2, 0, 0)).ToLongTimeString(),
            Offset = new Point(0, -4),
            VerticalAlignment = MapAlignment.End,
            IconWidth = 150,
            IconHeight = 150
        });
    }
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