namespace MAUIsland.Core;

public class BasePage : ContentPage
{
    public object NewWindowParameter { get; set; } = default!;
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is BaseViewModel vm)
        {
            vm.OnAppearingAsync();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is BaseViewModel vm)
        {
            vm.OnDisappearingAsync();
        }
    }

    public void SetNewWindowParameter(object parameter)
    {
        NewWindowParameter = parameter;
    }
}
