namespace MAUIsland;

public partial class GalleryPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public GalleryPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]

    #endregion

    #region [RelayCommand]

    [RelayCommand]
    Task NavigateToMauiControlAsync() => AppNavigator.NavigateAsync(AppRoutes.MAUIAllControlsPage);
    #endregion
}
