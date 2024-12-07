namespace MAUIsland.Core;

public partial class SfCartesianChartStackingLine100 : ContentView
{
    #region [ CTor ]
    public SfCartesianChartStackingLine100()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstLineComponentDataProperty = BindableProperty.Create(
        nameof(FirstLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStackingLine100),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondLineComponentDataProperty = BindableProperty.Create(
        nameof(SecondLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStackingLine100),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty ThirdLineComponentDataProperty = BindableProperty.Create(
        nameof(ThirdLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStackingLine100),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartStackingLine100),
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

    public ObservableCollection<SfCartesianChartModel> ThirdLineComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ThirdLineComponentDataProperty);
        set => SetValue(ThirdLineComponentDataProperty, value);
    }

    public string CodeDescription
    {
        get => (string)GetValue(CodeDescriptionProperty);
        set => SetValue(CodeDescriptionProperty, value);
    }
    #endregion}

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var stackingLine100ChartInfo = (string[])Resources["StackingLine100ChartInfo"];
        StackingLine100ChartCollectionView.ItemsSource = stackingLine100ChartInfo;
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