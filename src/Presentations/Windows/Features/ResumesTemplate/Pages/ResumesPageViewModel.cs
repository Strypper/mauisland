namespace MAUIsland.ResumesTemplate;

public partial class ResumesPageViewModel(IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    #region [ Relay Commands ]

    [RelayCommand]
    async Task NavigateUrlAsync(string url)
        => await AppNavigator.NavigateAsync(url);
    #endregion
}
