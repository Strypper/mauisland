namespace MAUIsland;

public partial class LoginFormContentView : ContentView
{
    #region [Delegates]
    public delegate void LoginEventHandler(string username, string password);
    #endregion

    #region [Events]
    public event LoginEventHandler LoginClicked;
    #endregion

    #region [CTor]
    public LoginFormContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Properties]
    #endregion

    #region [Event Handlers]
    private void Login_Clicked(object sender, EventArgs e)
    {
        LoginClicked?.Invoke(UserNameEntry.Text, PasswordEntry.Text);
    }
    #endregion

    private void root_Loaded(object sender, EventArgs e)
    {
        UserNameEntry.Text = "viet.to@totechs.com";
        PasswordEntry.Text = "Welkom112!!@";
    }
}