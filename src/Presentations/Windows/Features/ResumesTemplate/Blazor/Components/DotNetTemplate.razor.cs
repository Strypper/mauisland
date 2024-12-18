using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.Maui.Controls;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MAUIsland.ResumesTemplate;

public partial class DotNetTemplate : ComponentBase
{
    [Inject] 
    protected IJSRuntime JS { get; private set; }

    [Inject]
    protected ResumeDetailPageViewModel ViewModel { get; private set; }

    [Inject] 
    protected NavigationManager Navigation { get; private set; }

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

    private async void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ViewModel.SelectedPageIndex))
        {
            await ScrollToSectionAsync(ViewModel.Pages[ViewModel.SelectedPageIndex].Trim('#'));
        }
        if (e.PropertyName == nameof(ViewModel.SelectedWorksHistory))
        {
            await ScrollToElementAsync(ViewModel.SelectedWorksHistory.Id);
        }
        StateHasChanged();
    }

    private void WorksHistory_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
       => StateHasChanged();

    private void UpdatePageIndex(int index)
    {
        ViewModel.UpdatePageIndexCommand.Execute(index);
    }

    private void UpdateWorksHistoryItem(WorkHistoryModel work)
    {
        ViewModel.UpdateWorkHistorySelectedItemCommand.Execute(work);
    }

    private async Task ScrollToSectionAsync(string itemId)
    {
        await JS.InvokeVoidAsync("scrollToSection", (itemId));
    }

    private async Task ScrollToElementAsync(string itemId)
    {
        await JS.InvokeVoidAsync("scrollToElement", ("education" + itemId));
    }
}
