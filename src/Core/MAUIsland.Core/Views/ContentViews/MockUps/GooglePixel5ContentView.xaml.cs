namespace MAUIsland.Core;

public partial class GooglePixel5ContentView : ContentView
{

    #region [ CTor ]

    public GooglePixel5ContentView()
    {
        InitializeComponent();
    }

    #endregion

    #region [ Bindable Properties ]


    public static readonly BindableProperty SelectedMockUpProperty = BindableProperty.Create(
    nameof(SelectedMockUp),
    typeof(string),
    typeof(Iphone13MiniContentView),
    default(string),
    BindingMode.TwoWay);

    public string SelectedMockUp
    {
        get => (string)GetValue(SelectedMockUpProperty);
        set => SetValue(SelectedMockUpProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                                                                                   typeof(ObservableCollection<string>),
                                                                                   typeof(Iphone13MiniContentView),
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
        if (ItemsSource is null)
            return;

        var indexOfCurrent = ItemsSource.IndexOf(SelectedMockUp);
        if (indexOfCurrent == ItemsSource.Count - 1)
            return;

        var nextIndex = indexOfCurrent + 1;
        SelectedMockUp = ItemsSource[nextIndex];
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        if (ItemsSource is null)
            return;

        var indexOfCurrent = ItemsSource.IndexOf(SelectedMockUp);
        if (indexOfCurrent <= 0)
            return;

        var prevIndex = indexOfCurrent - 1;
        SelectedMockUp = ItemsSource[prevIndex];
    }

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
    #endregion

    #region [ Methods - Private ]

    private async Task ExportMockUp()
    {
        var result = await root.CaptureAsync();
        using MemoryStream stream = new();

        await result.CopyToAsync(stream);
        File.WriteAllBytes("C:\\Users\\Strypper\\Desktop\\Bruh.png", stream.ToArray());
    }
    #endregion
}
