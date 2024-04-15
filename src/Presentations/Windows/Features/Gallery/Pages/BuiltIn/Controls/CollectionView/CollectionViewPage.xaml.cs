using System.ComponentModel;

namespace MAUIsland;

public partial class CollectionViewPage : IGalleryPage
{
    #region [ Fields ]

    protected readonly CollectionViewPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public CollectionViewPage(CollectionViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    #region [ Override ]
    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.SpanningNumberChanged += ViewModelSpanningNumberPropertyChanged;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.SpanningNumberChanged -= ViewModelSpanningNumberPropertyChanged;
    }
    #endregion

    #region [ Event Handler ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
            viewModel.RefreshPageCommand.Execute(null);
        }
    }

    private void ViewModelSpanningNumberPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SpanningNumber")
        {
            switch (viewModel.SpanningNumber)
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

        if (picker.SelectedItem is null)
            return;

        var selectedFilter = picker.SelectedItem.ToString();

        var collectionView = CollectionViewItemLayoutChanged;
        var itemsSource = viewModel.ControlGroupList;

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