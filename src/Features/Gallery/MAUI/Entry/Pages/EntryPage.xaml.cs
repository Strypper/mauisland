namespace MAUIsland;

public partial class EntryPage
{
    #region [CTor]
    public EntryPage(EntryPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}