using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartTrackball : ContentView
{
    #region [ CTor ]
    public SfCartesianChartTrackball()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstLineComponentDataProperty = BindableProperty.Create(
        nameof(FirstLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartTrackball),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondLineComponentDataProperty = BindableProperty.Create(
        nameof(SecondLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartTrackball),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty ThirdLineComponentDataProperty = BindableProperty.Create(
        nameof(ThirdLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartTrackball),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty LabelDisplayModesProperty = BindableProperty.Create(
        nameof(LabelDisplayModes),
        typeof(ObservableCollection<string>),
        typeof(SfCartesianChartTrackball),
        default(ObservableCollection<string>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartTrackball),
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

    public ObservableCollection<string> LabelDisplayModes
    {
        get => (ObservableCollection<string>)GetValue(LabelDisplayModesProperty);
        set => SetValue(LabelDisplayModesProperty, value);
    }

    public string CodeDescription
    {
        get => (string)GetValue(CodeDescriptionProperty);
        set => SetValue(CodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        LabelDisplayModePicker.SelectedIndex = 0;

        var trackballBehaviorProperties = (string[])Resources["TrackballBehaviorProperties"];
        BehaviorPropertiesCollectionView.ItemsSource = trackballBehaviorProperties;

        var trackballDisplayEnum = (string[])Resources["TrackballDisplayEnum"];
        DisplayEnumCollectionView.ItemsSource = trackballDisplayEnum;

        var trackballActivationMode = (string[])Resources["TrackballActivationMode"];
        ActivationModeEnumCollectionView.ItemsSource = trackballActivationMode;

        var trackballLabelProperties = (string[])Resources["TrackballLabelProperties"];
        LabelPropertiesCollectionView.ItemsSource = trackballLabelProperties;
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

    private void OnPickerSelectedChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case (0): Trackball.DisplayMode = LabelDisplayMode.FloatAllPoints;
                break;
            case (1): Trackball.DisplayMode = LabelDisplayMode.NearestPoint;
                break;
            case (2): Trackball.DisplayMode = LabelDisplayMode.GroupAllPoints;
                break;
        }
    }
    #endregion
}