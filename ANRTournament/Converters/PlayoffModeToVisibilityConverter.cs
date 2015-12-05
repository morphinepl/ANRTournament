using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Drawing;
using System.Windows;
using ANRTournament.Objects;
using System.Diagnostics;

namespace ANRTournament.Converters
{
    public class PlayoffTop16ModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DoubleEliminationPlayoffRound? startround = value as DoubleEliminationPlayoffRound?;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (startround.HasValue)
                {
                    if (startround.Value == DoubleEliminationPlayoffRound.Top16)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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

    public class PlayoffTop8ModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DoubleEliminationPlayoffRound? startround = value as DoubleEliminationPlayoffRound?;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (startround.HasValue)
                {
                    if (startround.Value == DoubleEliminationPlayoffRound.Top8)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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

    public class PlayoffDEModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DoubleEliminationPlayoffRound? startround = value as DoubleEliminationPlayoffRound?;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (startround.HasValue)
                {
                    if (startround.Value == DoubleEliminationPlayoffRound.WithoutPlayoffs)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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

    public class PlayoffMode16ToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Playoffs playoffs = value as Playoffs;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (playoffs != null)
                {
                    if (playoffs.StartRound == PlayoffRound.Final_16)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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

    public class PlayoffMode8ToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Playoffs playoffs = value as Playoffs;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (playoffs != null)
                {
                    if (playoffs.StartRound == PlayoffRound.Final_16 ||
                        playoffs.StartRound == PlayoffRound.Final_8)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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

    public class PlayoffMode4ToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Playoffs playoffs = value as Playoffs;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (playoffs != null)
                {
                    if (playoffs.StartRound == PlayoffRound.Final_16 ||
                        playoffs.StartRound == PlayoffRound.Final_8 ||
                        playoffs.StartRound == PlayoffRound.Final_4)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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

    public class PlayoffMode2ToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Playoffs playoffs = value as Playoffs;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (playoffs != null)
                {
                    if (playoffs.StartRound == PlayoffRound.Final_16 ||
                        playoffs.StartRound == PlayoffRound.Final_8 ||
                        playoffs.StartRound == PlayoffRound.Final_4 ||
                        playoffs.StartRound == PlayoffRound.Final_2)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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

    public class PlayoffModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Playoffs playoffs = value as Playoffs;

            Visibility valToReturn = Visibility.Collapsed;
            try
            {
                if (playoffs != null)
                {
                    if (playoffs.StartRound == PlayoffRound.Final_16 ||
                        playoffs.StartRound == PlayoffRound.Final_8 ||
                        playoffs.StartRound == PlayoffRound.Final_4 ||
                        playoffs.StartRound == PlayoffRound.Final_2 ||
                        playoffs.StartRound == PlayoffRound.Final)
                        valToReturn = Visibility.Visible;
                    else
                        valToReturn = Visibility.Collapsed;
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
