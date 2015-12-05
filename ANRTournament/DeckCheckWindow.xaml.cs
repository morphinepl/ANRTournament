using System.Collections.ObjectModel;
using System.Windows;
using ANRTournament.Objects;
using System.Collections.Generic;
using System.Linq;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for DeckCheckWindow.xaml
    /// </summary>
    public partial class DeckCheckWindow : Window
    {
        private readonly List<Player> players = null;

        private DeckCheckWindow()
        {
            InitializeComponent();
            this.numPlayersNumber.Value = 1;
        }

        public DeckCheckWindow(ObservableCollection<Player> players)
            : this()
        {
            this.players = players.Where(p => p.Active == true && p.DeckCheck == false).ToList();
            if (this.players.Count == 0)
            {
                this.numPlayersNumber.Value = 0;
                this.numPlayersNumber.Maximum = 0;
            }
            else
            {
                this.numPlayersNumber.Maximum = this.players.Count;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGetPlayers_Click(object sender, RoutedEventArgs e)
        {
            SortedList<int, Player> randomList = new SortedList<int, Player>();

            foreach (Player player in this.players)
            {
                bool added = false;
                int index = 15;

                while (!added && index > 0)
                {
                    try
                    {
                        randomList.Add(Tournament.RandomGenerator.Next(9999), player);
                        added = true;
                    }
                    catch { index--; continue; }
                }
            }

            List<Player> randomPlayers = randomList.Values.Take(this.numPlayersNumber.Value.Value).ToList();

            this.DataContext = randomPlayers;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            Player player = ((FrameworkElement)sender).DataContext as Player;
            if (player == null) return;

            player.DeckCheck = !player.DeckCheck;
        }
    }
}
