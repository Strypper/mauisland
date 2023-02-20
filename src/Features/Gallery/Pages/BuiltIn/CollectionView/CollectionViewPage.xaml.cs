namespace MAUIsland;

public partial class CollectionViewPage : IControlPage
{

    #region [CTor]
    public CollectionViewPage(CollectionViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        UpdateSelectionData(Enumerable.Empty<Monkey>(), Enumerable.Empty<Monkey>());
    }
    #endregion

    void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
    }

    void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
    {
        string previous = (previousSelectedItems.FirstOrDefault() as Monkey)?.Name;
        string current = (currentSelectedItems.FirstOrDefault() as Monkey)?.Name;
        previousSelectedItemLabel.Text = string.IsNullOrWhiteSpace(previous) ? "[none]" : previous;
        currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[none]" : current;
    }
    private void RadioButton_Checked(object sender, CheckedChangedEventArgs e)
    {
        RadioButton button = sender as RadioButton;
        var layout = button.Content;

        //if (layout == "Grid")
            //CollectionViewExample.ItemsLayout = "VerticalGrid, 2" as IItemsLayout;
        //else
        //    CollectionViewExample.ItemsLayout = null;

    }

}