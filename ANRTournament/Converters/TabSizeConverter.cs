using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ANRTournament.Converters
{
    public class TabSizeConverter : MarkupExtension, IMultiValueConverter
    {
        private static TabSizeConverter _converter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null) _converter = new TabSizeConverter();
            return _converter;
        }

        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            TabControl tabControl = values[0] as TabControl;
            if (tabControl == null) return 20;
            double width = tabControl.ActualWidth / tabControl.Items.Count;
            //Subtract 2, otherwise we could overflow to two rows.
            return (width <= 0) ? 0 : (width - 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
