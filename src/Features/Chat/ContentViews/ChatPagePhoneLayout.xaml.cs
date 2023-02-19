namespace MAUIsland;

public partial class ChatPagePhoneLayout : ContentView
{
    #region [Delegates]
    public delegate void LoginEventHandler();
    #endregion

    #region [Events]
    public event LoginEventHandler LoginClicked;
    #endregion

    #region [CTor]
    public ChatPagePhoneLayout()
    {
        InitializeComponent();
    }
    #endregion

    private void ContentView_SizeChanged(object sender, EventArgs e)
    {
        if (Window is not null)
        {
            System.Diagnostics.Debug.WriteLine(Window.Height);
        }
    }
}