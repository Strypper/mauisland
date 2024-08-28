namespace MAUIsland.Core;

public partial class AppleIphone15ProMaxContentView : ContentView
{

    #region [ CTor ]

    public AppleIphone15ProMaxContentView()
    {
        InitializeComponent();
    }

    #endregion

    #region [ Properties ]

    private Thickness currentBorderPadding = new(10);
    public Thickness CurrentBorderPadding
    {
        get => currentBorderPadding;
        set
        {
            if (currentBorderPadding != value)
            {
                currentBorderPadding = value;
                OnPropertyChanged();
            }
        }
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

    private void Border_SizeChanged(object sender, EventArgs e)
    {
        var view = sender as Border;
        if (view != null)
        {
            double width = view.Width;
            double height = view.Height;

            if (height >= 521)
                CurrentBorderPadding = new(8);
            else if (height > 450)
                CurrentBorderPadding = new(10);
            else
                CurrentBorderPadding = new(6.5);

            System.Diagnostics.Debug.WriteLine($"Image size changed - Width: {width}, Height: {height}");
            System.Diagnostics.Debug.WriteLine($"Image size changed - Border padding: {view.Padding.Top}");
        }

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