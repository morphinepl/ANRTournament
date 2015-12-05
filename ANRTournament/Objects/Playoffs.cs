using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ANRTournament.Objects
{
    public class Playoffs : INotifyPropertyChanged
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
        private PlayoffRound startround = PlayoffRound.Final_16;

        #region final 16

        private Game final_16_01 = null;
        private Game final_16_02 = null;
        private Game final_16_03 = null;
        private Game final_16_04 = null;
        private Game final_16_05 = null;
        private Game final_16_06 = null;
        private Game final_16_07 = null;
        private Game final_16_08 = null;
        private Game final_16_09 = null;
        private Game final_16_10 = null;
        private Game final_16_11 = null;
        private Game final_16_12 = null;
        private Game final_16_13 = null;
        private Game final_16_14 = null;
        private Game final_16_15 = null;
        private Game final_16_16 = null;

        #endregion

        #region final 8

        private Game final_8_01 = null;
        private Game final_8_02 = null;
        private Game final_8_03 = null;
        private Game final_8_04 = null;
        private Game final_8_05 = null;
        private Game final_8_06 = null;
        private Game final_8_07 = null;
        private Game final_8_08 = null;

        #endregion

        #region final 4

        private Game final_4_01 = null;
        private Game final_4_02 = null;
        private Game final_4_03 = null;
        private Game final_4_04 = null;

        #endregion

        #region final 2

        private Game final_2_01 = null;
        private Game final_2_02 = null;

        #endregion

        #region final and 3rd game

        private Game final = null;
        private Game game3rdplace = null;

        #endregion

        #region Properties

        #region Final 16

        public Game Final_16_01
        {
            get { return this.final_16_01; }
            set
            {
                if (value != this.final_16_01)
                {
                    this.final_16_01 = value;
                    NotifyPropertyChanged("Final_16_01");
                }
            }
        }

        public Game Final_16_02
        {
            get { return this.final_16_02; }
            set
            {
                if (value != this.final_16_02)
                {
                    this.final_16_02 = value;
                    NotifyPropertyChanged("Final_16_02");
                }
            }
        }

        public Game Final_16_03
        {
            get { return this.final_16_03; }
            set
            {
                if (value != this.final_16_03)
                {
                    this.final_16_03 = value;
                    NotifyPropertyChanged("Final_16_03");
                }
            }
        }

        public Game Final_16_04
        {
            get { return this.final_16_04; }
            set
            {
                if (value != this.final_16_04)
                {
                    this.final_16_04 = value;
                    NotifyPropertyChanged("Final_16_04");
                }
            }
        }

        public Game Final_16_05
        {
            get { return this.final_16_05; }
            set
            {
                if (value != this.final_16_05)
                {
                    this.final_16_05 = value;
                    NotifyPropertyChanged("Final_16_05");
                }
            }
        }

        public Game Final_16_06
        {
            get { return this.final_16_06; }
            set
            {
                if (value != this.final_16_06)
                {
                    this.final_16_06 = value;
                    NotifyPropertyChanged("Final_16_06");
                }
            }
        }

        public Game Final_16_07
        {
            get { return this.final_16_07; }
            set
            {
                if (value != this.final_16_07)
                {
                    this.final_16_07 = value;
                    NotifyPropertyChanged("Final_16_07");
                }
            }
        }

        public Game Final_16_08
        {
            get { return this.final_16_08; }
            set
            {
                if (value != this.final_16_08)
                {
                    this.final_16_08 = value;
                    NotifyPropertyChanged("Final_16_08");
                }
            }
        }

        public Game Final_16_09
        {
            get { return this.final_16_09; }
            set
            {
                if (value != this.final_16_09)
                {
                    this.final_16_09 = value;
                    NotifyPropertyChanged("Final_16_09");
                }
            }
        }

        public Game Final_16_10
        {
            get { return this.final_16_10; }
            set
            {
                if (value != this.final_16_10)
                {
                    this.final_16_10 = value;
                    NotifyPropertyChanged("Final_16_10");
                }
            }
        }

        public Game Final_16_11
        {
            get { return this.final_16_11; }
            set
            {
                if (value != this.final_16_11)
                {
                    this.final_16_11 = value;
                    NotifyPropertyChanged("Final_16_11");
                }
            }
        }

        public Game Final_16_12
        {
            get { return this.final_16_12; }
            set
            {
                if (value != this.final_16_12)
                {
                    this.final_16_12 = value;
                    NotifyPropertyChanged("Final_16_12");
                }
            }
        }

        public Game Final_16_13
        {
            get { return this.final_16_13; }
            set
            {
                if (value != this.final_16_13)
                {
                    this.final_16_13 = value;
                    NotifyPropertyChanged("Final_16_13");
                }
            }
        }

        public Game Final_16_14
        {
            get { return this.final_16_14; }
            set
            {
                if (value != this.final_16_14)
                {
                    this.final_16_14 = value;
                    NotifyPropertyChanged("Final_16_14");
                }
            }
        }

        public Game Final_16_15
        {
            get { return this.final_16_15; }
            set
            {
                if (value != this.final_16_15)
                {
                    this.final_16_15 = value;
                    NotifyPropertyChanged("Final_16_15");
                }
            }
        }

        public Game Final_16_16
        {
            get { return this.final_16_16; }
            set
            {
                if (value != this.final_16_16)
                {
                    this.final_16_16 = value;
                    NotifyPropertyChanged("Final_16_16");
                }
            }
        }

        #endregion

        #region Final 8

        public Game Final_8_01
        {
            get { return this.final_8_01; }
            set
            {
                if (value != this.final_8_01)
                {
                    this.final_8_01 = value;
                    NotifyPropertyChanged("Final_8_01");
                }
            }
        }

        public Game Final_8_02
        {
            get { return this.final_8_02; }
            set
            {
                if (value != this.final_8_02)
                {
                    this.final_8_02 = value;
                    NotifyPropertyChanged("Final_8_02");
                }
            }
        }

        public Game Final_8_03
        {
            get { return this.final_8_03; }
            set
            {
                if (value != this.final_8_03)
                {
                    this.final_8_03 = value;
                    NotifyPropertyChanged("Final_8_03");
                }
            }
        }

        public Game Final_8_04
        {
            get { return this.final_8_04; }
            set
            {
                if (value != this.final_8_04)
                {
                    this.final_8_04 = value;
                    NotifyPropertyChanged("Final_8_04");
                }
            }
        }

        public Game Final_8_05
        {
            get { return this.final_8_05; }
            set
            {
                if (value != this.final_8_05)
                {
                    this.final_8_05 = value;
                    NotifyPropertyChanged("Final_8_05");
                }
            }
        }

        public Game Final_8_06
        {
            get { return this.final_8_06; }
            set
            {
                if (value != this.final_8_06)
                {
                    this.final_8_06 = value;
                    NotifyPropertyChanged("Final_8_06");
                }
            }
        }

        public Game Final_8_07
        {
            get { return this.final_8_07; }
            set
            {
                if (value != this.final_8_07)
                {
                    this.final_8_07 = value;
                    NotifyPropertyChanged("Final_8_07");
                }
            }
        }

        public Game Final_8_08
        {
            get { return this.final_8_08; }
            set
            {
                if (value != this.final_8_08)
                {
                    this.final_8_08 = value;
                    NotifyPropertyChanged("Final_8_08");
                }
            }
        }

        #endregion

        #region Final 4

        public Game Final_4_01
        {
            get { return this.final_4_01; }
            set
            {
                if (value != this.final_4_01)
                {
                    this.final_4_01 = value;
                    NotifyPropertyChanged("Final_4_01");
                }
            }
        }

        public Game Final_4_02
        {
            get { return this.final_4_02; }
            set
            {
                if (value != this.final_4_02)
                {
                    this.final_4_02 = value;
                    NotifyPropertyChanged("Final_4_02");
                }
            }
        }

        public Game Final_4_03
        {
            get { return this.final_4_03; }
            set
            {
                if (value != this.final_4_03)
                {
                    this.final_4_03 = value;
                    NotifyPropertyChanged("Final_4_03");
                }
            }
        }

        public Game Final_4_04
        {
            get { return this.final_4_04; }
            set
            {
                if (value != this.final_4_04)
                {
                    this.final_4_04 = value;
                    NotifyPropertyChanged("Final_4_04");
                }
            }
        }

        #endregion

        #region Final 2

        public Game Final_2_01
        {
            get { return this.final_2_01; }
            set
            {
                if (value != this.final_2_01)
                {
                    this.final_2_01 = value;
                    NotifyPropertyChanged("Final_2_01");
                }
            }
        }

        public Game Final_2_02
        {
            get { return this.final_2_02; }
            set
            {
                if (value != this.final_2_02)
                {
                    this.final_2_02 = value;
                    NotifyPropertyChanged("Final_2_02");
                }
            }
        }

        #endregion

        #region Final and 3rd game

        public Game Final
        {
            get { return this.final; }
            set
            {
                if (value != this.final)
                {
                    this.final = value;
                    NotifyPropertyChanged("Final");
                }
            }
        }

        public Game Game3rdPlace
        {
            get { return this.game3rdplace; }
            set
            {
                if (value != this.game3rdplace)
                {
                    this.game3rdplace = value;
                    NotifyPropertyChanged("Game3rdPlace");
                }
            }
        }

        #endregion

        #endregion

        public PlayoffRound StartRound
        {
            get { return this.startround; }
            set
            {
                if (value != this.startround)
                {
                    this.startround = value;
                    NotifyPropertyChanged("StartRound");
                }
            }
        }

        public bool StartPlayoffs16(IEnumerable<Player> players)
        {
            this.ClearPlayoffs();

            StartRound = PlayoffRound.Final_16;

            topplayers = players.Where(p => p.Active == true).OrderBy(p => p.Place).ToList();

            if (topplayers.Count() < 32) return false;

            topplayers = topplayers.Take(32);

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
            Player player17 = topplayers.ElementAt(16);
            Player player18 = topplayers.ElementAt(17);
            Player player19 = topplayers.ElementAt(18);
            Player player20 = topplayers.ElementAt(19);
            Player player21 = topplayers.ElementAt(20);
            Player player22 = topplayers.ElementAt(21);
            Player player23 = topplayers.ElementAt(22);
            Player player24 = topplayers.ElementAt(23);
            Player player25 = topplayers.ElementAt(24);
            Player player26 = topplayers.ElementAt(25);
            Player player27 = topplayers.ElementAt(26);
            Player player28 = topplayers.ElementAt(27);
            Player player29 = topplayers.ElementAt(28);
            Player player30 = topplayers.ElementAt(29);
            Player player31 = topplayers.ElementAt(30);
            Player player32 = topplayers.ElementAt(31);

            Final_16_01 = new Game()
            {
                Player1Alias = player01.Alias,
                Player1Id = player01.Id,
                Player1RaceCorpo = player01.RaceCorpo,
                Player1RaceRunner = player01.RaceRunner,

                Player2Alias = player32.Alias,
                Player2Id = player32.Id,
                Player2RaceCorpo = player32.RaceCorpo,
                Player2RaceRunner = player32.RaceRunner,
            };

            Final_16_02 = new Game()
            {
                Player1Alias = player16.Alias,
                Player1Id = player16.Id,
                Player1RaceCorpo = player16.RaceCorpo,
                Player1RaceRunner = player16.RaceRunner,

                Player2Alias = player17.Alias,
                Player2Id = player17.Id,
                Player2RaceCorpo = player17.RaceCorpo,
                Player2RaceRunner = player17.RaceRunner,
            };

            Final_16_03 = new Game()
            {
                Player1Alias = player08.Alias,
                Player1Id = player08.Id,
                Player1RaceCorpo = player08.RaceCorpo,
                Player1RaceRunner = player08.RaceRunner,

                Player2Alias = player25.Alias,
                Player2Id = player25.Id,
                Player2RaceCorpo = player25.RaceCorpo,
                Player2RaceRunner = player25.RaceRunner,
            };

            Final_16_04 = new Game()
            {
                Player1Alias = player09.Alias,
                Player1Id = player09.Id,
                Player1RaceCorpo = player09.RaceCorpo,
                Player1RaceRunner = player09.RaceRunner,

                Player2Alias = player24.Alias,
                Player2Id = player24.Id,
                Player2RaceCorpo = player24.RaceCorpo,
                Player2RaceRunner = player24.RaceRunner,
            };

            Final_16_05 = new Game()
            {
                Player1Alias = player04.Alias,
                Player1Id = player04.Id,
                Player1RaceCorpo = player04.RaceCorpo,
                Player1RaceRunner = player04.RaceRunner,

                Player2Alias = player29.Alias,
                Player2Id = player29.Id,
                Player2RaceCorpo = player29.RaceCorpo,
                Player2RaceRunner = player29.RaceRunner,
            };

            Final_16_06 = new Game()
            {
                Player1Alias = player13.Alias,
                Player1Id = player13.Id,
                Player1RaceCorpo = player13.RaceCorpo,
                Player1RaceRunner = player13.RaceRunner,

                Player2Alias = player20.Alias,
                Player2Id = player20.Id,
                Player2RaceCorpo = player20.RaceCorpo,
                Player2RaceRunner = player20.RaceRunner,
            };

            Final_16_07 = new Game()
            {
                Player1Alias = player05.Alias,
                Player1Id = player05.Id,
                Player1RaceCorpo = player05.RaceCorpo,
                Player1RaceRunner = player05.RaceRunner,

                Player2Alias = player28.Alias,
                Player2Id = player28.Id,
                Player2RaceCorpo = player28.RaceCorpo,
                Player2RaceRunner = player28.RaceRunner,
            };

            Final_16_08 = new Game()
            {
                Player1Alias = player12.Alias,
                Player1Id = player12.Id,
                Player1RaceCorpo = player12.RaceCorpo,
                Player1RaceRunner = player12.RaceRunner,

                Player2Alias = player21.Alias,
                Player2Id = player21.Id,
                Player2RaceCorpo = player21.RaceCorpo,
                Player2RaceRunner = player21.RaceRunner,
            };

            Final_16_09 = new Game()
            {
                Player1Alias = player02.Alias,
                Player1Id = player02.Id,
                Player1RaceCorpo = player02.RaceCorpo,
                Player1RaceRunner = player02.RaceRunner,

                Player2Alias = player31.Alias,
                Player2Id = player31.Id,
                Player2RaceCorpo = player31.RaceCorpo,
                Player2RaceRunner = player31.RaceRunner,
            };

            Final_16_10 = new Game()
            {
                Player1Alias = player15.Alias,
                Player1Id = player15.Id,
                Player1RaceCorpo = player15.RaceCorpo,
                Player1RaceRunner = player15.RaceRunner,

                Player2Alias = player18.Alias,
                Player2Id = player18.Id,
                Player2RaceCorpo = player18.RaceCorpo,
                Player2RaceRunner = player18.RaceRunner,
            };

            Final_16_11 = new Game()
            {
                Player1Alias = player07.Alias,
                Player1Id = player07.Id,
                Player1RaceCorpo = player07.RaceCorpo,
                Player1RaceRunner = player07.RaceRunner,

                Player2Alias = player26.Alias,
                Player2Id = player26.Id,
                Player2RaceCorpo = player26.RaceCorpo,
                Player2RaceRunner = player26.RaceRunner,
            };

            Final_16_12 = new Game()
            {
                Player1Alias = player10.Alias,
                Player1Id = player10.Id,
                Player1RaceCorpo = player10.RaceCorpo,
                Player1RaceRunner = player10.RaceRunner,

                Player2Alias = player23.Alias,
                Player2Id = player23.Id,
                Player2RaceCorpo = player23.RaceCorpo,
                Player2RaceRunner = player23.RaceRunner,
            };

            Final_16_13 = new Game()
            {
                Player1Alias = player03.Alias,
                Player1Id = player03.Id,
                Player1RaceCorpo = player03.RaceCorpo,
                Player1RaceRunner = player03.RaceRunner,

                Player2Alias = player30.Alias,
                Player2Id = player30.Id,
                Player2RaceCorpo = player30.RaceCorpo,
                Player2RaceRunner = player30.RaceRunner,
            };

            Final_16_14 = new Game()
            {
                Player1Alias = player14.Alias,
                Player1Id = player14.Id,
                Player1RaceCorpo = player14.RaceCorpo,
                Player1RaceRunner = player14.RaceRunner,

                Player2Alias = player19.Alias,
                Player2Id = player19.Id,
                Player2RaceCorpo = player19.RaceCorpo,
                Player2RaceRunner = player19.RaceRunner,
            };

            Final_16_15 = new Game()
            {
                Player1Alias = player06.Alias,
                Player1Id = player06.Id,
                Player1RaceCorpo = player06.RaceCorpo,
                Player1RaceRunner = player06.RaceRunner,

                Player2Alias = player27.Alias,
                Player2Id = player27.Id,
                Player2RaceCorpo = player27.RaceCorpo,
                Player2RaceRunner = player27.RaceRunner,
            };

            Final_16_16 = new Game()
            {
                Player1Alias = player11.Alias,
                Player1Id = player11.Id,
                Player1RaceCorpo = player11.RaceCorpo,
                Player1RaceRunner = player11.RaceRunner,

                Player2Alias = player22.Alias,
                Player2Id = player22.Id,
                Player2RaceCorpo = player22.RaceCorpo,
                Player2RaceRunner = player22.RaceRunner,
            };

            final_16_01.DiceSystemTop(topplayers);
            final_16_02.DiceSystemTop(topplayers);
            final_16_03.DiceSystemTop(topplayers);
            final_16_04.DiceSystemTop(topplayers);
            final_16_05.DiceSystemTop(topplayers);
            final_16_06.DiceSystemTop(topplayers);
            final_16_07.DiceSystemTop(topplayers);
            final_16_08.DiceSystemTop(topplayers);
            final_16_09.DiceSystemTop(topplayers);
            final_16_10.DiceSystemTop(topplayers);
            final_16_11.DiceSystemTop(topplayers);
            final_16_12.DiceSystemTop(topplayers);
            final_16_13.DiceSystemTop(topplayers);
            final_16_14.DiceSystemTop(topplayers);
            final_16_15.DiceSystemTop(topplayers);
            final_16_16.DiceSystemTop(topplayers);


            final_16_01.ScoreChanged += final16_ScoreChanged;
            final_16_02.ScoreChanged += final16_ScoreChanged;
            final_16_03.ScoreChanged += final16_ScoreChanged;
            final_16_04.ScoreChanged += final16_ScoreChanged;
            final_16_05.ScoreChanged += final16_ScoreChanged;
            final_16_06.ScoreChanged += final16_ScoreChanged;
            final_16_07.ScoreChanged += final16_ScoreChanged;
            final_16_08.ScoreChanged += final16_ScoreChanged;
            final_16_09.ScoreChanged += final16_ScoreChanged;
            final_16_10.ScoreChanged += final16_ScoreChanged;
            final_16_11.ScoreChanged += final16_ScoreChanged;
            final_16_12.ScoreChanged += final16_ScoreChanged;
            final_16_13.ScoreChanged += final16_ScoreChanged;
            final_16_14.ScoreChanged += final16_ScoreChanged;
            final_16_15.ScoreChanged += final16_ScoreChanged;
            final_16_16.ScoreChanged += final16_ScoreChanged;

            return true;
        }

        private void final16_ScoreChanged(object sender, EventArgs e)
        {
            if ((this.final_16_01.Player1Score1 == 0 && this.final_16_01.Player1Score2 == 0 && this.final_16_01.Player2Score1 == 0 && this.final_16_01.Player2Score2 == 0) ||
                (this.final_16_02.Player1Score1 == 0 && this.final_16_02.Player1Score2 == 0 && this.final_16_02.Player2Score1 == 0 && this.final_16_02.Player2Score2 == 0) ||
                (this.final_16_03.Player1Score1 == 0 && this.final_16_03.Player1Score2 == 0 && this.final_16_03.Player2Score1 == 0 && this.final_16_03.Player2Score2 == 0) ||
                (this.final_16_04.Player1Score1 == 0 && this.final_16_04.Player1Score2 == 0 && this.final_16_04.Player2Score1 == 0 && this.final_16_04.Player2Score2 == 0) ||
                (this.final_16_05.Player1Score1 == 0 && this.final_16_05.Player1Score2 == 0 && this.final_16_05.Player2Score1 == 0 && this.final_16_05.Player2Score2 == 0) ||
                (this.final_16_06.Player1Score1 == 0 && this.final_16_06.Player1Score2 == 0 && this.final_16_06.Player2Score1 == 0 && this.final_16_06.Player2Score2 == 0) ||
                (this.final_16_07.Player1Score1 == 0 && this.final_16_07.Player1Score2 == 0 && this.final_16_07.Player2Score1 == 0 && this.final_16_07.Player2Score2 == 0) ||
                (this.final_16_08.Player1Score1 == 0 && this.final_16_08.Player1Score2 == 0 && this.final_16_08.Player2Score1 == 0 && this.final_16_08.Player2Score2 == 0) ||
                (this.final_16_09.Player1Score1 == 0 && this.final_16_09.Player1Score2 == 0 && this.final_16_09.Player2Score1 == 0 && this.final_16_09.Player2Score2 == 0) ||
                (this.final_16_10.Player1Score1 == 0 && this.final_16_10.Player1Score2 == 0 && this.final_16_10.Player2Score1 == 0 && this.final_16_10.Player2Score2 == 0) ||
                (this.final_16_11.Player1Score1 == 0 && this.final_16_11.Player1Score2 == 0 && this.final_16_11.Player2Score1 == 0 && this.final_16_11.Player2Score2 == 0) ||
                (this.final_16_12.Player1Score1 == 0 && this.final_16_12.Player1Score2 == 0 && this.final_16_12.Player2Score1 == 0 && this.final_16_12.Player2Score2 == 0) ||
                (this.final_16_13.Player1Score1 == 0 && this.final_16_13.Player1Score2 == 0 && this.final_16_13.Player2Score1 == 0 && this.final_16_13.Player2Score2 == 0) ||
                (this.final_16_14.Player1Score1 == 0 && this.final_16_14.Player1Score2 == 0 && this.final_16_14.Player2Score1 == 0 && this.final_16_14.Player2Score2 == 0) ||
                (this.final_16_15.Player1Score1 == 0 && this.final_16_15.Player1Score2 == 0 && this.final_16_15.Player2Score1 == 0 && this.final_16_15.Player2Score2 == 0) ||
                (this.final_16_16.Player1Score1 == 0 && this.final_16_16.Player1Score2 == 0 && this.final_16_16.Player2Score1 == 0 && this.final_16_16.Player2Score2 == 0)) return;

            Final_8_01 = Game.GetNextPlayoffGame(final_16_01, final_16_02, this.topplayers);
            Final_8_02 = Game.GetNextPlayoffGame(final_16_03, final_16_04, this.topplayers);
            Final_8_03 = Game.GetNextPlayoffGame(final_16_05, final_16_06, this.topplayers);
            Final_8_04 = Game.GetNextPlayoffGame(final_16_07, final_16_08, this.topplayers);
            Final_8_05 = Game.GetNextPlayoffGame(final_16_09, final_16_10, this.topplayers);
            Final_8_06 = Game.GetNextPlayoffGame(final_16_11, final_16_12, this.topplayers);
            Final_8_07 = Game.GetNextPlayoffGame(final_16_13, final_16_14, this.topplayers);
            Final_8_08 = Game.GetNextPlayoffGame(final_16_15, final_16_16, this.topplayers);

            final_8_01.DiceSystemTop(topplayers);
            final_8_02.DiceSystemTop(topplayers);
            final_8_03.DiceSystemTop(topplayers);
            final_8_04.DiceSystemTop(topplayers);
            final_8_05.DiceSystemTop(topplayers);
            final_8_06.DiceSystemTop(topplayers);
            final_8_07.DiceSystemTop(topplayers);
            final_8_08.DiceSystemTop(topplayers);

            final_8_01.ScoreChanged += final8_ScoreChanged;
            final_8_02.ScoreChanged += final8_ScoreChanged;
            final_8_03.ScoreChanged += final8_ScoreChanged;
            final_8_04.ScoreChanged += final8_ScoreChanged;
            final_8_05.ScoreChanged += final8_ScoreChanged;
            final_8_06.ScoreChanged += final8_ScoreChanged;
            final_8_07.ScoreChanged += final8_ScoreChanged;
            final_8_08.ScoreChanged += final8_ScoreChanged;
        }

        public bool StartPlayoffs8(IEnumerable<Player> players)
        {
            this.ClearPlayoffs();

            StartRound = PlayoffRound.Final_8;

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

            Final_8_01 = new Game()
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

            Final_8_02 = new Game()
            {
                Player1Alias = player08.Alias,
                Player1Id = player08.Id,
                Player1RaceCorpo = player08.RaceCorpo,
                Player1RaceRunner = player08.RaceRunner,

                Player2Alias = player09.Alias,
                Player2Id = player09.Id,
                Player2RaceCorpo = player09.RaceCorpo,
                Player2RaceRunner = player09.RaceRunner,
            };

            Final_8_03 = new Game()
            {
                Player1Alias = player04.Alias,
                Player1Id = player04.Id,
                Player1RaceCorpo = player04.RaceCorpo,
                Player1RaceRunner = player04.RaceRunner,

                Player2Alias = player13.Alias,
                Player2Id = player13.Id,
                Player2RaceCorpo = player13.RaceCorpo,
                Player2RaceRunner = player13.RaceRunner,
            };

            Final_8_04 = new Game()
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

            Final_8_05 = new Game()
            {
                Player1Alias = player02.Alias,
                Player1Id = player02.Id,
                Player1RaceCorpo = player02.RaceCorpo,
                Player1RaceRunner = player02.RaceRunner,

                Player2Alias = player15.Alias,
                Player2Id = player15.Id,
                Player2RaceCorpo = player15.RaceCorpo,
                Player2RaceRunner = player15.RaceRunner,
            };

            Final_8_06 = new Game()
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

            Final_8_07 = new Game()
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

            Final_8_08 = new Game()
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

            final_8_01.DiceSystemTop(topplayers);
            final_8_02.DiceSystemTop(topplayers);
            final_8_03.DiceSystemTop(topplayers);
            final_8_04.DiceSystemTop(topplayers);
            final_8_05.DiceSystemTop(topplayers);
            final_8_06.DiceSystemTop(topplayers);
            final_8_07.DiceSystemTop(topplayers);
            final_8_08.DiceSystemTop(topplayers);

            final_8_01.ScoreChanged += final8_ScoreChanged;
            final_8_02.ScoreChanged += final8_ScoreChanged;
            final_8_03.ScoreChanged += final8_ScoreChanged;
            final_8_04.ScoreChanged += final8_ScoreChanged;
            final_8_05.ScoreChanged += final8_ScoreChanged;
            final_8_06.ScoreChanged += final8_ScoreChanged;
            final_8_07.ScoreChanged += final8_ScoreChanged;
            final_8_08.ScoreChanged += final8_ScoreChanged;

            return true;
        }

        private void final8_ScoreChanged(object sender, EventArgs e)
        {
            if ((this.final_8_01.Player1Score1 == 0 && this.final_8_01.Player1Score2 == 0 && this.final_8_01.Player2Score1 == 0 && this.final_8_01.Player2Score2 == 0) ||
                (this.final_8_02.Player1Score1 == 0 && this.final_8_02.Player1Score2 == 0 && this.final_8_02.Player2Score1 == 0 && this.final_8_02.Player2Score2 == 0) ||
                (this.final_8_03.Player1Score1 == 0 && this.final_8_03.Player1Score2 == 0 && this.final_8_03.Player2Score1 == 0 && this.final_8_03.Player2Score2 == 0) ||
                (this.final_8_04.Player1Score1 == 0 && this.final_8_04.Player1Score2 == 0 && this.final_8_04.Player2Score1 == 0 && this.final_8_04.Player2Score2 == 0) ||
                (this.final_8_05.Player1Score1 == 0 && this.final_8_05.Player1Score2 == 0 && this.final_8_05.Player2Score1 == 0 && this.final_8_05.Player2Score2 == 0) ||
                (this.final_8_06.Player1Score1 == 0 && this.final_8_06.Player1Score2 == 0 && this.final_8_06.Player2Score1 == 0 && this.final_8_06.Player2Score2 == 0) ||
                (this.final_8_07.Player1Score1 == 0 && this.final_8_07.Player1Score2 == 0 && this.final_8_07.Player2Score1 == 0 && this.final_8_07.Player2Score2 == 0) ||
                (this.final_8_08.Player1Score1 == 0 && this.final_8_08.Player1Score2 == 0 && this.final_8_08.Player2Score1 == 0 && this.final_8_08.Player2Score2 == 0)) return;

            Final_4_01 = Game.GetNextPlayoffGame(final_8_01, final_8_02, this.topplayers);
            Final_4_02 = Game.GetNextPlayoffGame(final_8_03, final_8_04, this.topplayers);
            Final_4_03 = Game.GetNextPlayoffGame(final_8_05, final_8_06, this.topplayers);
            Final_4_04 = Game.GetNextPlayoffGame(final_8_07, final_8_08, this.topplayers);

            final_4_01.DiceSystemTop(topplayers);
            final_4_02.DiceSystemTop(topplayers);
            final_4_03.DiceSystemTop(topplayers);
            final_4_04.DiceSystemTop(topplayers);

            final_4_01.ScoreChanged += final4_ScoreChanged;
            final_4_02.ScoreChanged += final4_ScoreChanged;
            final_4_03.ScoreChanged += final4_ScoreChanged;
            final_4_04.ScoreChanged += final4_ScoreChanged;

        }

        public bool StartPlayoffs4(IEnumerable<Player> players)
        {
            this.ClearPlayoffs();

            StartRound = PlayoffRound.Final_4;

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

            Final_4_01 = new Game()
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

            Final_4_02 = new Game()
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

            Final_4_03 = new Game()
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

            Final_4_04 = new Game()
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

            final_4_01.DiceSystemTop(topplayers);
            final_4_02.DiceSystemTop(topplayers);
            final_4_03.DiceSystemTop(topplayers);
            final_4_04.DiceSystemTop(topplayers);

            final_4_01.ScoreChanged += final4_ScoreChanged;
            final_4_02.ScoreChanged += final4_ScoreChanged;
            final_4_03.ScoreChanged += final4_ScoreChanged;
            final_4_04.ScoreChanged += final4_ScoreChanged;

            return true;
        }

        private void final4_ScoreChanged(object sender, EventArgs e)
        {
            if ((this.final_4_01.Player1Score1 == 0 && this.final_4_01.Player1Score2 == 0 && this.final_4_01.Player2Score1 == 0 && this.final_4_01.Player2Score2 == 0) ||
                (this.final_4_02.Player1Score1 == 0 && this.final_4_02.Player1Score2 == 0 && this.final_4_02.Player2Score1 == 0 && this.final_4_02.Player2Score2 == 0) ||
                (this.final_4_03.Player1Score1 == 0 && this.final_4_03.Player1Score2 == 0 && this.final_4_03.Player2Score1 == 0 && this.final_4_03.Player2Score2 == 0) ||
                (this.final_4_04.Player1Score1 == 0 && this.final_4_04.Player1Score2 == 0 && this.final_4_04.Player2Score1 == 0 && this.final_4_04.Player2Score2 == 0)) return;

            Final_2_01 = Game.GetNextPlayoffGame(final_4_01, final_4_02, this.topplayers);
            Final_2_02 = Game.GetNextPlayoffGame(final_4_03, final_4_04, this.topplayers);

            final_2_01.DiceSystemTop(topplayers);
            final_2_02.DiceSystemTop(topplayers);

            final_2_01.ScoreChanged += final2_ScoreChanged;
            final_2_02.ScoreChanged += final2_ScoreChanged;
        }

        public bool StartPlayoffs2(IEnumerable<Player> players)
        {
            this.ClearPlayoffs();
            StartRound = PlayoffRound.Final_2;

            topplayers = players.Where(p => p.Active == true).OrderBy(p => p.Place).ToList();

            if (topplayers.Count() < 4) return false;

            topplayers = topplayers.Take(4);

            Player player01 = topplayers.ElementAt(0);
            Player player02 = topplayers.ElementAt(1);
            Player player03 = topplayers.ElementAt(2);
            Player player04 = topplayers.ElementAt(3);

            Final_2_01 = new Game()
            {
                Player1Alias = player01.Alias,
                Player1Id = player01.Id,
                Player1RaceCorpo = player01.RaceCorpo,
                Player1RaceRunner = player01.RaceRunner,

                Player2Alias = player04.Alias,
                Player2Id = player04.Id,
                Player2RaceCorpo = player04.RaceCorpo,
                Player2RaceRunner = player04.RaceRunner,
            };

            Final_2_02 = new Game()
            {
                Player1Alias = player02.Alias,
                Player1Id = player02.Id,
                Player1RaceCorpo = player02.RaceCorpo,
                Player1RaceRunner = player02.RaceRunner,

                Player2Alias = player03.Alias,
                Player2Id = player03.Id,
                Player2RaceCorpo = player03.RaceCorpo,
                Player2RaceRunner = player03.RaceRunner,
            };

            final_2_01.DiceSystemTop(topplayers);
            final_2_02.DiceSystemTop(topplayers);

            final_2_01.ScoreChanged += final2_ScoreChanged;
            final_2_02.ScoreChanged += final2_ScoreChanged;

            return true;
        }

        private void final2_ScoreChanged(object sender, EventArgs e)
        {
            if ((this.final_2_01.Player1Score1 == 0 && this.final_2_01.Player1Score2 == 0 && this.final_2_01.Player2Score1 == 0 && this.final_2_01.Player2Score2 == 0) ||
                (this.final_2_02.Player1Score1 == 0 && this.final_2_02.Player1Score2 == 0 && this.final_2_02.Player2Score1 == 0 && this.final_2_02.Player2Score2 == 0)) return;

            Final = Game.GetNextPlayoffGame(final_2_01, final_2_02, this.topplayers);

            Game3rdPlace = new Game();

            if (final.Player1Id == final_2_01.Player1Id)
            {
                game3rdplace.Player1Alias = final_2_01.Player2Alias;
                game3rdplace.Player1Id = final_2_01.Player2Id;
                game3rdplace.Player1RaceCorpo = final_2_01.Player2RaceCorpo;
                game3rdplace.Player1RaceRunner = final_2_01.Player2RaceRunner;
            }
            else
            {
                game3rdplace.Player1Alias = final_2_01.Player1Alias;
                game3rdplace.Player1Id = final_2_01.Player1Id;
                game3rdplace.Player1RaceCorpo = final_2_01.Player1RaceCorpo;
                game3rdplace.Player1RaceRunner = final_2_01.Player1RaceRunner;
            }

            if (final.Player2Id == final_2_02.Player1Id)
            {
                game3rdplace.Player2Alias = final_2_02.Player2Alias;
                game3rdplace.Player2Id = final_2_02.Player2Id;
                game3rdplace.Player2RaceCorpo = final_2_02.Player2RaceCorpo;
                game3rdplace.Player2RaceRunner = final_2_02.Player2RaceRunner;
            }
            else
            {
                game3rdplace.Player2Alias = final_2_02.Player1Alias;
                game3rdplace.Player2Id = final_2_02.Player1Id;
                game3rdplace.Player2RaceCorpo = final_2_02.Player1RaceCorpo;
                game3rdplace.Player2RaceRunner = final_2_02.Player1RaceRunner;
            }

            final.DiceSystemTop(topplayers);
            game3rdplace.DiceSystemTop(topplayers);

            final.ScoreChanged += final_ScoreChanged;
            game3rdplace.ScoreChanged += final_ScoreChanged;
        }

        public bool StartPlayoffsFinal(IEnumerable<Player> players)
        {
            this.ClearPlayoffs();
            StartRound = PlayoffRound.Final;

            topplayers = players.Where(p => p.Active == true).OrderBy(p => p.Place).ToList();

            if (topplayers.Count() < 4) return false;

            topplayers = topplayers.Take(4);

            Player player01 = topplayers.ElementAt(0);
            Player player02 = topplayers.ElementAt(1);
            Player player03 = topplayers.ElementAt(2);
            Player player04 = topplayers.ElementAt(3);

            Final = new Game()
            {
                Player1Alias = player01.Alias,
                Player1Id = player01.Id,
                Player1RaceCorpo = player01.RaceCorpo,
                Player1RaceRunner = player01.RaceRunner,

                Player2Alias = player02.Alias,
                Player2Id = player02.Id,
                Player2RaceCorpo = player02.RaceCorpo,
                Player2RaceRunner = player02.RaceRunner,
            };

            Game3rdPlace = new Game()
            {
                Player1Alias = player03.Alias,
                Player1Id = player03.Id,
                Player1RaceCorpo = player03.RaceCorpo,
                Player1RaceRunner = player03.RaceRunner,

                Player2Alias = player04.Alias,
                Player2Id = player04.Id,
                Player2RaceCorpo = player04.RaceCorpo,
                Player2RaceRunner = player04.RaceRunner,
            };

            final.DiceSystemTop(topplayers);
            game3rdplace.DiceSystemTop(topplayers);

            final.ScoreChanged += final_ScoreChanged;
            game3rdplace.ScoreChanged += final_ScoreChanged;

            return true;
        }

        private void final_ScoreChanged(object sender, EventArgs e)
        {
            if ((this.final.Player1Score1 == 0 && this.final.Player1Score2 == 0 && this.final.Player2Score1 == 0 && this.final.Player2Score2 == 0) ||
                (this.game3rdplace.Player1Score1 == 0 && this.game3rdplace.Player1Score2 == 0 && this.game3rdplace.Player2Score1 == 0 && this.game3rdplace.Player2Score2 == 0)) return;

            //TODO: Koniec gry
        }

        public void ClearPlayoffs()
        {
            this.startround = PlayoffRound.Final_16;
            this.topplayers = null;

            if (final_16_01 != null) final_16_01.ScoreChanged -= final16_ScoreChanged;
            if (final_16_02 != null) final_16_02.ScoreChanged -= final16_ScoreChanged;
            if (final_16_03 != null) final_16_03.ScoreChanged -= final16_ScoreChanged;
            if (final_16_04 != null) final_16_04.ScoreChanged -= final16_ScoreChanged;
            if (final_16_05 != null) final_16_05.ScoreChanged -= final16_ScoreChanged;
            if (final_16_06 != null) final_16_06.ScoreChanged -= final16_ScoreChanged;
            if (final_16_07 != null) final_16_07.ScoreChanged -= final16_ScoreChanged;
            if (final_16_08 != null) final_16_08.ScoreChanged -= final16_ScoreChanged;
            if (final_16_09 != null) final_16_09.ScoreChanged -= final16_ScoreChanged;
            if (final_16_10 != null) final_16_10.ScoreChanged -= final16_ScoreChanged;
            if (final_16_11 != null) final_16_11.ScoreChanged -= final16_ScoreChanged;
            if (final_16_12 != null) final_16_12.ScoreChanged -= final16_ScoreChanged;
            if (final_16_13 != null) final_16_13.ScoreChanged -= final16_ScoreChanged;
            if (final_16_14 != null) final_16_14.ScoreChanged -= final16_ScoreChanged;
            if (final_16_15 != null) final_16_15.ScoreChanged -= final16_ScoreChanged;
            if (final_16_16 != null) final_16_16.ScoreChanged -= final16_ScoreChanged;

            if (final_8_01 != null) final_8_01.ScoreChanged -= final8_ScoreChanged;
            if (final_8_02 != null) final_8_02.ScoreChanged -= final8_ScoreChanged;
            if (final_8_03 != null) final_8_03.ScoreChanged -= final8_ScoreChanged;
            if (final_8_04 != null) final_8_04.ScoreChanged -= final8_ScoreChanged;
            if (final_8_05 != null) final_8_05.ScoreChanged -= final8_ScoreChanged;
            if (final_8_06 != null) final_8_06.ScoreChanged -= final8_ScoreChanged;
            if (final_8_07 != null) final_8_07.ScoreChanged -= final8_ScoreChanged;
            if (final_8_08 != null) final_8_08.ScoreChanged -= final8_ScoreChanged;

            if (final_4_01 != null) final_4_01.ScoreChanged -= final4_ScoreChanged;
            if (final_4_02 != null) final_4_02.ScoreChanged -= final4_ScoreChanged;
            if (final_4_03 != null) final_4_03.ScoreChanged -= final4_ScoreChanged;
            if (final_4_04 != null) final_4_04.ScoreChanged -= final4_ScoreChanged;

            if (final_2_01 != null) final_2_01.ScoreChanged -= final2_ScoreChanged;
            if (final_2_02 != null) final_2_02.ScoreChanged -= final2_ScoreChanged;

            if (final != null) final.ScoreChanged -= final_ScoreChanged;
            if (game3rdplace != null) game3rdplace.ScoreChanged -= final_ScoreChanged;

            final_16_01 = null;
            final_16_02 = null;
            final_16_03 = null;
            final_16_04 = null;
            final_16_05 = null;
            final_16_06 = null;
            final_16_07 = null;
            final_16_08 = null;
            final_16_09 = null;
            final_16_10 = null;
            final_16_11 = null;
            final_16_12 = null;
            final_16_13 = null;
            final_16_14 = null;
            final_16_15 = null;
            final_16_16 = null;

            final_8_01 = null;
            final_8_02 = null;
            final_8_03 = null;
            final_8_04 = null;
            final_8_05 = null;
            final_8_06 = null;
            final_8_07 = null;
            final_8_08 = null;

            final_4_01 = null;
            final_4_02 = null;
            final_4_03 = null;
            final_4_04 = null;

            final_2_01 = null;
            final_2_02 = null;

            final = null;
            game3rdplace = null;

            NotifyPropertyChanged("Final_16_01");
            NotifyPropertyChanged("Final_16_02");
            NotifyPropertyChanged("Final_16_03");
            NotifyPropertyChanged("Final_16_04");
            NotifyPropertyChanged("Final_16_05");
            NotifyPropertyChanged("Final_16_06");
            NotifyPropertyChanged("Final_16_07");
            NotifyPropertyChanged("Final_16_08");
            NotifyPropertyChanged("Final_16_09");
            NotifyPropertyChanged("Final_16_10");
            NotifyPropertyChanged("Final_16_11");
            NotifyPropertyChanged("Final_16_12");
            NotifyPropertyChanged("Final_16_13");
            NotifyPropertyChanged("Final_16_14");
            NotifyPropertyChanged("Final_16_15");
            NotifyPropertyChanged("Final_16_16");

            NotifyPropertyChanged("Final_8_01");
            NotifyPropertyChanged("Final_8_02");
            NotifyPropertyChanged("Final_8_03");
            NotifyPropertyChanged("Final_8_04");
            NotifyPropertyChanged("Final_8_05");
            NotifyPropertyChanged("Final_8_06");
            NotifyPropertyChanged("Final_8_07");
            NotifyPropertyChanged("Final_8_08");

            NotifyPropertyChanged("Final_4_01");
            NotifyPropertyChanged("Final_4_02");
            NotifyPropertyChanged("Final_4_03");
            NotifyPropertyChanged("Final_4_04");

            NotifyPropertyChanged("Final_2_01");
            NotifyPropertyChanged("Final_2_02");

            NotifyPropertyChanged("Final");
            NotifyPropertyChanged("Game3rdPlace");

            NotifyPropertyChanged("StartRound");
        }

        public void RefreshEvents()
        {
            if (final_16_01 != null) final_16_01.ScoreChanged -= final16_ScoreChanged;
            if (final_16_02 != null) final_16_02.ScoreChanged -= final16_ScoreChanged;
            if (final_16_03 != null) final_16_03.ScoreChanged -= final16_ScoreChanged;
            if (final_16_04 != null) final_16_04.ScoreChanged -= final16_ScoreChanged;
            if (final_16_05 != null) final_16_05.ScoreChanged -= final16_ScoreChanged;
            if (final_16_06 != null) final_16_06.ScoreChanged -= final16_ScoreChanged;
            if (final_16_07 != null) final_16_07.ScoreChanged -= final16_ScoreChanged;
            if (final_16_08 != null) final_16_08.ScoreChanged -= final16_ScoreChanged;
            if (final_16_09 != null) final_16_09.ScoreChanged -= final16_ScoreChanged;
            if (final_16_10 != null) final_16_10.ScoreChanged -= final16_ScoreChanged;
            if (final_16_11 != null) final_16_11.ScoreChanged -= final16_ScoreChanged;
            if (final_16_12 != null) final_16_12.ScoreChanged -= final16_ScoreChanged;
            if (final_16_13 != null) final_16_13.ScoreChanged -= final16_ScoreChanged;
            if (final_16_14 != null) final_16_14.ScoreChanged -= final16_ScoreChanged;
            if (final_16_15 != null) final_16_15.ScoreChanged -= final16_ScoreChanged;
            if (final_16_16 != null) final_16_16.ScoreChanged -= final16_ScoreChanged;

            if (final_8_01 != null) final_8_01.ScoreChanged -= final8_ScoreChanged;
            if (final_8_02 != null) final_8_02.ScoreChanged -= final8_ScoreChanged;
            if (final_8_03 != null) final_8_03.ScoreChanged -= final8_ScoreChanged;
            if (final_8_04 != null) final_8_04.ScoreChanged -= final8_ScoreChanged;
            if (final_8_05 != null) final_8_05.ScoreChanged -= final8_ScoreChanged;
            if (final_8_06 != null) final_8_06.ScoreChanged -= final8_ScoreChanged;
            if (final_8_07 != null) final_8_07.ScoreChanged -= final8_ScoreChanged;
            if (final_8_08 != null) final_8_08.ScoreChanged -= final8_ScoreChanged;

            if (final_4_01 != null) final_4_01.ScoreChanged -= final4_ScoreChanged;
            if (final_4_02 != null) final_4_02.ScoreChanged -= final4_ScoreChanged;
            if (final_4_03 != null) final_4_03.ScoreChanged -= final4_ScoreChanged;
            if (final_4_04 != null) final_4_04.ScoreChanged -= final4_ScoreChanged;

            if (final_2_01 != null) final_2_01.ScoreChanged -= final2_ScoreChanged;
            if (final_2_02 != null) final_2_02.ScoreChanged -= final2_ScoreChanged;

            if (final != null) final.ScoreChanged -= final_ScoreChanged;
            if (game3rdplace != null) game3rdplace.ScoreChanged -= final_ScoreChanged;

            if (final_16_01 != null) final_16_01.ScoreChanged += final16_ScoreChanged;
            if (final_16_02 != null) final_16_02.ScoreChanged += final16_ScoreChanged;
            if (final_16_03 != null) final_16_03.ScoreChanged += final16_ScoreChanged;
            if (final_16_04 != null) final_16_04.ScoreChanged += final16_ScoreChanged;
            if (final_16_05 != null) final_16_05.ScoreChanged += final16_ScoreChanged;
            if (final_16_06 != null) final_16_06.ScoreChanged += final16_ScoreChanged;
            if (final_16_07 != null) final_16_07.ScoreChanged += final16_ScoreChanged;
            if (final_16_08 != null) final_16_08.ScoreChanged += final16_ScoreChanged;
            if (final_16_09 != null) final_16_09.ScoreChanged += final16_ScoreChanged;
            if (final_16_10 != null) final_16_10.ScoreChanged += final16_ScoreChanged;
            if (final_16_11 != null) final_16_11.ScoreChanged += final16_ScoreChanged;
            if (final_16_12 != null) final_16_12.ScoreChanged += final16_ScoreChanged;
            if (final_16_13 != null) final_16_13.ScoreChanged += final16_ScoreChanged;
            if (final_16_14 != null) final_16_14.ScoreChanged += final16_ScoreChanged;
            if (final_16_15 != null) final_16_15.ScoreChanged += final16_ScoreChanged;
            if (final_16_16 != null) final_16_16.ScoreChanged += final16_ScoreChanged;

            if (final_8_01 != null) final_8_01.ScoreChanged += final8_ScoreChanged;
            if (final_8_02 != null) final_8_02.ScoreChanged += final8_ScoreChanged;
            if (final_8_03 != null) final_8_03.ScoreChanged += final8_ScoreChanged;
            if (final_8_04 != null) final_8_04.ScoreChanged += final8_ScoreChanged;
            if (final_8_05 != null) final_8_05.ScoreChanged += final8_ScoreChanged;
            if (final_8_06 != null) final_8_06.ScoreChanged += final8_ScoreChanged;
            if (final_8_07 != null) final_8_07.ScoreChanged += final8_ScoreChanged;
            if (final_8_08 != null) final_8_08.ScoreChanged += final8_ScoreChanged;

            if (final_4_01 != null) final_4_01.ScoreChanged += final4_ScoreChanged;
            if (final_4_02 != null) final_4_02.ScoreChanged += final4_ScoreChanged;
            if (final_4_03 != null) final_4_03.ScoreChanged += final4_ScoreChanged;
            if (final_4_04 != null) final_4_04.ScoreChanged += final4_ScoreChanged;

            if (final_2_01 != null) final_2_01.ScoreChanged += final2_ScoreChanged;
            if (final_2_02 != null) final_2_02.ScoreChanged += final2_ScoreChanged;

            if (final != null) final.ScoreChanged += final_ScoreChanged;
            if (game3rdplace != null) game3rdplace.ScoreChanged += final_ScoreChanged;
        }

        public void RenamePlayer(Player playerToChange)
        {
            if (final_16_01 != null && final_16_01.Player1Id == playerToChange.Id) { final_16_01.Player1Alias = playerToChange.Alias; final_16_01.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_02 != null && final_16_02.Player1Id == playerToChange.Id) { final_16_02.Player1Alias = playerToChange.Alias; final_16_02.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_03 != null && final_16_03.Player1Id == playerToChange.Id) { final_16_03.Player1Alias = playerToChange.Alias; final_16_03.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_04 != null && final_16_04.Player1Id == playerToChange.Id) { final_16_04.Player1Alias = playerToChange.Alias; final_16_04.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_05 != null && final_16_05.Player1Id == playerToChange.Id) { final_16_05.Player1Alias = playerToChange.Alias; final_16_05.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_06 != null && final_16_06.Player1Id == playerToChange.Id) { final_16_06.Player1Alias = playerToChange.Alias; final_16_06.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_07 != null && final_16_07.Player1Id == playerToChange.Id) { final_16_07.Player1Alias = playerToChange.Alias; final_16_07.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_08 != null && final_16_08.Player1Id == playerToChange.Id) { final_16_08.Player1Alias = playerToChange.Alias; final_16_08.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_09 != null && final_16_09.Player1Id == playerToChange.Id) { final_16_09.Player1Alias = playerToChange.Alias; final_16_09.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_10 != null && final_16_10.Player1Id == playerToChange.Id) { final_16_10.Player1Alias = playerToChange.Alias; final_16_10.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_11 != null && final_16_11.Player1Id == playerToChange.Id) { final_16_11.Player1Alias = playerToChange.Alias; final_16_11.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_12 != null && final_16_12.Player1Id == playerToChange.Id) { final_16_12.Player1Alias = playerToChange.Alias; final_16_12.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_13 != null && final_16_13.Player1Id == playerToChange.Id) { final_16_13.Player1Alias = playerToChange.Alias; final_16_13.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_14 != null && final_16_14.Player1Id == playerToChange.Id) { final_16_14.Player1Alias = playerToChange.Alias; final_16_14.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_15 != null && final_16_15.Player1Id == playerToChange.Id) { final_16_15.Player1Alias = playerToChange.Alias; final_16_15.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_16 != null && final_16_16.Player1Id == playerToChange.Id) { final_16_16.Player1Alias = playerToChange.Alias; final_16_16.Player1RaceCorpo = playerToChange.RaceCorpo; }

            if (final_16_01 != null && final_16_01.Player1Id == playerToChange.Id) { final_16_01.Player1Alias = playerToChange.Alias; final_16_01.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_02 != null && final_16_02.Player1Id == playerToChange.Id) { final_16_02.Player1Alias = playerToChange.Alias; final_16_02.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_03 != null && final_16_03.Player1Id == playerToChange.Id) { final_16_03.Player1Alias = playerToChange.Alias; final_16_03.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_04 != null && final_16_04.Player1Id == playerToChange.Id) { final_16_04.Player1Alias = playerToChange.Alias; final_16_04.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_05 != null && final_16_05.Player1Id == playerToChange.Id) { final_16_05.Player1Alias = playerToChange.Alias; final_16_05.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_06 != null && final_16_06.Player1Id == playerToChange.Id) { final_16_06.Player1Alias = playerToChange.Alias; final_16_06.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_07 != null && final_16_07.Player1Id == playerToChange.Id) { final_16_07.Player1Alias = playerToChange.Alias; final_16_07.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_08 != null && final_16_08.Player1Id == playerToChange.Id) { final_16_08.Player1Alias = playerToChange.Alias; final_16_08.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_09 != null && final_16_09.Player1Id == playerToChange.Id) { final_16_09.Player1Alias = playerToChange.Alias; final_16_09.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_10 != null && final_16_10.Player1Id == playerToChange.Id) { final_16_10.Player1Alias = playerToChange.Alias; final_16_10.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_11 != null && final_16_11.Player1Id == playerToChange.Id) { final_16_11.Player1Alias = playerToChange.Alias; final_16_11.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_12 != null && final_16_12.Player1Id == playerToChange.Id) { final_16_12.Player1Alias = playerToChange.Alias; final_16_12.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_13 != null && final_16_13.Player1Id == playerToChange.Id) { final_16_13.Player1Alias = playerToChange.Alias; final_16_13.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_14 != null && final_16_14.Player1Id == playerToChange.Id) { final_16_14.Player1Alias = playerToChange.Alias; final_16_14.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_15 != null && final_16_15.Player1Id == playerToChange.Id) { final_16_15.Player1Alias = playerToChange.Alias; final_16_15.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_16_16 != null && final_16_16.Player1Id == playerToChange.Id) { final_16_16.Player1Alias = playerToChange.Alias; final_16_16.Player1RaceRunner = playerToChange.RaceRunner; }

            if (final_16_01 != null && final_16_01.Player2Id == playerToChange.Id) { final_16_01.Player2Alias = playerToChange.Alias; final_16_01.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_02 != null && final_16_02.Player2Id == playerToChange.Id) { final_16_02.Player2Alias = playerToChange.Alias; final_16_02.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_03 != null && final_16_03.Player2Id == playerToChange.Id) { final_16_03.Player2Alias = playerToChange.Alias; final_16_03.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_04 != null && final_16_04.Player2Id == playerToChange.Id) { final_16_04.Player2Alias = playerToChange.Alias; final_16_04.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_05 != null && final_16_05.Player2Id == playerToChange.Id) { final_16_05.Player2Alias = playerToChange.Alias; final_16_05.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_06 != null && final_16_06.Player2Id == playerToChange.Id) { final_16_06.Player2Alias = playerToChange.Alias; final_16_06.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_07 != null && final_16_07.Player2Id == playerToChange.Id) { final_16_07.Player2Alias = playerToChange.Alias; final_16_07.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_08 != null && final_16_08.Player2Id == playerToChange.Id) { final_16_08.Player2Alias = playerToChange.Alias; final_16_08.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_09 != null && final_16_09.Player2Id == playerToChange.Id) { final_16_09.Player2Alias = playerToChange.Alias; final_16_09.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_10 != null && final_16_10.Player2Id == playerToChange.Id) { final_16_10.Player2Alias = playerToChange.Alias; final_16_10.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_11 != null && final_16_11.Player2Id == playerToChange.Id) { final_16_11.Player2Alias = playerToChange.Alias; final_16_11.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_12 != null && final_16_12.Player2Id == playerToChange.Id) { final_16_12.Player2Alias = playerToChange.Alias; final_16_12.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_13 != null && final_16_13.Player2Id == playerToChange.Id) { final_16_13.Player2Alias = playerToChange.Alias; final_16_13.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_14 != null && final_16_14.Player2Id == playerToChange.Id) { final_16_14.Player2Alias = playerToChange.Alias; final_16_14.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_15 != null && final_16_15.Player2Id == playerToChange.Id) { final_16_15.Player2Alias = playerToChange.Alias; final_16_15.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_16_16 != null && final_16_16.Player2Id == playerToChange.Id) { final_16_16.Player2Alias = playerToChange.Alias; final_16_16.Player2RaceCorpo = playerToChange.RaceCorpo; }

            if (final_16_01 != null && final_16_01.Player2Id == playerToChange.Id) { final_16_01.Player2Alias = playerToChange.Alias; final_16_01.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_02 != null && final_16_02.Player2Id == playerToChange.Id) { final_16_02.Player2Alias = playerToChange.Alias; final_16_02.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_03 != null && final_16_03.Player2Id == playerToChange.Id) { final_16_03.Player2Alias = playerToChange.Alias; final_16_03.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_04 != null && final_16_04.Player2Id == playerToChange.Id) { final_16_04.Player2Alias = playerToChange.Alias; final_16_04.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_05 != null && final_16_05.Player2Id == playerToChange.Id) { final_16_05.Player2Alias = playerToChange.Alias; final_16_05.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_06 != null && final_16_06.Player2Id == playerToChange.Id) { final_16_06.Player2Alias = playerToChange.Alias; final_16_06.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_07 != null && final_16_07.Player2Id == playerToChange.Id) { final_16_07.Player2Alias = playerToChange.Alias; final_16_07.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_08 != null && final_16_08.Player2Id == playerToChange.Id) { final_16_08.Player2Alias = playerToChange.Alias; final_16_08.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_09 != null && final_16_09.Player2Id == playerToChange.Id) { final_16_09.Player2Alias = playerToChange.Alias; final_16_09.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_10 != null && final_16_10.Player2Id == playerToChange.Id) { final_16_10.Player2Alias = playerToChange.Alias; final_16_10.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_11 != null && final_16_11.Player2Id == playerToChange.Id) { final_16_11.Player2Alias = playerToChange.Alias; final_16_11.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_12 != null && final_16_12.Player2Id == playerToChange.Id) { final_16_12.Player2Alias = playerToChange.Alias; final_16_12.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_13 != null && final_16_13.Player2Id == playerToChange.Id) { final_16_13.Player2Alias = playerToChange.Alias; final_16_13.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_14 != null && final_16_14.Player2Id == playerToChange.Id) { final_16_14.Player2Alias = playerToChange.Alias; final_16_14.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_15 != null && final_16_15.Player2Id == playerToChange.Id) { final_16_15.Player2Alias = playerToChange.Alias; final_16_15.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_16_16 != null && final_16_16.Player2Id == playerToChange.Id) { final_16_16.Player2Alias = playerToChange.Alias; final_16_16.Player2RaceRunner = playerToChange.RaceRunner; }


            if (final_8_01 != null && final_8_01.Player1Id == playerToChange.Id) { final_8_01.Player1Alias = playerToChange.Alias; final_8_01.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_02 != null && final_8_02.Player1Id == playerToChange.Id) { final_8_02.Player1Alias = playerToChange.Alias; final_8_02.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_03 != null && final_8_03.Player1Id == playerToChange.Id) { final_8_03.Player1Alias = playerToChange.Alias; final_8_03.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_04 != null && final_8_04.Player1Id == playerToChange.Id) { final_8_04.Player1Alias = playerToChange.Alias; final_8_04.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_05 != null && final_8_05.Player1Id == playerToChange.Id) { final_8_05.Player1Alias = playerToChange.Alias; final_8_05.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_06 != null && final_8_06.Player1Id == playerToChange.Id) { final_8_06.Player1Alias = playerToChange.Alias; final_8_06.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_07 != null && final_8_07.Player1Id == playerToChange.Id) { final_8_07.Player1Alias = playerToChange.Alias; final_8_07.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_08 != null && final_8_08.Player1Id == playerToChange.Id) { final_8_08.Player1Alias = playerToChange.Alias; final_8_08.Player1RaceCorpo = playerToChange.RaceCorpo; }

            if (final_8_01 != null && final_8_01.Player1Id == playerToChange.Id) { final_8_01.Player1Alias = playerToChange.Alias; final_8_01.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_8_02 != null && final_8_02.Player1Id == playerToChange.Id) { final_8_02.Player1Alias = playerToChange.Alias; final_8_02.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_8_03 != null && final_8_03.Player1Id == playerToChange.Id) { final_8_03.Player1Alias = playerToChange.Alias; final_8_03.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_8_04 != null && final_8_04.Player1Id == playerToChange.Id) { final_8_04.Player1Alias = playerToChange.Alias; final_8_04.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_8_05 != null && final_8_05.Player1Id == playerToChange.Id) { final_8_05.Player1Alias = playerToChange.Alias; final_8_05.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_8_06 != null && final_8_06.Player1Id == playerToChange.Id) { final_8_06.Player1Alias = playerToChange.Alias; final_8_06.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_8_07 != null && final_8_07.Player1Id == playerToChange.Id) { final_8_07.Player1Alias = playerToChange.Alias; final_8_07.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_8_08 != null && final_8_08.Player1Id == playerToChange.Id) { final_8_08.Player1Alias = playerToChange.Alias; final_8_08.Player1RaceRunner = playerToChange.RaceRunner; }

            if (final_8_01 != null && final_8_01.Player2Id == playerToChange.Id) { final_8_01.Player2Alias = playerToChange.Alias; final_8_01.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_02 != null && final_8_02.Player2Id == playerToChange.Id) { final_8_02.Player2Alias = playerToChange.Alias; final_8_02.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_03 != null && final_8_03.Player2Id == playerToChange.Id) { final_8_03.Player2Alias = playerToChange.Alias; final_8_03.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_04 != null && final_8_04.Player2Id == playerToChange.Id) { final_8_04.Player2Alias = playerToChange.Alias; final_8_04.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_05 != null && final_8_05.Player2Id == playerToChange.Id) { final_8_05.Player2Alias = playerToChange.Alias; final_8_05.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_06 != null && final_8_06.Player2Id == playerToChange.Id) { final_8_06.Player2Alias = playerToChange.Alias; final_8_06.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_07 != null && final_8_07.Player2Id == playerToChange.Id) { final_8_07.Player2Alias = playerToChange.Alias; final_8_07.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_8_08 != null && final_8_08.Player2Id == playerToChange.Id) { final_8_08.Player2Alias = playerToChange.Alias; final_8_08.Player2RaceCorpo = playerToChange.RaceCorpo; }

            if (final_8_01 != null && final_8_01.Player2Id == playerToChange.Id) { final_8_01.Player2Alias = playerToChange.Alias; final_8_01.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_8_02 != null && final_8_02.Player2Id == playerToChange.Id) { final_8_02.Player2Alias = playerToChange.Alias; final_8_02.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_8_03 != null && final_8_03.Player2Id == playerToChange.Id) { final_8_03.Player2Alias = playerToChange.Alias; final_8_03.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_8_04 != null && final_8_04.Player2Id == playerToChange.Id) { final_8_04.Player2Alias = playerToChange.Alias; final_8_04.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_8_05 != null && final_8_05.Player2Id == playerToChange.Id) { final_8_05.Player2Alias = playerToChange.Alias; final_8_05.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_8_06 != null && final_8_06.Player2Id == playerToChange.Id) { final_8_06.Player2Alias = playerToChange.Alias; final_8_06.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_8_07 != null && final_8_07.Player2Id == playerToChange.Id) { final_8_07.Player2Alias = playerToChange.Alias; final_8_07.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_8_08 != null && final_8_08.Player2Id == playerToChange.Id) { final_8_08.Player2Alias = playerToChange.Alias; final_8_08.Player2RaceRunner = playerToChange.RaceRunner; }

            if (final_4_01 != null && final_4_01.Player1Id == playerToChange.Id) { final_4_01.Player1Alias = playerToChange.Alias; final_4_01.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_4_02 != null && final_4_02.Player1Id == playerToChange.Id) { final_4_02.Player1Alias = playerToChange.Alias; final_4_02.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_4_03 != null && final_4_03.Player1Id == playerToChange.Id) { final_4_03.Player1Alias = playerToChange.Alias; final_4_03.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_4_04 != null && final_4_04.Player1Id == playerToChange.Id) { final_4_04.Player1Alias = playerToChange.Alias; final_4_04.Player1RaceCorpo = playerToChange.RaceCorpo; }

            if (final_4_01 != null && final_4_01.Player1Id == playerToChange.Id) { final_4_01.Player1Alias = playerToChange.Alias; final_4_01.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_4_02 != null && final_4_02.Player1Id == playerToChange.Id) { final_4_02.Player1Alias = playerToChange.Alias; final_4_02.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_4_03 != null && final_4_03.Player1Id == playerToChange.Id) { final_4_03.Player1Alias = playerToChange.Alias; final_4_03.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_4_04 != null && final_4_04.Player1Id == playerToChange.Id) { final_4_04.Player1Alias = playerToChange.Alias; final_4_04.Player1RaceRunner = playerToChange.RaceRunner; }

            if (final_4_01 != null && final_4_01.Player2Id == playerToChange.Id) { final_4_01.Player2Alias = playerToChange.Alias; final_4_01.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_4_02 != null && final_4_02.Player2Id == playerToChange.Id) { final_4_02.Player2Alias = playerToChange.Alias; final_4_02.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_4_03 != null && final_4_03.Player2Id == playerToChange.Id) { final_4_03.Player2Alias = playerToChange.Alias; final_4_03.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_4_04 != null && final_4_04.Player2Id == playerToChange.Id) { final_4_04.Player2Alias = playerToChange.Alias; final_4_04.Player2RaceCorpo = playerToChange.RaceCorpo; }

            if (final_4_01 != null && final_4_01.Player2Id == playerToChange.Id) { final_4_01.Player2Alias = playerToChange.Alias; final_4_01.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_4_02 != null && final_4_02.Player2Id == playerToChange.Id) { final_4_02.Player2Alias = playerToChange.Alias; final_4_02.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_4_03 != null && final_4_03.Player2Id == playerToChange.Id) { final_4_03.Player2Alias = playerToChange.Alias; final_4_03.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_4_04 != null && final_4_04.Player2Id == playerToChange.Id) { final_4_04.Player2Alias = playerToChange.Alias; final_4_04.Player2RaceRunner = playerToChange.RaceRunner; }


            if (final_2_01 != null && final_2_01.Player1Id == playerToChange.Id) { final_2_01.Player1Alias = playerToChange.Alias; final_2_01.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final_2_02 != null && final_2_02.Player1Id == playerToChange.Id) { final_2_02.Player1Alias = playerToChange.Alias; final_2_02.Player1RaceCorpo = playerToChange.RaceCorpo; }

            if (final_2_01 != null && final_2_01.Player1Id == playerToChange.Id) { final_2_01.Player1Alias = playerToChange.Alias; final_2_01.Player1RaceRunner = playerToChange.RaceRunner; }
            if (final_2_02 != null && final_2_02.Player1Id == playerToChange.Id) { final_2_02.Player1Alias = playerToChange.Alias; final_2_02.Player1RaceRunner = playerToChange.RaceRunner; }

            if (final_2_01 != null && final_2_01.Player2Id == playerToChange.Id) { final_2_01.Player2Alias = playerToChange.Alias; final_2_01.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final_2_02 != null && final_2_02.Player2Id == playerToChange.Id) { final_2_02.Player2Alias = playerToChange.Alias; final_2_02.Player2RaceCorpo = playerToChange.RaceCorpo; }

            if (final_2_01 != null && final_2_01.Player2Id == playerToChange.Id) { final_2_01.Player2Alias = playerToChange.Alias; final_2_01.Player2RaceRunner = playerToChange.RaceRunner; }
            if (final_2_02 != null && final_2_02.Player2Id == playerToChange.Id) { final_2_02.Player2Alias = playerToChange.Alias; final_2_02.Player2RaceRunner = playerToChange.RaceRunner; }

            if (final != null && final.Player1Id == playerToChange.Id) { final.Player1Alias = playerToChange.Alias; final.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (final != null && final.Player1Id == playerToChange.Id) { final.Player1Alias = playerToChange.Alias; final.Player1RaceRunner = playerToChange.RaceRunner; }
            if (game3rdplace != null && game3rdplace.Player1Id == playerToChange.Id) { game3rdplace.Player1Alias = playerToChange.Alias; game3rdplace.Player1RaceCorpo = playerToChange.RaceCorpo; }
            if (game3rdplace != null && game3rdplace.Player1Id == playerToChange.Id) { game3rdplace.Player1Alias = playerToChange.Alias; game3rdplace.Player1RaceRunner = playerToChange.RaceRunner; }

            if (final != null && final.Player2Id == playerToChange.Id) { final.Player2Alias = playerToChange.Alias; final.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (final != null && final.Player2Id == playerToChange.Id) { final.Player2Alias = playerToChange.Alias; final.Player2RaceRunner = playerToChange.RaceRunner; }
            if (game3rdplace != null && game3rdplace.Player2Id == playerToChange.Id) { game3rdplace.Player2Alias = playerToChange.Alias; game3rdplace.Player2RaceCorpo = playerToChange.RaceCorpo; }
            if (game3rdplace != null && game3rdplace.Player2Id == playerToChange.Id) { game3rdplace.Player2Alias = playerToChange.Alias; game3rdplace.Player2RaceRunner = playerToChange.RaceRunner; }
        }

        public bool IsFinal16()
        {
            return final_16_01 != null &&
                   final_16_02 != null &&
                   final_16_03 != null &&
                   final_16_04 != null &&
                   final_16_05 != null &&
                   final_16_06 != null &&
                   final_16_07 != null &&
                   final_16_08 != null &&
                   final_16_09 != null &&
                   final_16_10 != null &&
                   final_16_11 != null &&
                   final_16_12 != null &&
                   final_16_13 != null &&
                   final_16_14 != null &&
                   final_16_15 != null &&
                   final_16_16 != null;
        }

        public bool IsFinal8()
        {
            return final_8_01 != null &&
                   final_8_02 != null &&
                   final_8_03 != null &&
                   final_8_04 != null &&
                   final_8_05 != null &&
                   final_8_06 != null &&
                   final_8_07 != null &&
                   final_8_08 != null;
        }

        public bool IsFinal4()
        {
            return final_4_01 != null &&
                   final_4_02 != null &&
                   final_4_03 != null &&
                   final_4_04 != null;
        }

        public bool IsFinal2()
        {
            return final_2_01 != null &&
                   final_2_02 != null;
        }

        public bool IsFinal()
        {
            return final != null;
        }

        public bool IsGame3rd()
        {
            return game3rdplace != null;
        }

        public bool IsAllScoresSet()
        {
            if (IsFinal16())
            {
                if ((this.final_16_01.Player1Score1 == 0 && this.final_16_01.Player1Score2 == 0 && this.final_16_01.Player2Score1 == 0 && this.final_16_01.Player2Score2 == 0) ||
                    (this.final_16_02.Player1Score1 == 0 && this.final_16_02.Player1Score2 == 0 && this.final_16_02.Player2Score1 == 0 && this.final_16_02.Player2Score2 == 0) ||
                    (this.final_16_03.Player1Score1 == 0 && this.final_16_03.Player1Score2 == 0 && this.final_16_03.Player2Score1 == 0 && this.final_16_03.Player2Score2 == 0) ||
                    (this.final_16_04.Player1Score1 == 0 && this.final_16_04.Player1Score2 == 0 && this.final_16_04.Player2Score1 == 0 && this.final_16_04.Player2Score2 == 0) ||
                    (this.final_16_05.Player1Score1 == 0 && this.final_16_05.Player1Score2 == 0 && this.final_16_05.Player2Score1 == 0 && this.final_16_05.Player2Score2 == 0) ||
                    (this.final_16_06.Player1Score1 == 0 && this.final_16_06.Player1Score2 == 0 && this.final_16_06.Player2Score1 == 0 && this.final_16_06.Player2Score2 == 0) ||
                    (this.final_16_07.Player1Score1 == 0 && this.final_16_07.Player1Score2 == 0 && this.final_16_07.Player2Score1 == 0 && this.final_16_07.Player2Score2 == 0) ||
                    (this.final_16_08.Player1Score1 == 0 && this.final_16_08.Player1Score2 == 0 && this.final_16_08.Player2Score1 == 0 && this.final_16_08.Player2Score2 == 0) ||
                    (this.final_16_09.Player1Score1 == 0 && this.final_16_09.Player1Score2 == 0 && this.final_16_09.Player2Score1 == 0 && this.final_16_09.Player2Score2 == 0) ||
                    (this.final_16_10.Player1Score1 == 0 && this.final_16_10.Player1Score2 == 0 && this.final_16_10.Player2Score1 == 0 && this.final_16_10.Player2Score2 == 0) ||
                    (this.final_16_11.Player1Score1 == 0 && this.final_16_11.Player1Score2 == 0 && this.final_16_11.Player2Score1 == 0 && this.final_16_11.Player2Score2 == 0) ||
                    (this.final_16_12.Player1Score1 == 0 && this.final_16_12.Player1Score2 == 0 && this.final_16_12.Player2Score1 == 0 && this.final_16_12.Player2Score2 == 0) ||
                    (this.final_16_13.Player1Score1 == 0 && this.final_16_13.Player1Score2 == 0 && this.final_16_13.Player2Score1 == 0 && this.final_16_13.Player2Score2 == 0) ||
                    (this.final_16_14.Player1Score1 == 0 && this.final_16_14.Player1Score2 == 0 && this.final_16_14.Player2Score1 == 0 && this.final_16_14.Player2Score2 == 0) ||
                    (this.final_16_15.Player1Score1 == 0 && this.final_16_15.Player1Score2 == 0 && this.final_16_15.Player2Score1 == 0 && this.final_16_15.Player2Score2 == 0) ||
                    (this.final_16_16.Player1Score1 == 0 && this.final_16_16.Player1Score2 == 0 && this.final_16_16.Player2Score1 == 0 && this.final_16_16.Player2Score2 == 0)) return false;
            }

            if (IsFinal8())
            {
                if ((this.final_8_01.Player1Score1 == 0 && this.final_8_01.Player1Score2 == 0 && this.final_8_01.Player2Score1 == 0 && this.final_8_01.Player2Score2 == 0) ||
                    (this.final_8_02.Player1Score1 == 0 && this.final_8_02.Player1Score2 == 0 && this.final_8_02.Player2Score1 == 0 && this.final_8_02.Player2Score2 == 0) ||
                    (this.final_8_03.Player1Score1 == 0 && this.final_8_03.Player1Score2 == 0 && this.final_8_03.Player2Score1 == 0 && this.final_8_03.Player2Score2 == 0) ||
                    (this.final_8_04.Player1Score1 == 0 && this.final_8_04.Player1Score2 == 0 && this.final_8_04.Player2Score1 == 0 && this.final_8_04.Player2Score2 == 0) ||
                    (this.final_8_05.Player1Score1 == 0 && this.final_8_05.Player1Score2 == 0 && this.final_8_05.Player2Score1 == 0 && this.final_8_05.Player2Score2 == 0) ||
                    (this.final_8_06.Player1Score1 == 0 && this.final_8_06.Player1Score2 == 0 && this.final_8_06.Player2Score1 == 0 && this.final_8_06.Player2Score2 == 0) ||
                    (this.final_8_07.Player1Score1 == 0 && this.final_8_07.Player1Score2 == 0 && this.final_8_07.Player2Score1 == 0 && this.final_8_07.Player2Score2 == 0) ||
                    (this.final_8_08.Player1Score1 == 0 && this.final_8_08.Player1Score2 == 0 && this.final_8_08.Player2Score1 == 0 && this.final_8_08.Player2Score2 == 0)) return false;
            }

            if (IsFinal4())
            {
                if ((this.final_4_01.Player1Score1 == 0 && this.final_4_01.Player1Score2 == 0 && this.final_4_01.Player2Score1 == 0 && this.final_4_01.Player2Score2 == 0) ||
                    (this.final_4_02.Player1Score1 == 0 && this.final_4_02.Player1Score2 == 0 && this.final_4_02.Player2Score1 == 0 && this.final_4_02.Player2Score2 == 0) ||
                    (this.final_4_03.Player1Score1 == 0 && this.final_4_03.Player1Score2 == 0 && this.final_4_03.Player2Score1 == 0 && this.final_4_03.Player2Score2 == 0) ||
                    (this.final_4_04.Player1Score1 == 0 && this.final_4_04.Player1Score2 == 0 && this.final_4_04.Player2Score1 == 0 && this.final_4_04.Player2Score2 == 0)) return false;
            }

            if (IsFinal2())
            {
                if ((this.final_2_01.Player1Score1 == 0 && this.final_2_01.Player1Score2 == 0 && this.final_2_01.Player2Score1 == 0 && this.final_2_01.Player2Score2 == 0) ||
                    (this.final_2_02.Player1Score1 == 0 && this.final_2_02.Player1Score2 == 0 && this.final_2_02.Player2Score1 == 0 && this.final_2_02.Player2Score2 == 0)) return false;
            }

            if (IsFinal())
            {
                if (this.final.Player1Score1 == 0 && this.final.Player1Score2 == 0 && this.final.Player2Score1 == 0 && this.final.Player2Score2 == 0) return false;
            }

            if (IsGame3rd())
            {
                if (this.game3rdplace.Player1Score1 == 0 && this.game3rdplace.Player1Score2 == 0 && this.game3rdplace.Player2Score1 == 0 && this.game3rdplace.Player2Score2 == 0) return false;
            }

            return true;
        }
    }
}
