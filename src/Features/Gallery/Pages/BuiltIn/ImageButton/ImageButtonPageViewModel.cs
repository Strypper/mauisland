using CommunityToolkit.Maui.Storage;

namespace MAUIsland;

public partial class ImageButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IFilePicker filePicker;
    #endregion

    #region [CTor]
    public ImageButtonPageViewModel(IAppNavigator appNavigator,
                                    IFilePicker filePicker)
                                : base(appNavigator)
    {
        this.filePicker = filePicker;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    bool isEnable = true;

    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
<<<<<<< HEAD
    string standardButtonXamlCode = "<Button\r\n                            HorizontalOptions=\"Start\"\r\n                            IsEnabled=\"{x:Binding IsEnable}\"\r\n                            Text=\"Standard XAML Button\"\r\n                            VerticalOptions=\"Center\" />\r\n                        <HorizontalStackLayout HorizontalOptions = \"End\" >\r\n                            < CheckBox IsChecked=\"{x:Binding IsEnable, Mode=TwoWay}\" VerticalOptions=\"Center\" />\r\n                            <Label Text = \"Enable Button\" VerticalOptions=\"Center\" />\r\n                        </HorizontalStackLayout>";

=======
    ImageSource imageSource;

    [ObservableProperty]
    bool isEnable;

    [ObservableProperty]
    string standardButtonXamlCode;
>>>>>>> 8db9a834644453b23c0f2c6312e792171a570557
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task OpenFileAsync()
    {
        var pickedImage = await filePicker.OpenMediaPickerAsync();

        var imagefile = await filePicker.UploadImageFile(pickedImage);

        ImageSource = ImageSource.FromStream(() =>
            filePicker.ByteArrayToStream(filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
    }

    #endregion
}
