namespace MAUIsland;

public partial class LabelPage : IControlPage
{
    #region [CTor]

    public LabelPage(LabelPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}