using System.Globalization;

namespace AntiSpam.Ui.ViewModels.Homes.Converters;

public class DurationConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not CallItem item)
        {
            return string.Empty;
        }
        var time = item.Items.Last().Duration;
        return time.Seconds switch
        {
            0 => string.Empty,
            < 60 => string.Format("{0:mm\\:ss}", time),
            _ => string.Format("{0:hh\\:mm\\:ss}", time)
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
