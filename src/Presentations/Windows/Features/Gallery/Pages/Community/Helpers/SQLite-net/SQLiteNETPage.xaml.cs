namespace MAUIsland;

public partial class SQLiteNETPage : IGalleryPage
{

    #region [ CTor ]

    public SQLiteNETPage(SQLiteNETPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}