namespace MAUIsland.ResumesTemplate;

public partial class ResumeDetailPageViewModel(IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{

    #region [ Properties ]

    [ObservableProperty]
    string blazorWebViewStartPath = "/resumes-template/dotnet-template";

    [ObservableProperty]
    string userName = "Jonh Doe";

    [ObservableProperty]
    List<string> items = ["ads", "bg"];
    #endregion
}
