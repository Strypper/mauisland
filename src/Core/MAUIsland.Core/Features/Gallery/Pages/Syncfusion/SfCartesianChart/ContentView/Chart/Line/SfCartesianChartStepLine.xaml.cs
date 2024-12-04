namespace MAUIsland.Core;

public partial class SfCartesianChartStepLine : ContentView
{
    #region [ CTor ]
    public SfCartesianChartStepLine()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstLineComponentDataProperty = BindableProperty.Create(
        nameof(FirstLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStepLine),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondLineComponentDataProperty = BindableProperty.Create(
        nameof(SecondLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStepLine),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty LineCodeDescriptionProperty = BindableProperty.Create(
        nameof(LineCodeDescription),
        typeof(string),
        typeof(SfCartesianChartStepLine),
        default(string)
    );

    public static readonly BindableProperty DashedLineCodeDescriptionProperty = BindableProperty.Create(
        nameof(DashedLineCodeDescription),
        typeof(string),
        typeof(SfCartesianChartStepLine),
        default(string)
    );

    public static readonly BindableProperty VerticalLineCodeDescriptionProperty = BindableProperty.Create(
        nameof(VerticalLineCodeDescription),
        typeof(string),
        typeof(SfCartesianChartStepLine),
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

    public string VerticalLineCodeDescription
    {
        get => (string)GetValue(VerticalLineCodeDescriptionProperty);
        set => SetValue(VerticalLineCodeDescriptionProperty, value);
    }
    #endregion}

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var stepLineChartInfo = (string[])Resources["StepLineChartInfo"];
        StepLineChartCollectionView.ItemsSource = stepLineChartInfo;
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