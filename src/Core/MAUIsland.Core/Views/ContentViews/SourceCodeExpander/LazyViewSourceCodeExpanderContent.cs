using CommunityToolkit.Maui.Views;

namespace MAUIsland.Core;

public class LazyViewSourceCodeExpanderContent : LazyView<SourceCodeExpanderContent>
{
    #region [ Overrides ]

    public override async ValueTask LoadViewAsync(CancellationToken token)
    {
        await base.LoadViewAsync(token);
    }
    #endregion
}
