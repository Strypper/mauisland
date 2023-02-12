namespace MAUIsland;

public partial class EntryPage : IControlPage
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