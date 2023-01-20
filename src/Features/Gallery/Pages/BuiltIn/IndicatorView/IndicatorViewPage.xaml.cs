using Bogus.DataSets;

namespace MAUIsland;

public class Cats
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ImageSource Photo { get; set; }
}
public partial class IndicatorViewPage : IControlPage
{
    #region [CTor]
    public IndicatorViewPage(IndicatorViewPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    #endregion

}