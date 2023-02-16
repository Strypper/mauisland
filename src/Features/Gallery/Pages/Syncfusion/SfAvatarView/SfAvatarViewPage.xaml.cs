using Syncfusion.Maui.Core;

namespace MAUIsland;
public partial class SfAvatarViewPage : IControlPage
{
    #region [CTor]
    public SfAvatarViewPage(SfAvatarViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    #endregion
}