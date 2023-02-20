namespace MAUIsland;

public partial class StepperPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public StepperPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string standardStepperXamlCode = "<StackLayout Margin=\"20\">\r\n                        <Label\r\n                            x:Name=\"_rotatingLabel\"\r\n                            FontSize=\"18\"\r\n                            HorizontalOptions=\"Center\"\r\n                            Text=\"ROTATING TEXT\"\r\n                            VerticalOptions=\"Center\" />\r\n                        <Stepper\r\n                            HorizontalOptions=\"Center\"\r\n                            Increment=\"30\"\r\n                            Maximum=\"360\"\r\n                            ValueChanged=\"OnStepperValueChanged\" />\r\n                        <Label\r\n                            x:Name=\"_displayLabel\"\r\n                            HorizontalOptions=\"Center\"\r\n                            Text=\"(uninitialized)\"\r\n                            VerticalOptions=\"Center\" />\r\n                    </StackLayout>";

    [ObservableProperty]
    string dataBindAStepperXamlCode = "<StackLayout Margin=\"20\">\r\n                        <Label\r\n                            FontSize=\"18\"\r\n                            HorizontalOptions=\"Center\"\r\n                            Rotation=\"{Binding Source={x:Reference _stepper}, Path=Value}\"\r\n                            Text=\"ROTATING TEXT\"\r\n                            VerticalOptions=\"Center\" />\r\n                        <Stepper\r\n                            x:Name=\"_stepper\"\r\n                            HorizontalOptions=\"Center\"\r\n                            Increment=\"30\"\r\n                            Maximum=\"360\" />\r\n                        <Label\r\n                            HorizontalOptions=\"Center\"\r\n                            Text=\"{Binding Source={x:Reference _stepper}, Path=Value, StringFormat='The Stepper value is {0:F0}'}\"\r\n                            VerticalOptions=\"Center\" />\r\n                    </StackLayout>";

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
