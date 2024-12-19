using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartSelection : ContentView
{
    #region [ CTor ]
    public SfCartesianChartSelection()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartSelection),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty XamlCodeDescriptionProperty = BindableProperty.Create(
        nameof(XamlCodeDescription),
        typeof(string),
        typeof(SfCartesianChartSelection),
        default(string)
    );

    public static readonly BindableProperty CSharpCodeDescriptionProperty = BindableProperty.Create(
        nameof(CSharpCodeDescription),
        typeof(string),
        typeof(SfCartesianChartSelection),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string XamlCodeDescription
    {
        get => (string)GetValue(XamlCodeDescriptionProperty);
        set => SetValue(XamlCodeDescriptionProperty, value);
    }

    public string CSharpCodeDescription
    {
        get => (string)GetValue(CSharpCodeDescriptionProperty);
        set => SetValue(CSharpCodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        DataPointSelection.Type = e.Value ? ChartSelectionType.Multiple : ChartSelectionType.SingleDeselect;
    }
    #endregion
}