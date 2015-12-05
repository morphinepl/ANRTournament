using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void httpButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(((Button)sender).Content.ToString());
        }
    }
}
