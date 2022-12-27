namespace MAUIsland;

public partial class ButtonPageViewModel : NavigationAwareBaseViewModel
{
	#region [CTor]
	public ButtonPageViewModel(IAppNavigator appNavigator) 
									: base(appNavigator)
	{

	}
	#endregion

	#region [Properties]
	[ObservableProperty]
	bool isEnable = true;
	#endregion
}
