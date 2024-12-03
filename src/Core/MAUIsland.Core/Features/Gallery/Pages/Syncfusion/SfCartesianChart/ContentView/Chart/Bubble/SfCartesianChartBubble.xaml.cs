using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartBubble : ContentView
{
    #region [ CTor ]
    public SfCartesianChartBubble()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartBubble),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty BubbleCodeDescriptionProperty = BindableProperty.Create(
        nameof(BubbleCodeDescription),
        typeof(string),
        typeof(SfCartesianChartBubble),
        default(string)
    );

    public static readonly BindableProperty CustomBubbleCodeDescriptionProperty = BindableProperty.Create(
        nameof(CustomBubbleCodeDescription),
        typeof(string),
        typeof(SfCartesianChartBubble),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string BubbleCodeDescription
    {
        get => (string)GetValue(BubbleCodeDescriptionProperty);
        set => SetValue(BubbleCodeDescriptionProperty, value);
    }

    public string CustomBubbleCodeDescription
    {
        get => (string)GetValue(CustomBubbleCodeDescriptionProperty);
        set => SetValue(CustomBubbleCodeDescriptionProperty, value);
    }
    #endregion

    #region[ Event ]
    private void LabelCreated(object sender, ChartAxisLabelEventArgs e)
    {
        double position = e.Position;
        if (position >= 1000 && position <= 999999)
        {
            string text = (position / 1000).ToString();
            e.Label = $"${text}K";
        }
        else
        {
            e.Label = $"${position}K";
        }
    }
    #endregion
}