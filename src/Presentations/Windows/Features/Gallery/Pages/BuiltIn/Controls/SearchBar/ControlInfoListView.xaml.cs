namespace MAUIsland;

public partial class ControlInfoListView : ListView
{
    #region [CTor]
    public ControlInfoListView()
	{
		InitializeComponent();
	}
    #endregion

    #region [ Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(nameof(ComponentData),
                                                                                        typeof(IGalleryCardInfo),
                                                                                        typeof(ControlInfoListView),
                                                                                        default(IGalleryCardInfo));
    public IGalleryCardInfo ComponentData
    {
        get => (IGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion
}