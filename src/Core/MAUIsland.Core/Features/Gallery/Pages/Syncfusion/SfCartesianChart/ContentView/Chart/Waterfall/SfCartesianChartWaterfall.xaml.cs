namespace MAUIsland.Core;

public partial class SfCartesianChartWaterfall : ContentView
{
    #region [ CTor ]
    public SfCartesianChartWaterfall()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartWaterfall),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty WaterfallCodeDescriptionProperty = BindableProperty.Create(
        nameof(WaterfallCodeDescription),
        typeof(string),
        typeof(SfCartesianChartWaterfall),
        default(string)
    );

    public static readonly BindableProperty VerticalWaterfallCodeDescriptionProperty = BindableProperty.Create(
        nameof(VerticalWaterfallCodeDescription),
        typeof(string),
        typeof(SfCartesianChartWaterfall),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string WaterfallCodeDescription
    {
        get => (string)GetValue(WaterfallCodeDescriptionProperty);
        set => SetValue(WaterfallCodeDescriptionProperty, value);
    }

    public string VerticalWaterfallCodeDescription
    {
        get => (string)GetValue(VerticalWaterfallCodeDescriptionProperty);
        set => SetValue(VerticalWaterfallCodeDescriptionProperty, value);
    }
    #endregion
}