namespace MAUIsland;

public partial class SfCartesianChartPage : IGalleryPage
{
    #region [Services]
    private readonly SfCartesianChartPageViewModel viewModel;
    #endregion

    #region [CTor]
    public SfCartesianChartPage(SfCartesianChartPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;

        AreaChartsSelectionCollectionView.SelectionChanged += OnAreaChartSelectionChanged;
        BarChartsSelectionCollectionView.SelectionChanged += OnColumnBarChartSelectionChanged;
        ColumnChartsSelectionCollectionView.SelectionChanged += OnColumnBarChartSelectionChanged;

        InitializeDefaultView();
    }
    #endregion

    private void InitializeDefaultView()
    { 
        AreaView.IsVisible = true;
        SqlineAreaView.IsVisible = false;
        StepAreaView.IsVisible = false;
        RangeAreaView.IsVisible = false;
        SplineRangeAreaView.IsVisible = false;
        StackingAreaView.IsVisible = false;
        StackingArea100View.IsVisible = false;

        BarView.IsVisible = true;
        RangeBarView.IsVisible = false;
        StackingBarView.IsVisible = false;
        StackingBar100View.IsVisible = false;

        ColumnView.IsVisible = false;
        RangeColumnView.IsVisible = false;
        StackingColumnView.IsVisible = false;
        StackingColumn100View.IsVisible = false;
    }

    private void OnAreaChartSelectionChanged(object sender, SelectionChangedEventArgs e) 
    { 
        AreaView.IsVisible = false;
        SqlineAreaView.IsVisible = false;
        StepAreaView.IsVisible = false;
        RangeAreaView.IsVisible = false;
        SplineRangeAreaView.IsVisible = false;
        StackingAreaView.IsVisible = false;
        StackingArea100View.IsVisible = false;

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string; 
        if (selectedOption != null) 
        { 
            switch (selectedOption) 
            { 
                case "Area": AreaView.IsVisible = true; 
                    break;
                case "Spline Area": SqlineAreaView.IsVisible = true;
                    break;
                case "Step Area":  StepAreaView.IsVisible = true;
                    break;
                case "Range Area": RangeAreaView.IsVisible = true;
                    break;
                case "Spline Range Area": SplineRangeAreaView.IsVisible = true;
                    break;
                case "Stacking Area":  StackingAreaView.IsVisible = true;
                    break;
                case "100% Stacking Area": StackingArea100View.IsVisible = true;
                    break;
            } 
        } 
    }

    private void OnColumnBarChartSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        BarView.IsVisible = false;
        RangeBarView.IsVisible = false;
        StackingBarView.IsVisible = false;
        StackingBar100View.IsVisible = false;

        ColumnView.IsVisible = false;
        RangeColumnView.IsVisible = false;
        StackingColumnView.IsVisible = false;
        StackingColumn100View.IsVisible = false;

        var selectedOption = e.CurrentSelection.FirstOrDefault() as string;
        if (selectedOption != null)
        {
            switch (selectedOption)
            {
                case "Bar": BarView.IsVisible = true;
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
}