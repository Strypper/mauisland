namespace MAUIsland;
public partial class MaterialSwitchPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public MaterialSwitchPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string switchXamlCode = "<mdc:Switch />\r\n<mdc:Switch HasIcon=\"False\" />\r\n<mdc:Switch IsChecked=\"True\" />\r\n";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion
}