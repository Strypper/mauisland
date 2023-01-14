namespace MAUIsland;

public partial class DatePickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public DatePickerPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    string simpleDatePickerXamlCode = "<DatePicker />";
    #endregion
}
