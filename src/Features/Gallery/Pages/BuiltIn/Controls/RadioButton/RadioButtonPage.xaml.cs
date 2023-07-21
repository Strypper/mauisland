using System.Diagnostics;

namespace MAUIsland;

public partial class RadioButtonPage : IGalleryPage
{
    #region [CTor]
    public RadioButtonPage(RadioButtonPageViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
    }

    #endregion


}