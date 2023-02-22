namespace MAUIsland;

public partial class RegisterFormContentView : ContentView
{
    #region [Delegates]
    public delegate void RegisterEventHandler(string phoneNumber,
                                              string userName,
                                              string email,
                                              string password,
                                              string firstName,
                                              string lastName,
                                              string profilePicUrl);
    #endregion

    #region [Events]
    public event RegisterEventHandler RegisterClick;
    #endregion

    #region [CTor]
    public RegisterFormContentView()
    {
        InitializeComponent();
    }

    #endregion

    #region [Event Handlers]
    private void Signup_Clicked(object sender, EventArgs e)
    {
        RegisterClick?.Invoke(PhoneNumberEntry.Text,
                         EmailEntry.Text,
                         EmailEntry.Text,
                         ConfirmPasswordEntry.Text,
                         FirstNameEntry.Text,
                         LastNameEntry.Text,
                         "https://i.imgur.com/BhXNGWm.png");
    }
    #endregion

}