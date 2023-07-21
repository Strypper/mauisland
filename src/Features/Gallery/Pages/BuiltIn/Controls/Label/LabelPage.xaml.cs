namespace MAUIsland;

public partial class LabelPage : IGalleryPage
{
    #region [CTor]

    public LabelPage(LabelPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}