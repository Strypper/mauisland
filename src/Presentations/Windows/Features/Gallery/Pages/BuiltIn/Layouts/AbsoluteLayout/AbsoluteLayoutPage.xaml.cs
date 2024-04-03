namespace MAUIsland;
public partial class AbsoluteLayoutPage : IGalleryPage
{
    #region [ CTor ]

    public AbsoluteLayoutPage(AbsoluteLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}