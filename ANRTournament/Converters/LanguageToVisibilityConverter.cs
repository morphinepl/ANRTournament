using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace ANRTournament.Converters
{
    public class LanguageToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            string val = value.ToString();

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (val != "pl")
                {
                    valToReturn = Visibility.Collapsed;
                }
                else
                {
                    valToReturn = Visibility.Visible;
                }
            }
            catch { }

            return valToReturn;
        }

        /// <summary>
        /// Converts <c>null</c> back to <see cref="String.Empty"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The expected type of the result (ignored).</param>
        /// <param name="parameter">Optional parameter (ignored).</param>
        /// <param name="culture">The culture for the conversion (ignored).</param>
        /// <returns>If <paramref name="value"/> is <c>null</c>, it returns <see cref="String.Empty"/> otherwise <paramref name="value"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
