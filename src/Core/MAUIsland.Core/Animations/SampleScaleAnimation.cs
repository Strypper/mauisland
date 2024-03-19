using CommunityToolkit.Maui.Animations;

namespace MAUIsland.Core;

class SampleScaleAnimation : BaseAnimation
{
    public override async Task Animate(VisualElement view, CancellationToken token)
    {
        await view.ScaleTo(1.2, Length, Easing).WaitAsync(token);
        await view.ScaleTo(1, Length, Easing).WaitAsync(token);
    }
}