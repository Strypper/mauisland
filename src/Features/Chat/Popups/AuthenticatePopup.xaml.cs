namespace MAUIsland;

public partial class AuthenticatePopup
{
	public AuthenticatePopup(AuthenticatePopupViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}