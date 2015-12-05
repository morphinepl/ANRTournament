using System;
using System.Windows.Media.Imaging;
using System.Windows.Data;

namespace ANRTournament.Converters
{
    public class IdGalaktaToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? intvalue = value as int?;

            BitmapImage imageToReturn = null;
            try
            {
                if (intvalue.HasValue)
                {
                    if (intvalue.Value > 0)
                        imageToReturn = new BitmapImage(new Uri("../Resources/green_44.png", UriKind.Relative));
                    else
                        imageToReturn = new BitmapImage(new Uri("../Resources/red_44.png", UriKind.Relative));
                }
            }
            catch { }

            return imageToReturn;
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

