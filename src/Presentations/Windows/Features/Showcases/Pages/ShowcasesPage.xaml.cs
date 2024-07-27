namespace MAUIsland.Showcases;

public partial class ShowcasesPage
{
    Dictionary<(int min, int max), int> widthRanges = new()
    {
        { (1, 476), 1 },
        { (477, 782), 2 },
        { (783, 1098), 3 },
        { (1099, 1563), 4 }
    };

    private readonly ShowcasesPageViewModel viewModel;

    public ShowcasesPage(ShowcasesPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
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
}