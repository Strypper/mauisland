namespace MAUIsland;

public partial class EntryPage : IGalleryPage
{
    #region [CTor]
    public EntryPage(EntryPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

    private void Entry_Completed(object sender, EventArgs e)
    {

    }
}