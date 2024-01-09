

namespace MAUIsland;

public class MrIncreadibleMemeService : IMrIncreadibleMemeService
{
    private IDictionary<double, ImageSource> images = new Dictionary<double, ImageSource>()
    {
        { 12, ImageSource.FromFile("mrincredibleblackwhite.png")},
        { 13, ImageSource.FromFile("mrincredibleblackwhite1.png")},
        { 14, ImageSource.FromFile("mrincredibleblackwhite2.png")},
        { 15, ImageSource.FromFile("mrincredibleblackwhite3.png")},
        { 16, ImageSource.FromFile("mrincredibleblackwhite4.png")},
        { 17, ImageSource.FromFile("mrincredibleblackwhite5.png")},
        { 18, ImageSource.FromFile("mrincrediblesmile.png")},
        { 19, ImageSource.FromFile("mrincrediblesmile1.png")},
        { 20, ImageSource.FromFile("mrincrediblesmile2.png")},
        { 21, ImageSource.FromFile("mrincrediblesmile3.png")},
        { 22, ImageSource.FromFile("mrincrediblesmile4.png")},
        { 23, ImageSource.FromFile("mrincrediblesmile5.png")},
    };

    private IDictionary<double, string> titles = new Dictionary<double, string>()
    {
        { 12, "We send your IP Address to the FBI 🚓"},
        { 13, "No stop !!! 🚫"},
        { 14, "Bruh no !!! 🛑"},
        { 15, "You kidding ? 🤡"},
        { 16, "Really ? 💀"},
        { 17, "Ok stop right there ✋🏽"},
        { 18, "Lucky !!! 🍀"},
        { 19, "Cool 😎"},
        { 20, "Giggity ! 😏"},
        { 21, "SOLID"},
        { 22, "FINE"},
        { 23, "MEH"},
    };

    public IDictionary<double, ImageSource> GetAllMemeImage()
    {
        return images;
    }

    public IDictionary<double, string> GetAllMemeTitle()
    {
        return titles;
    }

    public ImageSource GetMemeImage(double age)
    {
        return !images.ContainsKey(age) ? ImageSource.FromFile("mrincredibleblackwhite.png") : images[age];
    }

    public string GetMemeTitle(double age)
    {
        return !titles.ContainsKey(age) ? "Well crap !! 💀" : titles[age];
    }
}