namespace MAUIsland;

public partial class TimePickerPage : IGalleryPage
{
    #region [CTor]
    public TimePickerPage(TimePickerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}