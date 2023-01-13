using Microsoft.Maui.Layouts;

namespace MAUIsland;

public class HorizontalWrapLayout : StackLayout
{
    public HorizontalWrapLayout()
    {
    }

    protected override ILayoutManager CreateLayoutManager()
    {
        return new HorizontalWrapLayoutManager(this);
    }
}
