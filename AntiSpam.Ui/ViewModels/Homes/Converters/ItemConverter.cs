using System.Globalization;

namespace AntiSpam.Ui.ViewModels.Homes.Converters;

public class ItemConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not CallItem item)
        {
            return "";
        }

        return $"{item.Call.Name ?? item.Caller?.Note ?? item.Call.Number.ToString()} {(item.Items.Count > 1 ? $"({item.Items.Count})" : "")}";
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
