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

    #region [ Events ]
    private void BasePage_Loaded(object sender, EventArgs e)
    {
        ViewModel.RefreshCommand.Execute(null);
        ViewModel.LoadAreaDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadColumnBarDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadLineDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadScatterDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadHistogramDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadBoxPlotDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadBubbleDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadFinancialDefaultChartOptionCommand.Execute(null);
        ViewModel.LoadWaterfallDefaultChartOptionCommand.Execute(null);
    }

    private void ChartsCollectionView_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadChartOptionCommand.Execute(null);
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
                    ScatterChartMenuView.IsVisible = true;
                    ScatterChartsCollectionView.IsVisible = true;
                    var scatterSelectedItem = ScatterChartsCollectionView.SelectedItem ?? null;
                    if (scatterSelectedItem != null)
                    {
                        ScatterChartChanged(scatterSelectedItem.ToString());
                    }
                    break;
                case "Histogram":
                    HistogramChartMenuView.IsVisible = true;
                    HistogramChartsCollectionView.IsVisible = true;
                    var histogramSelectedItem = HistogramChartsCollectionView.SelectedItem ?? null;
                    if (histogramSelectedItem != null)
                    {
                        HistogramChartChanged(histogramSelectedItem.ToString());
                    }
                    break;
                case "Box Plot":
                    BoxPlotChartMenuView.IsVisible = true;
                    BoxPlotChartsCollectionView.IsVisible = true;
                    var boxPlotSelectedItem = BoxPlotChartsCollectionView.SelectedItem ?? null;
                    if (boxPlotSelectedItem != null)
                    {
                        BoxPlotChartChanged(boxPlotSelectedItem.ToString());
                    }
                    break;
                case "Bubble":
                    BubbleChartMenuView.IsVisible = true;
                    BubbleChartsCollectionView.IsVisible = true;
                    var bubbleSelectedItem = BubbleChartsCollectionView.SelectedItem ?? null;
                    if (bubbleSelectedItem != null)
                    {
                        BubbleChartChanged(bubbleSelectedItem.ToString());
                    }
                    break;
                case "Financial":
                    FinancialChartMenuView.IsVisible = true;
                    FinancialChartsCollectionView.IsVisible = true;
                    var financialSelectedItem = FinancialChartsCollectionView.SelectedItem ?? null;
                    if (financialSelectedItem != null)
                    {
                        FinancialChartChanged(financialSelectedItem.ToString());
                    }
                    break;
                case "Waterfall":
                    WaterfallChartMenuView.IsVisible = true;
                    WaterfallChartsCollectionView.IsVisible = true;
                    var waterfallSelectedItem = WaterfallChartsCollectionView.SelectedItem ?? null;
                    if (waterfallSelectedItem != null)
                    {
                        WaterfallChartChanged(waterfallSelectedItem.ToString());
                    }
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

    private void OnBubbleChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        BubbleDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        BubbleChartChanged(selectedOption);
    }

    private void OnBoxPlotChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        BoxPlotDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        BoxPlotChartChanged(selectedOption);
    }

    private void OnHistogramChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        HistogramDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        HistogramChartChanged(selectedOption);
    }

    private void OnFinancialChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        FinancialDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        FinancialChartChanged(selectedOption);
    }

    private void OnWaterfallChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        WaterfallDefaultView();

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        WaterfallChartChanged(selectedOption);
    }
    #endregion

    #region [ Methods ]
    private void InitializeDefaultView()
    {
        AreaChartMenuView.IsVisible = false;
        AreaChartsCollectionView.IsVisible = false;

        BarChartMenuView.IsVisible = false;
        BarChartsCollectionView.IsVisible = false;

        ColumnChartMenuView.IsVisible = false;
        ColumnChartsCollectionView.IsVisible = false;

        LineChartMenuView.IsVisible = false;
        LineChartsCollectionView.IsVisible = false;

        ScatterChartMenuView.IsVisible = false;
        ScatterChartsCollectionView.IsVisible = false;

        BubbleChartMenuView.IsVisible = false;
        BubbleChartsCollectionView.IsVisible = false;

        BoxPlotChartMenuView.IsVisible = false;
        BoxPlotChartsCollectionView.IsVisible = false;

        HistogramChartMenuView.IsVisible = false;
        HistogramChartsCollectionView.IsVisible = false;

        FinancialChartMenuView.IsVisible = false;
        FinancialChartsCollectionView.IsVisible = false;

        WaterfallChartMenuView.IsVisible = false;
        WaterfallChartsCollectionView.IsVisible = false;

        AreaDefaultView();
        BarDefaultView();
        ColumnDefaultView();
        LineDefaultView();
        ScatterDefaultView();
        BubbleDefaultView();
        BoxPlotDefaultView();
        HistogramDefaultView();
        FinancialDefaultView();
        WaterfallDefaultView();
    }

    private void WaterfallDefaultView()
    {
        WaterfallView.IsVisible = false;
    }

    private void FinancialDefaultView()
    {
        CandleView.IsVisible = false;
        OHLCView.IsVisible = false;
    }

    private void HistogramDefaultView()
    {
        HistogramView.IsVisible = false;
    }

    private void BoxPlotDefaultView()
    {
        BoxAndWhiskerView.IsVisible = false;
    }

    private void BubbleDefaultView()
    {
        BubbleView.IsVisible = false;
    }

    private void ScatterDefaultView()
    {
        ScatterView.IsVisible = false;
    }

    private void LineDefaultView()
    {
        LineView.IsVisible = false;
        SplineView.IsVisible = false;
        StepLineView.IsVisible = false;
        StackingLineView.IsVisible = false;
        StackingLine100View.IsVisible = false;
        FastLineView.IsVisible = false;
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

    private void AreaChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Area": AreaView.IsVisible = true;
                    break;
                case "Spline Area": SqlineAreaView.IsVisible = true;
                    break;
                case "Step Area": StepAreaView.IsVisible = true;
                    break;
                case "Range Area": RangeAreaView.IsVisible = true;
                    break;
                case "Spline Range Area": SplineRangeAreaView.IsVisible = true;
                    break;
                case "Stacking Area": StackingAreaView.IsVisible = true;
                    break;
                case "100% Stacking Area": StackingArea100View.IsVisible = true;
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
                case "Bar": BarView.IsVisible = true;
                    break;
                case "Error Bar": ErrorBarView.IsVisible = true;
                    break;
                case "Range Bar": RangeBarView.IsVisible = true;
                    break;
                case "Stacking Bar": StackingBarView.IsVisible = true;
                    break;
                case "Stacking Bar 100": StackingBar100View.IsVisible = true;
                    break;
                case "Column": ColumnView.IsVisible = true;
                    break;
                case "Range Column": RangeColumnView.IsVisible = true;
                    break;
                case "Stacking Column": StackingColumnView.IsVisible = true;
                    break;
                case "Stacking Column 100": StackingColumn100View.IsVisible = true;
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
                case "Line": LineView.IsVisible = true;
                    break;
                case "Spline": SplineView.IsVisible = true;
                    break;
                case "Step Line": StepLineView.IsVisible = true;
                    break;
                case "Stacking Line": StackingLineView.IsVisible = true;
                    break;
                case "Stacking Line 100": StackingLine100View.IsVisible = true;
                    break;
                case "Fast Line": FastLineView.IsVisible = true;
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
                case "Scatter": ScatterView.IsVisible = true;
                    break;
            }
        }
    }

    private void BubbleChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Bubble": BubbleView.IsVisible = true;
                    break;
            }
        }
    }

    private void BoxPlotChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Box And Whisker": BoxAndWhiskerView.IsVisible = true;
                    break;
            }
        }
    }

    private void HistogramChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Histogram": HistogramView.IsVisible = true;
                    break;
            }
        }
    }

    private void FinancialChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Candle": CandleView.IsVisible = true;
                    break;
                case "OHLC": OHLCView.IsVisible = true;
                    break;
            }
        }
    }

    private void WaterfallChartChanged(string value)
    {
        if (value != null)
        {
            switch (value)
            {
                case "Waterfall": WaterfallView.IsVisible = true;
                    break;
            }
        }
    }
    #endregion
}