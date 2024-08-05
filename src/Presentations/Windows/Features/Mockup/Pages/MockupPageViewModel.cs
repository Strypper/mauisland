using CommunityToolkit.Mvvm.Messaging;

#if WINDOWS
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
#endif


namespace MAUIsland.Mockup;

public partial class MockupPageViewModel(IAppNavigator appNavigator,
        Core.IFilePicker filePicker,
        IDialogService dialogService) : NavigationAwareBaseViewModel(appNavigator)
{
    #region [ Fields ]

    private readonly Core.IFilePicker filePicker = filePicker;
    private readonly IDialogService dialogService = dialogService;
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        WeakReferenceMessenger.Default.Unregister<DropImageMessage>(this);
        WeakReferenceMessenger.Default.Register<DropImageMessage>(this, async (r, m) =>
        {
            await DropImage(m.Value.Sender, m.Value.Args, m.Value.CollectionViewId);
        });

        WeakReferenceMessenger.Default.Unregister<DeleteScreenShotMessage>(this);
        WeakReferenceMessenger.Default.Register<DeleteScreenShotMessage>(this, async (r, m) =>
        {
            await RemoveScreenShot(m.Value);
        });

        RefreshAsync().FireAndForget();
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    ObservableCollection<MockupItemModel> mockupItems;

    [ObservableProperty]
    ObservableCollection<PreviewImageModel> previewImages;

    [ObservableProperty]
    PreviewImageModel selectedMockup;

    [ObservableProperty]
    bool canMockupFrameChangeState;

    [ObservableProperty]
    string selectedDevice;

    [ObservableProperty]
    string selectedTab;

    [ObservableProperty]
    List<string> devicesList;
    #endregion

    #region [ Properties - Mockup Keys ]

    [ObservableProperty]
    string iphone13Mini = "iPhone 13 Mini";

    [ObservableProperty]
    string appleIphone15ProMax = "Apple iPhone 15 Pro Max";

    [ObservableProperty]
    string samsungGalaxyS22Ultra = "Samsung Galaxy S22 Ultra";

    [ObservableProperty]
    string googlePixel6Pro = "Google Pixel 6 Pro";

    [ObservableProperty]
    string googlePixel5 = "Google Pixel 5";
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    async Task OpenFileAsync()
    {

    }

    [RelayCommand]
    async Task AddDeviceAsync()
        => AddDevice();

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task RemoveMockups()
    {
        var freshMockup = PreviewImages.Where(x => x.IsAddButton);
        PreviewImages = new(freshMockup);

        return Task.CompletedTask;
    }

    #endregion

    #region [ Methods ]

    async Task RefreshAsync()
    {
        string mockupItemGuid = Guid.NewGuid().ToString();

        PreviewImages = new()
        {
            new()
            {
                CollectionViewId = mockupItemGuid,
                IsAddButton = true,
            }
        };

        MockupItems = new()
        {
            new()
            {
                Id = mockupItemGuid,
                DeviceModel = Iphone13Mini,
                PreviewImages = PreviewImages
            }
        };

        DevicesList = new()
        {
            Iphone13Mini,
            AppleIphone15ProMax,
            SamsungGalaxyS22Ultra,
            GooglePixel6Pro,
            GooglePixel5
        };

        CanMockupFrameChangeState = true;

        SelectedDevice = Iphone13Mini;
    }

    partial void OnSelectedDeviceChanged(string value)
    {

    }

    async Task DropImage(Object sender, DropEventArgs e, string collectionViewId)
    {
#if WINDOWS
        var args = e.PlatformArgs!.DragEventArgs;

        var dv = e.PlatformArgs!.DragEventArgs.DataView;
        if (!dv.Contains(StandardDataFormats.StorageItems))
            return;

        var items = await dv.GetStorageItemsAsync();
        List<FileResult> filePaths = [];
        items.OfType<StorageFile>().ToList().ForEach(f => filePaths.Add(new(f.Path)));

        if (filePaths.Count > 0)
        {
            var mockupItem = MockupItems.FirstOrDefault(x => x.Id == collectionViewId);
            if (mockupItem is null)
                return;

            mockupItem.PreviewImages.Add(new()
            {
                Id = new Guid().ToString(),
                ImageSource = filePaths.First().FullPath,
                IsAddButton = false,
                CollectionViewId = mockupItem.Id
            });
            SelectedMockup = PreviewImages.LastOrDefault();
            e.Handled = true;
        }
        else
            return;
#endif
    }

    async Task AddDevice()
    {
        string newMockupCollectionViewId = Guid.NewGuid().ToString();
        MockupItems.Add(new()
        {
            Id = newMockupCollectionViewId,
            DeviceModel = Iphone13Mini,
            PreviewImages = new()
            {
                new()
                {
                    CollectionViewId = newMockupCollectionViewId,
                    IsAddButton = true
                }
            }
        });
    }

    async Task RemoveScreenShot(PreviewImageModel screenshot)
    {
        string dialogTitle = "Do you want to remove this screenshot ?";
        string dialogMessage = "This screenshot will be removed";
        var wantToScreenShot = await this.dialogService.ShowConfirmationAsync(dialogTitle, dialogMessage);
        if (!wantToScreenShot)
            return;

        if (screenshot.CollectionViewId is null)
            return;

        var mockupItem = MockupItems.FirstOrDefault(x => x.Id == screenshot.CollectionViewId);
        if (mockupItem is null)
            return;


        mockupItem.PreviewImages.Remove(screenshot);
    }


    #endregion
}