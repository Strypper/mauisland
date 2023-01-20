

namespace MAUIsland;

public partial class LabelPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public LabelPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    string labelSpanBinding = "as well as binding the label to a state";

    [ObservableProperty]
    string labelXamlCodeExample = "<Label>\r\n                        <Label.FormattedText>\r\n                            <FormattedString>\r\n                                <Span Text=\"Sometimes we only want to use one label to display a complex line of text rather than using multiples labels and arrange them inside a layout ex: \" />\r\n                                <Span\r\n                                    BackgroundColor=\"Gray\"\r\n                                    Text=\"HorizontalStackLayout\"\r\n                                    TextColor=\"Blue\" />\r\n                                <Span Text=\", You can also apply color to Span \" TextColor=\"Violet\" />\r\n                                <Span Text=\"{x:Binding LabelSpanBinding}\" TextColor=\"#e89e4e\" />\r\n                            </FormattedString>\r\n                        </Label.FormattedText>\r\n                    </Label>";

    [ObservableProperty]
    int selectedLineBreakModeIndex;

    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    List<string> lineBreakModes = Enum.GetNames(typeof(LineBreakMode)).ToList();
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
