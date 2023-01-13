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

    private void Button_Clicked2(object sender, EventArgs e)
    {
        example2.IsVisible = !example2.IsVisible;
        code2.IsVisible = !code2.IsVisible;
        if (example2.IsVisible)
        {
            showCode2.Text = "Show Code";
        }
        else
        {
            showCode2.Text = "Hide Code";
        }
    }

    private void Button_Clicked3(object sender, EventArgs e)
    {
        example3.IsVisible = !example3.IsVisible;
        code3.IsVisible = !code3.IsVisible;
        if (example3.IsVisible)
        {
            showCode3.Text = "Show Code";
        }
        else
        {
            showCode3.Text = "Hide Code";
        }
    }
}