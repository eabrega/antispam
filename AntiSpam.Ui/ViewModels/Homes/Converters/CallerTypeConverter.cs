using System.Globalization;

namespace AntiSpam.Ui.ViewModels.Homes.Converters;

public class CallerTypeConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not CallType type)
        {
            return string.Empty;
        }

        return type.ToString().ToLower();
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
