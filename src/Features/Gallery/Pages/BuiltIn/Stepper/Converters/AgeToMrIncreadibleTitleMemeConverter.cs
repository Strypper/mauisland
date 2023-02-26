namespace MAUIsland;

public class AgeToMrIncreadibleTitleMemeConverter : IValueConverter
{
    IDictionary<double, string> memes = new Dictionary<double, string>(){
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
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var age = (double)value;
        return !memes.ContainsKey(age) ? "Well crap !! 💀"
                                       : memes[age];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
