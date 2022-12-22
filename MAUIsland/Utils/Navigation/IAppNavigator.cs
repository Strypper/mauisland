namespace MAUIsland;

public interface IAppNavigator
{
    Task GoBackAsync(bool animated = false, object data = default);

    Task NavigateAsync(string target, bool animated = false, object args = default);

    Task<bool> OpenUrlAsync(string url);

    Task ShareAsync(string text, string title = default);

    Task ShowSnackbarAsync(string message, Action action = null, string actionText = null);
}
