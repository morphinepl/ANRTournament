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
    /// Interaction logic for CreateRoundWindow.xaml
    /// </summary>
    public partial class CreateRoundWindow : Window
    {
        private int gamescount = 0;
        private List<Game> possiblegames = null;
        private Round round = new Round();

        public Round Round
        {
            get { return this.round; }
        }

        private CreateRoundWindow()
        {
            InitializeComponent();
        }

        public CreateRoundWindow(IEnumerable<Game> games, int gamescount)
            : this()
        {
            this.gamescount = gamescount;
            this.possiblegames = games.ToList();
            this.dgAllGames.DataContext = this.possiblegames;

            this.dgRound.DataContext = this.round;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnCreateRound_Click(object sender, RoutedEventArgs e)
        {
            if (this.gamescount != this.round.Games.Count)
            {
                new PME(StringTable.CreateRoundWindow_NiepelnaRunda);
                return; 
            }

            this.DialogResult = true;
            this.Close();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnAddToRound_Click(object sender, RoutedEventArgs e)
        {
            Game selectedGame = this.dgAllGames.SelectedItem as Game;
            if (selectedGame == null) return;

            this.round.Games.Add(selectedGame);
            this.txtFilter.Text = string.Empty;
            this.txtFilter_TextChange(null, null);
        }

        private void btnDeleteFromRound_Click(object sender, RoutedEventArgs e)
        {
            Game selectedGame = this.dgRound.SelectedItem as Game;
            if (selectedGame == null) return;

            this.round.Games.Remove(selectedGame);
            this.txtFilter.Text = string.Empty;
            this.txtFilter_TextChange(null, null);
        }

        private void txtFilter_TextChange(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(this.dgAllGames.ItemsSource) as ListCollectionView;
            view.Filter = delegate(object item)
            {
                bool show = string.IsNullOrEmpty(this.txtFilter.Text);

                Game game = item as Game;
                if (game != null)
                {
                    show = (show || game.Player1Alias.ToLower().Contains(this.txtFilter.Text.ToLower()) || (!string.IsNullOrEmpty(game.Player2Alias) && game.Player2Alias.ToLower().Contains(this.txtFilter.Text.ToLower())))
                            && !this.round.IsPlayerInGame(game.Player1Id)
                            && !this.round.IsPlayerInGame(game.Player2Id);
                }

                return show;
            };
        }
    }
}
