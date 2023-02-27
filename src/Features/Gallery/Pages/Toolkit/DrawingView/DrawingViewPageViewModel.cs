using CommunityToolkit.Maui.Core;

namespace MAUIsland;
public partial class DrawingViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public DrawingViewPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;
    [ObservableProperty]
    IDrawingLine myLines;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();
        
    }
    #endregion
}