using Syncfusion.Maui.Core;

namespace MAUIsland;
public partial class SfAvatarViewPage : IGalleryPage
{
    #region [CTor]
    public SfAvatarViewPage(SfAvatarViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    #endregion
}