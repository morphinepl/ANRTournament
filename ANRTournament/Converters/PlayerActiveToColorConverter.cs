using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;

namespace ANRTournament.Converters
{
    public class PlayerActiveToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Boolean? boolvalue = value as Boolean?;

            SolidBrush colorToReturn = new SolidBrush(Color.Black);
            try
            {
                if (boolvalue.HasValue)
                {
                    if (boolvalue.Value == true)
                        colorToReturn = new SolidBrush(Color.Black);
                    else
                        colorToReturn = new SolidBrush(Color.Black);
                }
            }
            catch { }

            return colorToReturn;
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
