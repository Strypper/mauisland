namespace MAUIsland;

public partial class RadioButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public RadioButtonPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]

    [ObservableProperty]
    string codeExample1 = "<VerticalStackLayout>\r\n    <RadioButton Content=\"Cat\"\r\n         IsChecked=\"True\"/>\r\n    <RadioButton Content=\"Dog\"/>\r\n    <RadioButton Content=\"Fish/>\r\n    <RadioButton Content=\"Bird\"/>\r\n</VerticalStackLayout>";
    #endregion

}
