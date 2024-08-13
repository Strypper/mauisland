namespace MAUIsland.Showcases;

public partial class ShowcasesPage
{
    #region [ Fields ]

    Dictionary<(int min, int max), int> widthRanges = new()
    {
        { (1, 676), 1 },
        { (677, 1142), 2 },
        { (1143, 1444), 3 },
        { (1445, 1863), 4 }
    };

    private readonly ShowcasesPageViewModel viewModel;

    #endregion

    #region [ CTor ]

    public ShowcasesPage(ShowcasesPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }

    #endregion

    #region [ Methods ]

    private void BasePage_Appearing(System.Object sender, System.EventArgs e)
    {

        ResizeWindows();
    }

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        var page = sender as Page; // Assuming your BasePage is derived from Page
        if (page != null)
        {
            double width = page.Width;
            double height = page.Height;

            viewModel.CollectionViewSpan = GetCorrespondingValue(widthRanges, width);
            System.Diagnostics.Debug.WriteLine($"Window size changed - Width: {width}, Height: {height}");
        }

    }

    private void ResizeWindows()
    {

        if (Window is not null)
        {
            Window.Width = 1200;
        }
    }

    int GetCorrespondingValue(Dictionary<(int min, int max), int> widthRanges, double width)
    {
        foreach (var range in widthRanges)
        {
            if (width >= range.Key.min && width <= range.Key.max)
            {
                return range.Value;
            }
        }

        // Handle case where width is greater than 1563
        if (width > 1563)
        {
            return 5;
        }

        throw new ArgumentOutOfRangeException(nameof(width), "Width is out of range.");
    }

    async Task CreateBackgroundImage()
    {
    }
    private async void root_Loaded(System.Object sender, System.EventArgs e)
    {

        DemoOverFlower.Rotation = -45;
        await DemoOverFlower.TranslateTo(110, 90, 1000);
    }
    #endregion

}