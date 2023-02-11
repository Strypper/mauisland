namespace MAUIsland;

public partial class TimePickerPage : IControlPage
{
    #region [CTor]
    public TimePickerPage(TimePickerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}