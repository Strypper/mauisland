

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
