namespace MAUIsland.Mockup;


public class ImageDropEventArgs : EventArgs
{
    public DroppedImage EventModel { get; set; }

    public ImageDropEventArgs(DroppedImage eventModel)
    {
        this.EventModel = eventModel;
    }
}