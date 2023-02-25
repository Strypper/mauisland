namespace MAUIsland;

public class IntToMrIncreadibleMemeConverter : IValueConverter
{
    IDictionary<double, ImageSource> memes = new Dictionary<double, ImageSource>(){
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

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var age = (double)value;
        return !memes.ContainsKey(age) ? "mrincredibleblackwhite4.png"
                                       : memes[age];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
