namespace MAUIsland.Showcases;

public partial class ShowcasesPage
{
    public ShowcasesPage(ShowcasesPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}