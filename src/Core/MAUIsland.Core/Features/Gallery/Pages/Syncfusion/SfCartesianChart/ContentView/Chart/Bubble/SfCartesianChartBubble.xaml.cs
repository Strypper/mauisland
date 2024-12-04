using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartBubble : ContentView
{
    #region [ CTor ]
    public SfCartesianChartBubble()
    {
        InitializeComponent();
        Info.IsVisible = false;
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
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var bubbleChartInfo = (string[])Resources["BubbleChartInfo"];
        BubbleChartCollectionView.ItemsSource = bubbleChartInfo;
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