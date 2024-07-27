namespace MAUIsland.Core;

public partial class MobileAppShowcaseContentView : ContentView
{
    #region [ CTor ]
    public MobileAppShowcaseContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Properties ]


    private bool canStateChange = true;

    public bool CanStateChange
    {
        get { return canStateChange; }
        set { canStateChange = value; OnPropertyChanged("CanStateChange"); }
    }

    private string currentState;

    public string CurrentState
    {
        get { return currentState; }
        set { currentState = value; OnPropertyChanged("CurrentState"); }
    }
    #endregion

    #region [ Bindable Properties ]


    public static readonly BindableProperty PhoneModelProperty = BindableProperty.Create(nameof(PhoneModel),
                                                                                   typeof(string),
                                                                                   typeof(MobileAppShowcaseContentView),
                                                                                   default(string),
                                                                                   BindingMode.TwoWay,
                                                                                   propertyChanged: PhoneModelChanged);

    public string PhoneModel
    {
        get => (string)GetValue(PhoneModelProperty);
        set => SetValue(PhoneModelProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                                                                                   typeof(ObservableCollection<MockupImage>),
                                                                                   typeof(MobileAppShowcaseContentView),
                                                                                   default(ObservableCollection<MockupImage>),
                                                                                   BindingMode.TwoWay);
    public ObservableCollection<MockupImage> ItemsSource
    {
        get => (ObservableCollection<MockupImage>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }
    #endregion


    #region [ Event Handlers ]

    private void root_Loaded(object sender, EventArgs e)
    {

    }

    private static void PhoneModelChanged(BindableObject bindable, object oldValue, object newValue)
    {

        var contentView = bindable as MobileAppShowcaseContentView;
        if (contentView != null)
        {
            if (newValue is null || newValue.ToString() is null)
                return;

            string newModel = newValue.ToString();
            contentView.HandlePhoneModelChanged(newModel);
        }
    }


    private void HandlePhoneModelChanged(string newModel)
        => CurrentState = newModel;
    #endregion
}