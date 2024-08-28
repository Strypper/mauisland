namespace MAUIsland.ResumesTemplate;

public partial class ResumesPage
{

    #region [ CTors ]

    public ResumesPage(ResumesPageViewModel vm)
    {
        InitializeComponent();

        this.BindingContext = vm;
    }
    #endregion
}