using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestQ1
{
    class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double sliderValue = (double)value;
            double sliderMax = 300;
            if (sliderMax != null && sliderValue != null)
            {
                if (sliderValue <= sliderMax * 0.25)
                {
                    return "Small";
                }
                else if (sliderValue <= sliderMax * 0.5)
                {
                    return "Medium";
                }
                else if (sliderValue <= sliderMax * 0.75)
                {
                    return "Large";
                }
                else
                {
                    return "Extra Large";
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
