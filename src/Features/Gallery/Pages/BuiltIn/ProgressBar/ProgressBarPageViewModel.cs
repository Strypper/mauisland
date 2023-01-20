namespace MAUIsland;

public partial class ProgressBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public ProgressBarPageViewModel(IAppNavigator appNavigator)
                                               : base(appNavigator)
    {

    }
    #endregion

    #region [Property]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string standardProgressBarXamlCode = "<ProgressBar Progress=\"0\"\r\n             Margin=\"10\"\r\n             ProgressColor=\"Yellow\"/>";
    [ObservableProperty]
    string animateProgressBarXamlCode = "Control\r\n\r\n<ProgressBar x:Name=\"progress_bar2\"\r\n             Progress=\"0\"\r\n             Margin=\"10\"\r\n             ProgressColor=\"Red\"/>\r\n             \r\nClick Event\r\n\r\nprivate async void button2_Clicked(object sender, EventArgs e)\r\n    {\r\n        progress_bar2.Progress = 0;\r\n        button2.IsEnabled= false;\r\n        await progress_bar2.ProgressTo(0.99, 2000, Easing.BounceIn);\r\n        button2.IsEnabled= true;\r\n    }";

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
