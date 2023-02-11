namespace MAUIsland;
public partial class SfAvatarViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfAvatarViewPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        //base.OnInit(query);

        //ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion
}