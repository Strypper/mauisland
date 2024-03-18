namespace MAUIsland;

public partial class AvatarViewPage : IGalleryPage
{
    #region [CTor]
    public AvatarViewPage(AvatarViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}