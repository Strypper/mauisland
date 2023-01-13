namespace MAUIsland;

public partial class LabelPage
{
    #region [CTor]

    public LabelPage(LabelPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}