using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ANRTournament.Objects
{
    public class Game : INotifyPropertyChanged
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

        private Guid player1id = Guid.Empty;
        private Guid player2id = Guid.Empty;

        private string player1alias = null;
        private string player2alias = null;

        private bool player1dice = false;
        private bool player2dice = false;

        private RaceCorpo player1racecorpo = RaceCorpo.NotSet;
        private RaceCorpo player2racecorpo = RaceCorpo.NotSet;
        private RaceRunner player1racerunner = RaceRunner.NotSet;
        private RaceRunner player2racerunner = RaceRunner.NotSet;

        private int player1score = 1;
        private int player2score = 1;

        private int player1score1 = 0;
        private int player1score2 = 0;
        private int player2score1 = 0;
        private int player2score2 = 0;

        private bool isbye = false;

        private bool issecondgamenotstarted = false;

        private int number = 0;

        public event EventHandler ScoreChanged = null;

        /// <summary>
        /// Id gracza 1
        /// </summary>
        public Guid Player1Id
        {
            get { return this.player1id; }
            set
            {
                if (value != this.player1id)
                {
                    this.player1id = value;
                    NotifyPropertyChanged("Player1Id");
                }
            }
        }

        /// <summary>
        /// Id gracza 2
        /// </summary>
        public Guid Player2Id
        {
            get { return this.player2id; }
            set
            {
                if (value != this.player2id)
                {
                    this.player2id = value;
                    NotifyPropertyChanged("Player2Id");
                }
            }
        }

        /// <summary>
        /// Zaczyna gracz 1
        /// </summary>
        public bool Player1Dice
        {
            get { return this.player1dice; }
            set
            {
                if (value != this.player1dice)
                {
                    this.player1dice = value;
                    NotifyPropertyChanged("Player1Dice");
                }
            }
        }

        /// <summary>
        /// Zaczyna gracz 2
        /// </summary>
        public bool Player2Dice
        {
            get { return this.player2dice; }
            set
            {
                if (value != this.player2dice)
                {
                    this.player2dice = value;
                    NotifyPropertyChanged("Player2Dice");
                }
            }
        }

        /// <summary>
        /// Nazwa gracza 1
        /// </summary>
        public string Player1Alias
        {
            get { return this.player1alias; }
            set
            {
                if (value != this.player1alias)
                {
                    this.player1alias = value;
                    NotifyPropertyChanged("Player1Alias");
                }
            }
        }

        /// <summary>
        /// Nazwa gracza 2
        /// </summary>
        public string Player2Alias
        {
            get { return this.player2alias; }
            set
            {
                if (value != this.player2alias)
                {
                    this.player2alias = value;
                    NotifyPropertyChanged("Player2Alias");
                }
            }
        }

        /// <summary>
        /// Rasa gracza 1
        /// </summary>
        public RaceCorpo Player1RaceCorpo
        {
            get { return this.player1racecorpo; }
            set
            {
                if (value != this.player1racecorpo)
                {
                    this.player1racecorpo = value;
                    NotifyPropertyChanged("Player1RaceCorpo");
                }
            }
        }

        /// <summary>
        /// Rasa gracza 2
        /// </summary>
        public RaceCorpo Player2RaceCorpo
        {
            get { return this.player2racecorpo; }
            set
            {
                if (value != this.player2racecorpo)
                {
                    this.player2racecorpo = value;
                    NotifyPropertyChanged("Player2RaceCorpo");
                }
            }
        }

        /// <summary>
        /// Rasa gracza 1
        /// </summary>
        public RaceRunner Player1RaceRunner
        {
            get { return this.player1racerunner; }
            set
            {
                if (value != this.player1racerunner)
                {
                    this.player1racerunner = value;
                    NotifyPropertyChanged("Player1RaceRunner");
                }
            }
        }

        /// <summary>
        /// Rasa gracza 2
        /// </summary>
        public RaceRunner Player2RaceRunner
        {
            get { return this.player2racerunner; }
            set
            {
                if (value != this.player2racerunner)
                {
                    this.player2racerunner = value;
                    NotifyPropertyChanged("Player2RaceRunner");
                }
            }
        }

        /// <summary>
        /// Duże punkty gracz 1
        /// </summary>
        public int Player1Score
        {
            get { return this.player1score; }
        }

        /// <summary>
        /// Duże punkty gracz 2
        /// </summary>
        public int Player2Score
        {
            get { return this.player2score; }
        }


        /// <summary>
        /// Małe punkty suma gracz 1
        /// </summary>
        public int Player1ScoreSum
        {
            get { return this.player1score1 + this.player1score2; }
        }

        /// <summary>
        /// Małe punkty suma gracz 2
        /// </summary>
        public int Player2ScoreSum
        {
            get { return this.player2score1 + this.player2score2; }
        }

        /// <summary>
        /// Małe punkty gracz 1 gra 1
        /// </summary>
        public int Player1Score1
        {
            get { return this.player1score1; }
            set
            {
                if (value != this.player1score1)
                {
                    this.player1score1 = value;
                    this.RefreshScores();
                    NotifyPropertyChanged("Player1Score1");
                    NotifyPropertyChanged("Player1Score");
                    NotifyPropertyChanged("Player2Score");
                    NotifyPropertyChanged("Player1ScoreSum");
                    NotifyPropertyChanged("Player2ScoreSum");
                    if (this.ScoreChanged != null) this.ScoreChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Małe punkty gracz 1 gra 2
        /// </summary>
        public int Player1Score2
        {
            get { return this.player1score2; }
            set
            {
                if (value != this.player1score2)
                {
                    this.player1score2 = value;
                    this.RefreshScores();
                    NotifyPropertyChanged("Player1Score2");
                    NotifyPropertyChanged("Player1Score");
                    NotifyPropertyChanged("Player2Score");
                    NotifyPropertyChanged("Player1ScoreSum");
                    NotifyPropertyChanged("Player2ScoreSum");
                    if (this.ScoreChanged != null) this.ScoreChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Małe punkty gracz 2 gra 1
        /// </summary>
        public int Player2Score1
        {
            get { return this.player2score1; }
            set
            {
                if (value != this.player2score1)
                {
                    this.player2score1 = value;
                    this.RefreshScores();
                    NotifyPropertyChanged("Player2Score1");
                    NotifyPropertyChanged("Player1Score");
                    NotifyPropertyChanged("Player2Score");
                    NotifyPropertyChanged("Player1ScoreSum");
                    NotifyPropertyChanged("Player2ScoreSum");
                    if (this.ScoreChanged != null) this.ScoreChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Małe punkty gracz 2 gra 2
        /// </summary>
        public int Player2Score2
        {
            get { return this.player2score2; }
            set
            {
                if (value != this.player2score2)
                {
                    this.player2score2 = value;
                    this.RefreshScores();
                    NotifyPropertyChanged("Player2Score2");
                    NotifyPropertyChanged("Player1Score");
                    NotifyPropertyChanged("Player2Score");
                    NotifyPropertyChanged("Player1ScoreSum");
                    NotifyPropertyChanged("Player2ScoreSum");
                    if (this.ScoreChanged != null) this.ScoreChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSecondGameNotStarted
        {
            get { return this.issecondgamenotstarted; }
            set
            {
                if (value != this.issecondgamenotstarted)
                {
                    this.issecondgamenotstarted = value;
                    this.RefreshScores();
                    NotifyPropertyChanged("IsSecondGameNotStarted");
                    NotifyPropertyChanged("Player1Score");
                    NotifyPropertyChanged("Player2Score");
                    NotifyPropertyChanged("Player1ScoreSum");
                    NotifyPropertyChanged("Player2ScoreSum");
                    if (this.ScoreChanged != null) this.ScoreChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Czy BYE
        /// </summary>
        public bool IsBYE
        {
            get { return this.isbye; }
            set
            {
                if (value != this.isbye)
                {
                    this.isbye = value;
                    this.RefreshScores();
                    NotifyPropertyChanged("IsBYE");
                    NotifyPropertyChanged("Player1Score");
                    NotifyPropertyChanged("Player2Score");
                    NotifyPropertyChanged("Player1Score1");
                    NotifyPropertyChanged("Player2Score1");
                    NotifyPropertyChanged("Player1Score2");
                    NotifyPropertyChanged("Player2Score2");
                    NotifyPropertyChanged("Player1ScoreSum");
                    NotifyPropertyChanged("Player2ScoreSum");
                    if (this.ScoreChanged != null) this.ScoreChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Numer stołu
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
        /// Przeliczenie punktów turniejowych
        /// </summary>
        private void RefreshScores()
        {
            player1score = 0;
            player2score = 0;

            if (this.isbye)
            {
                //BYE - 4 dużych punktów, 0 małych punktów i buholz 0
                player1score = 4;
                player2score = 0;
                player1score1 = 0;
                player1score2 = 0;
                player2score1 = 0;
                player2score2 = 0;
                return;
            }

            /*
                TODO: Nowe zasady turniejowe
 
                Zmienione tiebreakery w tabeli:
                Do tej pory było: duże punkty, suma małych punktów, buholz
                Teraz: duże punkty, ilość wygranych gier słabszą stroną, buholz
                
                Definiowanie ilości wygranych gier słabszą stroną: 
                    program w tabeli potrzebuje 2 nowe kolumny - ilość zwycięstw jako runner oraz jako korporacja. 
                    Zwycięstwo jako runner/korporacja to gra w której zdobył 10pkt grając tą stroną. 
                    Jako tiebreaker jest brana mniejsza liczba  z tych dwóch.
             */

            #region Każdą z gier ktoś wygrał (ma 10 punktów i nie było remisu 10 = 10)

            if ((this.player1score1 == 10 || this.player2score1 == 10) &&
                (this.player1score2 == 10 || this.player2score2 == 10) &&
                (this.player1score1 != this.player2score1) &&
                (this.player1score2 != this.player2score2))
            {
                //pierwsza gra
                if (this.player1score1 > this.player2score1)
                {
                    this.player1score += 2;
                }
                else
                {
                    this.player2score += 2;
                }

                //druga gra
                if (this.player1score2 > this.player2score2)
                {
                    this.player1score += 2;
                }
                else
                {
                    this.player2score += 2;
                }

                return;
            }

            #endregion

            #region Same zera (niedokończona gra 1)

            if (this.player1score1 == 0 && this.player1score2 == 0 && this.player2score1 == 0 && this.player2score2 == 0)
            {
                this.player1score = 1;
                this.player2score = 1;
                return;
            }

            #endregion

            //Najpierw sprawdzamy czy chociaż jedna się zakończyła (ktoś ma 10)
            #region Jeżeli 2 gra bardzo się przeciągnie i zostanie przerwana przez koniec czasu (pierwszą ktoś wygrał - ma 10) lub druga się nie odbyła

            if (((this.player1score1 == 10 || this.player2score1 == 10) && ((this.player1score2 >= 0 && this.player1score2 < 10) || (this.player2score2 >= 0 && this.player2score2 < 10))) ||
                ((this.player1score2 == 10 || this.player2score2 == 10) && ((this.player1score1 >= 0 && this.player1score1 < 10) || (this.player2score1 >= 0 && this.player2score1 < 10))))
            {
                if (this.player1score1 == 10 || this.player1score2 == 10)
                {
                    this.player1score += 2;
                }

                if (this.player2score1 == 10 || this.player2score2 == 10)
                {
                    this.player2score += 2;
                }

                //Jeśli któras gra jest deaktywowana to nie dodajemy punktów poniżej
                if (this.issecondgamenotstarted) return;

                //korp - runner się skończyło - a druga nie
                if ((this.player1score1 == 10 || this.player2score1 == 10) && ((this.player1score2 >= 0 && this.player1score2 < 10) || (this.player2score2 >= 0 && this.player2score2 < 10)))
                {
                    if (this.player1score2 == this.player2score2)
                    {
                        this.player1score++;
                        this.player2score++;
                    }
                    else if (this.player1score2 > this.player2score2)
                    {
                        this.player1score += 1;
                    }
                    else
                    {
                        this.player2score += 1;
                    }
                }

                //runner - korp się skończyło - a druga nie
                if (((this.player1score2 == 10 || this.player2score2 == 10) && ((this.player1score1 >= 0 && this.player1score1 < 10) || (this.player2score1 >= 0 && this.player2score1 < 10))))
                {
                    if (this.player1score1 == this.player2score1)
                    {
                        this.player1score++;
                        this.player2score++;
                    }
                    else if (this.player1score1 > this.player2score1)
                    {
                        this.player1score += 1;
                    }
                    else
                    {
                        this.player2score += 1;
                    }
                }

                return;
            }

            #endregion

            #region Jeżeli 1 gra bardzo się przeciągnie i zostanie przerwana przez koniec czasu (w małych punktach w pierwszej grze nikt nie ma 10, w drugiej jest 0-0)

            if (((this.player1score1 == 0 && this.player2score1 == 0) && ((this.player1score2 > 0 && this.player1score2 < 10) || (this.player2score2 > 0 && this.player2score2 < 10))) ||
                ((this.player1score2 == 0 && this.player2score2 == 0) && ((this.player1score1 > 0 && this.player1score1 < 10) || (this.player2score1 > 0 && this.player2score1 < 10))))
            {
                //Za nieskończoną grę (nikt nie zdobył 10pkt) do tej pory obaj gracze dostawali po 1 dużym pkt.
                //Teraz 1pkt dostaje osoba która w tej nieskończonej grze miała więcej małych punktów (obaj gracze po 1pkt jeśli zdobyli tyle samo).

                //suma małych punktów
                if (this.player1score1 + this.player1score2 == this.player2score1 + this.player2score2)
                {
                    this.player1score++;
                    this.player2score++;
                }
                else if (this.player1score1 + this.player1score2 > this.player2score1 + this.player2score2)
                {
                    this.player1score += 1;
                }
                else
                {
                    this.player2score += 1;
                }

                return;
            }

            #endregion

        }

        public Guid GetWinnerId()
        {
            if (this.player1score > this.player2score || this.IsBYE == true) return this.player1id;

            if (this.player1score < this.player2score) return this.player2id;

            return Guid.Empty;
        }

        public Guid GetLoserId()
        {
            if (this.player1score < this.player2score || this.IsBYE == true) return this.player1id;

            if (this.player1score > this.player2score) return this.player2id;

            return Guid.Empty;
        }
        
        public Guid GetPlayoffWinnerId(IEnumerable<Player> playerslist)
        {
            if (this.Player1ScoreSum > this.Player2ScoreSum || this.IsBYE == true) return this.player1id;

            if (this.Player1ScoreSum < this.Player2ScoreSum) return this.player2id;

            int player1place = Game.GetPlayerPlace(this.Player1Id, playerslist);
            int player2place = Game.GetPlayerPlace(this.Player2Id, playerslist);

            if (player1place < player2place)
            {
                return this.player1id;
            }
            else
            {
                return this.player2id;
            }
        }

        public Guid GetPlayoffLoserId(IEnumerable<Player> playerslist)
        {
            if (this.Player1ScoreSum < this.Player2ScoreSum || this.IsBYE == true) return this.player1id;

            if (this.Player1ScoreSum > this.Player2ScoreSum) return this.player2id;

            int player1place = Game.GetPlayerPlace(this.Player1Id, playerslist);
            int player2place = Game.GetPlayerPlace(this.Player2Id, playerslist);

            if (player1place > player2place)
            {
                return this.player1id;
            }
            else
            {
                return this.player2id;
            }
        }

        public void DiceSystem(Tournament tournament)
        {
            switch (App.Settings.DiceSystem)
            {
                case ANRTournament.DiceSystem.OnlyRandom:
                    if (this.player2id == Guid.Empty)
                    {
                        return;
                    }
                    else
                    {
                        this.player1dice = Tournament.RandomGenerator.Next(9999) % 2 == 1;
                        this.player2dice = !this.player1dice;

                        NotifyPropertyChanged("Player1Dice");
                        NotifyPropertyChanged("Player2Dice");
                        return;
                    }

                case ANRTournament.DiceSystem.FullEnabled:
                    if (this.player2id == Guid.Empty)
                    {
                        if (App.Settings.BYEHasDice)
                        {
                            this.player1dice = true;
                            NotifyPropertyChanged("Player1Dice");
                        }
                        return;
                    }
                    else
                    {
                        int player1dc = tournament.PointsTable.First(p => p.Id == this.player1id).DiceCount;
                        int player2dc = tournament.PointsTable.First(p => p.Id == this.player2id).DiceCount;

                        if (player1dc == player2dc)
                        {
                            //Jeśli kostka równa to losowo
                            this.player1dice = Tournament.RandomGenerator.Next(9999) % 2 == 1;
                            this.player2dice = !this.player1dice;
                        }
                        else
                        {
                            //Jeśli kostka nie jest równa zaczyna ten co ma mniejszą
                            this.player1dice = player1dc < player2dc;
                            this.player2dice = player1dc > player2dc;
                        }

                        NotifyPropertyChanged("Player1Dice");
                        NotifyPropertyChanged("Player2Dice");
                    }
                    break;

                case ANRTournament.DiceSystem.Disabled:
                default:
                    return;
            }
        }

        public void DiceSystemTop(IEnumerable<Player> topplayers)
        {
            //Jeśli system wyłączony to wyskocz
            if (App.Settings.DiceSystem == ANRTournament.DiceSystem.Disabled ||
                this.player2id == Guid.Empty) return;

            if (App.Settings.DiceSystem == ANRTournament.DiceSystem.OnlyRandom)
            {
                this.player1dice = Tournament.RandomGenerator.Next(9999) % 2 == 1;
                this.player2dice = !this.player1dice;
                NotifyPropertyChanged("Player1Dice");
                NotifyPropertyChanged("Player2Dice");
                return;
            }

            int player1dc = topplayers.First(p => p.Id == this.player1id).Place;
            int player2dc = topplayers.First(p => p.Id == this.player2id).Place;

            if (player1dc == player2dc)
            {
                //Jeśli kostka równa to losowo
                this.player1dice = Tournament.RandomGenerator.Next(9999) % 2 == 1;
                this.player2dice = !this.player1dice;
            }
            else
            {
                //Jeśli miejsce nie jest równe zaczyna ten co jest wyżej w tabeli
                this.player1dice = player1dc < player2dc;
                this.player2dice = player1dc > player2dc;
            }

            NotifyPropertyChanged("Player1Dice");
            NotifyPropertyChanged("Player2Dice");
        }

        public static Game GetNextPlayoffGame(Game game1, Game game2, IEnumerable<Player> playerslist)
        {
            Game gameToRet = new Game();

            //Rozpatrzenie pierwszej gry
            if (game1.Player1Score1 + game1.Player1Score2 > game1.Player2Score1 + game1.Player2Score2)
            {
                gameToRet.Player1Alias = game1.Player1Alias;
                gameToRet.Player1Id = game1.Player1Id;
                gameToRet.Player1RaceCorpo = game1.Player1RaceCorpo;
                gameToRet.Player1RaceRunner = game1.Player1RaceRunner;
            }
            else if (game1.Player1Score1 + game1.Player1Score2 == game1.Player2Score1 + game1.Player2Score2)
            {
                int player1place = Game.GetPlayerPlace(game1.Player1Id, playerslist);
                int player2place = Game.GetPlayerPlace(game1.Player2Id, playerslist);

                if (player1place < player2place)
                {
                    gameToRet.Player1Alias = game1.Player1Alias;
                    gameToRet.Player1Id = game1.Player1Id;
                    gameToRet.Player1RaceCorpo = game1.Player1RaceCorpo;
                    gameToRet.Player1RaceRunner = game1.Player1RaceRunner;
                }
                else
                {
                    gameToRet.Player1Alias = game1.Player2Alias;
                    gameToRet.Player1Id = game1.Player2Id;
                    gameToRet.Player1RaceCorpo = game1.Player2RaceCorpo;
                    gameToRet.Player1RaceRunner = game1.Player2RaceRunner;
                }
            }
            else
            {
                gameToRet.Player1Alias = game1.Player2Alias;
                gameToRet.Player1Id = game1.Player2Id;
                gameToRet.Player1RaceCorpo = game1.Player2RaceCorpo;
                gameToRet.Player1RaceRunner = game1.Player2RaceRunner;
            }

            //Rozpatrzenie drugiej gry
            if (game2.Player1Score1 + game2.Player1Score2 > game2.Player2Score1 + game2.Player2Score2)
            {
                gameToRet.Player2Alias = game2.Player1Alias;
                gameToRet.Player2Id = game2.Player1Id;
                gameToRet.Player2RaceCorpo = game2.Player1RaceCorpo;
                gameToRet.Player2RaceRunner = game2.Player1RaceRunner;
            }
            else if (game2.Player1Score1 + game2.Player1Score2 == game2.Player2Score1 + game2.Player2Score2)
            {
                int player1place = Game.GetPlayerPlace(game2.Player1Id, playerslist);
                int player2place = Game.GetPlayerPlace(game2.Player2Id, playerslist);

                if (player1place < player2place)
                {
                    gameToRet.Player2Alias = game2.Player1Alias;
                    gameToRet.Player2Id = game2.Player1Id;
                    gameToRet.Player2RaceCorpo = game2.Player1RaceCorpo;
                    gameToRet.Player2RaceRunner = game2.Player1RaceRunner;
                }
                else
                {
                    gameToRet.Player2Alias = game2.Player2Alias;
                    gameToRet.Player2Id = game2.Player2Id;
                    gameToRet.Player2RaceCorpo = game2.Player2RaceCorpo;
                    gameToRet.Player2RaceRunner = game2.Player2RaceRunner;
                }
            }
            else
            {
                gameToRet.Player2Alias = game2.Player2Alias;
                gameToRet.Player2Id = game2.Player2Id;
                gameToRet.Player2RaceCorpo = game2.Player2RaceCorpo;
                gameToRet.Player2RaceRunner = game2.Player2RaceRunner;
            }

            return gameToRet;
        }

        public static Game GetNextPlayoffGameWinerLoser(Game gamewinner, Game gameloser, IEnumerable<Player> playerslist)
        {
            Game gameToRet = new Game();

            //Rozpatrzenie wygranego
            if (gamewinner.Player1Score1 + gamewinner.Player1Score2 > gamewinner.Player2Score1 + gamewinner.Player2Score2)
            {
                gameToRet.Player1Alias = gamewinner.Player1Alias;
                gameToRet.Player1Id = gamewinner.Player1Id;
                gameToRet.Player1RaceCorpo = gamewinner.Player1RaceCorpo;
                gameToRet.Player1RaceRunner = gamewinner.Player1RaceRunner;
            }
            else if (gamewinner.Player1Score1 + gamewinner.Player1Score2 == gamewinner.Player2Score1 + gamewinner.Player2Score2)
            {
                int player1place = Game.GetPlayerPlace(gamewinner.Player1Id, playerslist);
                int player2place = Game.GetPlayerPlace(gamewinner.Player2Id, playerslist);

                if (player1place < player2place)
                {
                    gameToRet.Player1Alias = gamewinner.Player1Alias;
                    gameToRet.Player1Id = gamewinner.Player1Id;
                    gameToRet.Player1RaceCorpo = gamewinner.Player1RaceCorpo;
                    gameToRet.Player1RaceRunner = gamewinner.Player1RaceRunner;
                }
                else
                {
                    gameToRet.Player1Alias = gamewinner.Player2Alias;
                    gameToRet.Player1Id = gamewinner.Player2Id;
                    gameToRet.Player1RaceCorpo = gamewinner.Player2RaceCorpo;
                    gameToRet.Player1RaceRunner = gamewinner.Player2RaceRunner;
                }
            }
            else
            {
                gameToRet.Player1Alias = gamewinner.Player2Alias;
                gameToRet.Player1Id = gamewinner.Player2Id;
                gameToRet.Player1RaceCorpo = gamewinner.Player2RaceCorpo;
                gameToRet.Player1RaceRunner = gamewinner.Player2RaceRunner;
            }

            //wypełnienie przegranego
            if (gameloser.Player1Score1 + gameloser.Player1Score2 < gameloser.Player2Score1 + gameloser.Player2Score2)
            {
                gameToRet.Player2Alias = gameloser.Player1Alias;
                gameToRet.Player2Id = gameloser.Player1Id;
                gameToRet.Player2RaceCorpo = gameloser.Player1RaceCorpo;
                gameToRet.Player2RaceRunner = gameloser.Player1RaceRunner;
            }
            else if (gameloser.Player1Score1 + gameloser.Player1Score2 == gameloser.Player2Score1 + gameloser.Player2Score2)
            {
                int player1place = Game.GetPlayerPlace(gameloser.Player1Id, playerslist);
                int player2place = Game.GetPlayerPlace(gameloser.Player2Id, playerslist);

                if (player1place > player2place)
                {
                    gameToRet.Player2Alias = gameloser.Player1Alias;
                    gameToRet.Player2Id = gameloser.Player1Id;
                    gameToRet.Player2RaceCorpo = gameloser.Player1RaceCorpo;
                    gameToRet.Player2RaceRunner = gameloser.Player1RaceRunner;
                }
                else
                {
                    gameToRet.Player2Alias = gameloser.Player2Alias;
                    gameToRet.Player2Id = gameloser.Player2Id;
                    gameToRet.Player2RaceCorpo = gameloser.Player2RaceCorpo;
                    gameToRet.Player2RaceRunner = gameloser.Player2RaceRunner;
                }
            }
            else
            {
                gameToRet.Player2Alias = gameloser.Player2Alias;
                gameToRet.Player2Id = gameloser.Player2Id;
                gameToRet.Player2RaceCorpo = gameloser.Player2RaceCorpo;
                gameToRet.Player2RaceRunner = gameloser.Player2RaceRunner;
            }

            return gameToRet;
        }

        public static Game GetNextPlayoffGameLosers(Game game1, Game game2, IEnumerable<Player> playerslist)
        {
            Game gameToRet = new Game();

            //Rozpatrzenie pierwszej gry
            if (game1.Player1Score1 + game1.Player1Score2 < game1.Player2Score1 + game1.Player2Score2)
            {
                gameToRet.Player1Alias = game1.Player1Alias;
                gameToRet.Player1Id = game1.Player1Id;
                gameToRet.Player1RaceCorpo = game1.Player1RaceCorpo;
                gameToRet.Player1RaceRunner = game1.Player1RaceRunner;
            }
            else if (game1.Player1Score1 + game1.Player1Score2 == game1.Player2Score1 + game1.Player2Score2)
            {
                int player1place = Game.GetPlayerPlace(game1.Player1Id, playerslist);
                int player2place = Game.GetPlayerPlace(game1.Player2Id, playerslist);

                if (player1place > player2place)
                {
                    gameToRet.Player1Alias = game1.Player1Alias;
                    gameToRet.Player1Id = game1.Player1Id;
                    gameToRet.Player1RaceCorpo = game1.Player1RaceCorpo;
                    gameToRet.Player1RaceRunner = game1.Player1RaceRunner;
                }
                else
                {
                    gameToRet.Player1Alias = game1.Player2Alias;
                    gameToRet.Player1Id = game1.Player2Id;
                    gameToRet.Player1RaceCorpo = game1.Player2RaceCorpo;
                    gameToRet.Player1RaceRunner = game1.Player2RaceRunner;
                }
            }
            else
            {
                gameToRet.Player1Alias = game1.Player2Alias;
                gameToRet.Player1Id = game1.Player2Id;
                gameToRet.Player1RaceCorpo = game1.Player2RaceCorpo;
                gameToRet.Player1RaceRunner = game1.Player2RaceRunner;
            }

            //Rozpatrzenie drugiej gry
            if (game2.Player1Score1 + game2.Player1Score2 < game2.Player2Score1 + game2.Player2Score2)
            {
                gameToRet.Player2Alias = game2.Player1Alias;
                gameToRet.Player2Id = game2.Player1Id;
                gameToRet.Player2RaceCorpo = game2.Player1RaceCorpo;
                gameToRet.Player2RaceRunner = game2.Player1RaceRunner;
            }
            else if (game2.Player1Score1 + game2.Player1Score2 == game2.Player2Score1 + game2.Player2Score2)
            {
                int player1place = Game.GetPlayerPlace(game2.Player1Id, playerslist);
                int player2place = Game.GetPlayerPlace(game2.Player2Id, playerslist);

                if (player1place > player2place)
                {
                    gameToRet.Player2Alias = game2.Player1Alias;
                    gameToRet.Player2Id = game2.Player1Id;
                    gameToRet.Player2RaceCorpo = game2.Player1RaceCorpo;
                    gameToRet.Player2RaceRunner = game2.Player1RaceRunner;
                }
                else
                {
                    gameToRet.Player2Alias = game2.Player2Alias;
                    gameToRet.Player2Id = game2.Player2Id;
                    gameToRet.Player2RaceCorpo = game2.Player2RaceCorpo;
                    gameToRet.Player2RaceRunner = game2.Player2RaceRunner;
                }
            }
            else
            {
                gameToRet.Player2Alias = game2.Player2Alias;
                gameToRet.Player2Id = game2.Player2Id;
                gameToRet.Player2RaceCorpo = game2.Player2RaceCorpo;
                gameToRet.Player2RaceRunner = game2.Player2RaceRunner;
            }

            return gameToRet;
        }

        private static int GetPlayerPlace(Guid playerId, IEnumerable<Player> playerslist)
        {
            return playerslist.First(p => p.Id == playerId).Place;
        }
    }
}
