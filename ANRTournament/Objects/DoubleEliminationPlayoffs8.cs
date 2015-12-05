using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ANRTournament.Objects
{
    public class DoubleEliminationPlayoffs8 : INotifyPropertyChanged
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

        private IEnumerable<Player> topplayers = null;

        #region Games

        private Game final_01 = null;
        private Game final_02 = null;
        private Game final_03 = null;
        private Game final_04 = null;
        private Game final_05 = null;
        private Game final_06 = null;
        private Game final_07 = null;
        private Game final_08 = null;
        private Game final_09 = null;
        private Game final_10 = null;
        private Game final_11 = null;
        private Game final_12 = null;
        private Game final_13 = null;
        private Game final_14 = null;
        private Game final_15 = null;

        #endregion

        #region Games Properties

        public Game Final_01
        {
            get { return this.final_01; }
            set
            {
                if (value != this.final_01)
                {
                    this.final_01 = value;
                    NotifyPropertyChanged("Final_01");
                }
            }
        }

        public Game Final_02
        {
            get { return this.final_02; }
            set
            {
                if (value != this.final_02)
                {
                    this.final_02 = value;
                    NotifyPropertyChanged("Final_02");
                }
            }
        }

        public Game Final_03
        {
            get { return this.final_03; }
            set
            {
                if (value != this.final_03)
                {
                    this.final_03 = value;
                    NotifyPropertyChanged("Final_03");
                }
            }
        }

        public Game Final_04
        {
            get { return this.final_04; }
            set
            {
                if (value != this.final_04)
                {
                    this.final_04 = value;
                    NotifyPropertyChanged("Final_04");
                }
            }
        }

        public Game Final_05
        {
            get { return this.final_05; }
            set
            {
                if (value != this.final_05)
                {
                    this.final_05 = value;
                    NotifyPropertyChanged("Final_05");
                }
            }
        }

        public Game Final_06
        {
            get { return this.final_06; }
            set
            {
                if (value != this.final_06)
                {
                    this.final_06 = value;
                    NotifyPropertyChanged("Final_06");
                }
            }
        }

        public Game Final_07
        {
            get { return this.final_07; }
            set
            {
                if (value != this.final_07)
                {
                    this.final_07 = value;
                    NotifyPropertyChanged("Final_07");
                }
            }
        }

        public Game Final_08
        {
            get { return this.final_08; }
            set
            {
                if (value != this.final_08)
                {
                    this.final_08 = value;
                    NotifyPropertyChanged("Final_08");
                }
            }
        }

        public Game Final_09
        {
            get { return this.final_09; }
            set
            {
                if (value != this.final_09)
                {
                    this.final_09 = value;
                    NotifyPropertyChanged("Final_09");
                }
            }
        }

        public Game Final_10
        {
            get { return this.final_10; }
            set
            {
                if (value != this.final_10)
                {
                    this.final_10 = value;
                    NotifyPropertyChanged("Final_10");
                }
            }
        }

        public Game Final_11
        {
            get { return this.final_11; }
            set
            {
                if (value != this.final_11)
                {
                    this.final_11 = value;
                    NotifyPropertyChanged("Final_11");
                }
            }
        }

        public Game Final_12
        {
            get { return this.final_12; }
            set
            {
                if (value != this.final_12)
                {
                    this.final_12 = value;
                    NotifyPropertyChanged("Final_12");
                }
            }
        }

        public Game Final_13
        {
            get { return this.final_13; }
            set
            {
                if (value != this.final_13)
                {
                    this.final_13 = value;
                    NotifyPropertyChanged("Final_13");
                }
            }
        }

        public Game Final_14
        {
            get { return this.final_14; }
            set
            {
                if (value != this.final_14)
                {
                    this.final_14 = value;
                    NotifyPropertyChanged("Final_14");
                }
            }
        }

        public Game Final_15
        {
            get { return this.final_15; }
            set
            {
                if (value != this.final_15)
                {
                    this.final_15 = value;
                    NotifyPropertyChanged("Final_15");
                }
            }
        }

        #endregion

        public bool StartPlayoffsTop8(IEnumerable<Player> players)
        {
            this.ClearPlayoffs();

            topplayers = players.Where(p => p.Active == true).OrderBy(p => p.Place).ToList();

            if (topplayers.Count() < 8) return false;

            topplayers = topplayers.Take(8);

            Player player01 = topplayers.ElementAt(0);
            Player player02 = topplayers.ElementAt(1);
            Player player03 = topplayers.ElementAt(2);
            Player player04 = topplayers.ElementAt(3);
            Player player05 = topplayers.ElementAt(4);
            Player player06 = topplayers.ElementAt(5);
            Player player07 = topplayers.ElementAt(6);
            Player player08 = topplayers.ElementAt(7);

            Final_01 = new Game()
            {
                Player1Alias = player01.Alias,
                Player1Id = player01.Id,
                Player1RaceCorpo = player01.RaceCorpo,
                Player1RaceRunner = player01.RaceRunner,

                Player2Alias = player08.Alias,
                Player2Id = player08.Id,
                Player2RaceCorpo = player08.RaceCorpo,
                Player2RaceRunner = player08.RaceRunner,
            };

            Final_02 = new Game()
            {
                Player1Alias = player04.Alias,
                Player1Id = player04.Id,
                Player1RaceCorpo = player04.RaceCorpo,
                Player1RaceRunner = player04.RaceRunner,

                Player2Alias = player05.Alias,
                Player2Id = player05.Id,
                Player2RaceCorpo = player05.RaceCorpo,
                Player2RaceRunner = player05.RaceRunner,
            };

            Final_03 = new Game()
            {
                Player1Alias = player02.Alias,
                Player1Id = player02.Id,
                Player1RaceCorpo = player02.RaceCorpo,
                Player1RaceRunner = player02.RaceRunner,

                Player2Alias = player07.Alias,
                Player2Id = player07.Id,
                Player2RaceCorpo = player07.RaceCorpo,
                Player2RaceRunner = player07.RaceRunner,
            };

            Final_04 = new Game()
            {
                Player1Alias = player03.Alias,
                Player1Id = player03.Id,
                Player1RaceCorpo = player03.RaceCorpo,
                Player1RaceRunner = player03.RaceRunner,

                Player2Alias = player06.Alias,
                Player2Id = player06.Id,
                Player2RaceCorpo = player06.RaceCorpo,
                Player2RaceRunner = player06.RaceRunner,
            };

            final_01.ScoreChanged += final_0104_ScoreChanged;
            final_02.ScoreChanged += final_0104_ScoreChanged;
            final_03.ScoreChanged += final_0104_ScoreChanged;
            final_04.ScoreChanged += final_0104_ScoreChanged;

            return true;
        }

        public void ClearPlayoffs()
        {
            this.topplayers = null;

            if (final_01 != null) final_01.ScoreChanged -= final_0104_ScoreChanged;
            if (final_02 != null) final_02.ScoreChanged -= final_0104_ScoreChanged;
            if (final_03 != null) final_03.ScoreChanged -= final_0104_ScoreChanged;
            if (final_04 != null) final_04.ScoreChanged -= final_0104_ScoreChanged;
            if (final_05 != null) final_05.ScoreChanged -= final_0508_ScoreChanged;
            if (final_06 != null) final_06.ScoreChanged -= final_0508_ScoreChanged;
            if (final_07 != null) final_07.ScoreChanged -= final_0508_ScoreChanged;
            if (final_08 != null) final_08.ScoreChanged -= final_0508_ScoreChanged;
            if (final_09 != null) final_09.ScoreChanged -= final_0913_ScoreChanged;
            if (final_10 != null) final_10.ScoreChanged -= final_1011_ScoreChanged;
            if (final_11 != null) final_11.ScoreChanged -= final_1011_ScoreChanged;
            if (final_12 != null) final_12.ScoreChanged -= final_12_ScoreChanged;
            if (final_13 != null) final_13.ScoreChanged -= final_0913_ScoreChanged;
            if (final_14 != null) final_14.ScoreChanged -= final_14_ScoreChanged;
            if (final_15 != null) final_15.ScoreChanged -= final_15_ScoreChanged;

            final_01 = null;
            final_02 = null;
            final_03 = null;
            final_04 = null;
            final_05 = null;
            final_06 = null;
            final_07 = null;
            final_08 = null;
            final_09 = null;
            final_10 = null;
            final_11 = null;
            final_12 = null;
            final_13 = null;
            final_14 = null;
            final_15 = null;

            NotifyPropertyChanged("Final_01");
            NotifyPropertyChanged("Final_02");
            NotifyPropertyChanged("Final_03");
            NotifyPropertyChanged("Final_04");
            NotifyPropertyChanged("Final_05");
            NotifyPropertyChanged("Final_06");
            NotifyPropertyChanged("Final_07");
            NotifyPropertyChanged("Final_08");
            NotifyPropertyChanged("Final_09");
            NotifyPropertyChanged("Final_10");
            NotifyPropertyChanged("Final_11");
            NotifyPropertyChanged("Final_12");
            NotifyPropertyChanged("Final_13");
            NotifyPropertyChanged("Final_14");
            NotifyPropertyChanged("Final_15");
        }

        public void RefreshEvents(IEnumerable<Player> players)
        {
            this.topplayers = players.Where(p => p.Active == true).OrderBy(p => p.Place).ToList();

            if (final_01 != null) final_01.ScoreChanged -= final_0104_ScoreChanged;
            if (final_02 != null) final_02.ScoreChanged -= final_0104_ScoreChanged;
            if (final_03 != null) final_03.ScoreChanged -= final_0104_ScoreChanged;
            if (final_04 != null) final_04.ScoreChanged -= final_0104_ScoreChanged;
            if (final_05 != null) final_05.ScoreChanged -= final_0508_ScoreChanged;
            if (final_06 != null) final_06.ScoreChanged -= final_0508_ScoreChanged;
            if (final_07 != null) final_07.ScoreChanged -= final_0508_ScoreChanged;
            if (final_08 != null) final_08.ScoreChanged -= final_0508_ScoreChanged;
            if (final_09 != null) final_09.ScoreChanged -= final_0913_ScoreChanged;
            if (final_10 != null) final_10.ScoreChanged -= final_1011_ScoreChanged;
            if (final_11 != null) final_11.ScoreChanged -= final_1011_ScoreChanged;
            if (final_12 != null) final_12.ScoreChanged -= final_12_ScoreChanged;
            if (final_13 != null) final_13.ScoreChanged -= final_0913_ScoreChanged;
            if (final_14 != null) final_14.ScoreChanged -= final_14_ScoreChanged;
            if (final_15 != null) final_15.ScoreChanged -= final_15_ScoreChanged;

            if (final_01 != null) final_01.ScoreChanged += final_0104_ScoreChanged;
            if (final_02 != null) final_02.ScoreChanged += final_0104_ScoreChanged;
            if (final_03 != null) final_03.ScoreChanged += final_0104_ScoreChanged;
            if (final_04 != null) final_04.ScoreChanged += final_0104_ScoreChanged;
            if (final_05 != null) final_05.ScoreChanged += final_0508_ScoreChanged;
            if (final_06 != null) final_06.ScoreChanged += final_0508_ScoreChanged;
            if (final_07 != null) final_07.ScoreChanged += final_0508_ScoreChanged;
            if (final_08 != null) final_08.ScoreChanged += final_0508_ScoreChanged;
            if (final_09 != null) final_09.ScoreChanged += final_0913_ScoreChanged;
            if (final_10 != null) final_10.ScoreChanged += final_1011_ScoreChanged;
            if (final_11 != null) final_11.ScoreChanged += final_1011_ScoreChanged;
            if (final_12 != null) final_12.ScoreChanged += final_12_ScoreChanged;
            if (final_13 != null) final_13.ScoreChanged += final_0913_ScoreChanged;
            if (final_14 != null) final_14.ScoreChanged += final_14_ScoreChanged;
            if (final_15 != null) final_15.ScoreChanged += final_15_ScoreChanged;
        }

        #region ScoreChanged

        private void final_15_ScoreChanged(object sender, EventArgs e)
        {

        }

        private void final_14_ScoreChanged(object sender, EventArgs e)
        {
            this.Final_15 = null;

            if (this.final_14 == null) return;
            if (this.final_14.Player1Score1 == 0 && this.final_14.Player1Score2 == 0 && this.final_14.Player2Score1 == 0 && this.final_14.Player2Score2 == 0) return;

            Game game31 = Game.GetNextPlayoffGameWinerLoser(this.final_14, this.final_14, this.topplayers);

            //jeśli przegrany był również w grze 29 to koniec
            if (game31.Player2Id == this.final_13.Player1Id || game31.Player2Id == this.final_13.Player1Id) return;
            else
            {
                this.Final_15 = game31;
                this.Final_15.ScoreChanged += final_15_ScoreChanged;
            }
        }

        private void final_0913_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_09 == null ||
                this.final_13 == null) return;

            if ((this.final_09.Player1Score1 == 0 && this.final_09.Player1Score2 == 0 && this.final_09.Player2Score1 == 0 && this.final_09.Player2Score2 == 0) ||
                (this.final_13.Player1Score1 == 0 && this.final_13.Player1Score2 == 0 && this.final_13.Player2Score1 == 0 && this.final_13.Player2Score2 == 0)) return;

            this.Final_14 = Game.GetNextPlayoffGame(final_09, final_13, this.topplayers);
            this.final_14.ScoreChanged += final_14_ScoreChanged;
        }

        private void final_12_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_09 == null || 
                this.final_12 == null) return;

            if ((this.final_09.Player1Score1 == 0 && this.final_09.Player1Score2 == 0 && this.final_09.Player2Score1 == 0 && this.final_09.Player2Score2 == 0) ||
                (this.final_12.Player1Score1 == 0 && this.final_12.Player1Score2 == 0 && this.final_12.Player2Score1 == 0 && this.final_12.Player2Score2 == 0))return;

            this.Final_13 = Game.GetNextPlayoffGameWinerLoser(final_12, final_09, this.topplayers);
            this.final_13.ScoreChanged += final_0913_ScoreChanged;
        }

        private void final_1011_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_10 == null ||
                this.final_11 == null) return;

            if ((this.final_10.Player1Score1 == 0 && this.final_10.Player1Score2 == 0 && this.final_10.Player2Score1 == 0 && this.final_10.Player2Score2 == 0) ||
                (this.final_11.Player1Score1 == 0 && this.final_11.Player1Score2 == 0 && this.final_11.Player2Score1 == 0 && this.final_11.Player2Score2 == 0)) return;

            this.Final_12 = Game.GetNextPlayoffGame(final_10, final_11, this.topplayers);

            this.final_12.ScoreChanged += final_12_ScoreChanged;
        }

        private void final_0508_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_05 == null ||
                this.final_06 == null ||
                this.final_07 == null ||
                this.final_08 == null) return;

            if ((this.final_05.Player1Score1 == 0 && this.final_05.Player1Score2 == 0 && this.final_05.Player2Score1 == 0 && this.final_05.Player2Score2 == 0) ||
                (this.final_06.Player1Score1 == 0 && this.final_06.Player1Score2 == 0 && this.final_06.Player2Score1 == 0 && this.final_06.Player2Score2 == 0) ||
                (this.final_07.Player1Score1 == 0 && this.final_07.Player1Score2 == 0 && this.final_07.Player2Score1 == 0 && this.final_07.Player2Score2 == 0) ||
                (this.final_08.Player1Score1 == 0 && this.final_08.Player1Score2 == 0 && this.final_08.Player2Score1 == 0 && this.final_08.Player2Score2 == 0)) return;

            this.Final_10 = Game.GetNextPlayoffGameWinerLoser(final_07, final_06, this.topplayers);
            this.Final_11 = Game.GetNextPlayoffGameWinerLoser(final_08, final_05, this.topplayers);

            this.Final_09 = Game.GetNextPlayoffGame(final_05, final_06, this.topplayers);


            this.final_09.ScoreChanged += final_0913_ScoreChanged;

            this.final_10.ScoreChanged += final_1011_ScoreChanged;
            this.final_11.ScoreChanged += final_1011_ScoreChanged;
        }

        private void final_0104_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_04 == null ||
                this.final_03 == null ||
                this.final_02 == null ||
                this.final_01 == null) return;

            if ((this.final_04.Player1Score1 == 0 && this.final_04.Player1Score2 == 0 && this.final_04.Player2Score1 == 0 && this.final_04.Player2Score2 == 0) ||
                (this.final_03.Player1Score1 == 0 && this.final_03.Player1Score2 == 0 && this.final_03.Player2Score1 == 0 && this.final_03.Player2Score2 == 0) ||
                (this.final_02.Player1Score1 == 0 && this.final_02.Player1Score2 == 0 && this.final_02.Player2Score1 == 0 && this.final_02.Player2Score2 == 0) ||
                (this.final_01.Player1Score1 == 0 && this.final_01.Player1Score2 == 0 && this.final_01.Player2Score1 == 0 && this.final_01.Player2Score2 == 0)) return;

            this.Final_07 = Game.GetNextPlayoffGameLosers(final_01, final_02, this.topplayers);
            this.Final_08 = Game.GetNextPlayoffGameLosers(final_03, final_04, this.topplayers);

            this.Final_05 = Game.GetNextPlayoffGame(final_01, final_02, this.topplayers);
            this.Final_06 = Game.GetNextPlayoffGame(final_03, final_04, this.topplayers);

            this.final_05.ScoreChanged += final_0508_ScoreChanged;
            this.final_06.ScoreChanged += final_0508_ScoreChanged;
            this.final_07.ScoreChanged += final_0508_ScoreChanged;
            this.final_08.ScoreChanged += final_0508_ScoreChanged;
        }

        #endregion

        public void RenamePlayer(Player playerToChange)
        {
            if (final_01 != null && final_01.Player1Id == playerToChange.Id) { final_01.Player1Alias = playerToChange.Alias; final_01.Player1RaceCorpo = playerToChange.RaceCorpo; final_01.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_02 != null && final_02.Player1Id == playerToChange.Id) { final_02.Player1Alias = playerToChange.Alias; final_02.Player1RaceCorpo = playerToChange.RaceCorpo; final_02.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_03 != null && final_03.Player1Id == playerToChange.Id) { final_03.Player1Alias = playerToChange.Alias; final_03.Player1RaceCorpo = playerToChange.RaceCorpo; final_03.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_04 != null && final_04.Player1Id == playerToChange.Id) { final_04.Player1Alias = playerToChange.Alias; final_04.Player1RaceCorpo = playerToChange.RaceCorpo; final_04.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_05 != null && final_05.Player1Id == playerToChange.Id) { final_05.Player1Alias = playerToChange.Alias; final_05.Player1RaceCorpo = playerToChange.RaceCorpo; final_05.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_06 != null && final_06.Player1Id == playerToChange.Id) { final_06.Player1Alias = playerToChange.Alias; final_06.Player1RaceCorpo = playerToChange.RaceCorpo; final_06.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_07 != null && final_07.Player1Id == playerToChange.Id) { final_07.Player1Alias = playerToChange.Alias; final_07.Player1RaceCorpo = playerToChange.RaceCorpo; final_07.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_08 != null && final_08.Player1Id == playerToChange.Id) { final_08.Player1Alias = playerToChange.Alias; final_08.Player1RaceCorpo = playerToChange.RaceCorpo; final_08.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_09 != null && final_09.Player1Id == playerToChange.Id) { final_09.Player1Alias = playerToChange.Alias; final_09.Player1RaceCorpo = playerToChange.RaceCorpo; final_09.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_10 != null && final_10.Player1Id == playerToChange.Id) { final_10.Player1Alias = playerToChange.Alias; final_10.Player1RaceCorpo = playerToChange.RaceCorpo; final_10.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_11 != null && final_11.Player1Id == playerToChange.Id) { final_11.Player1Alias = playerToChange.Alias; final_11.Player1RaceCorpo = playerToChange.RaceCorpo; final_11.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_12 != null && final_12.Player1Id == playerToChange.Id) { final_12.Player1Alias = playerToChange.Alias; final_12.Player1RaceCorpo = playerToChange.RaceCorpo; final_12.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_13 != null && final_13.Player1Id == playerToChange.Id) { final_13.Player1Alias = playerToChange.Alias; final_13.Player1RaceCorpo = playerToChange.RaceCorpo; final_13.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_14 != null && final_14.Player1Id == playerToChange.Id) { final_14.Player1Alias = playerToChange.Alias; final_14.Player1RaceCorpo = playerToChange.RaceCorpo; final_14.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_15 != null && final_15.Player1Id == playerToChange.Id) { final_15.Player1Alias = playerToChange.Alias; final_15.Player1RaceCorpo = playerToChange.RaceCorpo; final_15.Player1RaceRunner = playerToChange.RaceRunner; }

            if (final_01 != null && final_01.Player2Id == playerToChange.Id) { final_01.Player2Alias = playerToChange.Alias; final_01.Player2RaceCorpo = playerToChange.RaceCorpo; final_01.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_02 != null && final_02.Player2Id == playerToChange.Id) { final_02.Player2Alias = playerToChange.Alias; final_02.Player2RaceCorpo = playerToChange.RaceCorpo; final_02.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_03 != null && final_03.Player2Id == playerToChange.Id) { final_03.Player2Alias = playerToChange.Alias; final_03.Player2RaceCorpo = playerToChange.RaceCorpo; final_03.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_04 != null && final_04.Player2Id == playerToChange.Id) { final_04.Player2Alias = playerToChange.Alias; final_04.Player2RaceCorpo = playerToChange.RaceCorpo; final_04.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_05 != null && final_05.Player2Id == playerToChange.Id) { final_05.Player2Alias = playerToChange.Alias; final_05.Player2RaceCorpo = playerToChange.RaceCorpo; final_05.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_06 != null && final_06.Player2Id == playerToChange.Id) { final_06.Player2Alias = playerToChange.Alias; final_06.Player2RaceCorpo = playerToChange.RaceCorpo; final_06.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_07 != null && final_07.Player2Id == playerToChange.Id) { final_07.Player2Alias = playerToChange.Alias; final_07.Player2RaceCorpo = playerToChange.RaceCorpo; final_07.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_08 != null && final_08.Player2Id == playerToChange.Id) { final_08.Player2Alias = playerToChange.Alias; final_08.Player2RaceCorpo = playerToChange.RaceCorpo; final_08.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_09 != null && final_09.Player2Id == playerToChange.Id) { final_09.Player2Alias = playerToChange.Alias; final_09.Player2RaceCorpo = playerToChange.RaceCorpo; final_09.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_10 != null && final_10.Player2Id == playerToChange.Id) { final_10.Player2Alias = playerToChange.Alias; final_10.Player2RaceCorpo = playerToChange.RaceCorpo; final_10.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_11 != null && final_11.Player2Id == playerToChange.Id) { final_11.Player2Alias = playerToChange.Alias; final_11.Player2RaceCorpo = playerToChange.RaceCorpo; final_11.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_12 != null && final_12.Player2Id == playerToChange.Id) { final_12.Player2Alias = playerToChange.Alias; final_12.Player2RaceCorpo = playerToChange.RaceCorpo; final_12.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_13 != null && final_13.Player2Id == playerToChange.Id) { final_13.Player2Alias = playerToChange.Alias; final_13.Player2RaceCorpo = playerToChange.RaceCorpo; final_13.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_14 != null && final_14.Player2Id == playerToChange.Id) { final_14.Player2Alias = playerToChange.Alias; final_14.Player2RaceCorpo = playerToChange.RaceCorpo; final_14.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_15 != null && final_15.Player2Id == playerToChange.Id) { final_15.Player2Alias = playerToChange.Alias; final_15.Player2RaceCorpo = playerToChange.RaceCorpo; final_15.Player2RaceRunner = playerToChange.RaceRunner; }
        }

        internal bool IsAllScoresSet()
        {
            if (this.final_14 == null
                || (final_14.Player1Score1 == 0 && final_14.Player1Score2 == 0 && final_14.Player2Score1 == 0 && final_14.Player2Score2 == 0)
                || (this.final_15 != null && final_15.Player1Score1 == 0 && final_15.Player1Score2 == 0 && final_15.Player2Score1 == 0 && final_15.Player2Score2 == 0))
                return false;

            return true;
        }
    }
}
