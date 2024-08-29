using Microsoft.AspNetCore.Components;

namespace MAUIsland.ResumesTemplate;

public partial class ResumeDetailPage
{
    public ResumeDetailPage()
    {
        InitializeComponent();
    }

    private async void BasePage_Loaded(System.Object sender, System.EventArgs e)
    {
        await blazorWebView.TryDispatchAsync(sp =>
        {
            var navMan = sp.GetRequiredService<NavigationManager>();
            navMan.NavigateTo("/test");
        });
    }

    private async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var a = await blazorWebView.TryDispatchAsync(sp =>
        {
            var navMan = sp.GetRequiredService<NavigationManager>();
            navMan.NavigateTo("/controls");
        });
    }
}