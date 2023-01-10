namespace MAUIsland;

public partial class StackLayoutPage
{
    #region [CTor]

    public StackLayoutPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}