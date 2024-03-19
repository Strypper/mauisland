using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;

namespace MAUIsland;

public class PilotInfo : ObservableValue
{
    public PilotInfo(string name, int value, SolidColorPaint paint)
    {
        Name = name;
        Paint = paint;
        // the ObservableValue.Value property is used by the chart
        Value = value;
    }

    public string Name { get; set; }
    public SolidColorPaint Paint { get; set; }
}