namespace MAUIsland.ResumesTemplate;

public partial class ResumeDetailPageViewModel(IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    #region [ Properties ]

    [ObservableProperty]
    string blazorWebViewStartPath = "/resumes-template";
    #endregion
}
