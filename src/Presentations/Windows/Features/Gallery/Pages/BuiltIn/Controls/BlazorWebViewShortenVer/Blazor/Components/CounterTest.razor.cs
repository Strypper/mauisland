using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace MAUIsland.A;

public partial class CounterTest : ComponentBase
{
    #region [ Properties - Inject ]
    [Inject]
    protected BlazorWebViewShortenVerPageViewModel ViewModel { get; private set; }
    #endregion

    #region [ Override ]
    protected override async Task OnInitializedAsync()
    {
        ViewModel.PropertyChanged += OnViewModelChanged;

        await base.OnInitializedAsync();
    }
    #endregion

    #region [ Event ]
    private void OnViewModelChanged(object? sender, PropertyChangedEventArgs e)
        => StateHasChanged();

    public void Dispose()
        => ViewModel.PropertyChanged -= OnViewModelChanged;

    private void OnCounterButtonClicked(EventArgs e)
    {
        ViewModel.CounterButtonCommand.Execute(this);
    }
    #endregion
}
