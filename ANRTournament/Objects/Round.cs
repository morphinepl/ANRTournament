using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ANRTournament.Objects
{
    public class Round : INotifyPropertyChanged
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

        private int number = 0;
        private ObservableCollection<Game> games = new ObservableCollection<Game>();
        private bool scoreenabled = true;

        public bool ScoreEnabled
        {
            get { return this.scoreenabled; }
            set
            {
                if (value != this.scoreenabled)
                {
                    this.scoreenabled = value;
                    NotifyPropertyChanged("ScoreEnabled");
                }
            }
        }

        /// <summary>
        /// Numer
        /// </summary>
        public int Number
        {
            get { return this.number; }
            set
            {
                if (value != this.number)
                {
                    this.number = value;
                    NotifyPropertyChanged("Number");
                }
            }
        }

        /// <summary>
        /// Gry
        /// </summary>
        public ObservableCollection<Game> Games
        {
            get { return this.games; }
            set
            {
                if (value != this.games)
                {
                    this.games = value;
                    NotifyPropertyChanged("Games");
                }
            }
        }

        /// <summary>
        /// Funkcja sprawdza czy w danej rundzie gracz już jest dodany
        /// </summary>
        /// <param name="idPlayer"></param>
        /// <returns></returns>
        public bool IsPlayerInGame(Guid idPlayer)
        {
            return this.Games.Where(g => (g.Player1Id == idPlayer || g.Player2Id == idPlayer)).Count() != 0;
        }

        /// <summary>
        /// Funkcja sprawdza czy w danej rundzie wszyscy gracze są unikalni
        /// </summary>
        /// <returns></returns>
        public bool IsAllPlayersOnlyInOneGame()
        {
            foreach (Game game in this.Games)
            {
                if (this.Games.Where(g => (g.Player1Id == game.Player1Id ||
                                           g.Player2Id == game.Player1Id)).Count() > 1) return false;

                if (this.Games.Where(g => (g.Player1Id == game.Player2Id ||
                                           g.Player2Id == game.Player2Id)).Count() > 1) return false;
            }

            return true;
        }

        /// <summary>
        /// Zwraca Id gracza z BYE
        /// </summary>
        /// <returns></returns>
        public Guid GetBYEPlayerId()
        {
            Guid result = Guid.Empty;

            IEnumerable<Game> byeGames = this.Games.Where(g => (g.Player2Id == Guid.Empty));
            if (byeGames.Count() > 0)
            {
                result = byeGames.ElementAt(0).Player1Id;
            }

            return result;
        }
    }
}
