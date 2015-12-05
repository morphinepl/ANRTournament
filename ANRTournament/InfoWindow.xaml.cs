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
using System.Windows.Shapes;
using ANRTournament.Resources;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public MessageBoxResult Result { get; set; }

        private InfoWindow()
        {
            InitializeComponent();
        }

        public InfoWindow(string text, MessageBoxButton buttons, MessageBoxImage type)
            : this()
        {
            this.lblText.Content = text;

            switch (type)
            {
                case MessageBoxImage.Error:
                    this.lblTitle.Content = StringTable.PM_Error;
                    this.lblTitle.Foreground = Brushes.Red;
                    break;

                case MessageBoxImage.Warning:
                    this.lblTitle.Content = StringTable.PM_Warning;
                    this.lblTitle.Foreground = Brushes.DarkOrange;
                    break;

                case MessageBoxImage.Information:
                default:
                    this.lblTitle.Content = StringTable.PM_Information;
                    this.lblTitle.Foreground = Brushes.LightBlue;
                    break;
            }

            switch (buttons)
            {
                case MessageBoxButton.YesNo:
                case MessageBoxButton.YesNoCancel:
                    this.btnOK.Visibility = System.Windows.Visibility.Collapsed;
                    break;
                case MessageBoxButton.OK:
                case MessageBoxButton.OKCancel:
                default:
                    this.btnNo.Visibility = this.btnYes.Visibility = System.Windows.Visibility.Collapsed;
                    break;

            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.OK;
            this.Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.No;
            this.Close();
        }
    }
}
