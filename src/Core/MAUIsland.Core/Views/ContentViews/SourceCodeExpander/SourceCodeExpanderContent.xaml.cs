namespace MAUIsland.Core;

public partial class SourceCodeExpanderContent : ContentView
{

    #region [ CTor ]

    public SourceCodeExpanderContent()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Overrides ]

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        BindingContext = (FormattedString)BindingContext;
    }

    #endregion

}