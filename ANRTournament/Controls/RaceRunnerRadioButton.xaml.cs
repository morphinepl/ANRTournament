using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace ANRTournament.Controls
{
    /// <summary>
    /// Interaction logic for RaceRunnerRadioButton.xaml
    /// </summary>
    public partial class RaceRunnerRadioButton : UserControl
    {
        #region public RaceRunner? RaceRunner

        // Dependency properties declaration
        public static readonly DependencyProperty RaceRunnerProperty = DependencyProperty.Register(
            "RaceRunner",
            typeof(RaceRunner?),
            typeof(RaceRunnerRadioButton),
            new PropertyMetadata(null, OnRaceRunnerChanged));

        public static void OnRaceRunnerChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RaceRunnerRadioButton iControl = sender as RaceRunnerRadioButton;

            if (iControl.rdbRunnerAnarch != null &&
                iControl.rdbRunnerCriminal != null &&
                iControl.rdbRunnerShaper != null &&
                iControl.rdbRunnerApex != null &&
                iControl.rdbRunnerAdam != null &&
                iControl.rdbRunnerSunny != null)
            {
                RaceRunner? newvalue = (e.NewValue as RaceRunner?);
                if (newvalue.HasValue)
                {
                    switch ((RaceRunner)newvalue.Value)
                    {
                        case ANRTournament.RaceRunner.Anarch:
                            iControl.rdbRunnerAnarch.IsChecked = true;
                            break;
                        case ANRTournament.RaceRunner.Criminal:
                            iControl.rdbRunnerCriminal.IsChecked = true;
                            break;
                        case ANRTournament.RaceRunner.Shaper:
                            iControl.rdbRunnerShaper.IsChecked = true;
                            break;
                        case ANRTournament.RaceRunner.Apex:
                            iControl.rdbRunnerApex.IsChecked = true;
                            break;
                        case ANRTournament.RaceRunner.Adam:
                            iControl.rdbRunnerAdam.IsChecked = true;
                            break;
                        case ANRTournament.RaceRunner.Sunny:
                            iControl.rdbRunnerSunny.IsChecked = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    iControl.rdbRunnerAnarch.IsChecked = true;
                }
            }
        }

        public RaceRunner? RaceRunner
        {
            get { return GetValue(RaceRunnerProperty) as RaceRunner?; }
            set { SetValue(RaceRunnerProperty, value); }
        }

        #endregion   

        public RaceRunnerRadioButton()
        {
            InitializeComponent();

            if (!App.IsInDesignMode)
            {
                string imagedirectory = "../Resources";
                
                this.imgRunnerAnarch.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "runner-anarch.png"), UriKind.Relative));
                this.imgRunnerCriminal.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "runner-criminal.png"), UriKind.Relative));
                this.imgRunnerShaper.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "runner-shaper.png"), UriKind.Relative));
                this.imgRunnerApex.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "runner-apex.png"), UriKind.Relative));
                this.imgRunnerAdam.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "runner-adam.png"), UriKind.Relative));
                this.imgRunnerSunny.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "runner-sunny.png"), UriKind.Relative));
            }
        }

        private void imgRunnerAnarch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbRunnerAnarch.IsChecked = true;
        }

        private void imgRunnerCriminal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbRunnerCriminal.IsChecked = true;
        }

        private void imgRunnerShaper_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbRunnerShaper.IsChecked = true;
        }

        private void imgRunnerApex_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbRunnerApex.IsChecked = true;
        }

        private void imgRunnerAdam_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbRunnerAdam.IsChecked = true;
        }

        private void imgRunnerSunny_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbRunnerSunny.IsChecked = true;
        }

        private void rdbRunner_CheckedChange(object sender, RoutedEventArgs e)
        {
            if (this.rdbRunnerAnarch == null ||
                this.rdbRunnerCriminal == null ||
                this.rdbRunnerShaper == null ||
                this.rdbRunnerApex == null ||
                this.rdbRunnerAdam == null ||
                this.rdbRunnerSunny == null) return;

            ANRTournament.RaceRunner race = ANRTournament.RaceRunner.Anarch;

            if (this.rdbRunnerAnarch.IsChecked == true) race = ANRTournament.RaceRunner.Anarch;
            if (this.rdbRunnerCriminal.IsChecked == true) race = ANRTournament.RaceRunner.Criminal;
            if (this.rdbRunnerShaper.IsChecked == true) race = ANRTournament.RaceRunner.Shaper;
            if (this.rdbRunnerApex.IsChecked == true) race = ANRTournament.RaceRunner.Apex;
            if (this.rdbRunnerAdam.IsChecked == true) race = ANRTournament.RaceRunner.Adam;
            if (this.rdbRunnerSunny.IsChecked == true) race = ANRTournament.RaceRunner.Sunny;

            SetValue(RaceRunnerProperty, (RaceRunner?)race);

            BindingExpression expression = this.GetBindingExpression(RaceRunnerRadioButton.RaceRunnerProperty);
            if (expression != null) expression.UpdateSource();
        }
    }
}

