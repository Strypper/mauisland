using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace MAUIsland.ResumesTemplate;

public partial class DotNetTemplate : ComponentBase
{
    public DotNetTemplate()
    {
        
    }

    protected override async Task OnInitializedAsync()
    {
        ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        await base.OnInitializedAsync();
    }

    private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        StateHasChanged();
    }

    [Inject]
    protected ResumeDetailPageViewModel ViewModel { get; private set; }
}
