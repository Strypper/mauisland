namespace MAUIsland;

public partial class LabelPage
{
    #region [CTor]

    public LabelPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}