using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace MAUIsland;

public partial class Counter : ComponentBase
{
    #region [ Properties - Inject ]
    [Inject]
    protected BlazorWebViewPageViewModel ViewModel { get; private set; }
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
