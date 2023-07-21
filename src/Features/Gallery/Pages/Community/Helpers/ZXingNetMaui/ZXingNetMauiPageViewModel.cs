namespace MAUIsland;
public partial class ZXingNetMauiPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public ZXingNetMauiPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion
}