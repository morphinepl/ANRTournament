namespace ANRTournament.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Data;
    using System.Drawing;
    using System.Windows.Media.Imaging;
    using System.IO;

    public class RaceRunnerToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imagePath = string.Empty;

            if (value is RaceRunner)
            {
                RaceRunner? raceToConvert = value as RaceRunner?;
                if (!raceToConvert.HasValue) return null;

                switch (raceToConvert.Value)
                {
                    case RaceRunner.Anarch:
                        imagePath = "runner-anarch.png";
                        break;

                    case RaceRunner.Criminal:
                        imagePath = "runner-criminal.png";
                        break;

                    case RaceRunner.Shaper:
                        imagePath = "runner-shaper.png";
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

