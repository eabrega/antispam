using System.Globalization;

namespace AntiSpam.Ui.ViewModels.Homes.Converters;

public class DataTimeConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not CallItem item)
        {
            return string.Empty;
        }

        var datetime = item.Items.Max().Date.ToLocalTime();
        var days = (DateTime.UtcNow - datetime).Days;

        return days switch
        {
            0 => string.Format("{0:HH\\:mm}", datetime),
            1 => "Вчера",
            > 1 and < 4 => datetime.ToString("dddd", new CultureInfo("ru-RU")),
            _ => string.Format("{0:dd.MM.yyyy}", datetime)
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
