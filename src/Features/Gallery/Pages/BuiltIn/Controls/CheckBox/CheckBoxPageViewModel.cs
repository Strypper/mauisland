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
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string standardCheckBoxXamlCode = "<CheckBox />";

    [ObservableProperty]
    string checkBoxWithColorXamlCode = "<CheckBox Color=\"#FFFFFF\"/>";

    [ObservableProperty]
    string checkBoxTrueByDefaultXamlCode = "<CheckBox IsChecked=\"True\"/>";

    [ObservableProperty]
    string checkBoxWithBindingXamlCode = "<CheckBox IsChecked=\"{x:Binding IsChecked, Mode=TwoWay}\"\r\nColor=\"{x:Binding CurrentColor, Mode=OneWay}\"/>";

    [ObservableProperty]
    string checkBoxWithLabelXamlCode = "<HorizontalStackLayout HorizontalOptions=\"Start\" VerticalOptions=\"Center\">\r\n                            <Label\r\n                                FontAttributes=\"Bold\"\r\n                                FontSize=\"Default\"\r\n                                Text=\"CheckBox 1\" />\r\n                            <CheckBox x:Name=\"checkBox1\" />\r\n                        </HorizontalStackLayout>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
