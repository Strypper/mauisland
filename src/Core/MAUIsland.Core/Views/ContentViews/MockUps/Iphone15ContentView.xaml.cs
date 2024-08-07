namespace MAUIsland.Core;

public partial class Iphone15ContentView : ContentView
{

    #region [ CTor ]

    public Iphone15ContentView()
    {
        InitializeComponent();
    }

    #endregion

    #region [ Properties ]

    private string selectedMockUp;

    public string SelectedMockUp
    {
        get { return selectedMockUp; }
        set { selectedMockUp = value; OnPropertyChanged("SelectedMockUp"); }
    }
    #endregion

    #region [ Bindable Properties ]

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                                                                                   typeof(ObservableCollection<string>),
                                                                                   typeof(Iphone15ContentView),
                                                                                   default(ObservableCollection<string>),
                                                                                   BindingMode.OneWay);
    public ObservableCollection<string> ItemsSource
    {
        get => (ObservableCollection<string>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }
    #endregion

    #region [ Event Handlers ]

    private void root_Loaded(object sender, EventArgs e)
    {
        if (ItemsSource is null
            ||
           !ItemsSource.Any()
            ||
           ItemsSource.FirstOrDefault() is null)
            return;

        SelectedMockUp = ItemsSource.FirstOrDefault()!;
    }

    private void NextButton_Clicked(object sender, EventArgs e)
    {
        var indexOfCurrent = ItemsSource.IndexOf(SelectedMockUp);
        if (indexOfCurrent == ItemsSource.Count - 1)
            return;

        var nextIndex = indexOfCurrent + 1;
        SelectedMockUp = ItemsSource[nextIndex];
        MockUpCarousel.ScrollTo(nextIndex);
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        var indexOfCurrent = ItemsSource.IndexOf(SelectedMockUp);
        if (indexOfCurrent <= 0)
            return;

        var prevIndex = indexOfCurrent - 1;
        SelectedMockUp = ItemsSource[prevIndex];
        MockUpCarousel.ScrollTo(prevIndex);
    }
    #endregion

    #region [ Methods - Private ]


    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {

        if (ItemsSource is null || ItemsSource.Count == 1)
            return;

        var button = (ImageButton)sender;
        button.FadeTo(0.5, 1500);
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        if (ItemsSource is null || ItemsSource.Count == 1)
            return;

        var button = (ImageButton)sender;
        button.FadeTo(0, 1500);
    }

    private async Task ExportMockUp()
    {
        var result = await root.CaptureAsync();
        using MemoryStream stream = new();

        await result.CopyToAsync(stream);
        File.WriteAllBytes("C:\\Users\\Strypper\\Desktop\\Bruh.png", stream.ToArray());
    }
    #endregion
}