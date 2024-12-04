namespace MAUIsland.Core;

public partial class SfCartesianChartArea : ContentView
{
    #region [ CTor ]
    public SfCartesianChartArea()
    {
        InitializeComponent();
        Info.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartArea),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartArea),
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
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var rangeAreaChartInfo = (string[])Resources["AreaChartInfo"];
        RangeAreaChartCollectionView.ItemsSource = rangeAreaChartInfo;
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
            Info.IsVisible= false;
        } 
    }
    #endregion
}
