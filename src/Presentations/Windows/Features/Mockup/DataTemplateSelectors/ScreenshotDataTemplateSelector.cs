namespace MAUIsland.Mockup;

public class ScreenshotDataTemplateSelector : DataTemplateSelector
{
    #region [ Templates ]

    public DataTemplate Mockup { get; set; }
    public DataTemplate AddButton { get; set; }
    #endregion

    #region [ Overrides ]

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
     => ((ScreenshotModel)item).IsAddButton ? AddButton : Mockup;
    #endregion
}
