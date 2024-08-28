using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace MAUIsland;

public partial class ControlsPage : ComponentBase
{
    #region [ Properties - Inject ]
    [Inject]
    protected BlazorWebViewPageViewModel ViewModel { get; private set; }
    #endregion

    #region [ Override ]
    protected override async Task OnInitializedAsync()
    {
        //ViewModel.PropertyChanged += OnCounterChanged;

        await base.OnInitializedAsync();
    }
    #endregion

    #region [ Event ]
    //private void OnCounterChanged(object? sender, PropertyChangedEventArgs e)
    //{
    //    StateHasChanged();
    //}

    //public void Dispose()
    //{
    //    ViewModel.PropertyChanged -= OnCounterChanged;
    //}

    private void OnCounterButtonClicked(EventArgs e)
    {
        ViewModel.CounterButtonCommand.Execute(this);
    }
    #endregion
}
