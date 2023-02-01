namespace MAUIsland;

public partial class ChatBubbleContentView : ContentView
{
    #region [CTor]
    public ChatBubbleContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
                                nameof(ComponentData),
                                typeof(ChatMessage),
                                typeof(ChatBubbleContentView),
                                default(ChatMessage));
    #endregion

    #region [Properties]
    public ChatMessage ComponentData
    {
        get => (ChatMessage)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion
}