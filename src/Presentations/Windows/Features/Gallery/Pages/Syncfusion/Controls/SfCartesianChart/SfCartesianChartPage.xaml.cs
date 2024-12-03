namespace MAUIsland;

public partial class SfCartesianChartPage : IGalleryPage
{
    #region [Services]
    private readonly SfCartesianChartPageViewModel ViewModel;
    #endregion

    #region [CTor]
    public SfCartesianChartPage(SfCartesianChartPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = ViewModel = vm;
    }
    #endregion

    #region [ Override ]
    protected override void OnAppearing()
    {
        base.OnAppearing();

        InitializeDefaultView();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
    #endregion

    #region [ Events ]
    private void BasePage_Loaded(object sender, EventArgs e)
    {
        ViewModel.RefreshCommand.Execute(null);
    }

    private void AreaChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadAreaChartOptionCommand.Execute(null);
    }

    private void ColumnBarChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadColumnBarChartOptionCommand.Execute(null);
    }

    private void LineChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadLineChartOptionCommand.Execute(null);
    }

    private void ScatterChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadScatterChartOptionCommand.Execute(null);
    }

    private void HistogramChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadHistogramChartOptionCommand.Execute(null);
    }

    private void BoxPlotChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadBoxPlotChartOptionCommand.Execute(null);
    }

    private void BubbleChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadBubbleChartOptionCommand.Execute(null);
    }

    private void CandleChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadCandleChartOptionCommand.Execute(null);
    }

    private void WaterfallChartCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadWaterfallChartOptionCommand.Execute(null);
    }

    private void InitializeDefaultView()
    {
        AreaChartMenuView.IsVisible = false;
        BarChartMenuView.IsVisible = false;
        ColumnChartMenuView.IsVisible = false;
        LineChartMenuView.IsVisible = false;

        AreaDefaultView();
        BarDefaultView();
        ColumnDefaultView();
        LineDefaultView();
    }

    private void LineDefaultView()
    {
        LineView.IsVisible = false;
        SplineView.IsVisible = false;
        StepLineView.IsVisible = false;
        StackingLineView.IsVisible = false;
        StackingLineView100.IsVisible = false;
    }

    private void ColumnDefaultView()
    {
        ColumnView.IsVisible = false;
        RangeColumnView.IsVisible = false;
        StackingColumnView.IsVisible = false;
        StackingColumn100View.IsVisible = false;
    }

    private void BarDefaultView()
    {
        BarView.IsVisible = false;
        ErrorBarView.IsVisible = false;
        RangeBarView.IsVisible = false;
        StackingBarView.IsVisible = false;
        StackingBar100View.IsVisible = false;
    }

    private void AreaDefaultView()
    {
        AreaView.IsVisible = false;
        SqlineAreaView.IsVisible = false;
        StepAreaView.IsVisible = false;
        RangeAreaView.IsVisible = false;
        SplineRangeAreaView.IsVisible = false;
        StackingAreaView.IsVisible = false;
        StackingArea100View.IsVisible = false;
    }

    private void OnChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        InitializeDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        if (selectedOption != null) 
        { 
            switch (selectedOption)                                                 
            { 
                case "Area":
                    AreaChartMenuView.IsVisible = true;
                    AreaChartsCollectionView.IsVisible = true;
                    var areaSelectedItem = AreaChartsCollectionView.SelectedItem ?? null;
                    if (areaSelectedItem != null)
                    {
                        AreaChartChanged(areaSelectedItem.ToString());
                    }
                    break;
                case "Column":
                    ColumnChartMenuView.IsVisible = true;
                    BarChartMenuView.IsVisible = true;
                    ColumnChartsCollectionView.IsVisible = true;
                    BarChartsCollectionView.IsVisible = true; 
                    var columnBarSelectedItem = ColumnChartsCollectionView.SelectedItem ?? BarChartsCollectionView.SelectedItem ?? null;
                    if (columnBarSelectedItem != null)
                    {
                        ColumnBarChartChanged(columnBarSelectedItem.ToString());
                    }
                    break;
                case "Line":
                    LineChartMenuView.IsVisible= true;
                    LineChartsCollectionView.IsVisible = true;
                    var lineSelectedItem = LineChartsCollectionView.SelectedItem ?? null;
                    if (lineSelectedItem != null)
                    {
                        LineChartChanged(lineSelectedItem.ToString());
                    }
                    break;
                case "Scatter": 
                    break;
                case "Histogram":  
                    break;
                case "Box Plot": 
                    break;
                case "Bubble":
                    
                    break;
                case "Candle": 
                    break;
                case "Waterfall": 
                    break;
            } 
        }
    }

    private void OnAreaChartSelectionChanged(object sender, SelectionChangedEventArgs e) 
    {
        AreaDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        AreaChartChanged(selectedOption);
    }

    private void OnColumnBarChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        BarDefaultView();
        ColumnDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        ColumnBarChartChanged(selectedOption);
    }

    private void OnLineChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LineDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        LineChartChanged(selectedOption);
    }

    private void OnScatterChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ScatterDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        ScatterChartChanged(selectedOption);
    }
    #endregion

    #region [ Methods ]
    private void AreaChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Area":
                    AreaView.IsVisible = true;
                    //AreaView.IsEnabled = true;
                    break;
                case "Spline Area":
                    SqlineAreaView.IsVisible = true;
                    //SqlineAreaView.IsEnabled = true;
                    break;
                case "Step Area":
                    StepAreaView.IsVisible = true;
                    //StepAreaView.IsEnabled = true;
                    break;
                case "Range Area":
                    RangeAreaView.IsVisible = true;
                    //RangeAreaView.IsEnabled = true;
                    break;
                case "Spline Range Area":
                    SplineRangeAreaView.IsVisible = true;
                    //SplineRangeAreaView.IsEnabled = true;
                    break;
                case "Stacking Area":
                    StackingAreaView.IsVisible = true;
                    //StackingAreaView.IsEnabled = true;
                    break;
                case "100% Stacking Area":
                    StackingArea100View.IsVisible = true;
                    //StackingArea100View.IsEnabled = true;
                    break;
            }
        }
    }

    private void ColumnBarChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Bar":
                    BarView.IsVisible = true;
                    //BarView.IsEnabled = true;
                    break;
                case "Error Bar":
                    ErrorBarView.IsVisible = true;
                    //ErrorBarView.IsEnabled = true;
                    break;
                case "Range Bar":
                    RangeBarView.IsVisible = true;
                    //RangeBarView.IsEnabled = true;
                    break;
                case "Stacking Bar":
                    StackingBarView.IsVisible = true;
                    //StackingBarView.IsEnabled = true;
                    break;
                case "Stacking Bar 100":
                    StackingBar100View.IsVisible = true;
                    //StackingBar100View.IsEnabled = true;
                    break;
                case "Column":
                    ColumnView.IsVisible = true;
                    //ColumnView.IsEnabled = true;
                    break;
                case "Range Column":
                    RangeColumnView.IsVisible = true;
                    //RangeColumnView.IsEnabled = true;
                    break;
                case "Stacking Column":
                    StackingColumnView.IsVisible = true;
                    //StackingColumnView.IsEnabled = true;
                    break;
                case "Stacking Column 100":
                    StackingColumn100View.IsVisible = true;
                    //StackingColumn100View.IsEnabled = true;
                    break;
            }
        }
    }

    private void LineChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Line":
                    LineView.IsVisible = true;
                    //LineView.IsEnabled = true;
                    break;
                case "Spline":
                    SplineView.IsVisible = true;
                    //SplineView.IsEnabled = true;
                    break;
                case "Step Line":
                    StepLineView.IsVisible = true;
                    //StepLineView.IsEnabled = true;
                    break;
                case "Stacking Line":
                    StackingLineView.IsVisible = true;
                    //StackingLineView.IsEnabled = true;
                    break;
                case "Stacking Line 100":
                    StackingLineView100.IsVisible = true;
                    //StackingLineView100.IsEnabled = true;
                    break;
            }
        }
    }

    private void ScatterChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Scatter":
                    ScatterView.IsVisible = true;
                    break;
            }
        }
    }
    #endregion
}