namespace MAUIsland.Core;

public partial class SfCartesianChartLegend : ContentView
{
    #region [ CTor ]
    public SfCartesianChartLegend()
    {
        InitializeComponent();
        PropertiesInfo.IsVisible = true;
        ItemLayoutLegendInfo.IsVisible = false;
        ItemTemplateLegendInfo.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstLineComponentDataProperty = BindableProperty.Create(
        nameof(FirstLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartLegend),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondLineComponentDataProperty = BindableProperty.Create(
        nameof(SecondLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartLegend),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty ThirdLineComponentDataProperty = BindableProperty.Create(
        nameof(ThirdLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartLegend),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty LegendCodeDescriptionProperty = BindableProperty.Create(
        nameof(LegendCodeDescription),
        typeof(string),
        typeof(SfCartesianChartLegend),
        default(string)
    );

    public static readonly BindableProperty ItemLayoutLegendCodeDescriptionProperty = BindableProperty.Create(
        nameof(ItemLayoutLegendCodeDescription),
        typeof(string),
        typeof(SfCartesianChartLegend),
        default(string)
    );

    public static readonly BindableProperty ItemTemplateLegendCodeDescriptionProperty = BindableProperty.Create(
        nameof(ItemTemplateLegendCodeDescription),
        typeof(string),
        typeof(SfCartesianChartLegend),
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

    public string LegendCodeDescription
    {
        get => (string)GetValue(LegendCodeDescriptionProperty);
        set => SetValue(LegendCodeDescriptionProperty, value);
    }

    public string ItemLayoutLegendCodeDescription
    {
        get => (string)GetValue(ItemLayoutLegendCodeDescriptionProperty);
        set => SetValue(ItemLayoutLegendCodeDescriptionProperty, value);
    }

    public string ItemTemplateLegendCodeDescription
    {
        get => (string)GetValue(ItemTemplateLegendCodeDescriptionProperty);
        set => SetValue(ItemTemplateLegendCodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var legendProperties = (string[])Resources["LegendProperties"];
        PropertiesCollectionView.ItemsSource = legendProperties;
    }

    private async void OnPropertiesGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (PropertiesArrowImage.Rotation == 0)
        {
            await PropertiesArrowImage.RotateTo(90);
            PropertiesInfo.IsVisible = true;
        }
        else
        {
            await PropertiesArrowImage.RotateTo(0);
            PropertiesInfo.IsVisible = false;
        }
    }

    private async void OnItemLayoutLegendGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ItemLayoutLegendArrowImage.Rotation == 0)
        {
            await ItemLayoutLegendArrowImage.RotateTo(90);
            ItemLayoutLegendInfo.IsVisible = true;
        }
        else
        {
            await ItemLayoutLegendArrowImage.RotateTo(0);
            ItemLayoutLegendInfo.IsVisible = false;
        }
    }

    private async void OnItemTemplateLegendGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ItemTemplateLegendArrowImage.Rotation == 0)
        {
            await ItemTemplateLegendArrowImage.RotateTo(90);
            ItemTemplateLegendInfo.IsVisible = true;
        }
        else
        {
            await ItemTemplateLegendArrowImage.RotateTo(0);
            ItemTemplateLegendInfo.IsVisible = false;
        }
    }
    #endregion
}