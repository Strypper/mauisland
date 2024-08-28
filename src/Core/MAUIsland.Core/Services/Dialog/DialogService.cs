namespace MAUIsland.Core;

public class DialogService : IDialogService
{
    public Task<bool> ShowConfirmationAsync(string title, string message)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, "Yes", "Cancel");
    }

    public Task ShowAlertAsync(string title, string message, string accept, string cancel)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
    }

    public Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons)
    {
        return Application.Current.MainPage.DisplayActionSheet(title, "Closed", destruction, buttons);
    }
}
