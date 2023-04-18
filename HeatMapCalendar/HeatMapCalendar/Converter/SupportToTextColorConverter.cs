using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using System.Globalization;

namespace HeatMapCalendar;

internal class SupportDetailsToTextColorConverter : IValueConverter
{
    public SupportDetailsToTextColorConverter()
    {

    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        ReadOnlyCollection<SchedulerAppointment>? appointments = (ReadOnlyCollection<SchedulerAppointment>?)value;
        if (appointments == null || appointments.Count == 0)
        {
            return Colors.Black;
        }

        return this.GetColor((appointments[0].DataItem as SupportDetails).SupportCount);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
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