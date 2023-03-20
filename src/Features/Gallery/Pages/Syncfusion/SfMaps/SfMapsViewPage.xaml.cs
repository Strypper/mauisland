using MAUIsland.Gallery.Syncfusion;
using Syncfusion.Maui.Maps;

namespace MAUIsland;
public partial class SfMapsViewPage : IControlPage
{
    private bool canStopTimer;
    #region [CTor]
    public SfMapsViewPage(SfMapsViewPageViewModel vm)
    {
        InitializeComponent();
        this.markerLayer.ShapesSource = MapSource.FromResource("MAUIsland.Resources.Raw.world-map.json");
        #region TODO

        //this.selectionLayer.ShapesSource = MapSource.FromResource("MAUIsland.Resources.Raw.usa_state.shp");
        //this.shapeLayer.ShapesSource = MapSource.FromResource("MAUIsland.Resources.Raw.australia.shp");
        //this.sublayer.ShapesSource = MapSource.FromResource("MAUIsland.Resources.Raw.river.json");

        //sampleGrid.Remove(popup);
        #endregion
        StartTimer();

        BindingContext = vm;
    }
    #endregion

    #region Marker Layer
    private async void StartTimer()
    {
        await Task.Delay(500);
        if (Application.Current != null)
        {
            Application.Current.Dispatcher.StartTimer(new TimeSpan(0, 0, 0, 1, 0), UpdateMarker);
        }

        canStopTimer = false;
    }

    private bool UpdateMarker()
    {
        if (canStopTimer) return false;
        foreach (var marker in markerLayer.Markers)
        {
            if (marker is CustomMarker customMarker)
            {
                if (customMarker.Name == "Seattle")
                {
                    customMarker.Time = DateTime.UtcNow.Subtract(new TimeSpan(7, 0, 0)).ToLongTimeString();
                }
                else if (customMarker.Name == "Belem")
                {
                    customMarker.Time = DateTime.UtcNow.Subtract(new TimeSpan(3, 0, 0)).ToLongTimeString();
                }
                else if (customMarker.Name == "Nuuk")
                {
                    customMarker.Time = DateTime.UtcNow.Subtract(new TimeSpan(2, 0, 0)).ToLongTimeString();
                }
                else if (customMarker.Name == "Yakutsk")
                {
                    customMarker.Time = DateTime.UtcNow.Add(new TimeSpan(9, 0, 0)).ToLongTimeString();
                }
                else if (customMarker.Name == "Delhi")
                {
                    customMarker.Time = DateTime.UtcNow.Add(new TimeSpan(5, 30, 0)).ToLongTimeString();
                }
                else if (customMarker.Name == "Brisbane")
                {
                    customMarker.Time = DateTime.UtcNow.Add(new TimeSpan(10, 0, 0)).ToLongTimeString();
                }
                else if (customMarker.Name == "Harare")
                {
                    customMarker.Time = DateTime.UtcNow.Add(new TimeSpan(2, 0, 0)).ToLongTimeString();
                }
            }
        }

        return true;
    }
    #endregion

    #region Selection Layer
    //private void shapeLayer_ShapeSelected(object sender, ShapeSelectedEventArgs e)
    //{
    //    this.ClearPopup();
    //    if (e.IsSelected && e.DataItem is PopulationDensityDetails selectedItem)
    //    {
    //        stateName.Text = selectedItem.State;
    //        rankTitle.Text = "Density rank";
    //        rank.Text = " : " + selectedItem.Rank.ToString();
    //        kmTitle.Text = "Density per miles";
    //        kilometer.Text = " : " + selectedItem.SquareMiles.ToString();
    //        sampleGrid.Add(popup, row: 2, column: 1);
    //    }
    //}

    //private void ClearPopup()
    //{
    //    stateName.Text = "";
    //    kmTitle.Text = "";
    //    kilometer.Text = "";
    //    rankTitle.Text = "";
    //    rank.Text = "";
    //    sampleGrid.Remove(popup);
    //}
    #endregion
}