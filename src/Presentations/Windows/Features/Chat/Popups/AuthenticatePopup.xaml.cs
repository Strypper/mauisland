using CommunityToolkit.Diagnostics;

namespace MAUIsland;

public partial class AuthenticatePopup
{
    #region [Fields]
    private readonly AuthenticatePopupViewModel viewModel;
    #endregion

    public AuthenticatePopup(AuthenticatePopupViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }

    private void LoginFormContentView_LoginClicked(string username, string password)
    {
        Guard.IsNotNullOrEmpty(username);
        Guard.IsNotNullOrEmpty(password);
        viewModel.LoginCommand.Execute(new UserNameLoginDTO(username, password));
    }

    private void RegisterFormContentView_RegisterClick(string phoneNumber, string userName, string email, string password, string firstName, string lastName, string profilePicUrl)
    {
        Guard.IsNotNullOrEmpty(phoneNumber);
        Guard.IsNotNullOrEmpty(password);
        Guard.IsNotNullOrEmpty(email);
        Guard.IsNotNullOrEmpty(userName);
        Guard.IsNotNullOrEmpty(profilePicUrl);
        viewModel.SignUpCommand.Execute(new RegisterDTO(userName, firstName, lastName, phoneNumber, email, password, profilePicUrl));
    }
}