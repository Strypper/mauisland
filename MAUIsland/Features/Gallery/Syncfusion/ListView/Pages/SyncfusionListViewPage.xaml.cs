namespace MAUIsland;

public partial class SyncfusionListViewPage
{
    #region [Fields]
    private SyncfusionListViewPageViewModel viewModel;
    #endregion
    public SyncfusionListViewPage(SyncfusionListViewPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
    }

    #region [Event Handlers]
    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 1;
                gridLayout.SpanCount = 1;
                return;
            }
        }
        else if (Window.Width < 900)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 2;
                gridLayout.SpanCount = 2;
                return;
            }
        }
        else if (Window.Width < 2000)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 4;
                gridLayout.SpanCount = 4;
                return;
            }
        }
    }
    #endregion
}