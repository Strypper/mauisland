namespace MAUIsland.Mockup;

public partial class MockupPage
{
    #region [ Fields ]

    private readonly MockupPageViewModel viewModel;
    #endregion

    #region [ CTors ]

    public MockupPage(MockupPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    #region [ Event Handlers ]

    private async void ExportMockUpButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var result = await iPhone13MiniMockup.CaptureAsync();
        using MemoryStream stream = new();

        await result.CopyToAsync(stream);
        File.WriteAllBytes("C:\\Users\\Strypper\\Desktop\\Bruh.png", stream.ToArray());
    }
    #endregion
}