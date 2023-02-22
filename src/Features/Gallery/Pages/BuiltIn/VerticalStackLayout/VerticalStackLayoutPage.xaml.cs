namespace MAUIsland;
public partial class VerticalStackLayoutPage : IControlPage
{
    #region [CTor]
    public VerticalStackLayoutPage(VerticalStackLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}