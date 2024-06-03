namespace MAUIsland.Core;

public partial class DocumentAlert : ContentView
{

    #region [ CTor ]

    public DocumentAlert()
    {
        InitializeComponent();
    }

    #endregion

    #region [ Properties ]

    private Color componentColor;
    public Color ComponentColor
    {
        get => componentColor;
        set
        {
            if (componentColor != value)
            {
                componentColor = value;
                OnPropertyChanged();
            }
        }
    }


    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
                                                                                   typeof(string),
                                                                                   typeof(IconLabel),
                                                                                   default(string),
                                                                                   BindingMode.OneWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty AlertTypeProperty = BindableProperty.Create(nameof(AlertType),
                                                                               typeof(DocumentAlertType),
                                                                               typeof(IconLabel),
                                                                               default(DocumentAlertType),
                                                                               BindingMode.OneWay);
    public DocumentAlertType AlertType
    {
        get => (DocumentAlertType)GetValue(AlertTypeProperty);
        set => SetValue(AlertTypeProperty, value);
    }
    #endregion

    #region [ Event Handlers ]

    private void root_Loaded(object sender, EventArgs e)
    {
        ComponentColor = ColorMatching(AlertType);
    }
    #endregion

    #region [ Methods - Private ]

    Color ColorMatching(DocumentAlertType type)
        => type switch
        {
            DocumentAlertType.Note => Color.FromArgb("#3b2e58"),
            DocumentAlertType.Important => Color.FromArgb("#004173"),
            DocumentAlertType.Warning => Color.FromArgb("#6a4b16"),
            DocumentAlertType.Tip => Color.FromArgb("#054b16")
        };
    #endregion
}
public enum DocumentAlertType
{
    Note, Important, Warning, Tip
}