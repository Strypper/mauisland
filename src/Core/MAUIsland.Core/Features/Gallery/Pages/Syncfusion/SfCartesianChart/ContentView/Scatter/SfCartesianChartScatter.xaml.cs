namespace MAUIsland.Core;

public partial class SfCartesianChartScatter : ContentView
{
    #region [ CTor ]
    public SfCartesianChartScatter()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty FirstScatterComponentDataProperty = BindableProperty.Create(
        nameof(FirstScatterComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartScatter),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty SecondScatterComponentDataProperty = BindableProperty.Create(
        nameof(SecondScatterComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartScatter),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
        typeof(string),
        typeof(SfCartesianChartScatter),
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
}