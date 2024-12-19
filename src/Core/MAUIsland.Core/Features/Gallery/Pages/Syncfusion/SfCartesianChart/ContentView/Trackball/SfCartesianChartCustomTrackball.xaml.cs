using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartCustomTrackball : ContentView
{
    #region [ CTor ]
    public SfCartesianChartCustomTrackball()
    {
        InitializeComponent();
        ItemInfo.IsVisible = false;
        AxisInfo.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstLineComponentDataProperty = BindableProperty.Create(
        nameof(FirstLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartCustomTrackball),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondLineComponentDataProperty = BindableProperty.Create(
        nameof(SecondLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartCustomTrackball),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty ThirdLineComponentDataProperty = BindableProperty.Create(
        nameof(ThirdLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartCustomTrackball),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SeriesCodeDescriptionProperty = BindableProperty.Create(
        nameof(SeriesCodeDescription),
        typeof(string),
        typeof(SfCartesianChartCustomTrackball),
        default(string)
    );

    public static readonly BindableProperty AxisCodeDescriptionProperty = BindableProperty.Create(
        nameof(AxisCodeDescription),
        typeof(string),
        typeof(SfCartesianChartCustomTrackball),
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

    public string SeriesCodeDescription
    {
        get => (string)GetValue(SeriesCodeDescriptionProperty);
        set => SetValue(SeriesCodeDescriptionProperty, value);
    }

    public string AxisCodeDescription
    {
        get => (string)GetValue(AxisCodeDescriptionProperty);
        set => SetValue(AxisCodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private async void OnItemGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ItemArrowImage.Rotation == 0)
        {
            await ItemArrowImage.RotateTo(90);
            ItemInfo.IsVisible = true;
        }
        else
        {
            await ItemArrowImage.RotateTo(0);
            ItemInfo.IsVisible = false;
        }
    }

    private async void OnAxisGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (AxisArrowImage.Rotation == 0)
        {
            await AxisArrowImage.RotateTo(90);
            AxisInfo.IsVisible = true;
        }
        else
        {
            await AxisArrowImage.RotateTo(0);
            AxisInfo.IsVisible = false;
        }
    }
    #endregion
}