namespace MAUIsland.Core;

public interface IDialogService
{
    Task<bool> ShowConfirmationAsync(string title, string message);
    Task ShowAlertAsync(string title, string message, string accept, string cancel);
    Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons);
}
