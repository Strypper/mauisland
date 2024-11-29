namespace MAUIsland.Core;

public partial class SfCartesianChartStackingLine : ContentView
{
    #region [ CTor ]
    public SfCartesianChartStackingLine()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstLineComponentDataProperty = BindableProperty.Create(
        nameof(FirstLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStackingLine),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondLineComponentDataProperty = BindableProperty.Create(
        nameof(SecondLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStackingLine),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty ThirdLineComponentDataProperty = BindableProperty.Create(
        nameof(ThirdLineComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartStackingLine),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartStackingLine),
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
}