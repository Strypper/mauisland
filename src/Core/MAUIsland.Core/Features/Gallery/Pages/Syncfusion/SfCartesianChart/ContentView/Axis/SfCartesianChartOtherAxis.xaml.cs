namespace MAUIsland.Core;

public partial class SfCartesianChartOtherAxis : ContentView
{
    #region [ CTor ]
    public SfCartesianChartOtherAxis()
    {
        InitializeComponent();
        MultipleAxesInfo.IsVisible = false;
        AxisCrossingInfo.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty MultipleAxesComponentDataProperty = BindableProperty.Create(
        nameof(MultipleAxesComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartOtherAxis),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty AxisCrossingComponentDataProperty = BindableProperty.Create(
        nameof(AxisCrossingComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartOtherAxis),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty MultipleAxesCodeDescriptionProperty = BindableProperty.Create(
        nameof(MultipleAxesCodeDescription),
        typeof(string),
        typeof(SfCartesianChartOtherAxis),
        default(string)
    );

    public static readonly BindableProperty AxisCrossingCodeDescriptionProperty = BindableProperty.Create(
        nameof(AxisCrossingCodeDescription),
        typeof(string),
        typeof(SfCartesianChartOtherAxis),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> MultipleAxesComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(MultipleAxesComponentDataProperty);
        set => SetValue(MultipleAxesComponentDataProperty, value);
    }

    public ObservableCollection<SfCartesianChartModel> AxisCrossingComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(AxisCrossingComponentDataProperty);
        set => SetValue(AxisCrossingComponentDataProperty, value);
    }

    public string MultipleAxesCodeDescription
    {
        get => (string)GetValue(MultipleAxesCodeDescriptionProperty);
        set => SetValue(MultipleAxesCodeDescriptionProperty, value);
    }

    public string AxisCrossingCodeDescription
    {
        get => (string)GetValue(AxisCrossingCodeDescriptionProperty);
        set => SetValue(AxisCrossingCodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var axisCrossingInfo = (string[])Resources["AxisCrossingInfo"];
        AxisCrossingCollectionView.ItemsSource = axisCrossingInfo;
    }

    private async void OnMultipleAxesGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (MultipleAxesArrowImage.Rotation == 0)
        {
            await MultipleAxesArrowImage.RotateTo(90);
            MultipleAxesInfo.IsVisible = true;
        }
        else
        {
            await MultipleAxesArrowImage.RotateTo(0);
            MultipleAxesInfo.IsVisible = false;
        }
    }

    private async void OnAxisCrossingGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (AxisCrossingArrowImage.Rotation == 0)
        {
            await AxisCrossingArrowImage.RotateTo(90);
            AxisCrossingInfo.IsVisible = true;
        }
        else
        {
            await AxisCrossingArrowImage.RotateTo(0);
            AxisCrossingInfo.IsVisible = false;
        }
    }
    #endregion
}