using Microsoft.AspNetCore.Components;

namespace MAUIsland.ResumesTemplate;

public partial class ResumeDetailPage
{

    #region [ CTor ]

    public ResumeDetailPage(ResumeDetailPageViewModel vm)
    {
        InitializeComponent();

        this.BindingContext = vm;
    }
    #endregion

    private async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var a = await BlazorWebViewElement.TryDispatchAsync(sp =>
        {
            var navMan = sp.GetRequiredService<NavigationManager>();
            navMan.NavigateTo("/resumes-template/dotnet-template");
        });
    }

    private async void BlazorWebViewElement_Loaded(System.Object sender, System.EventArgs e)
    {
        await BlazorWebViewElement.TryDispatchAsync(sp =>
        {
            var navMan = sp.GetRequiredService<NavigationManager>();
            navMan.NavigateTo("/resumes-template/dotnet-template");
        });
    }

}