namespace MAUIsland;

public partial class IndikoMauiControlsMarkdownPage : IGalleryPage
{

    #region [ CTor ]

    public IndikoMauiControlsMarkdownPage(IndikoMauiControlsMarkdownPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}