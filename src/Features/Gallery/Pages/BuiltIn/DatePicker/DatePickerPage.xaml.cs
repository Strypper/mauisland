namespace MAUIsland;

public partial class DatePickerPage : IControlPage
{
    #region [CTor]
    public DatePickerPage(DatePickerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}