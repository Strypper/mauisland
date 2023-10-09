namespace MAUIsland;
public partial class DevExpressButtonPage : IGalleryPage
{
    #region [CTor]
    public DevExpressButtonPage(DevExpressButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}