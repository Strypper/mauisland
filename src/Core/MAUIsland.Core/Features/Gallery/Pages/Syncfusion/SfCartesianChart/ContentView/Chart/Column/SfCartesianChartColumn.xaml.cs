using Syncfusion.Maui.Toolkit.Charts;
using Syncfusion.Maui.Toolkit.Graphics.Internals;

namespace MAUIsland.Core;

public partial class SfCartesianChartColumn : ContentView
{
    #region [ CTor ]
    public SfCartesianChartColumn()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartColumn),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty ColumnXamlCodeDescriptionProperty = BindableProperty.Create(
        nameof(ColumnXamlCodeDescription),
        typeof(string),
        typeof(SfCartesianChartColumn),
        default(string)
    );

    public static readonly BindableProperty TripleColumnXamlCodeDescriptionProperty = BindableProperty.Create(
        nameof(TripleColumnXamlCodeDescription),
        typeof(string),
        typeof(SfCartesianChartColumn),
        default(string)
    );

    public static readonly BindableProperty RoundedColumnXamlCodeDescriptionProperty = BindableProperty.Create(
        nameof(RoundedColumnXamlCodeDescription),
        typeof(string),
        typeof(SfCartesianChartColumn),
        default(string)
    );

    public static readonly BindableProperty CustomColumnXamlCodeDescriptionProperty = BindableProperty.Create(
        nameof(CustomColumnXamlCodeDescription),
        typeof(string),
        typeof(SfCartesianChartColumn),
        default(string)
    );

    public static readonly BindableProperty CustomColumnCSharpCodeDescriptionProperty = BindableProperty.Create(
        nameof(CustomColumnCSharpCodeDescription),
        typeof(string),
        typeof(SfCartesianChartColumn),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string ColumnXamlCodeDescription
    {
        get => (string)GetValue(ColumnXamlCodeDescriptionProperty);
        set => SetValue(ColumnXamlCodeDescriptionProperty, value);
    }

    public string TripleColumnXamlCodeDescription
    {
        get => (string)GetValue(TripleColumnXamlCodeDescriptionProperty);
        set => SetValue(TripleColumnXamlCodeDescriptionProperty, value);
    }

    public string RoundedColumnXamlCodeDescription
    {
        get => (string)GetValue(RoundedColumnXamlCodeDescriptionProperty);
        set => SetValue(RoundedColumnXamlCodeDescriptionProperty, value);
    }

    public string CustomColumnXamlCodeDescription
    {
        get => (string)GetValue(CustomColumnXamlCodeDescriptionProperty);
        set => SetValue(CustomColumnXamlCodeDescriptionProperty, value);
    }

    public string CustomColumnCSharpCodeDescription
    {
        get => (string)GetValue(CustomColumnCSharpCodeDescriptionProperty);
        set => SetValue(CustomColumnCSharpCodeDescriptionProperty, value);
    }
    #endregion}

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var columnChartInfo = (string[])Resources["ColumnChartInfo"];
        ColumnChartCollectionView.ItemsSource = columnChartInfo;
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

public class CustomColumnSeries : ColumnSeries
{
    protected override ChartSegment CreateSegment()
    {
        return new CustomColumnSegment();
    }

    public static readonly BindableProperty TrackColorProperty =BindableProperty.Create(
        nameof(TrackColor), 
        typeof(SolidColorBrush), 
        typeof(CustomColumnSeries), 
        new SolidColorBrush(Color.FromArgb("#E7E0EC"))
    );

    public SolidColorBrush TrackColor
    {
        get { return (SolidColorBrush)GetValue(TrackColorProperty); }
        set { SetValue(TrackColorProperty, value); }
    }

    protected override void DrawDataLabel(ICanvas canvas, Brush? fillcolor, string label, PointF point, int index)
    {
        var items = ItemsSource as ObservableCollection<SfCartesianChartModel>;
        if (items != null)
        {
            var text = items[index].Name ?? "";
            base.DrawDataLabel(canvas, new SolidColorBrush(Colors.Transparent), label, point, index);
            base.DrawDataLabel(canvas, new SolidColorBrush(Colors.Transparent), text, new PointF(point.X, point.Y - 30), index);
        }
    }
}

public class CustomColumnSegment : ColumnSegment
{
    float curveHeight;
    float curveXGape = 30;
    float curveYGape = 20;

    protected override void Draw(ICanvas canvas)
    {
        base.Draw(canvas);

        if (Series is CartesianSeries series && series.ActualYAxis is NumericalAxis yAxis)
        {
            var top = yAxis.ValueToPoint(Convert.ToDouble(yAxis.Maximum ?? double.NaN));

            var trackRect = new RectF() { Left = Left, Top = top, Right = Right, Bottom = Bottom };
            curveHeight = trackRect.Height / curveYGape;
            var width = trackRect.Width + (float)Math.Sqrt((trackRect.Width * trackRect.Width) + (trackRect.Height * trackRect.Height));
            var waveLeft = trackRect.Left;
            var waveRight = waveLeft + width;
            var waveTop = trackRect.Bottom;
            var waveBottom = trackRect.Bottom + trackRect.Height;

            var waveRect = new Rect() { Left = waveLeft, Top = waveTop, Right = waveRight, Bottom = waveBottom };

            float freq = trackRect.Bottom - Top;

            canvas.CanvasSaveState();

            DrawTrackPath(canvas, trackRect);

            var color = (Fill is SolidColorBrush brush) ? brush.Color : Colors.Transparent;

            canvas.SetFillPaint(new SolidColorBrush(color.MultiplyAlpha(0.6f)), waveRect);
            DrawWave(canvas, new Rect(new Point(waveLeft - curveXGape - freq, waveTop - freq), waveRect.Size));

            canvas.SetFillPaint(Fill, waveRect);
            DrawWave(canvas, new Rect(new Point(waveLeft - freq, waveTop - freq), waveRect.Size));

            canvas.CanvasRestoreState();
        }
    }

    private void DrawTrackPath(ICanvas canvas, RectF trackRect)
    {
        if (Series is not CustomColumnSeries series) return;
        PathF path = new();
        path.MoveTo(trackRect.Left, trackRect.Bottom);
        path.LineTo(trackRect.Left, trackRect.Top);
        path.LineTo(trackRect.Right, trackRect.Top);
        path.LineTo(trackRect.Right, trackRect.Bottom);

        path.Close();
        canvas.ClipPath(path);

        canvas.SetFillPaint(series.TrackColor, trackRect);
        canvas.FillPath(path);
    }

    private void DrawWave(ICanvas canvas, RectF rectangle)
    {
        PathF path = new();

        path.MoveTo(rectangle.Left, rectangle.Bottom);
        path.LineTo(rectangle.Left, rectangle.Top);

        var top = rectangle.Top;
        var start = rectangle.Left;
        var split = rectangle.Width / 5;
        do
        {
            var next = start + split;

            var crX = start + (split / 2);
            var crY = top - curveHeight;
            var crY2 = top + curveHeight;

            path.CurveTo(crX, crY, crX, crY2, next, top);

            start = next;
        } while (start <= rectangle.Right);

        path.LineTo(rectangle.Right, rectangle.Bottom);
        path.Close();
        canvas.FillPath(path);
    }
}