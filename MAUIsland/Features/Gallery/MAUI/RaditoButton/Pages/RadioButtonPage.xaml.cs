using System.Diagnostics;

namespace MAUIsland;

public partial class RadioButtonPage
{
    #region [CTor]
    public RadioButtonPage(RadioButtonPageViewModel vm)
    {
        InitializeComponent();
        BindingContext= vm;
    }

    #endregion

    private void Button_Clicked(object sender, EventArgs e)
    {
        example1.IsVisible = !example1.IsVisible;
        code1.IsVisible= !code1.IsVisible;
        if(example1.IsVisible)
        {
            showCode1.Text = "Show Code";
        }
        else
        {
            showCode1.Text = "Hide Code";
        }
    }
}