namespace MAUIsland.Core;

public partial class SfCartesianChartAppearanceSeries : ContentView
{
    #region [ CTor ]
    public SfCartesianChartAppearanceSeries()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartAppearanceSeries),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty PalletBrushesDataProperty = BindableProperty.Create(
        nameof(PalletBrushesData),
        typeof(List<Brush>),
        typeof(SfCartesianChartAppearanceSeries),
        default(List<Brush>)
    );

    public static readonly BindableProperty XamlCodeDescriptionProperty = BindableProperty.Create(
        nameof(XamlCodeDescription),
        typeof(string),
        typeof(SfCartesianChartAppearanceChart),
        default(string)
    );

    public static readonly BindableProperty CSharpCodeDescriptionProperty = BindableProperty.Create(
        nameof(CSharpCodeDescription),
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

    public string XamlCodeDescription
    {
        get => (string)GetValue(XamlCodeDescriptionProperty);
        set => SetValue(XamlCodeDescriptionProperty, value);
    }

    public string CSharpCodeDescription
    {
        get => (string)GetValue(CSharpCodeDescriptionProperty);
        set => SetValue(CSharpCodeDescriptionProperty, value);
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