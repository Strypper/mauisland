namespace MAUIsland;

public partial class SQLitePCLRawPage : IGalleryPage
{

    #region [ CTor ]

    public SQLitePCLRawPage(SQLitePCLRawPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}