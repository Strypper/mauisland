namespace MAUIsland.Mockup;


public class ImageDropEventArgs : EventArgs
{
    public AddButtonEventModel EventModel { get; set; }

    public ImageDropEventArgs(AddButtonEventModel eventModel)
    {
        this.EventModel = eventModel;
    }
}