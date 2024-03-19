namespace MAUIsland;

public partial class PickerPage : IGalleryPage
{
    #region [CTor]
    public PickerPage(PickerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}