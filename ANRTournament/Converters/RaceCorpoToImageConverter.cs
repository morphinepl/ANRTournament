namespace ANRTournament.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Data;
    using System.Drawing;
    using System.Windows.Media.Imaging;
    using System.IO;

    public class RaceCorpoToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imagePath = string.Empty;            
        
            if (value is RaceCorpo)
            {
                RaceCorpo? raceToConvert = value as RaceCorpo?;
                if(!raceToConvert.HasValue) return null;

                switch (raceToConvert.Value)
                {
                    case RaceCorpo.HaasBioroid:
                        imagePath = "corp-hb.png";
                        break;

                    case RaceCorpo.Jinteki:
                        imagePath = "corp-jinteki.png";
                        break;

                    case RaceCorpo.NBN:
                        imagePath = "corp-nbn.png";
                        break;

                    case RaceCorpo.WeylandConsortium:
                        imagePath = "corp-weyland.png";
                        break;

                    default:
                        break;
                }
            }

            BitmapImage imageToReturn = null;

            try
            {
                imageToReturn = new BitmapImage(new Uri("../Resources/" + imagePath, UriKind.Relative));
                //imageToReturn = new BitmapImage(new Uri(imagePath));
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
