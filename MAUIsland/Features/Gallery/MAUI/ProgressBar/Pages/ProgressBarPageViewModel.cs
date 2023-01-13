

namespace MAUIsland;

public partial class ProgressBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public ProgressBarPageViewModel(IAppNavigator appNavigator)
                                               : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]

    [ObservableProperty]
    string standardRadioButtonXamlCode = "<VerticalStackLayout>\r\n    <RadioButton Content=\"Cat\"\r\n         IsChecked=\"True\"/>\r\n    <RadioButton Content=\"Dog\"/>\r\n    <RadioButton Content=\"Fish/>\r\n    <RadioButton Content=\"Bird\"/>\r\n</VerticalStackLayout>";
    
    #endregion
}
