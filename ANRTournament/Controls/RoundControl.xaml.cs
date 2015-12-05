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
using ANRTournament.Objects;
using System.ComponentModel;
using System.Printing;

namespace ANRTournament.Controls
{
    /// <summary>
    /// Kontrolka Rundy
    /// </summary>
    public partial class RoundControl : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        public RoundControl()
        {
            InitializeComponent();
        }

        public void SelectPlayerGame(Guid playerid)
        {
            IEnumerable<Game> gameToSelect = (this.DataContext as Round).Games.Where(g => g.Player1Id == playerid || g.Player2Id == playerid);

            if (gameToSelect.Count() > 0)
                this.dgPointsTable.SelectedItem = gameToSelect.ElementAt(0);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            //if ((this.DataContext as Round).Games.Count(g => g.Score == GameScore.NotSet) > 0)
            //    return;

            (this.DataContext as Round).ScoreEnabled = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Round).ScoreEnabled = true;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            XamlTemplatePrinter.PrintRound((this.DataContext as Round));
        }
    }
}
