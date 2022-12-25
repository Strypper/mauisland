namespace MAUIsland;

public partial class ButtonPageViewModel : NavigationAwareBaseViewModel
{
	#region [CTor]
	public ButtonPageViewModel(IAppNavigator appNavigator) 
									: base(appNavigator)
	{

	}
	#endregion

	#region [Fields]
	[ObservableProperty]
	bool isEnable = true;
	#endregion
}
