namespace MAUIsland;

public partial class ActivityIndicatorPage : IGalleryPage
{

    #region [ CTor ] 

    public ActivityIndicatorPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}