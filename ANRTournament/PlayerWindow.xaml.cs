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
using ANRTournament.Objects;
using ANRTournament.Resources;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private Player player = null;

        public Player Player
        {
            get { return this.player; }
            set { this.player = value; }
        }

        private PlayerWindow()
        {
            InitializeComponent();
        }

        public PlayerWindow(Player player)
            : this()
        {
            this.player = player;
            this.DataContext = this.player;
            this.txtAlias.SelectAll();
            this.txtAlias.Focus();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.player.Alias))            
            {
                new PMW(StringTable.PlayerWindow_PoleNazwaJestObowiązkowe);
                return;
            }

            int i = 0;
            if (!Int32.TryParse(this.txtRank.Text, out i))            
            {
                new PMW(StringTable.PlayerWindow_PoleRankingMusiBycWartosciaLiczbową);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
