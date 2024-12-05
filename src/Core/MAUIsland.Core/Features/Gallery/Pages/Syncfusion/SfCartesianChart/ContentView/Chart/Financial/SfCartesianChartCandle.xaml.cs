using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartCandle : ContentView
{
    #region [ CTor ]
    public SfCartesianChartCandle()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartCandle),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartCandle),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string CodeDescription
    {
        get => (string)GetValue(CodeDescriptionProperty);
        set => SetValue(CodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void LabelCreated(object? sender, ChartAxisLabelEventArgs e)
    {
        var month = int.MaxValue;

        DateTime baseDate = new(1899, 12, 30);
        var date = baseDate.AddDays(e.Position);
        if (date.Month != month)
        {
            ChartAxisLabelStyle labelStyle = new();
            labelStyle.LabelFormat = "MMM-dd";
            labelStyle.FontAttributes = FontAttributes.Bold;
            e.LabelStyle = labelStyle;

            month = date.Month;
        }
        else
        {
            ChartAxisLabelStyle labelStyle = new();
            labelStyle.LabelFormat = "dd";
            e.LabelStyle = labelStyle;
        }
    }

    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var candleChartInfo = (string[])Resources["CandleChartInfo"];
        CandleChartCollectionView.ItemsSource = candleChartInfo;
    }

    private async void OnGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ArrowImage.Rotation == 0)
        {
            await ArrowImage.RotateTo(90);
            Info.IsVisible = true;
        }
        else
        {
            await ArrowImage.RotateTo(0);
            Info.IsVisible = false;
        }
    }
    #endregion
}