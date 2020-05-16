using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Navigation;
using static AnimatedGifRecorder.ViewModels.MainViewModel;

namespace AnimatedGifRecorder.Converters
{
    public class AppStateToCursor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine((AppState)value);
            return (AppState)value == AppState.SelectCaptureRegion ? "Cross" : "Default";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Cross".Equals(value) ? AppState.SelectCaptureRegion : AppState.None;
        }
    }
}
