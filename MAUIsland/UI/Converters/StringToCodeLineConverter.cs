namespace MAUIsland;

public class StringToCodeLineConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value != null)
        {
            var stringCode = value.ToString();
            if (!string.IsNullOrEmpty(stringCode) && !string.IsNullOrWhiteSpace(stringCode))
            {
                var codeLines = new List<CodeLine>();
                var allLines = stringCode.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                for (int i = 0; i < allLines.Count(); i++)
                {
                    codeLines.Add(new CodeLine()
                    {
                        Index = i + 1,
                        Code = allLines[i]
                    });
                }
                return codeLines;
            }
            else return new List<CodeLine>();
        }
        else return new List<CodeLine>();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
