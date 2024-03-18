namespace MAUIsland;

public interface IMrIncreadibleMemeService
{
    ImageSource GetMemeImage(double age);
    string GetMemeTitle(double age);
    IDictionary<double, ImageSource> GetAllMemeImage();
    IDictionary<double, string> GetAllMemeTitle();
}
