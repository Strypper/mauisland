using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
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
        if (ViewModel.WorksHistory != null)
            ViewModel.WorksHistory.CollectionChanged += WorksHistory_CollectionChanged;

        await base.OnInitializedAsync();
    }

    private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
       => StateHasChanged();

    private void WorksHistory_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
       => StateHasChanged();

    [Inject]
    protected ResumeDetailPageViewModel ViewModel { get; private set; }
}
