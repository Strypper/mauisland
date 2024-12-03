namespace MAUIsland.Core;

public partial class SfCartesianChartSpline : ContentView
{
    #region [ CTor ]
    public SfCartesianChartSpline()
    {
        InitializeComponent();
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
}