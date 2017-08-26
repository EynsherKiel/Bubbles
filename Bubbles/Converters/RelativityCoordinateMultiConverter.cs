using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Bubbles.Converters
{
    public class RelativityCoordinateMultiConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is int == false || values[2] is double == false || values[1] is int == false)
                return default(double);

            return (int)values[0] *(double)values[2] / (int)values[1];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException(); 
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
