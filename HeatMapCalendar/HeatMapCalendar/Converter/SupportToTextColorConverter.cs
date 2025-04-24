using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using System.Globalization;

namespace HeatMapCalendar;

internal class SupportDetailsToTextColorConverter : IValueConverter
{
    public SupportDetailsToTextColorConverter()
    {

    }

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not ReadOnlyCollection<SchedulerAppointment> appointments || appointments.Count == 0)
        {
            return Colors.Black;
        }
        if (appointments[0].DataItem is not SupportDetails supportDetails)
        {
            return Colors.Black;
        }
        return this.GetColor(supportDetails.SupportCount);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }

    private Color GetColor(int supportCount)
    {
        if (supportCount <= 1000)
        {
            return Colors.Black;
        }

        return Colors.White;
    }
}