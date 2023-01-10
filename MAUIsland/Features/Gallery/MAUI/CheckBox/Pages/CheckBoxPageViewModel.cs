namespace MAUIsland;

public partial class CheckBoxPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public CheckBoxPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [ Fields ]
    [ObservableProperty]
    bool isChecked;

    [ObservableProperty]
    string currentColor = "F2F1F1";

    [ObservableProperty]
    string standardCheckBoxXamlCode = "<CheckBox />";

    [ObservableProperty]
    string checkBoxWithColorXamlCode = "<CheckBox Color=\"#FFFFFF\"/>";

    [ObservableProperty]
    string checkBoxTrueByDefaultXamlCode = "<CheckBox IsChecked=\"True\"/>";

    [ObservableProperty]
    string checkBoxWithBindingXamlCode = "<CheckBox IsChecked=\"{x:Binding IsChecked, Mode=TwoWay}\"\r\nColor=\"{x:Binding CurrentColor, Mode=OneWay}\"/>";

    [ObservableProperty]
    string checkBoxWithLabelXamlCode = "Label Text=\"CheckBox\"/>\r\n<CheckBox/>";
    #endregion
}
