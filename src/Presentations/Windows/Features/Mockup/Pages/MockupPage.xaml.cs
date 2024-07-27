

#if WINDOWS
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
#endif

namespace MAUIsland.Mockup;

public partial class MockupPage
{
    #region [ Fields ]

    private readonly MockupPageViewModel viewModel;
    #endregion

    public MockupPage(MockupPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }

    private async void AddButton_ImageDropped(Object sender, DropEventArgs e, AddButtonEventModel model)
    {
        await DropImage(sender, e);
    }

    private async Task DropImage(Object sender, DropEventArgs e)
    {
#if WINDOWS
        var args = e.PlatformArgs!.DragEventArgs;

        var dv = e.PlatformArgs!.DragEventArgs.DataView;
        if (!dv.Contains(StandardDataFormats.StorageItems))
        {
            return;
        }

        var items = await dv.GetStorageItemsAsync();
        List<FileResult> filePaths = [];
        items.OfType<StorageFile>().ToList().ForEach(f => filePaths.Add(new(f.Path)));

        if (filePaths.Count > 0)
        {
            viewModel.PreviewImages.Add(new()
            {
                Id = new Guid().ToString(),
                ImageSource = filePaths.First().FullPath,
                IsAddButton = false,
            });
            viewModel.SelectedMockUp = viewModel.PreviewImages.LastOrDefault();
            e.Handled = true;
        }
        else
            return;
#endif
    }

    private async void ExportMockUpButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var result = await iPhone13MiniMockup.CaptureAsync();
        using MemoryStream stream = new();

        await result.CopyToAsync(stream);
        File.WriteAllBytes("C:\\Users\\Strypper\\Desktop\\Bruh.png", stream.ToArray());
    }

    private void RemoveAllMockUpButton_Clicked(System.Object sender, System.EventArgs e)
    {
        viewModel.PreviewImages.Clear();
    }
}