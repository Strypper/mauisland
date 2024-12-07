namespace MAUIsland.Core;

public partial class SfCartesianChartAppearanceChart : ContentView
{
    #region [ CTor ]
    public SfCartesianChartAppearanceChart()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartAppearanceChart),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty PalletBrushesDataProperty = BindableProperty.Create(
        nameof(PalletBrushesData),
        typeof(List<Brush>),
        typeof(SfCartesianChartAppearanceChart),
        default(List<Brush>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartAppearanceChart),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public List<Brush> PalletBrushesData
    {
        get => (List<Brush>)GetValue(PalletBrushesDataProperty);
        set => SetValue(PalletBrushesDataProperty, value);
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
        }
        else
        {
            await ArrowImage.RotateTo(0);
            Info.IsVisible = false;
        }
    }
    #endregion
}
