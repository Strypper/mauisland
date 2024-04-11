using System.ComponentModel;

namespace MAUIsland;

public partial class CollectionViewPage : IGalleryPage
{
    #region [ Service ]
    protected readonly CollectionViewPageViewModel ViewModel;
    #endregion

    #region [ CTor ]
    public CollectionViewPage(CollectionViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = ViewModel = vm;
    }
    #endregion

    #region [ Override ]
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.SpanningNumberChanged += ViewModelSpanningNumberPropertyChanged;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ViewModel.SpanningNumberChanged -= ViewModelSpanningNumberPropertyChanged;
    }
    #endregion

    #region [ Event Handler ]
    private void ViewModelSpanningNumberPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SpanningNumber")
        {
            switch (ViewModel.SpanningNumber)
            {
                case 1:
                    CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources["ControllInfoCollectionTemplate"];
                    break;
                case 2:
                    CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources["ControllInfoCollectionTwoItemRowTemplate"];
                    break;
                case 3:
                    CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources["ControllInfoCollectionThreeItemRowTemplate"];
                    break;
                case 4:
                    CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources["ControllInfoCollectionFourItemRowTemplate"];
                    break;
            }
        }
    }

    void OnFilterItemChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedFilter = picker.SelectedItem.ToString();

        var collectionView = CollectionViewItemLayoutChanged;
        var itemsSource = ViewModel.ControlGroupList;

        var filteredItems = new ObservableCollection<IGalleryCardInfo>(itemsSource.Where(x => x.CardType.ToString() == selectedFilter));

        var itemsToSelect = itemsSource.Where(x => x.CardType.ToString() == selectedFilter).ToList();

        collectionView.SelectedItems.Clear();
        foreach (var item in itemsToSelect)
        {
            collectionView.SelectedItems.Add(item);
        }

        // Refresh the CollectionView
        collectionView.ItemsSource = null;
        collectionView.ItemsSource = itemsSource;
    }
    #endregion
}