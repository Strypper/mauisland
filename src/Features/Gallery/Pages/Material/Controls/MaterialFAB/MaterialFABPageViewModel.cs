namespace MAUIsland;
public partial class MaterialFABPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public MaterialFABPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string fabXamlCode = "<mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource SecondaryFABStyle}\" />\r\n                        <mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource SurfaceFABStyle}\" />\r\n                        <mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource TertiaryFABStyle}\" />\r\n                        <mdc:FAB\r\n                            IconKind=\"Add\"\r\n                            IsExtended=\"True\"\r\n                            Style=\"{DynamicResource SecondaryFABStyle}\"\r\n                            Text=\"Extended\" />\r\n                        <mdc:FAB IconKind=\"Add\" Style=\"{DynamicResource LargeSecondaryFABStyle}\" />";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion
}