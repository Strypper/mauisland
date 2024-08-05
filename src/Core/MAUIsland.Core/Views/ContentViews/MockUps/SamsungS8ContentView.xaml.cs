namespace MAUIsland.Core;

public partial class SamsungS8ContentView : ContentView
{

    #region [ CTor ]

    public SamsungS8ContentView()
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

    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(nameof(ComponentData),
                                                                                   typeof(SamsungS8Model),
                                                                                   typeof(Iphone15ContentView),
                                                                                   default(SamsungS8Model),
                                                                                   BindingMode.OneWay);
    public SamsungS8Model ComponentData
    {
        get => (SamsungS8Model)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion

    #region [ Event Handlers ]

    private void root_Loaded(object sender, EventArgs e)
    {
        if (ComponentData is null
            ||
            ComponentData.Mockups is null
            ||
            !ComponentData.Mockups.Any()
            ||
            ComponentData.Mockups.FirstOrDefault() is null)
            return;

        SelectedMockUp = ComponentData.Mockups.FirstOrDefault();
    }

    private void NextButton_Clicked(object sender, EventArgs e)
    {
        var indexOfCurrent = ComponentData.Mockups.IndexOf(SelectedMockUp);
        if (indexOfCurrent == ComponentData.Mockups.Count - 1)
            return;

        //if (indexOfCurrent >= ComponentData.Mockups.Count - 1)
        //    indexOfCurrent = 0;

        var nextIndex = indexOfCurrent + 1;
        SelectedMockUp = ComponentData.Mockups[nextIndex];
        MockUpCarousel.ScrollTo(nextIndex);
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        var indexOfCurrent = ComponentData.Mockups.IndexOf(SelectedMockUp);
        if (indexOfCurrent == 0)
            return;

        var prevIndex = indexOfCurrent - 1;
        SelectedMockUp = ComponentData.Mockups[prevIndex];
        MockUpCarousel.ScrollTo(prevIndex);
    }

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {

        if (ComponentData is null || ComponentData.Mockups.Count == 1)
            return;

        var button = (ImageButton)sender;
        button.FadeTo(0.5, 1500);
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        if (ComponentData is null || ComponentData.Mockups.Count == 1)
            return;

        var button = (ImageButton)sender;
        button.FadeTo(0, 1500);
    }
    #endregion

    #region [ Methods - Private ]

    #endregion
}