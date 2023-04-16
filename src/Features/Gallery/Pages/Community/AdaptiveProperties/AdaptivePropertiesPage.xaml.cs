namespace MAUIsland;
public partial class AdaptivePropertiesPage : IControlPage
{
    #region [CTor]
    public AdaptivePropertiesPage(AdaptivePropertiesPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion


}