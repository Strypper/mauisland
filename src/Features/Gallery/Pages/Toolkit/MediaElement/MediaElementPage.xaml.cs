namespace MAUIsland;
public partial class MediaElementPage : IControlPage
{
    #region [CTor]
    public MediaElementPage(MediaElementPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}