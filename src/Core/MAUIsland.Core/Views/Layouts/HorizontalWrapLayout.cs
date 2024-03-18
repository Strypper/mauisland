using Microsoft.Maui.Layouts;

namespace MAUIsland.Core;

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
