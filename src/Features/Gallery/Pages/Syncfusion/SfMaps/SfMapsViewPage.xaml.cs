using MAUIsland.Gallery.Syncfusion;
using Syncfusion.Maui.Maps;

namespace MAUIsland;
public partial class SfMapsViewPage : IControlPage
{
    #region [CTor]
    public SfMapsViewPage(SfMapsViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        this.shapeLayer.ShapesSource = MapSource.FromResource("MAUIsland.Resources.Raw.usa_state.shp");

        sampleGrid.Remove(popup);
    }

    private void shapeLayer_ShapeSelected(object sender, ShapeSelectedEventArgs e)
    {
        this.ClearPopup();
        if (e.IsSelected && e.DataItem is PopulationDensityDetails selectedItem)
        {
            stateName.Text = selectedItem.State;
            rankTitle.Text = "Density rank";
            rank.Text = " : " + selectedItem.Rank.ToString();
            kmTitle.Text = "Density per miles";
            kilometer.Text = " : " + selectedItem.SquareMiles.ToString();
            sampleGrid.Add(popup, row: 2, column: 1);
        }
    }

    private void ClearPopup()
    {
        stateName.Text = "";
        kmTitle.Text = "";
        kilometer.Text = "";
        rankTitle.Text = "";
        rank.Text = "";
        sampleGrid.Remove(popup);
    }
    #endregion
}