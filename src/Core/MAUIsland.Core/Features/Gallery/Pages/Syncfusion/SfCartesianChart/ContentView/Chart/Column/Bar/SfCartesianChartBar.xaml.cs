using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartBar : ContentView
{
    #region [ CTor ]
    public SfCartesianChartBar()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartBar),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty BarCodeDescriptionProperty = BindableProperty.Create(
        nameof(BarCodeDescription),
        typeof(string),
        typeof(SfCartesianChartBar),
        default(string)
    ); 
    
    public static readonly BindableProperty CustomBarXamlCodeDescriptionProperty = BindableProperty.Create(
        nameof(CustomBarXamlCodeDescription),
        typeof(string),
        typeof(SfCartesianChartBar),
        default(string)
    );

    public static readonly BindableProperty CustomBarCSharpCodeDescriptionProperty = BindableProperty.Create(
        nameof(CustomBarCSharpCodeDescription),
        typeof(string),
        typeof(SfCartesianChartBar),
        default(string)
    );

    public static readonly BindableProperty DoubleBarCodeDescriptionProperty = BindableProperty.Create(
        nameof(DoubleBarCodeDescription),
        typeof(string),
        typeof(SfCartesianChartBar),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string BarCodeDescription
    {
        get => (string)GetValue(BarCodeDescriptionProperty);
        set => SetValue(BarCodeDescriptionProperty, value);
    }

    public string CustomBarXamlCodeDescription
    {
        get => (string)GetValue(CustomBarXamlCodeDescriptionProperty);
        set => SetValue(CustomBarXamlCodeDescriptionProperty, value);
    }

    public string CustomBarCSharpCodeDescription
    {
        get => (string)GetValue(CustomBarCSharpCodeDescriptionProperty);
        set => SetValue(CustomBarCSharpCodeDescriptionProperty, value);
    }

    public string DoubleBarCodeDescription
    {
        get => (string)GetValue(DoubleBarCodeDescriptionProperty);
        set => SetValue(DoubleBarCodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var barChartInfo = (string[])Resources["BarChartInfo"];
        BarChartCollectionView.ItemsSource = barChartInfo;
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

public class CustomBarChart : ColumnSeries
{
    protected override ChartSegment CreateSegment()
    {
        return new BarSegment();
    }

    public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(
        nameof(TrackColor), 
        typeof(SolidColorBrush), 
        typeof(ColumnSeries), 
        new SolidColorBrush(Color.FromArgb("#E7E0EC"))
    );

    public SolidColorBrush TrackColor
    {
        get { return (SolidColorBrush)GetValue(TrackColorProperty); }
        set { SetValue(TrackColorProperty, value); }
    }
}

public class BarSegment : ColumnSegment
{
    RectF trackRect = RectF.Zero;

    protected override void OnLayout()
    {
        base.OnLayout();
        if (Series is CartesianSeries series && series.ActualYAxis is NumericalAxis yAxis)
        {
            var top = yAxis.ValueToPoint(Convert.ToDouble(yAxis.Maximum ?? double.NaN));
            trackRect = new RectF() { Left = Left, Top = Top, Right = top, Bottom = Bottom };
        }
    }

    protected override void Draw(ICanvas canvas)
    {
        if (Series is not CustomBarChart series) return;

        canvas.SetFillPaint(series.TrackColor, trackRect);
        canvas.FillRoundedRectangle(trackRect, 25);

        base.Draw(canvas);
    }
}