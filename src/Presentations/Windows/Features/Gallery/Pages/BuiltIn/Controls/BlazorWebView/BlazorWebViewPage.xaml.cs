using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace MAUIsland;

public partial class BlazorWebViewPage : IGalleryPage
{
    #region [ Fields ]

    private readonly BlazorWebViewPageViewModel viewModel;
    #endregion

    #region [ CTor ] 
    public BlazorWebViewPage(BlazorWebViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    #region [ Event Handlers ]
    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }

    private async void PageNavigateButton_Clicked(System.Object sender, System.EventArgs e)
    {
        var button = (Button)sender;
        var pageUrl = viewModel.BlazorWebViewStartPath + button.Text.Replace(" Page", "").ToLower();
        var wasDispatchCalled = await BlazorWebView.TryDispatchAsync(sp =>
        {
            var navMan = sp.GetRequiredService<NavigationManager>();
            navMan.NavigateTo(pageUrl);
        });
    }
    #endregion
}