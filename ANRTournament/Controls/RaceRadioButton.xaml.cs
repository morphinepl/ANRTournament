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
    /// Interaction logic for RaceRadioButton.xaml
    /// </summary>
    public partial class RaceRadioButton : UserControl
    {

        #region public RaceCorpo? RaceCorpo

        // Dependency properties declaration
        public static readonly DependencyProperty RaceCorpoProperty = DependencyProperty.Register(
            "RaceCorpo",
            typeof(RaceCorpo?),
            typeof(RaceRadioButton),
            new PropertyMetadata(null, OnRaceCorpoChanged));

        public static void OnRaceCorpoChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RaceRadioButton iControl = sender as RaceRadioButton;

            if (iControl.rdbCorpHB != null &&
                iControl.rdbCorpJinteki != null &&
                iControl.rdbCorpNBN != null &&
                iControl.rdbCorpWeyland != null)
            {
                RaceCorpo? newvalue = (e.NewValue as RaceCorpo?);
                if (newvalue.HasValue)
                {
                    switch ((RaceCorpo)newvalue.Value)
                    {
                        case ANRTournament.RaceCorpo.HaasBioroid:
                            iControl.rdbCorpHB.IsChecked = true;
                            break;
                        case ANRTournament.RaceCorpo.Jinteki:
                            iControl.rdbCorpJinteki.IsChecked = true;
                            break;
                        case ANRTournament.RaceCorpo.NBN:
                            iControl.rdbCorpNBN.IsChecked = true;
                            break;
                        case ANRTournament.RaceCorpo.WeylandConsortium:
                            iControl.rdbCorpWeyland.IsChecked = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    iControl.rdbCorpHB.IsChecked = true;
                }
            }
        }

        public RaceCorpo? RaceCorpo
        {
            get { return GetValue(RaceCorpoProperty) as RaceCorpo?; }
            set { SetValue(RaceCorpoProperty, value); }
        }

        #endregion

        public RaceRadioButton()
        {
            InitializeComponent();

            if (!App.IsInDesignMode)
            {
                string imagedirectory = "../Resources";
                this.imgCorpHB.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "corp-hb.png"), UriKind.Relative));
                this.imgCorpJinteki.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "corp-jinteki.png"), UriKind.Relative));
                this.imgCorpNBN.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "corp-nbn.png"), UriKind.Relative));
                this.imgCorpWeyland.Source = new BitmapImage(new Uri(System.IO.Path.Combine(imagedirectory, "corp-weyland.png"), UriKind.Relative));
            }
        }

        private void imgCorpHB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbCorpHB.IsChecked = true;
        }

        private void imgCorpJinteki_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbCorpJinteki.IsChecked = true;
        }

        private void imgCorpNBN_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbCorpNBN.IsChecked = true;
        }

        private void imgCorpWeyland_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rdbCorpWeyland.IsChecked = true;
        }

        private void rdbCorp_CheckedChange(object sender, RoutedEventArgs e)
        {
            if (this.rdbCorpHB == null ||
                this.rdbCorpJinteki == null ||
                this.rdbCorpNBN == null ||
                this.rdbCorpWeyland == null) return;

            ANRTournament.RaceCorpo race = ANRTournament.RaceCorpo.HaasBioroid;

            if (this.rdbCorpHB.IsChecked == true) race = ANRTournament.RaceCorpo.HaasBioroid;
            if (this.rdbCorpJinteki.IsChecked == true) race = ANRTournament.RaceCorpo.Jinteki;
            if (this.rdbCorpNBN.IsChecked == true) race = ANRTournament.RaceCorpo.NBN;
            if (this.rdbCorpWeyland.IsChecked == true) race = ANRTournament.RaceCorpo.WeylandConsortium;

            SetValue(RaceCorpoProperty, (RaceCorpo?)race);

            BindingExpression expression = this.GetBindingExpression(RaceRadioButton.RaceCorpoProperty);
            if (expression != null) expression.UpdateSource();
        }
    }
}
