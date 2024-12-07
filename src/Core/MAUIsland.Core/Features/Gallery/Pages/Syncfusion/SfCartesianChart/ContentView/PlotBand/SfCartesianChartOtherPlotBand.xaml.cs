namespace MAUIsland.Core;

public partial class SfCartesianChartOtherPlotBand : ContentView
{
    #region [ CTor ]
    public SfCartesianChartOtherPlotBand()
    {
        InitializeComponent();
        RecursivePlotBandInfo.IsVisible = false;
        SegmentedPlotBandInfo.IsVisible = false;
        PlotLineInfo.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartOtherPlotBand),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty RecursivePlotCodeDescriptionProperty = BindableProperty.Create(
        nameof(RecursivePlotCodeDescription),
        typeof(string),
        typeof(SfCartesianChartOtherPlotBand),
        default(string)
    );

    public static readonly BindableProperty SegmentedPlotCodeDescriptionProperty = BindableProperty.Create(
        nameof(SegmentedPlotCodeDescription),
        typeof(string),
        typeof(SfCartesianChartOtherPlotBand),
        default(string)
    );

    public static readonly BindableProperty PlotLineCodeDescriptionProperty = BindableProperty.Create(
        nameof(PlotLineCodeDescription),
        typeof(string),
        typeof(SfCartesianChartOtherPlotBand),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string RecursivePlotCodeDescription
    {
        get => (string)GetValue(RecursivePlotCodeDescriptionProperty);
        set => SetValue(RecursivePlotCodeDescriptionProperty, value);
    }

    public string SegmentedPlotCodeDescription
    {
        get => (string)GetValue(SegmentedPlotCodeDescriptionProperty);
        set => SetValue(SegmentedPlotCodeDescriptionProperty, value);
    }

    public string PlotLineCodeDescription
    {
        get => (string)GetValue(PlotLineCodeDescriptionProperty);
        set => SetValue(PlotLineCodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var recursivePlotBandInfo = (string[])Resources["RecursivePlotBandInfo"];
        RecursivePlotBandCollectionView.ItemsSource = recursivePlotBandInfo;

        var segmentedPlotBandInfo = (string[])Resources["SegmentedPlotBandInfo"];
        SegmentedPlotBandCollectionView.ItemsSource = segmentedPlotBandInfo;

        var plotLineInfo = (string[])Resources["PlotLineInfo"];
        PlotLineCollectionView.ItemsSource = plotLineInfo;
    }

    private async void OnRecursivePlotBandGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (RecursiveArrowImage.Rotation == 0)
        {
            await RecursiveArrowImage.RotateTo(90);
            RecursivePlotBandInfo.IsVisible = true;
        }
        else
        {
            await RecursiveArrowImage.RotateTo(0);
            RecursivePlotBandInfo.IsVisible = false;
        }
    }

    private async void OnSegmentedPlotBandGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (SegmentedArrowImage.Rotation == 0)
        {
            await SegmentedArrowImage.RotateTo(90);
            SegmentedPlotBandInfo.IsVisible = true;
        }
        else
        {
            await SegmentedArrowImage.RotateTo(0);
            SegmentedPlotBandInfo.IsVisible = false;
        }
    }

    private async void OnPlotLineGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (LineArrowImage.Rotation == 0)
        {
            await LineArrowImage.RotateTo(90);
            PlotLineInfo.IsVisible = true;
        }
        else
        {
            await LineArrowImage.RotateTo(0);
            PlotLineInfo.IsVisible = false;
        }
    }
    #endregion
}