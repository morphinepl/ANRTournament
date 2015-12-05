using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ANRTournament.Objects
{
    public class DoubleEliminationPlayoffs16 : INotifyPropertyChanged
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
        private Game final_16 = null;
        private Game final_17 = null;
        private Game final_18 = null;
        private Game final_19 = null;
        private Game final_20 = null;
        private Game final_21 = null;
        private Game final_22 = null;
        private Game final_23 = null;
        private Game final_24 = null;
        private Game final_25 = null;
        private Game final_26 = null;
        private Game final_27 = null;
        private Game final_28 = null;
        private Game final_29 = null;
        private Game final_30 = null;
        private Game final_31 = null;

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

        public Game Final_16
        {
            get { return this.final_16; }
            set
            {
                if (value != this.final_16)
                {
                    this.final_16 = value;
                    NotifyPropertyChanged("Final_16");
                }
            }
        }

        public Game Final_17
        {
            get { return this.final_17; }
            set
            {
                if (value != this.final_17)
                {
                    this.final_17 = value;
                    NotifyPropertyChanged("Final_17");
                }
            }
        }

        public Game Final_18
        {
            get { return this.final_18; }
            set
            {
                if (value != this.final_18)
                {
                    this.final_18 = value;
                    NotifyPropertyChanged("Final_18");
                }
            }
        }

        public Game Final_19
        {
            get { return this.final_19; }
            set
            {
                if (value != this.final_19)
                {
                    this.final_19 = value;
                    NotifyPropertyChanged("Final_19");
                }
            }
        }

        public Game Final_20
        {
            get { return this.final_20; }
            set
            {
                if (value != this.final_20)
                {
                    this.final_20 = value;
                    NotifyPropertyChanged("Final_20");
                }
            }
        }

        public Game Final_21
        {
            get { return this.final_21; }
            set
            {
                if (value != this.final_21)
                {
                    this.final_21 = value;
                    NotifyPropertyChanged("Final_21");
                }
            }
        }

        public Game Final_22
        {
            get { return this.final_22; }
            set
            {
                if (value != this.final_22)
                {
                    this.final_22 = value;
                    NotifyPropertyChanged("Final_22");
                }
            }
        }

        public Game Final_23
        {
            get { return this.final_23; }
            set
            {
                if (value != this.final_23)
                {
                    this.final_23 = value;
                    NotifyPropertyChanged("Final_23");
                }
            }
        }

        public Game Final_24
        {
            get { return this.final_24; }
            set
            {
                if (value != this.final_24)
                {
                    this.final_24 = value;
                    NotifyPropertyChanged("Final_24");
                }
            }
        }

        public Game Final_25
        {
            get { return this.final_25; }
            set
            {
                if (value != this.final_25)
                {
                    this.final_25 = value;
                    NotifyPropertyChanged("Final_25");
                }
            }
        }

        public Game Final_26
        {
            get { return this.final_26; }
            set
            {
                if (value != this.final_26)
                {
                    this.final_26 = value;
                    NotifyPropertyChanged("Final_26");
                }
            }
        }

        public Game Final_27
        {
            get { return this.final_27; }
            set
            {
                if (value != this.final_27)
                {
                    this.final_27 = value;
                    NotifyPropertyChanged("Final_27");
                }
            }
        }

        public Game Final_28
        {
            get { return this.final_28; }
            set
            {
                if (value != this.final_28)
                {
                    this.final_28 = value;
                    NotifyPropertyChanged("Final_28");
                }
            }
        }

        public Game Final_29
        {
            get { return this.final_29; }
            set
            {
                if (value != this.final_29)
                {
                    this.final_29 = value;
                    NotifyPropertyChanged("Final_29");
                }
            }
        }

        public Game Final_30
        {
            get { return this.final_30; }
            set
            {
                if (value != this.final_30)
                {
                    this.final_30 = value;
                    NotifyPropertyChanged("Final_30");
                }
            }
        }

        public Game Final_31
        {
            get { return this.final_31; }
            set
            {
                if (value != this.final_31)
                {
                    this.final_31 = value;
                    NotifyPropertyChanged("Final_31");
                }
            }
        }

        #endregion

        public bool StartPlayoffsTop16(IEnumerable<Player> players)
        {
            this.ClearPlayoffs();

            topplayers = players.Where(p => p.Active == true).OrderBy(p => p.Place).ToList();

            if (topplayers.Count() < 16) return false;

            topplayers = topplayers.Take(16);

            Player player01 = topplayers.ElementAt(0);
            Player player02 = topplayers.ElementAt(1);
            Player player03 = topplayers.ElementAt(2);
            Player player04 = topplayers.ElementAt(3);
            Player player05 = topplayers.ElementAt(4);
            Player player06 = topplayers.ElementAt(5);
            Player player07 = topplayers.ElementAt(6);
            Player player08 = topplayers.ElementAt(7);
            Player player09 = topplayers.ElementAt(8);
            Player player10 = topplayers.ElementAt(9);
            Player player11 = topplayers.ElementAt(10);
            Player player12 = topplayers.ElementAt(11);
            Player player13 = topplayers.ElementAt(12);
            Player player14 = topplayers.ElementAt(13);
            Player player15 = topplayers.ElementAt(14);
            Player player16 = topplayers.ElementAt(15);

            Final_01 = new Game()
            {
                Player1Alias = player01.Alias,
                Player1Id = player01.Id,
                Player1RaceCorpo = player01.RaceCorpo,
                Player1RaceRunner = player01.RaceRunner,

                Player2Alias = player16.Alias,
                Player2Id = player16.Id,
                Player2RaceCorpo = player16.RaceCorpo,
                Player2RaceRunner = player16.RaceRunner,
            };

            Final_02 = new Game()
            {
                Player1Alias = player09.Alias,
                Player1Id = player09.Id,
                Player1RaceCorpo = player09.RaceCorpo,
                Player1RaceRunner = player09.RaceRunner,

                Player2Alias = player08.Alias,
                Player2Id = player08.Id,
                Player2RaceCorpo = player08.RaceCorpo,
                Player2RaceRunner = player08.RaceRunner,
            };

            Final_03 = new Game()
            {
                Player1Alias = player05.Alias,
                Player1Id = player05.Id,
                Player1RaceCorpo = player05.RaceCorpo,
                Player1RaceRunner = player05.RaceRunner,

                Player2Alias = player12.Alias,
                Player2Id = player12.Id,
                Player2RaceCorpo = player12.RaceCorpo,
                Player2RaceRunner = player12.RaceRunner,
            };

            Final_04 = new Game()
            {
                Player1Alias = player13.Alias,
                Player1Id = player13.Id,
                Player1RaceCorpo = player13.RaceCorpo,
                Player1RaceRunner = player13.RaceRunner,

                Player2Alias = player04.Alias,
                Player2Id = player04.Id,
                Player2RaceCorpo = player04.RaceCorpo,
                Player2RaceRunner = player04.RaceRunner,
            };

            Final_05 = new Game()
            {
                Player1Alias = player03.Alias,
                Player1Id = player03.Id,
                Player1RaceCorpo = player03.RaceCorpo,
                Player1RaceRunner = player03.RaceRunner,

                Player2Alias = player14.Alias,
                Player2Id = player14.Id,
                Player2RaceCorpo = player14.RaceCorpo,
                Player2RaceRunner = player14.RaceRunner,
            };

            Final_06 = new Game()
            {
                Player1Alias = player06.Alias,
                Player1Id = player06.Id,
                Player1RaceCorpo = player06.RaceCorpo,
                Player1RaceRunner = player06.RaceRunner,

                Player2Alias = player11.Alias,
                Player2Id = player11.Id,
                Player2RaceCorpo = player11.RaceCorpo,
                Player2RaceRunner = player11.RaceRunner,
            };

            Final_07 = new Game()
            {
                Player1Alias = player07.Alias,
                Player1Id = player07.Id,
                Player1RaceCorpo = player07.RaceCorpo,
                Player1RaceRunner = player07.RaceRunner,

                Player2Alias = player10.Alias,
                Player2Id = player10.Id,
                Player2RaceCorpo = player10.RaceCorpo,
                Player2RaceRunner = player10.RaceRunner,
            };

            Final_08 = new Game()
            {
                Player1Alias = player15.Alias,
                Player1Id = player15.Id,
                Player1RaceCorpo = player15.RaceCorpo,
                Player1RaceRunner = player15.RaceRunner,

                Player2Alias = player02.Alias,
                Player2Id = player02.Id,
                Player2RaceCorpo = player02.RaceCorpo,
                Player2RaceRunner = player02.RaceRunner,
            };

            final_01.ScoreChanged += final_0108_ScoreChanged;
            final_02.ScoreChanged += final_0108_ScoreChanged;
            final_03.ScoreChanged += final_0108_ScoreChanged;
            final_04.ScoreChanged += final_0108_ScoreChanged;
            final_05.ScoreChanged += final_0108_ScoreChanged;
            final_06.ScoreChanged += final_0108_ScoreChanged;
            final_07.ScoreChanged += final_0108_ScoreChanged;
            final_08.ScoreChanged += final_0108_ScoreChanged;

            return true;
        }

        public void ClearPlayoffs()
        {
            this.topplayers = null;

            if (final_01 != null) final_01.ScoreChanged -= final_0108_ScoreChanged;
            if (final_02 != null) final_02.ScoreChanged -= final_0108_ScoreChanged;
            if (final_03 != null) final_03.ScoreChanged -= final_0108_ScoreChanged;
            if (final_04 != null) final_04.ScoreChanged -= final_0108_ScoreChanged;
            if (final_05 != null) final_05.ScoreChanged -= final_0108_ScoreChanged;
            if (final_06 != null) final_06.ScoreChanged -= final_0108_ScoreChanged;
            if (final_07 != null) final_07.ScoreChanged -= final_0108_ScoreChanged;
            if (final_08 != null) final_08.ScoreChanged -= final_0108_ScoreChanged;

            if (final_09 != null) final_09.ScoreChanged -= final_0916_ScoreChanged;
            if (final_10 != null) final_10.ScoreChanged -= final_0916_ScoreChanged;
            if (final_11 != null) final_11.ScoreChanged -= final_0916_ScoreChanged;
            if (final_12 != null) final_12.ScoreChanged -= final_0916_ScoreChanged;
            if (final_13 != null) final_13.ScoreChanged -= final_0916_ScoreChanged;
            if (final_14 != null) final_14.ScoreChanged -= final_0916_ScoreChanged;
            if (final_15 != null) final_15.ScoreChanged -= final_0916_ScoreChanged;
            if (final_16 != null) final_16.ScoreChanged -= final_0916_ScoreChanged;

            if (final_17 != null) final_17.ScoreChanged -= final_1722_ScoreChanged;
            if (final_18 != null) final_18.ScoreChanged -= final_1722_ScoreChanged;
            if (final_19 != null) final_19.ScoreChanged -= final_1722_ScoreChanged;
            if (final_20 != null) final_20.ScoreChanged -= final_1722_ScoreChanged;
            if (final_21 != null) final_21.ScoreChanged -= final_1722_ScoreChanged;
            if (final_22 != null) final_22.ScoreChanged -= final_1722_ScoreChanged;

            if (final_23 != null) final_23.ScoreChanged -= final_2324_ScoreChanged;
            if (final_24 != null) final_24.ScoreChanged -= final_2324_ScoreChanged;

            if (final_25 != null) final_25.ScoreChanged -= final_2526_ScoreChanged;
            if (final_26 != null) final_26.ScoreChanged -= final_2526_ScoreChanged;

            if (final_27 != null) final_27.ScoreChanged -= final_2729_ScoreChanged;
            if (final_28 != null) final_28.ScoreChanged -= final_28_ScoreChanged;
            if (final_29 != null) final_29.ScoreChanged -= final_2729_ScoreChanged;
            if (final_30 != null) final_30.ScoreChanged -= final_30_ScoreChanged;
            if (final_31 != null) final_31.ScoreChanged -= final_31_ScoreChanged;

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
            final_16 = null;
            final_17 = null;
            final_18 = null;
            final_19 = null;
            final_20 = null;
            final_21 = null;
            final_22 = null;
            final_23 = null;
            final_24 = null;
            final_25 = null;
            final_26 = null;
            final_27 = null;
            final_28 = null;
            final_29 = null;
            final_30 = null;
            final_31 = null;

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
            NotifyPropertyChanged("Final_16");
            NotifyPropertyChanged("Final_17");
            NotifyPropertyChanged("Final_18");
            NotifyPropertyChanged("Final_19");
            NotifyPropertyChanged("Final_20");
            NotifyPropertyChanged("Final_21");
            NotifyPropertyChanged("Final_22");
            NotifyPropertyChanged("Final_23");
            NotifyPropertyChanged("Final_24");
            NotifyPropertyChanged("Final_25");
            NotifyPropertyChanged("Final_26");
            NotifyPropertyChanged("Final_27");
            NotifyPropertyChanged("Final_28");
            NotifyPropertyChanged("Final_29");
            NotifyPropertyChanged("Final_30");
            NotifyPropertyChanged("Final_31");
        }

        public void RefreshEvents(IEnumerable<Player> players)
        {
            this.topplayers = players.Where(p => p.Active == true).OrderBy(p => p.Place).ToList();

            if (final_01 != null) final_01.ScoreChanged -= final_0108_ScoreChanged;
            if (final_02 != null) final_02.ScoreChanged -= final_0108_ScoreChanged;
            if (final_03 != null) final_03.ScoreChanged -= final_0108_ScoreChanged;
            if (final_04 != null) final_04.ScoreChanged -= final_0108_ScoreChanged;
            if (final_05 != null) final_05.ScoreChanged -= final_0108_ScoreChanged;
            if (final_06 != null) final_06.ScoreChanged -= final_0108_ScoreChanged;
            if (final_07 != null) final_07.ScoreChanged -= final_0108_ScoreChanged;
            if (final_08 != null) final_08.ScoreChanged -= final_0108_ScoreChanged;

            if (final_09 != null) final_09.ScoreChanged -= final_0916_ScoreChanged;
            if (final_10 != null) final_10.ScoreChanged -= final_0916_ScoreChanged;
            if (final_11 != null) final_11.ScoreChanged -= final_0916_ScoreChanged;
            if (final_12 != null) final_12.ScoreChanged -= final_0916_ScoreChanged;
            if (final_13 != null) final_13.ScoreChanged -= final_0916_ScoreChanged;
            if (final_14 != null) final_14.ScoreChanged -= final_0916_ScoreChanged;
            if (final_15 != null) final_15.ScoreChanged -= final_0916_ScoreChanged;
            if (final_16 != null) final_16.ScoreChanged -= final_0916_ScoreChanged;

            if (final_17 != null) final_17.ScoreChanged -= final_1722_ScoreChanged;
            if (final_18 != null) final_18.ScoreChanged -= final_1722_ScoreChanged;
            if (final_19 != null) final_19.ScoreChanged -= final_1722_ScoreChanged;
            if (final_20 != null) final_20.ScoreChanged -= final_1722_ScoreChanged;
            if (final_21 != null) final_21.ScoreChanged -= final_1722_ScoreChanged;
            if (final_22 != null) final_22.ScoreChanged -= final_1722_ScoreChanged;

            if (final_23 != null) final_23.ScoreChanged -= final_2324_ScoreChanged;
            if (final_24 != null) final_24.ScoreChanged -= final_2324_ScoreChanged;

            if (final_25 != null) final_25.ScoreChanged -= final_2526_ScoreChanged;
            if (final_26 != null) final_26.ScoreChanged -= final_2526_ScoreChanged;

            if (final_27 != null) final_27.ScoreChanged -= final_2729_ScoreChanged;
            if (final_28 != null) final_28.ScoreChanged -= final_28_ScoreChanged;
            if (final_29 != null) final_29.ScoreChanged -= final_2729_ScoreChanged;
            if (final_30 != null) final_30.ScoreChanged -= final_30_ScoreChanged;
            if (final_31 != null) final_31.ScoreChanged -= final_31_ScoreChanged;

            if (final_01 != null) final_01.ScoreChanged += final_0108_ScoreChanged;
            if (final_02 != null) final_02.ScoreChanged += final_0108_ScoreChanged;
            if (final_03 != null) final_03.ScoreChanged += final_0108_ScoreChanged;
            if (final_04 != null) final_04.ScoreChanged += final_0108_ScoreChanged;
            if (final_05 != null) final_05.ScoreChanged += final_0108_ScoreChanged;
            if (final_06 != null) final_06.ScoreChanged += final_0108_ScoreChanged;
            if (final_07 != null) final_07.ScoreChanged += final_0108_ScoreChanged;
            if (final_08 != null) final_08.ScoreChanged += final_0108_ScoreChanged;

            if (final_09 != null) final_09.ScoreChanged += final_0916_ScoreChanged;
            if (final_10 != null) final_10.ScoreChanged += final_0916_ScoreChanged;
            if (final_11 != null) final_11.ScoreChanged += final_0916_ScoreChanged;
            if (final_12 != null) final_12.ScoreChanged += final_0916_ScoreChanged;
            if (final_13 != null) final_13.ScoreChanged += final_0916_ScoreChanged;
            if (final_14 != null) final_14.ScoreChanged += final_0916_ScoreChanged;
            if (final_15 != null) final_15.ScoreChanged += final_0916_ScoreChanged;
            if (final_16 != null) final_16.ScoreChanged += final_0916_ScoreChanged;

            if (final_17 != null) final_17.ScoreChanged += final_1722_ScoreChanged;
            if (final_18 != null) final_18.ScoreChanged += final_1722_ScoreChanged;
            if (final_19 != null) final_19.ScoreChanged += final_1722_ScoreChanged;
            if (final_20 != null) final_20.ScoreChanged += final_1722_ScoreChanged;
            if (final_21 != null) final_21.ScoreChanged += final_1722_ScoreChanged;
            if (final_22 != null) final_22.ScoreChanged += final_1722_ScoreChanged;

            if (final_23 != null) final_23.ScoreChanged += final_2324_ScoreChanged;
            if (final_24 != null) final_24.ScoreChanged += final_2324_ScoreChanged;

            if (final_25 != null) final_25.ScoreChanged += final_2526_ScoreChanged;
            if (final_26 != null) final_26.ScoreChanged += final_2526_ScoreChanged;

            if (final_27 != null) final_27.ScoreChanged += final_2729_ScoreChanged;
            if (final_28 != null) final_28.ScoreChanged += final_28_ScoreChanged;
            if (final_29 != null) final_29.ScoreChanged += final_2729_ScoreChanged;
            if (final_30 != null) final_30.ScoreChanged += final_30_ScoreChanged;
            if (final_31 != null) final_31.ScoreChanged += final_31_ScoreChanged;
        }

        #region ScoreChanged

        private void final_31_ScoreChanged(object sender, EventArgs e)
        {

        }

        private void final_30_ScoreChanged(object sender, EventArgs e)
        {
            this.Final_31 = null;

            if (this.final_30 == null) return;
            if (this.final_30.Player1Score1 == 0 && this.final_30.Player1Score2 == 0 && this.final_30.Player2Score1 == 0 && this.final_30.Player2Score2 == 0) return;

            Game game31 = Game.GetNextPlayoffGameWinerLoser(this.final_30, this.final_30, this.topplayers);

            //jeśli przegrany był również w grze 29 to koniec
            if (game31.Player2Id == this.final_29.Player1Id || game31.Player2Id == this.final_29.Player1Id) return;
            else
            {
                this.Final_31 = game31;
                this.Final_31.ScoreChanged += final_31_ScoreChanged;
            }
        }

        private void final_2729_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_27 == null ||
                this.final_29 == null) return;

            if ((this.final_27.Player1Score1 == 0 && this.final_27.Player1Score2 == 0 && this.final_27.Player2Score1 == 0 && this.final_27.Player2Score2 == 0) ||
                (this.final_29.Player1Score1 == 0 && this.final_29.Player1Score2 == 0 && this.final_29.Player2Score1 == 0 && this.final_29.Player2Score2 == 0)) return;

            this.Final_30 = Game.GetNextPlayoffGame(final_27, final_29, this.topplayers);
            this.final_30.ScoreChanged += final_30_ScoreChanged;
        }

        private void final_28_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_28 == null ||
                this.final_27 == null) return;

            if ((this.final_27.Player1Score1 == 0 && this.final_27.Player1Score2 == 0 && this.final_27.Player2Score1 == 0 && this.final_27.Player2Score2 == 0) ||
                (this.final_28.Player1Score1 == 0 && this.final_28.Player1Score2 == 0 && this.final_28.Player2Score1 == 0 && this.final_28.Player2Score2 == 0)) return;

            this.Final_29 = Game.GetNextPlayoffGameWinerLoser(final_28, final_27, this.topplayers);
            this.final_29.ScoreChanged += final_2729_ScoreChanged;
        }

        private void final_2526_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_25 == null ||
                this.final_26 == null) return;

            if ((this.final_25.Player1Score1 == 0 && this.final_25.Player1Score2 == 0 && this.final_25.Player2Score1 == 0 && this.final_25.Player2Score2 == 0) ||
                (this.final_26.Player1Score1 == 0 && this.final_26.Player1Score2 == 0 && this.final_26.Player2Score1 == 0 && this.final_26.Player2Score2 == 0)) return;

            this.Final_28 = Game.GetNextPlayoffGame(final_25, final_26, this.topplayers);
            this.final_28.ScoreChanged += final_28_ScoreChanged;
        }

        private void final_2324_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_23 == null ||
                this.final_24 == null) return;

            if ((this.final_23.Player1Score1 == 0 && this.final_23.Player1Score2 == 0 && this.final_23.Player2Score1 == 0 && this.final_23.Player2Score2 == 0) ||
                (this.final_24.Player1Score1 == 0 && this.final_24.Player1Score2 == 0 && this.final_24.Player2Score1 == 0 && this.final_24.Player2Score2 == 0)) return;

            this.Final_25 = Game.GetNextPlayoffGameWinerLoser(final_23, final_21, this.topplayers);
            this.Final_26 = Game.GetNextPlayoffGameWinerLoser(final_24, final_22, this.topplayers);

            this.final_25.ScoreChanged += final_2526_ScoreChanged;
            this.final_26.ScoreChanged += final_2526_ScoreChanged;
        }

        private void final_1722_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_17 == null ||
                this.final_18 == null ||
                this.final_19 == null ||
                this.final_20 == null ||
                this.final_21 == null ||
                this.final_22 == null) return;

            if ((this.final_17.Player1Score1 == 0 && this.final_17.Player1Score2 == 0 && this.final_17.Player2Score1 == 0 && this.final_17.Player2Score2 == 0) ||
                (this.final_18.Player1Score1 == 0 && this.final_18.Player1Score2 == 0 && this.final_18.Player2Score1 == 0 && this.final_18.Player2Score2 == 0) ||
                (this.final_19.Player1Score1 == 0 && this.final_19.Player1Score2 == 0 && this.final_19.Player2Score1 == 0 && this.final_19.Player2Score2 == 0) ||
                (this.final_20.Player1Score1 == 0 && this.final_20.Player1Score2 == 0 && this.final_20.Player2Score1 == 0 && this.final_20.Player2Score2 == 0) ||
                (this.final_21.Player1Score1 == 0 && this.final_21.Player1Score2 == 0 && this.final_21.Player2Score1 == 0 && this.final_21.Player2Score2 == 0) ||
                (this.final_22.Player1Score1 == 0 && this.final_22.Player1Score2 == 0 && this.final_22.Player2Score1 == 0 && this.final_22.Player2Score2 == 0)) return;

            this.Final_23 = Game.GetNextPlayoffGame(final_17, final_18, this.topplayers);
            this.Final_24 = Game.GetNextPlayoffGame(final_19, final_20, this.topplayers);

            this.Final_27 = Game.GetNextPlayoffGame(final_21, final_22, this.topplayers);

            this.final_23.ScoreChanged += final_2324_ScoreChanged;
            this.final_24.ScoreChanged += final_2324_ScoreChanged;
            this.final_27.ScoreChanged += final_2729_ScoreChanged;
        }

        private void final_0916_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_09 == null ||
                this.final_10 == null ||
                this.final_11 == null ||
                this.final_12 == null ||
                this.final_13 == null ||
                this.final_14 == null ||
                this.final_15 == null ||
                this.final_16 == null) return;

            if ((this.final_09.Player1Score1 == 0 && this.final_09.Player1Score2 == 0 && this.final_09.Player2Score1 == 0 && this.final_09.Player2Score2 == 0) ||
                (this.final_10.Player1Score1 == 0 && this.final_10.Player1Score2 == 0 && this.final_10.Player2Score1 == 0 && this.final_10.Player2Score2 == 0) ||
                (this.final_11.Player1Score1 == 0 && this.final_11.Player1Score2 == 0 && this.final_11.Player2Score1 == 0 && this.final_11.Player2Score2 == 0) ||
                (this.final_12.Player1Score1 == 0 && this.final_12.Player1Score2 == 0 && this.final_12.Player2Score1 == 0 && this.final_12.Player2Score2 == 0) ||
                (this.final_13.Player1Score1 == 0 && this.final_13.Player1Score2 == 0 && this.final_13.Player2Score1 == 0 && this.final_13.Player2Score2 == 0) ||
                (this.final_14.Player1Score1 == 0 && this.final_14.Player1Score2 == 0 && this.final_14.Player2Score1 == 0 && this.final_14.Player2Score2 == 0) ||
                (this.final_15.Player1Score1 == 0 && this.final_15.Player1Score2 == 0 && this.final_15.Player2Score1 == 0 && this.final_15.Player2Score2 == 0) ||
                (this.final_16.Player1Score1 == 0 && this.final_16.Player1Score2 == 0 && this.final_16.Player2Score1 == 0 && this.final_16.Player2Score2 == 0)) return;

            this.Final_17 = Game.GetNextPlayoffGameWinerLoser(final_09, final_16, this.topplayers);
            this.Final_18 = Game.GetNextPlayoffGameWinerLoser(final_10, final_15, this.topplayers);
            this.Final_19 = Game.GetNextPlayoffGameWinerLoser(final_11, final_14, this.topplayers);
            this.Final_20 = Game.GetNextPlayoffGameWinerLoser(final_12, final_13, this.topplayers);


            this.Final_21 = Game.GetNextPlayoffGame(final_13, final_14, this.topplayers);
            this.Final_22 = Game.GetNextPlayoffGame(final_15, final_16, this.topplayers);


            this.final_17.ScoreChanged += final_1722_ScoreChanged;
            this.final_18.ScoreChanged += final_1722_ScoreChanged;
            this.final_19.ScoreChanged += final_1722_ScoreChanged;
            this.final_20.ScoreChanged += final_1722_ScoreChanged;

            this.final_21.ScoreChanged += final_1722_ScoreChanged;
            this.final_22.ScoreChanged += final_1722_ScoreChanged;
        }

        private void final_0108_ScoreChanged(object sender, EventArgs e)
        {
            if (this.final_08 == null ||
                this.final_07 == null ||
                this.final_06 == null ||
                this.final_05 == null ||
                this.final_04 == null ||
                this.final_03 == null ||
                this.final_02 == null ||
                this.final_01 == null) return;

            if ((this.final_08.Player1Score1 == 0 && this.final_08.Player1Score2 == 0 && this.final_08.Player2Score1 == 0 && this.final_08.Player2Score2 == 0) ||
                (this.final_07.Player1Score1 == 0 && this.final_07.Player1Score2 == 0 && this.final_07.Player2Score1 == 0 && this.final_07.Player2Score2 == 0) ||
                (this.final_06.Player1Score1 == 0 && this.final_06.Player1Score2 == 0 && this.final_06.Player2Score1 == 0 && this.final_06.Player2Score2 == 0) ||
                (this.final_05.Player1Score1 == 0 && this.final_05.Player1Score2 == 0 && this.final_05.Player2Score1 == 0 && this.final_05.Player2Score2 == 0) ||
                (this.final_04.Player1Score1 == 0 && this.final_04.Player1Score2 == 0 && this.final_04.Player2Score1 == 0 && this.final_04.Player2Score2 == 0) ||
                (this.final_03.Player1Score1 == 0 && this.final_03.Player1Score2 == 0 && this.final_03.Player2Score1 == 0 && this.final_03.Player2Score2 == 0) ||
                (this.final_02.Player1Score1 == 0 && this.final_02.Player1Score2 == 0 && this.final_02.Player2Score1 == 0 && this.final_02.Player2Score2 == 0) ||
                (this.final_01.Player1Score1 == 0 && this.final_01.Player1Score2 == 0 && this.final_01.Player2Score1 == 0 && this.final_01.Player2Score2 == 0)) return;

            this.Final_09 = Game.GetNextPlayoffGameLosers(final_01, final_02, this.topplayers);
            this.Final_10 = Game.GetNextPlayoffGameLosers(final_03, final_04, this.topplayers);
            this.Final_11 = Game.GetNextPlayoffGameLosers(final_05, final_06, this.topplayers);
            this.Final_12 = Game.GetNextPlayoffGameLosers(final_07, final_08, this.topplayers);

            this.Final_13 = Game.GetNextPlayoffGame(final_01, final_02, this.topplayers);
            this.Final_14 = Game.GetNextPlayoffGame(final_03, final_04, this.topplayers);
            this.Final_15 = Game.GetNextPlayoffGame(final_05, final_06, this.topplayers);
            this.Final_16 = Game.GetNextPlayoffGame(final_07, final_08, this.topplayers);

            this.final_09.ScoreChanged += final_0916_ScoreChanged;
            this.final_10.ScoreChanged += final_0916_ScoreChanged;
            this.final_11.ScoreChanged += final_0916_ScoreChanged;
            this.final_12.ScoreChanged += final_0916_ScoreChanged;
            this.final_13.ScoreChanged += final_0916_ScoreChanged;
            this.final_14.ScoreChanged += final_0916_ScoreChanged;
            this.final_15.ScoreChanged += final_0916_ScoreChanged;
            this.final_16.ScoreChanged += final_0916_ScoreChanged;
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
            if (final_16 != null && final_16.Player1Id == playerToChange.Id) { final_16.Player1Alias = playerToChange.Alias; final_16.Player1RaceCorpo = playerToChange.RaceCorpo; final_16.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_17 != null && final_17.Player1Id == playerToChange.Id) { final_17.Player1Alias = playerToChange.Alias; final_17.Player1RaceCorpo = playerToChange.RaceCorpo; final_17.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_18 != null && final_18.Player1Id == playerToChange.Id) { final_18.Player1Alias = playerToChange.Alias; final_18.Player1RaceCorpo = playerToChange.RaceCorpo; final_18.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_19 != null && final_19.Player1Id == playerToChange.Id) { final_19.Player1Alias = playerToChange.Alias; final_19.Player1RaceCorpo = playerToChange.RaceCorpo; final_19.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_20 != null && final_20.Player1Id == playerToChange.Id) { final_20.Player1Alias = playerToChange.Alias; final_20.Player1RaceCorpo = playerToChange.RaceCorpo; final_20.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_21 != null && final_21.Player1Id == playerToChange.Id) { final_21.Player1Alias = playerToChange.Alias; final_21.Player1RaceCorpo = playerToChange.RaceCorpo; final_21.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_22 != null && final_22.Player1Id == playerToChange.Id) { final_22.Player1Alias = playerToChange.Alias; final_22.Player1RaceCorpo = playerToChange.RaceCorpo; final_22.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_23 != null && final_23.Player1Id == playerToChange.Id) { final_23.Player1Alias = playerToChange.Alias; final_23.Player1RaceCorpo = playerToChange.RaceCorpo; final_23.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_24 != null && final_24.Player1Id == playerToChange.Id) { final_24.Player1Alias = playerToChange.Alias; final_24.Player1RaceCorpo = playerToChange.RaceCorpo; final_24.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_25 != null && final_25.Player1Id == playerToChange.Id) { final_25.Player1Alias = playerToChange.Alias; final_25.Player1RaceCorpo = playerToChange.RaceCorpo; final_25.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_26 != null && final_26.Player1Id == playerToChange.Id) { final_26.Player1Alias = playerToChange.Alias; final_26.Player1RaceCorpo = playerToChange.RaceCorpo; final_26.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_27 != null && final_27.Player1Id == playerToChange.Id) { final_27.Player1Alias = playerToChange.Alias; final_27.Player1RaceCorpo = playerToChange.RaceCorpo; final_27.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_28 != null && final_28.Player1Id == playerToChange.Id) { final_28.Player1Alias = playerToChange.Alias; final_28.Player1RaceCorpo = playerToChange.RaceCorpo; final_28.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_29 != null && final_29.Player1Id == playerToChange.Id) { final_29.Player1Alias = playerToChange.Alias; final_29.Player1RaceCorpo = playerToChange.RaceCorpo; final_29.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_30 != null && final_30.Player1Id == playerToChange.Id) { final_30.Player1Alias = playerToChange.Alias; final_30.Player1RaceCorpo = playerToChange.RaceCorpo; final_30.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_31 != null && final_31.Player1Id == playerToChange.Id) { final_31.Player1Alias = playerToChange.Alias; final_31.Player1RaceCorpo = playerToChange.RaceCorpo; final_31.Player1RaceRunner = playerToChange.RaceRunner; }


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
            if (final_16 != null && final_16.Player2Id == playerToChange.Id) { final_16.Player2Alias = playerToChange.Alias; final_16.Player2RaceCorpo = playerToChange.RaceCorpo; final_16.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_17 != null && final_17.Player2Id == playerToChange.Id) { final_17.Player2Alias = playerToChange.Alias; final_17.Player2RaceCorpo = playerToChange.RaceCorpo; final_17.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_18 != null && final_18.Player2Id == playerToChange.Id) { final_18.Player2Alias = playerToChange.Alias; final_18.Player2RaceCorpo = playerToChange.RaceCorpo; final_18.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_19 != null && final_19.Player2Id == playerToChange.Id) { final_19.Player2Alias = playerToChange.Alias; final_19.Player2RaceCorpo = playerToChange.RaceCorpo; final_19.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_20 != null && final_20.Player2Id == playerToChange.Id) { final_20.Player2Alias = playerToChange.Alias; final_20.Player2RaceCorpo = playerToChange.RaceCorpo; final_20.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_21 != null && final_21.Player2Id == playerToChange.Id) { final_21.Player2Alias = playerToChange.Alias; final_21.Player2RaceCorpo = playerToChange.RaceCorpo; final_21.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_22 != null && final_22.Player2Id == playerToChange.Id) { final_22.Player2Alias = playerToChange.Alias; final_22.Player2RaceCorpo = playerToChange.RaceCorpo; final_22.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_23 != null && final_23.Player2Id == playerToChange.Id) { final_23.Player2Alias = playerToChange.Alias; final_23.Player2RaceCorpo = playerToChange.RaceCorpo; final_23.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_24 != null && final_24.Player2Id == playerToChange.Id) { final_24.Player2Alias = playerToChange.Alias; final_24.Player2RaceCorpo = playerToChange.RaceCorpo; final_24.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_25 != null && final_25.Player2Id == playerToChange.Id) { final_25.Player2Alias = playerToChange.Alias; final_25.Player2RaceCorpo = playerToChange.RaceCorpo; final_25.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_26 != null && final_26.Player2Id == playerToChange.Id) { final_26.Player2Alias = playerToChange.Alias; final_26.Player2RaceCorpo = playerToChange.RaceCorpo; final_26.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_27 != null && final_27.Player2Id == playerToChange.Id) { final_27.Player2Alias = playerToChange.Alias; final_27.Player2RaceCorpo = playerToChange.RaceCorpo; final_27.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_28 != null && final_28.Player2Id == playerToChange.Id) { final_28.Player2Alias = playerToChange.Alias; final_28.Player2RaceCorpo = playerToChange.RaceCorpo; final_28.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_29 != null && final_29.Player2Id == playerToChange.Id) { final_29.Player2Alias = playerToChange.Alias; final_29.Player2RaceCorpo = playerToChange.RaceCorpo; final_29.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_30 != null && final_30.Player2Id == playerToChange.Id) { final_30.Player2Alias = playerToChange.Alias; final_30.Player2RaceCorpo = playerToChange.RaceCorpo; final_30.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_31 != null && final_31.Player2Id == playerToChange.Id) { final_31.Player2Alias = playerToChange.Alias; final_31.Player2RaceCorpo = playerToChange.RaceCorpo; final_31.Player2RaceRunner = playerToChange.RaceRunner; }
        }

        internal bool IsAllScoresSet()
        {
            if (this.final_30 == null
                || (final_30.Player1Score1 == 0 && final_30.Player1Score2 == 0 && final_30.Player2Score1 == 0 && final_30.Player2Score2 == 0)
                || (this.final_31 != null && final_31.Player1Score1 == 0 && final_31.Player1Score2 == 0 && final_31.Player2Score1 == 0 && final_31.Player2Score2 == 0))
                return false;

            return true;
        }
    }
}
