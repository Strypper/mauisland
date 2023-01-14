

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
    List<string> lineBreakModes = Enum.GetNames(typeof(LineBreakMode)).ToList();
    #endregion
}
