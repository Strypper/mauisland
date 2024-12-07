using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartSeriesSelection : ContentView
{
    #region [ CTor ]
    public SfCartesianChartSeriesSelection()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartSeriesSelection),
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
    List<int> SelectedIndexes = new List<int>();

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
        SeriesSelection.Type = e.Value ? ChartSelectionType.Multiple : ChartSelectionType.SingleDeselect;
        SelectedIndexes.Clear();

        var fadedColors = new List<SolidColorBrush> 
        {
            new SolidColorBrush(Color.FromArgb("#8000BDAE")),
            new SolidColorBrush(Color.FromArgb("#80404041")),
            new SolidColorBrush(Color.FromArgb("#80357CD2"))
        };

        foreach (var series in SelectionChart.Series)
        {
            series.Fill = fadedColors[SelectionChart.Series.IndexOf(series)];
        }
    }

    private void SelectionChanging(object sender, ChartSelectionChangingEventArgs e)
    {
        var defaultColors = new List<SolidColorBrush>
        {
            new SolidColorBrush(Color.FromArgb("#00BDAE")),
            new SolidColorBrush(Color.FromArgb("#404041")),
            new SolidColorBrush(Color.FromArgb("#357CD2"))
        };

        var fadedColors = new List<SolidColorBrush>
        {
            new SolidColorBrush(Color.FromArgb("#8000BDAE")),
            new SolidColorBrush(Color.FromArgb("#80404041")),
            new SolidColorBrush(Color.FromArgb("#80357CD2"))
        };

        // Create a HashSet of all selected indexes including old and new indexes.
        var selectedIndexes = new HashSet<int>(SelectedIndexes);

        // Add new indexes to the selected set.
        foreach (var index in e.NewIndexes)
        {
            selectedIndexes.Add(index);
            if (!SelectedIndexes.Contains(index))
                SelectedIndexes.Add(index);
        }

        // Remove old indexes from the selected set.
        foreach (var index in e.OldIndexes)
        {
            selectedIndexes.Remove(index);
            if (SelectedIndexes.Contains(index))
                SelectedIndexes.Remove(index);
        }

        // Set the fill color based on whether the index is in the selected set.
        foreach (var series in SelectionChart.Series)
        {
            int index = SelectionChart.Series.IndexOf(series);
            series.Fill = selectedIndexes.Contains(index) ? defaultColors[index] : fadedColors[index];
        }
    }

    #endregion
}