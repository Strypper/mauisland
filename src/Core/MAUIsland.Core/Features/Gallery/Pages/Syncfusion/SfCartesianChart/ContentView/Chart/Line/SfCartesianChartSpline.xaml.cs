namespace MAUIsland.Core;

public partial class SfCartesianChartSpline : ContentView
{
    #region [ CTor ]
    public SfCartesianChartSpline()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstLineComponentDataProperty = BindableProperty.Create(
        nameof(FirstLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartSpline),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondLineComponentDataProperty = BindableProperty.Create(
        nameof(SecondLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartSpline),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty LineCodeDescriptionProperty = BindableProperty.Create(
        nameof(LineCodeDescription),
        typeof(string),
        typeof(SfCartesianChartSpline),
        default(string)
    );

    public static readonly BindableProperty DashedLineCodeDescriptionProperty = BindableProperty.Create(
        nameof(DashedLineCodeDescription),
        typeof(string),
        typeof(SfCartesianChartSpline),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> FirstLineComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(FirstLineComponentDataProperty);
        set => SetValue(FirstLineComponentDataProperty, value);
    }

    public ObservableCollection<SfCartesianChartModel> SecondLineComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(SecondLineComponentDataProperty);
        set => SetValue(SecondLineComponentDataProperty, value);
    }

    public string LineCodeDescription
    {
        get => (string)GetValue(LineCodeDescriptionProperty);
        set => SetValue(LineCodeDescriptionProperty, value);
    }

    public string DashedLineCodeDescription
    {
        get => (string)GetValue(DashedLineCodeDescriptionProperty);
        set => SetValue(DashedLineCodeDescriptionProperty, value);
    }
    #endregion}

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var splineChartInfo = (string[])Resources["SplineChartInfo"];
        SplineChartCollectionView.ItemsSource = splineChartInfo;
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