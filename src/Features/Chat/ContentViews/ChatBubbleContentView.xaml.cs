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
                                typeof(ChatMessageModel),
                                typeof(ChatBubbleContentView),
                                default(ChatMessageModel));
    #endregion

    #region [Properties]
    public ChatMessageModel ComponentData
    {
        get => (ChatMessageModel)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion
}