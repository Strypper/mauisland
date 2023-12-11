using Syncfusion.Maui.ListView;

namespace MAUIsland;

public partial class CollectionViewPage : IGalleryPage
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

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {

    }
}