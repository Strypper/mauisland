using System.Diagnostics;

namespace MAUIsland;

public partial class RadioButtonPage : IControlPage
{
    #region [CTor]
    public RadioButtonPage(RadioButtonPageViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
    }

    #endregion


}