using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartZooming : ContentView
{
    #region [ CTor ]
    public SfCartesianChartZooming()
    {
        InitializeComponent();
        //Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstScatterComponentDataProperty = BindableProperty.Create(
        nameof(FirstScatterComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartZooming),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondScatterComponentDataProperty = BindableProperty.Create(
        nameof(SecondScatterComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartZooming),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartZooming),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> FirstScatterComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(FirstScatterComponentDataProperty);
        set => SetValue(FirstScatterComponentDataProperty, value);
    }

    public ObservableCollection<SfCartesianChartModel> SecondScatterComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(SecondScatterComponentDataProperty);
        set => SetValue(SecondScatterComponentDataProperty, value);
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
        var zoomMode = Enum.GetNames(typeof(ZoomMode)).ToList();
        ZoomModePicker.ItemsSource = zoomMode;
        ZoomModePicker.SelectedIndex = 2;   
    }

    private void OnZoomModeChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        switch (selectedIndex)
        {
            case 0: Zooming.ZoomMode = ZoomMode.X;
                break;
            case 1: Zooming.ZoomMode = ZoomMode.Y;
                break;
            case 2: Zooming.ZoomMode = ZoomMode.XY;
                break;

        };
    }
    #endregion
}