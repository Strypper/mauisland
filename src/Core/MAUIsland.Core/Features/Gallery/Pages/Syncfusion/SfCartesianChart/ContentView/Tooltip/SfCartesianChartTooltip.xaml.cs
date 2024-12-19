namespace MAUIsland.Core;

public partial class SfCartesianChartTooltip : ContentView
{
    #region [ CTor ]
    public SfCartesianChartTooltip()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartTooltip),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty TooltipCodeDescriptionProperty = BindableProperty.Create(
        nameof(TooltipCodeDescription),
        typeof(string),
        typeof(SfCartesianChartTooltip),
        default(string)
    );

    public static readonly BindableProperty CustomToolTipCodeDescriptionProperty = BindableProperty.Create(
        nameof(CustomToolTipCodeDescription),
        typeof(string),
        typeof(SfCartesianChartTooltip),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string TooltipCodeDescription
    {
        get => (string)GetValue(TooltipCodeDescriptionProperty);
        set => SetValue(TooltipCodeDescriptionProperty, value);
    }

    public string CustomToolTipCodeDescription
    {
        get => (string)GetValue(CustomToolTipCodeDescriptionProperty);
        set => SetValue(CustomToolTipCodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
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