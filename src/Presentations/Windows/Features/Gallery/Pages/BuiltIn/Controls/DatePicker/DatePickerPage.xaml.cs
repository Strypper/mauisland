namespace MAUIsland;

public partial class DatePickerPage : IGalleryPage
{
    #region [CTor]
    public DatePickerPage(DatePickerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}