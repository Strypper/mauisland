using Microsoft.Maui;

namespace MAUIsland;

public partial class ControlActivityCardContentView : ContentView
{
    #region [CTor]
    public ControlActivityCardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ApplicationNewProperty = BindableProperty.Create(
    nameof(ApplicationNew),
    typeof(ApplicationNew),
    typeof(ControlActivityCardContentView),
    default(ApplicationNew)
    );
    #endregion

    #region [Properties]
    public ApplicationNew ApplicationNew
    {
        get => (ApplicationNew)GetValue(ApplicationNewProperty);
        set => SetValue(ApplicationNewProperty, value);
    }
    #endregion

    private void Detail_Clicked(object sender, EventArgs e)
       => Shell.Current.GoToAsync(ApplicationNew.Component.ControlRoute);
}