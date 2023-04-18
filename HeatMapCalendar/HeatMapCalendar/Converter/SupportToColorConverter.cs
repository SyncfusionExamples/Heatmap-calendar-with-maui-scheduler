using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;
using System.Globalization;

namespace HeatMapCalendar;

internal class SupportDetailsToColorConverter : IValueConverter
{
    private readonly Color lighter = Color.FromArgb("#dbe5f9");
    private readonly Color light = Color.FromArgb("#82a2ea");
    private readonly Color mid = Color.FromArgb("#4071e0");
    private readonly Color dark = Color.FromArgb("#1e4cb4");
    private readonly Color darker = Color.FromArgb("#173c8d");

    public SupportDetailsToColorConverter()
    {

    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        ReadOnlyCollection<SchedulerAppointment>? appointments = (ReadOnlyCollection<SchedulerAppointment>?)value;
        if (appointments == null || appointments.Count == 0)
        {
            return Colors.Transparent;
        }

        return this.GetColor((appointments[0].DataItem as SupportDetails).SupportCount);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }

    private Color GetColor(int supportCount)
    {
        if (supportCount <= 500)
        {
            return this.lighter;
        }
        else if (supportCount <= 1000)
        {
            return this.light;
        }
        else if (supportCount <= 1500)
        {
            return this.mid;
        }
        else if (supportCount <= 2000)
        {
            return this.dark;
        }
        else
        {
            return this.darker;
        }
    }
}