namespace MAUIsland.Core;

public partial class SfCartesianChartDataLabelTemplate : ContentView
{
    #region [ CTor ]
    public SfCartesianChartDataLabelTemplate()
    {
        InitializeComponent();
        Info.IsVisible = false;
        ExpanderHeader.IsVisible = true;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartDataLabelTemplate),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartDataLabelTemplate),
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
    private async void OnGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ArrowImage.Rotation == 0)
        {
            await ArrowImage.RotateTo(90);
            Info.IsVisible = true;
            ExpanderHeader.IsVisible = false;
        }
        else
        {
            await ArrowImage.RotateTo(0);
            Info.IsVisible = false;
            ExpanderHeader.IsVisible = true;
        }
    }
    #endregion
}