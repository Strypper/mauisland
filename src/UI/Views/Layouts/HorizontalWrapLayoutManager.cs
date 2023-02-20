using Microsoft.Maui.Layouts;
using StackLayoutManager = Microsoft.Maui.Layouts.StackLayoutManager;

namespace MAUIsland;

public class HorizontalWrapLayoutManager : StackLayoutManager
{
    HorizontalWrapLayout _layout;

    public HorizontalWrapLayoutManager(HorizontalWrapLayout horizontalWrapLayout) : base(horizontalWrapLayout)
    {
        _layout = horizontalWrapLayout;
    }

    public override Size Measure(double widthConstraint, double heightConstraint)
    {
        var padding = _layout.Padding;

        widthConstraint -= padding.HorizontalThickness;

        var rows = new Dictionary<int, List<Size>>();
        var currentRowIndex = 0;
        var currentRow = new List<Size>();

        rows.Add(currentRowIndex, currentRow);

        foreach (var child in _layout)
        {
            if (child.Visibility == Visibility.Collapsed)
            {
                continue;
            }

            var childSize = child.Measure(double.PositiveInfinity, heightConstraint);
            var childWidth = childSize.Width + (currentRow.Any() ? _layout.Spacing : 0);

            var rowWidth = currentRow.Aggregate(0.0, (w, x) => w + x.Width);
            if (rowWidth + childWidth > widthConstraint)
            {
                if (currentRow.Any())
                {
                    currentRowIndex++;
                    currentRow = new List<Size>();
                    rows.Add(currentRowIndex, currentRow);
                }
            }
            else if (currentRow.Any())
            {
                currentRow.Add(new Size(_layout.Spacing, 0));
            }

            currentRow.Add(childSize);
        }

        var totalWidth = 0.0;
        var totalHeight = 0.0;

        if (rows.Any())
        {
            var rowWidths = rows.Select(x => x.Value.Aggregate(0.0, (result, item) => result + item.Width)).ToList();
            var rowHeights = rows.Select(x => x.Value.Any() ? x.Value.Max(i => i.Height) : 0).ToList();

            totalWidth = rowWidths.Any() ? rowWidths.Max() : 0;
            totalHeight = rowHeights.Any() ? rowHeights.Sum() : 0;
            if (rows.Keys.Count > 1)
            {
                totalHeight += _layout.Spacing * (rows.Keys.Count - 1);
            }
        }

        totalWidth += padding.HorizontalThickness;
        totalHeight += padding.VerticalThickness;

        var finalHeight = ResolveConstraints(heightConstraint, Stack.Height, totalHeight, Stack.MinimumHeight, Stack.MaximumHeight);
        var finalWidth = ResolveConstraints(widthConstraint, Stack.Width, totalWidth, Stack.MinimumWidth, Stack.MaximumWidth);

        return new Size(finalWidth, finalHeight);
    }

    public override Size ArrangeChildren(Rect bounds)
    {
        var padding = Stack.Padding;
        double top = padding.Top + bounds.Top;
        double left = padding.Left + bounds.Left;

        double currentRowTop = top;
        double currentX = left;
        double currentRowHeight = 0;

        double maxStackWidth = currentX;

        for (int n = 0; n < _layout.Count; n++)
        {
            var child = _layout[n];

            if (child.Visibility == Visibility.Collapsed)
            {
                continue;
            }

            if (currentX + child.DesiredSize.Width > bounds.Right)
            {
                // Keep track of our maximum width so far
                maxStackWidth = Math.Max(maxStackWidth, currentX);

                // Move down to the next row
                currentX = left;
                currentRowTop += currentRowHeight + _layout.Spacing;
                currentRowHeight = 0;
            }

            var destination = new Rect(currentX, currentRowTop, child.DesiredSize.Width, child.DesiredSize.Height);
            child.Arrange(destination);

            currentX += destination.Width + _layout.Spacing;
            currentRowHeight = Math.Max(currentRowHeight, destination.Height);
        }

        var actual = new Size(maxStackWidth, currentRowTop + currentRowHeight);

        return actual.AdjustForFill(bounds, Stack);
    }

}
