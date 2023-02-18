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
}