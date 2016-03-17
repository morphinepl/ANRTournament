using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using System.Windows;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace ANRTournament.Objects
{
    public class Tournament : INotifyPropertyChanged
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

        #region Zmienne wewnętrzne

        public static Random RandomGenerator = new Random();
        private string name = string.Empty;
        private DateTime date = new DateTime();
        private TournamentImportance importance = TournamentImportance.Local;
        private ObservableCollection<Player> pointstable = null;
        private ObservableCollection<Round> rounds = null;
        private ObservableCollection<FinalResult> finalresults = null;
        private ObservableCollection<Game> allGames = new ObservableCollection<Game>();
        private DoubleEliminationPlayoffs16 playoffs16 = new DoubleEliminationPlayoffs16();
        private DoubleEliminationPlayoffs8 playoffs8 = new DoubleEliminationPlayoffs8();

        private DoubleEliminationPlayoffRound playoffstartround = DoubleEliminationPlayoffRound.WithoutPlayoffs;

        #endregion

        #region Properties

        public DoubleEliminationPlayoffRound PlayoffStartRound
        {
            get { return this.playoffstartround; }
            set
            {
                if (value != this.playoffstartround)
                {
                    this.playoffstartround = value;
                    NotifyPropertyChanged("PlayoffStartRound");
                }
            }
        }

        public event EventHandler PlayerPlaceChanged
        {
            add
            {
                playerplacechanged += value;
                foreach (Player player in this.PointsTable)
                {
                    player.PlaceChanged += playerplacechanged;
                }
            }

            remove
            {
                playerplacechanged -= value;
                foreach (Player player in this.PointsTable)
                {
                    player.PlaceChanged -= playerplacechanged;
                }
            }
        }

        /// <summary>
        /// Nazwa turnieju
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Data
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set
            {
                if (value != this.date)
                {
                    this.date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        /// <summary>
        /// Ranga turnieju
        /// </summary>
        public TournamentImportance Importance
        {
            get { return this.importance; }
            set
            {
                if (value != this.importance)
                {
                    this.importance = value;
                    NotifyPropertyChanged("Importance");
                }
            }
        }

        /// <summary>
        /// Średni ranking graczy
        /// </summary>
        public int AveragePlayersRank
        {
            get
            {
                int avgrank = 0;
                if (this.PointsTable.Count == 0) return 0;

                foreach (Player player in this.PointsTable)
                {
                    avgrank += player.RankBeforeTournament;
                }

                return avgrank / this.PointsTable.Count;
            }
        }

        /// <summary>
        /// Tabela wyników
        /// </summary>
        public ObservableCollection<Player> PointsTable
        {
            get { return this.pointstable; }
            set
            {
                if (value != this.pointstable)
                {
                    this.pointstable = value;
                    NotifyPropertyChanged("PointsTable");
                }
            }
        }

        /// <summary>
        /// Tabela rund
        /// </summary>
        public ObservableCollection<Round> Rounds
        {
            get { return this.rounds; }
            set
            {
                if (value != this.rounds)
                {
                    this.rounds = value;
                    NotifyPropertyChanged("Runds");
                }
            }
        }

        /// <summary>
        /// Tabela wszysrkich gier
        /// </summary>
        public ObservableCollection<Game> AllGames
        {
            get { return this.allGames; }
            set
            {
                if (value != this.allGames)
                {
                    this.allGames = value;
                    NotifyPropertyChanged("AllGames");
                }
            }
        }

        /// <summary>
        /// Klasyfikacja końcowa
        /// </summary>
        public ObservableCollection<FinalResult> FinalResults
        {
            get { return this.finalresults; }
            set
            {
                if (value != this.finalresults)
                {
                    this.finalresults = value;
                    NotifyPropertyChanged("FinalResults");
                }
            }
        }

        public DoubleEliminationPlayoffs16 Playoffs16
        {
            get
            {
                return this.playoffs16;
            }

            set
            {
                if (value != this.playoffs16)
                {
                    this.playoffs16 = value;
                    NotifyPropertyChanged("Playoffs16");
                }
            }
        }

        public DoubleEliminationPlayoffs8 Playoffs8
        {
            get
            {
                return this.playoffs8;
            }

            set
            {
                if (value != this.playoffs8)
                {
                    this.playoffs8 = value;
                    NotifyPropertyChanged("Playoffs8");
                }
            }
        }

        #endregion

        public Tournament()
        {
            this.date = DateTime.Today;
            this.pointstable = new ObservableCollection<Player>();
            this.pointstable.CollectionChanged += pointstable_CollectionChanged;

            this.rounds = new ObservableCollection<Round>();
            this.rounds.CollectionChanged += rounds_CollectionChanged;

            this.finalresults = new ObservableCollection<FinalResult>();
        }

        #region Eventy wewnętrzne

        private event EventHandler playerplacechanged = null;

        private void rounds_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Round roundAdded = item as Round;
                    if (roundAdded != null)
                    {
                        foreach (Game game in roundAdded.Games)
                        {
                            game.ScoreChanged += game_ScoreChanged;
                        }
                    }
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    Round roundDeleted = item as Round;
                    if (roundDeleted != null)
                    {
                        foreach (Game game in roundDeleted.Games)
                        {
                            game.ScoreChanged -= game_ScoreChanged;
                        }
                    }
                }
            }
        }

        private void game_ScoreChanged(object sender, EventArgs e)
        {
            this.RefreshPointsTable();
        }

        private void pointstable_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("AveragePlayersRank");

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Player playerAdded = item as Player;
                    if (playerAdded != null)
                    {
                        if (this.playerplacechanged != null)
                        {
                            playerAdded.PlaceChanged += this.playerplacechanged;
                        }

                        playerAdded.PlayerDataChanged += player_PlayerDataChanged;
                    }
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    Player playerDeleted = item as Player;
                    if (playerDeleted != null)
                    {
                        if (this.playerplacechanged != null)
                        {
                            playerDeleted.PlaceChanged -= this.playerplacechanged;
                        }

                        playerDeleted.PlayerDataChanged -= this.player_PlayerDataChanged;
                    }
                }
            }
        }

        private void player_PlayerDataChanged(object sender, EventArgs e)
        {
            Player playerToChange = sender as Player;

            if (playerToChange == null) return;

            foreach (Round round in this.rounds)
            {
                foreach (Game game in round.Games)
                {
                    if (playerToChange.Id == game.Player1Id)
                    {
                        game.Player1Alias = playerToChange.Alias;
                        game.Player1RaceCorpo = playerToChange.RaceCorpo;
                        game.Player1RaceRunner = playerToChange.RaceRunner;
                    }

                    if (playerToChange.Id == game.Player2Id)
                    {
                        game.Player2Alias = playerToChange.Alias;
                        game.Player2RaceCorpo = playerToChange.RaceCorpo;
                        game.Player2RaceRunner = playerToChange.RaceRunner;
                    }
                }
            }

            foreach (Game game in this.allGames)
            {
                if (playerToChange.Id == game.Player1Id)
                {
                    game.Player1Alias = playerToChange.Alias;
                    game.Player1RaceCorpo = playerToChange.RaceCorpo;
                    game.Player1RaceRunner = playerToChange.RaceRunner;
                }

                if (playerToChange.Id == game.Player2Id)
                {
                    game.Player2Alias = playerToChange.Alias;
                    game.Player2RaceCorpo = playerToChange.RaceCorpo;
                    game.Player2RaceRunner = playerToChange.RaceRunner;
                }
            }

            if (this.playoffs16 != null) this.playoffs16.RenamePlayer(playerToChange);
            if (this.playoffs8 != null) this.playoffs8.RenamePlayer(playerToChange);
        }

        #endregion

        #region Funkcje wewnętrzne

        /// <summary>
        /// Zwraca pierwszego od końca możliwego do BYE
        /// </summary>
        /// <param name="activePlayers"></param>
        /// <returns></returns>
        private Game GetGameBYE(IEnumerable<Player> activePlayers)
        {
            if (activePlayers.Count() % 2 == 0) return null;

            foreach (Player player in activePlayers.OrderByDescending(p => p.Place))
            {
                IEnumerable<Game> games = allGames.Where(g => (g.Player1Id == player.Id && g.IsBYE == true));

                if (games.Count() > 0)
                {
                    //Opcja BYE tylko dla przegranych - jeśli ktoś nie grał nie dostaje BYE
                    if (App.Settings.BYEOnlyForLosers &&
                        this.rounds.Count > 0 &&
                        player.GamesCount == 0)
                    {
                        continue;
                    }

                    return games.ElementAt(0);
                }
            }

            return null;
        }

        /// <summary>
        /// Pobiera
        /// </summary>
        /// <param name="round"></param>
        private Round GenerateNextRound()
        {
            if (this.allGames.Count == 0) return null;

            Round roundToRet = new Round();
            roundToRet = this.GenerateAlternativeRound();

            if (roundToRet != null)
            {
                int lp = 1;
                foreach (Game game in roundToRet.Games)
                {
                    allGames.Remove(game);
                    game.Number = lp++;

                    game.DiceSystem(this);
                }
            }

            return roundToRet;
        }

        private Round GenerateAlternativeRound()
        {
            if (this.allGames.Count == 0) return null;

            IEnumerable<Player> activePlayers = null;

            if (App.Settings.RandomTieAfterPoints)
            {
                activePlayers = this.PointsTable.Where(p => p.Active == true)
                                                .OrderByDescending(p => p.Points)
                                                .ThenByDescending(p => p.LastTieBreak);
            }
            else
            {
                activePlayers = this.PointsTable.Where(p => p.Active == true)
                                                .OrderBy(p => p.Place);
            }

            Round roundToRet = new Round();
            if (!this.GetGame(activePlayers.ToList(), ref roundToRet))
                return null;
            else
                return roundToRet;
        }

        private bool GetGame(IEnumerable<Player> playersToPair, ref Round round)
        {
            //warunek stopu
            if (playersToPair == null || playersToPair.Count() == 0) return true;

            //BYE
            if (playersToPair.Count() == 1)
            {
                Player player1 = playersToPair.First();

                IEnumerable<Game> gameBYE = allGames.Where(g => g.Player1Id == player1.Id && g.Player2Id == Guid.Empty);

                if (gameBYE.Count() > 0 && !player1.SuperBYE)
                {
                    //Opcja BYE tylko dla przegranych - jeśli ktoś nie grał nie dostaje BYE
                    if (App.Settings.BYEOnlyForLosers &&
                        this.rounds.Count > 0 &&
                        player1.GamesCount == 0)
                    {
                        return false;
                    }

                    round.Games.Add(gameBYE.First());
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //Sparuj dwóch

            for (int indexPlayer1 = 0; indexPlayer1 < playersToPair.Count(); indexPlayer1++)
            {
                if (round.IsPlayerInGame(playersToPair.ElementAt(indexPlayer1).Id)) continue;

                for (int indexPlayer2 = indexPlayer1 + 1; indexPlayer2 < playersToPair.Count(); indexPlayer2++)
                {
                    if (round.IsPlayerInGame(playersToPair.ElementAt(indexPlayer2).Id)) continue;

                    Player player1 = playersToPair.ElementAt(indexPlayer1);
                    Player player2 = playersToPair.ElementAt(indexPlayer2);

                    IEnumerable<Game> gamesPlayers =
                        allGames.Where(g => ((g.Player1Id == player1.Id && g.Player2Id == player2.Id) ||
                                             (g.Player1Id == player2.Id && g.Player2Id == player1.Id)));

                    if (gamesPlayers.Count() > 0)
                    {
                        Game gameToAdd = gamesPlayers.ElementAt(0);
                        round.Games.Add(gameToAdd);

                        if (!this.GetGame(playersToPair.Where(p => p.Id != gameToAdd.Player1Id && p.Id != gameToAdd.Player2Id), ref round))
                        {
                            round.Games.Remove(gameToAdd);
                            continue;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Generuje losowo pierwszą rundę
        /// </summary>
        /// <returns></returns>
        private Round AddFirstRound()
        {
            Round roundToRet = new Round();

            SortedList<int, Player> randomList = new SortedList<int, Player>();

            //Generowanie losowo miejsc w tabeli
            foreach (Player player in this.PointsTable)
            {
                if (player.Active == false || player.SuperBYE == true) continue;

                bool added = false;
                int index = 5;

                while (!added && index > 0)
                {
                    try
                    {
                        randomList.Add(RandomGenerator.Next(9999), player);
                        added = true;
                    }
                    catch { index--; continue; }
                }
            }

            //Przydzielanie miejsc w tabeli
            int place = this.pointstable.Where(p => p.SuperBYE).Count() + 1;
            foreach (KeyValuePair<int, Player> item in randomList)
            {
                item.Value.Place = place++;
            }

            //Generowanie par graczy
            for (int i = 0; i < randomList.Count; i++, i++)
            {
                //ostatni nieparzysty
                if (i + 1 == randomList.Count)
                {
                    Player player1 = randomList.Values[i];
                    IEnumerable<Game> gamesPlayers =
                        allGames.Where(g => (g.Player1Id == player1.Id && g.IsBYE == true));

                    roundToRet.Games.Add(gamesPlayers.ElementAt(0));
                    allGames.Remove(gamesPlayers.ElementAt(0));
                }
                else
                {
                    Player player1 = randomList.Values[i];
                    Player player2 = randomList.Values[i + 1];
                    IEnumerable<Game> gamesPlayers =
                        allGames.Where(g => ((g.Player1Id == player1.Id && g.Player2Id == player2.Id) ||
                                             (g.Player1Id == player2.Id && g.Player2Id == player1.Id)));

                    if (gamesPlayers.Count() > 0)
                    {
                        roundToRet.Games.Add(gamesPlayers.ElementAt(0));
                        allGames.Remove(gamesPlayers.ElementAt(0));
                    }
                }
            }

            int lp = 1;
            foreach (Game game in roundToRet.Games)
            {
                game.Number = lp++;
                game.DiceSystem(this);
            }

            return roundToRet;
        }

        #endregion

        #region Funkcje zewnętrzne

        /// <summary>
        /// Generuje kolekcje allGames
        /// </summary>
        public void GenerateAllGames()
        {
            if (this.rounds.Count > 0) return;

            IEnumerable<Player> activePlayers = this.PointsTable.Where(p => p.Active == true);

            this.allGames.Clear();

            //utwórz kombinacje wszystkich gier między graczami
            for (int indexPlayer1 = 0; indexPlayer1 < activePlayers.Count(); indexPlayer1++)
            {
                for (int indexPlayer2 = indexPlayer1 + 1; indexPlayer2 < activePlayers.Count(); indexPlayer2++)
                {
                    Player player1 = activePlayers.ElementAt(indexPlayer1);
                    Player player2 = activePlayers.ElementAt(indexPlayer2);
                    Game game = new Game()
                    {
                        Player1Alias = player1.Alias,
                        Player1Id = player1.Id,
                        Player2Alias = player2.Alias,
                        Player2Id = player2.Id,
                        Player1RaceCorpo = player1.RaceCorpo,
                        Player1RaceRunner = player1.RaceRunner,
                        Player2RaceCorpo = player2.RaceCorpo,
                        Player2RaceRunner = player2.RaceRunner,
                    };

                    this.allGames.Add(game);
                }
            }

            //dogeneruj BYE jeśli nieparzysta liczba graczy
            //if (activePlayers.Count() % 2 == 1)
            //{
                foreach (Player player1 in activePlayers)
                {
                    Game game = new Game()
                    {
                        Player1Alias = player1.Alias,
                        Player1Id = player1.Id,
                        Player1RaceRunner = player1.RaceRunner,
                        Player1RaceCorpo = player1.RaceCorpo,
                        IsBYE = true,
                    };

                    allGames.Add(game);
                }
            //}
        }

        public void AddRound(Round round)
        {
            round.Number = this.rounds.Count + 1;
            this.rounds.Add(round);

            int lp = 1;
            foreach (Game game in round.Games)
            {
                allGames.Remove(game);
                game.Number = lp++;

                game.DiceSystem(this);
            }
        }

        /// <summary>
        /// Generowanie i dodawanie nowej rundy
        /// </summary>
        /// <returns>Dodana runda</returns>
        public Round CreateNextRound()
        {
            if (App.Settings.AutoSave)
            {
                this.AutoSave();
            }

            Round roundToAdd = null;

            if (this.Rounds.Count == 0)
            {
                this.GenerateAllGames();
                roundToAdd = this.AddFirstRound();
            }
            else
            {
                this.RefreshPointsTable();
                roundToAdd = this.GenerateNextRound();
                //roundToAdd = this.GenerateAlternativeRound();
            }

            if (roundToAdd != null)
            {
                roundToAdd.Number = this.Rounds.Count + 1;
                //this.Rounds.Add(roundToAdd);
            }

            return roundToAdd;
        }

        /// <summary>
        /// Funkcja usuwa ostatnią rundę
        /// </summary>
        public void DeleteLastRound()
        {
            if (this.Rounds.Count == 0) return;

            Round lastRound = this.Rounds[this.Rounds.Count - 1];

            foreach (Game game in lastRound.Games)
            {
                if (!game.IsBYE &&
                    !game.Player2Id.Equals(Guid.Empty))
                {
                    game.Player1Score1 = 0;
                    game.Player1Score2 = 0;
                    game.Player2Score1 = 0;
                    game.Player2Score2 = 0;
                }

                this.allGames.Add(game);
            }

            this.Rounds.Remove(lastRound);
            this.RefreshPointsTable();
        }

        /// <summary>
        /// Funkcja sprawdza czy w ostatniej rundzie zostały wypełnione wszystkie wyniki
        /// </summary>
        /// <returns></returns>
        public bool IsLastRoundEnded()
        {
            if (this.Rounds.Count == 0) return true;

            Round lastRound = this.Rounds[this.Rounds.Count - 1];

            if (lastRound.Games.Count == 0) return false;

            foreach (Game game in lastRound.Games)
            {
                if (game.Player1Score == game.Player2Score && game.Player2Score == 0) return false;
            }

            return true;
        }

        public void CreatePlayoffsDoubleElimination(DoubleEliminationPlayoffRound startround)
        {
            switch (startround)
            {
                case DoubleEliminationPlayoffRound.Top16:
                    this.playoffs16.StartPlayoffsTop16(this.PointsTable);
                    this.PlayoffStartRound = DoubleEliminationPlayoffRound.Top16;
                    break;

                case DoubleEliminationPlayoffRound.Top8:
                    this.playoffs8.StartPlayoffsTop8(this.PointsTable);
                    this.PlayoffStartRound = DoubleEliminationPlayoffRound.Top8;
                    break;

                default:
                    break;
            }
        }

        public void RemovePlayer(Player playerToDel)
        {
            if (this.Rounds.Count == 0)
            {
                this.PointsTable.Remove(playerToDel);
                this.RefreshPointsTable();
            }
            else
            {
                playerToDel.Active = false;
            }

            //Usunięcie gier playera
            List<Game> gamesToDel = this.allGames.Where(g => g.Player1Id == playerToDel.Id || g.Player2Id == playerToDel.Id).ToList();
            foreach (Game game in gamesToDel)
            {
                this.allGames.Remove(game);
            }

            IEnumerable<Player> activePlayers = this.PointsTable.Where(p => p.Active == true);
            if (activePlayers.Count() % 2 == 0)
            {
                //usuń BYE bo już jest parzysta liczba graczy
                List<Game> byesToDel = this.allGames.Where(g => g.Player2Id == Guid.Empty && g.IsBYE == true).ToList();

                foreach (Game game in byesToDel)
                {
                    this.allGames.Remove(game);
                }
            }
            else
            {
                //dodaj bye bo nieparzysta liczba
                foreach (Player player1 in activePlayers)
                {
                    if (this.Rounds.Where(r => r.Games.Where(g => g.Player1Id == player1.Id && g.Player2Id == Guid.Empty && g.IsBYE == true).Count() > 0).Count() > 0) continue;

                    Game game = new Game()
                    {
                        Player1Alias = player1.Alias,
                        Player1Id = player1.Id,
                        Player1RaceCorpo = player1.RaceCorpo,
                        Player1RaceRunner = player1.RaceRunner,
                        IsBYE = true,
                    };

                    allGames.Add(game);
                }
            }
        }

        public void AddPlayer(Player playerToAdd)
        {
            IEnumerable<Player> activePlayers = this.PointsTable.Where(p => p.Active == true);

            //utwórz kombinacje wszystkich gier między graczem dodawanym a innymi
            for (int indexPlayer1 = 0; indexPlayer1 < activePlayers.Count(); indexPlayer1++)
            {
                Player player1 = activePlayers.ElementAt(indexPlayer1);
                Game game = new Game()
                {
                    Player1Alias = player1.Alias,
                    Player1Id = player1.Id,
                    Player2Alias = playerToAdd.Alias,
                    Player2Id = playerToAdd.Id,
                    Player1RaceCorpo = player1.RaceCorpo,
                    Player1RaceRunner = player1.RaceRunner,
                    Player2RaceCorpo = playerToAdd.RaceCorpo,
                    Player2RaceRunner = playerToAdd.RaceRunner,
                };

                this.allGames.Add(game);
            }

            this.PointsTable.Add(playerToAdd);

            //dogeneruj BYE jeśli nieparzysta liczba graczy
            if (activePlayers.Count() % 2 == 1)
            {
                //Dla wszystkich
                foreach (Player player1 in activePlayers)
                {
                    Game game = new Game()
                    {
                        Player1Alias = player1.Alias,
                        Player1Id = player1.Id,
                        Player1RaceCorpo = player1.RaceCorpo,
                        Player1RaceRunner = player1.RaceRunner,
                        IsBYE = true,
                    };

                    allGames.Add(game);
                }

                //Game gameBYE = new Game()
                //{
                //    Player1Alias = playerToAdd.Alias,
                //    Player1Id = playerToAdd.Id,
                //    Player1Race = playerToAdd.Race,
                //    Score = GameScore.Score_BYE,
                //};

                //allGames.Add(gameBYE);
            }
            else
            {
                //usuń BYE bo już jest parzysta liczba graczy
                List<Game> gamesToDel = this.allGames.Where(g => g.Player2Id == Guid.Empty && g.IsBYE == true).ToList();

                foreach (Game game in gamesToDel)
                {
                    this.allGames.Remove(game);
                }
            }

            if (Rounds.Count > 0)
            {
                bool addToLastRound = playerToAdd.AddPlayerToLastRound;
                if (addToLastRound)
                {
                    ObservableCollection<Round> activeRounds = Rounds;
                    Round lastRound = activeRounds[activeRounds.Count - 1];
                    Game lastGame = lastRound.Games[lastRound.Games.Count - 1];
                    if (lastGame.IsBYE)
                    {
                        lastGame.IsBYE = false;
                        lastGame.Player2Alias = playerToAdd.Alias;
                        lastGame.Player2Id = playerToAdd.Id;
                        lastGame.Player2RaceCorpo = playerToAdd.RaceCorpo;
                        lastGame.Player2RaceRunner = playerToAdd.RaceRunner;
                    }
                    else
                    {
                        Game game = new Game()
                        {
                            Player1Alias = playerToAdd.Alias,
                            Player1Id = playerToAdd.Id,
                            Player1RaceCorpo = playerToAdd.RaceCorpo,
                            Player1RaceRunner = playerToAdd.RaceRunner,
                            IsBYE = true,
                            Number = lastGame.Number + 1,
                        };
                        lastRound.Games.Add(game);
                    }

                }
            }
        }

        public void ActivatePlayer(Player playerToActivate)
        {
            playerToActivate.Active = true;

            IEnumerable<Player> activePlayers = this.PointsTable.Where(p => p.Active == true);

            //utwórz kombinacje wszystkich gier między graczem aktywowanym a innymi
            for (int indexPlayer1 = 0; indexPlayer1 < activePlayers.Count(); indexPlayer1++)
            {
                Player player1 = activePlayers.ElementAt(indexPlayer1);

                if (this.Rounds.Where(r => r.Games.Where(g => (g.Player1Id == player1.Id &&
                                                               g.Player2Id == playerToActivate.Id) ||
                                                              (g.Player2Id == player1.Id &&
                                                               g.Player1Id == playerToActivate.Id)).Count() > 0).Count() > 0) continue;

                Game game = new Game()
                {
                    Player1Alias = player1.Alias,
                    Player1Id = player1.Id,
                    Player2Alias = playerToActivate.Alias,
                    Player2Id = playerToActivate.Id,
                    Player1RaceCorpo = player1.RaceCorpo,
                    Player1RaceRunner = player1.RaceRunner,
                    Player2RaceCorpo = playerToActivate.RaceCorpo,
                    Player2RaceRunner = playerToActivate.RaceRunner,
                };

                this.allGames.Add(game);
            }

            //dogeneruj BYE jeśli nieparzysta liczba graczy
            if (activePlayers.Count() % 2 == 1)
            {
                foreach (Player player1 in activePlayers)
                {
                    if (this.Rounds.Where(r => r.Games.Where(g => g.Player1Id == player1.Id &&
                                                                  g.Player2Id == Guid.Empty &&
                                                                  g.IsBYE == true).Count() > 0).Count() > 0) continue;

                    Game game = new Game()
                    {
                        Player1Alias = player1.Alias,
                        Player1Id = player1.Id,
                        Player1RaceCorpo = player1.RaceCorpo,
                        Player1RaceRunner = player1.RaceRunner,
                        IsBYE = true,
                    };

                    allGames.Add(game);
                }
            }
            else
            {
                //usuń BYE bo już jest parzysta liczba graczy
                List<Game> gamesToDel = this.allGames.Where(g => g.Player2Id == Guid.Empty && g.IsBYE == true).ToList();

                foreach (Game game in gamesToDel)
                {
                    this.allGames.Remove(game);
                }
            }
        }

        public void DisqualifyPlayer(Player playerToDisqualify)
        {
            foreach (Round round in this.rounds)
            {
                foreach (Game game in round.Games)
                {
                    if (game.Player1Id == playerToDisqualify.Id) { game.Player1Score1 = 0; game.Player2Score1 = 10; game.Player1Score2 = 0; game.Player2Score2 = 10; }
                    if (game.Player2Id == playerToDisqualify.Id) { game.Player1Score1 = 10; game.Player2Score1 = 0; game.Player1Score2 = 10; game.Player2Score2 = 0; }
                }
            }

            this.RemovePlayer(playerToDisqualify);
            this.RefreshPointsTable();
        }

        public void ClearPlayoffs()
        {
            this.playoffs16.ClearPlayoffs();
            this.playoffs8.ClearPlayoffs();
            this.PlayoffStartRound = DoubleEliminationPlayoffRound.WithoutPlayoffs;
        }

        /// <summary>
        /// Przeliczanie na nowo tabeli wyników
        /// </summary>
        public void RefreshPointsTable()
        {
            Dictionary<Guid, List<Guid>> playersOponents = new Dictionary<Guid, List<Guid>>();

            #region Przeliczenie punktów

            foreach (Player player in this.pointstable)
            {
                int gameswin = 0;
                int gamesdraw = 0;
                int gameslost = 0;
                int points = 0;
                int smallpointsplus = 0;
                int smallpointsminus = 0;
                int dicecount = 0;
                int runnerwins = 0;
                int corpowins = 0;

                if (player.SuperBYE)
                {
                    points += 4;
                    gameswin++;
                    smallpointsplus += 20;
                    runnerwins++;
                    corpowins++;
                }

                List<Guid> oponentList = new List<Guid>();

                foreach (Round round in this.rounds)
                {
                    foreach (Game game in round.Games)
                    {
                        if (game.Player1Id.Equals(player.Id))
                        {
                            #region Scoring Player 1

                            if (game.Player1Score > game.Player2Score)
                                gameswin++;
                            else if (game.Player1Score == game.Player2Score)
                                gamesdraw++;
                            else
                                gameslost++;

                            smallpointsplus += game.Player1Score1 + game.Player1Score2;
                            smallpointsminus += game.Player2Score1 + game.Player2Score2;
                            points += game.Player1Score;

                            if (game.Player1Score1 > game.Player2Score1) corpowins++;
                            if (game.Player1Score2 > game.Player2Score2) runnerwins++;

                            //if (game.Player1Score1 == 10 && game.Player1Score2 < 10 && game.Player1Score2 > game.Player2Score2) runnerwins++;
                            //if (game.Player1Score2 == 10 && game.Player1Score1 < 10 && game.Player1Score1 > game.Player2Score1) corpowins++;

                            #endregion

                            if (game.Player1Dice) dicecount++;

                            oponentList.Add(game.Player2Id);
                        }
                        else if (game.Player2Id.Equals(player.Id))
                        {
                            #region Scoring Player 2

                            if (game.Player1Score < game.Player2Score)
                                gameswin++;
                            else if (game.Player1Score == game.Player2Score)
                                gamesdraw++;
                            else
                                gameslost++;

                            smallpointsminus += game.Player1Score1 + game.Player1Score2;
                            smallpointsplus += game.Player2Score1 + game.Player2Score2;
                            points += game.Player2Score;

                            if (game.Player2Score2 > game.Player1Score2) corpowins++;
                            if (game.Player2Score1 > game.Player1Score1) runnerwins++;

                            //if (game.Player2Score2 == 10 && game.Player2Score1 < 10 && game.Player2Score1 > game.Player1Score1) runnerwins++;
                            //if (game.Player2Score1 == 10 && game.Player2Score2 < 10 && game.Player2Score2 > game.Player1Score2) corpowins++;

                            #endregion

                            if (game.Player2Dice) dicecount++;

                            oponentList.Add(game.Player1Id);
                        }
                    }
                }

                player.GamesDraw = gamesdraw;
                player.GamesLoose = gameslost;
                player.GamesWin = gameswin;
                player.SmallPointsMinus = smallpointsminus;
                player.SmallPointsPlus = smallpointsplus;
                player.DiceCount = dicecount;
                player.Points = points;
                player.CorpoWins = corpowins;
                player.RunnerWins = runnerwins;

                playersOponents.Add(player.Id, oponentList);
            }

            #endregion

            #region Przydzielanie miejsc w tabeli

            //przeliczenie współczynników przeciwników
            foreach (KeyValuePair<Guid, List<Guid>> item in playersOponents)
            {
                Player player = this.pointstable.Where(p => p.Id == item.Key).First();


                //     player.Bucholz = 0;
                //    player.MBucholz = 0;
                player.Sos = 0.0m;


    //            if (player.SuperBYE && this.rounds.Count > 0)
     //           {
     //               player.Bucholz += (this.rounds.Count - 1) * 4;
    //            }

                //             List<int> minmax = new List<int>();

                int numberOfOponents = 0;
                decimal sosPartsSum = 0.0m;
                
                foreach (Guid oponentId in item.Value)
                {
                    if (oponentId == Guid.Empty)
                    {
                        //        minmax.Add(0);
                        continue;
                    }
                    numberOfOponents++;
                    //int points = this.pointstable.Where(p => p.Id == oponentId).First().Points;
                    //                  minmax.Add(points);
                    //                  player.Bucholz += points;

                    int points = this.pointstable.Where(p => p.Id == oponentId).First().Points;
                    string name = this.pointstable.Where(p => p.Id == oponentId).First().Alias;
                    Console.WriteLine(name);
                    int gamesCount = this.pointstable.Where(p => p.Id == oponentId).First().GamesCount;
                    decimal sosPart = Decimal.Divide(points, gamesCount);
                    sosPartsSum += sosPart;
              
                   
                }
                if (numberOfOponents != 0)
                {
                    player.Sos = Decimal.Round(Decimal.Divide(sosPartsSum,numberOfOponents), 2);
                    

                }


   //             if (minmax.Count > 2)
   //             {
  //                  if (player.SuperBYE) player.MBucholz = player.Bucholz - minmax.Min(); // bo super bye jest maxem
  //                  else player.MBucholz = player.Bucholz - minmax.Max() - minmax.Min();
  //              }
            }
            foreach (KeyValuePair<Guid, List<Guid>> item in playersOponents)
            {
                Player player = this.pointstable.Where(p => p.Id == item.Key).First();
                decimal extSosPartsSum = 0.0m;
                int numberOfOponents = 0;
                foreach (Guid oponentId in item.Value)
                {
                    if (oponentId == Guid.Empty)
                    {
                        //        minmax.Add(0);
                        continue;
                    }
                    numberOfOponents++;
                    extSosPartsSum += this.pointstable.Where(p => p.Id == oponentId).First().Sos;
                }
                if (numberOfOponents != 0)
                {
                    player.Extsos = Decimal.Round(Decimal.Divide(extSosPartsSum, numberOfOponents), 2);

                }
            }
                //przeliczenie miejsc z uwzględnieniem przeciwników
                IEnumerable<Player> sortedplayers = this.pointstable.OrderByDescending(p => p.Points)
                //.ThenByDescending(p => p.MBucholz)
                //.ThenByDescending(p => p.CorpoRunnerTieBreak)
                //.ThenByDescending(p => p.Bucholz)
                 //.ThenByDescending(p => p.Bucholz)
                                                                .ThenByDescending(p => p.Sos)
                //.ThenByDescending(p => p.SmallPointsPlus)
                //.ThenByDescending(p => (p.SmallPointsPlus - p.SmallPointsMinus))
                                                                .ThenByDescending(p => p.LastTieBreak);

            int place = 1;
            foreach (Player player in sortedplayers)
            {
                player.Place = place++;
            }

            #endregion
        }

        public void RefreshFinalResults()
        {
            this.finalresults.Clear();

            if (!this.IsLastRoundEnded() ||
                (this.PlayoffStartRound == DoubleEliminationPlayoffRound.Top16 && !this.playoffs16.IsAllScoresSet()) ||
                (this.PlayoffStartRound == DoubleEliminationPlayoffRound.Top8 && !this.playoffs8.IsAllScoresSet()))
            {
                new PMW(Resources.StringTable.Tournament_ErrorPoints);
                return;
            }

            #region TOP16

            if (this.PlayoffStartRound == DoubleEliminationPlayoffRound.Top16)
            {
                try
                {
                    Player winner = null;
                    Player loser = null;
                    List<Player> losers = new List<Player>();

                    //30 i 31
                    if (this.playoffs16.Final_31 != null)
                    {
                        winner = this.pointstable.First(p => p.Id == this.playoffs16.Final_31.GetPlayoffWinnerId(this.PointsTable));
                        loser = this.pointstable.First(p => p.Id == this.playoffs16.Final_31.GetPlayoffLoserId(this.PointsTable));

                        this.finalresults.Add(new FinalResult() { FinalPlace = 1, Player = winner });
                        this.finalresults.Add(new FinalResult() { FinalPlace = 2, Player = loser });
                    }
                    else
                    {
                        winner = this.pointstable.First(p => p.Id == this.playoffs16.Final_30.GetPlayoffWinnerId(this.PointsTable));
                        loser = this.pointstable.First(p => p.Id == this.playoffs16.Final_30.GetPlayoffLoserId(this.PointsTable));

                        this.finalresults.Add(new FinalResult() { FinalPlace = 1, Player = winner });
                        this.finalresults.Add(new FinalResult() { FinalPlace = 2, Player = loser });
                    }

                    int lp = 3;
                    //29
                    loser = this.pointstable.First(p => p.Id == this.playoffs16.Final_29.GetPlayoffLoserId(this.PointsTable));
                    this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = loser });

                    //28
                    loser = this.pointstable.First(p => p.Id == this.playoffs16.Final_28.GetPlayoffLoserId(this.PointsTable));
                    this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = loser });

                    //25, 26
                    losers.Clear();
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_25.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_26.GetPlayoffLoserId(this.PointsTable)));
                    foreach (Player player in losers.OrderBy(p => p.Place))
                    {
                        this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = player });
                    }

                    //23, 24
                    losers.Clear();
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_23.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_24.GetPlayoffLoserId(this.PointsTable)));
                    foreach (Player player in losers.OrderBy(p => p.Place))
                    {
                        this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = player });
                    }

                    //17, 18, 19, 20
                    losers.Clear();
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_17.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_18.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_19.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_20.GetPlayoffLoserId(this.PointsTable)));
                    foreach (Player player in losers.OrderBy(p => p.Place))
                    {
                        this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = player });
                    }

                    //09, 10, 11, 12
                    losers.Clear();
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_09.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_10.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_11.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs16.Final_12.GetPlayoffLoserId(this.PointsTable)));
                    foreach (Player player in losers.OrderBy(p => p.Place))
                    {
                        this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = player });
                    }
                }
                catch (Exception)
                {
                    new PME(Resources.StringTable.Tournament_ErrorGen);
                    return;
                }
            }

            #endregion

            #region TOP8

            if (this.PlayoffStartRound == DoubleEliminationPlayoffRound.Top8)
            {
                try
                {
                    Player winner = null;
                    Player loser = null;
                    List<Player> losers = new List<Player>();

                    //15 i 14
                    if (this.playoffs8.Final_15 != null)
                    {
                        winner = this.pointstable.First(p => p.Id == this.playoffs8.Final_15.GetPlayoffWinnerId(this.PointsTable));
                        loser = this.pointstable.First(p => p.Id == this.playoffs8.Final_15.GetPlayoffLoserId(this.PointsTable));

                        this.finalresults.Add(new FinalResult() { FinalPlace = 1, Player = winner });
                        this.finalresults.Add(new FinalResult() { FinalPlace = 2, Player = loser });
                    }
                    else
                    {
                        winner = this.pointstable.First(p => p.Id == this.playoffs8.Final_14.GetPlayoffWinnerId(this.PointsTable));
                        loser = this.pointstable.First(p => p.Id == this.playoffs8.Final_14.GetPlayoffLoserId(this.PointsTable));

                        this.finalresults.Add(new FinalResult() { FinalPlace = 1, Player = winner });
                        this.finalresults.Add(new FinalResult() { FinalPlace = 2, Player = loser });
                    }

                    int lp = 3;
                    //13
                    loser = this.pointstable.First(p => p.Id == this.playoffs8.Final_13.GetPlayoffLoserId(this.PointsTable));
                    this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = loser });

                    //12
                    loser = this.pointstable.First(p => p.Id == this.playoffs8.Final_12.GetPlayoffLoserId(this.PointsTable));
                    this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = loser });

                    //10, 11
                    losers.Clear();
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs8.Final_10.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs8.Final_11.GetPlayoffLoserId(this.PointsTable)));
                    foreach (Player player in losers.OrderBy(p => p.Place))
                    {
                        this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = player });
                    }

                    //07, 08
                    losers.Clear();
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs8.Final_07.GetPlayoffLoserId(this.PointsTable)));
                    losers.Add(this.pointstable.First(p => p.Id == this.playoffs8.Final_08.GetPlayoffLoserId(this.PointsTable)));
                    foreach (Player player in losers.OrderBy(p => p.Place))
                    {
                        this.finalresults.Add(new FinalResult() { FinalPlace = lp++, Player = player });
                    }
                }
                catch (Exception)
                {
                    new PME(Resources.StringTable.Tournament_ErrorGen);
                    return;
                }
            }

            #endregion

            //wpis reszty tabeli
            int place = this.finalresults.Count + 1;
            foreach (Player player in this.pointstable.OrderBy(p => p.Place))
            {
                if (this.finalresults.Where(f => f.Player.Id == player.Id).Count() > 0) continue;
                this.finalresults.Add(new FinalResult()
                {
                    FinalPlace = place++,
                    Player = player
                });
            }
        }

        #endregion

        #region Save/Load

        /// <summary>
        /// Zapis obiektu do pliku
        /// </summary>
        /// <param name="tournament"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Save(Tournament tournament, string path)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(tournament.GetType());
                TextWriter textWriter = new StreamWriter(path);
                serializer.Serialize(textWriter, tournament);
                textWriter.Close();
            }
            catch (Exception ex)
            {
                new PME(String.Format(Resources.StringTable.Tournament_ErrorSaveTournament, path, ex.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Odczyt obiektu z pliku
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Tournament Load(string path)
        {
            Tournament tournament = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Tournament));
                TextReader textReader = new StreamReader(path);
                tournament = (Tournament)deserializer.Deserialize(textReader);
                textReader.Close();

                if (tournament.Playoffs16 != null) tournament.Playoffs16.RefreshEvents(tournament.PointsTable);
                if (tournament.Playoffs8 != null) tournament.Playoffs8.RefreshEvents(tournament.PointsTable);

                foreach (FinalResult result in tournament.FinalResults)
                {
                    result.Player = tournament.PointsTable.Where(p => p.Id == result.Player.Id).First();
                }
            }
            catch (Exception ex)
            {
                new PME(String.Format(Resources.StringTable.Tournament_ErrorOpenTournament, path, ex.Message));
                return null;
            }

            return tournament;
        }

        public static bool SavePlayers(Tournament tournament, string filepath)
        {
            List<Player> playersList = tournament.PointsTable.Where(p => p.Active == true).ToList();

            try
            {
                XmlSerializer serializer = new XmlSerializer(playersList.GetType());
                TextWriter textWriter = new StreamWriter(filepath);
                serializer.Serialize(textWriter, playersList);
                textWriter.Close();
            }
            catch (Exception ex)
            {
                new PME(String.Format(Resources.StringTable.Tournament_ErrorSavePlayers, filepath, ex.Message));
                return false;
            }

            return true;
        }

        public static List<Player> LoadPlayers(string filepath)
        {
            List<Player> playersList = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Player>));
                TextReader textReader = new StreamReader(filepath);
                playersList = (List<Player>)deserializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception ex)
            {
                new PME(String.Format(Resources.StringTable.Tournament_ErrorOpenPlayers, filepath, ex.Message));
                return null;
            }

            return playersList;
        }

        #endregion

        private bool AutoSave()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "AutoSaves");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, string.Format("{0}_Round_{1}.ant", DateTime.Now.ToString("yyyyMMdd_HHmmss"), this.rounds.Count));

            if (!Tournament.Save(this, path)) return false;

            return true;
        }

        #region Export GALAKTA

        private static int GetGALAKTAPlayerId(Guid idplayer, Tournament tournament)
        {
            int idRet = 0;

            if (tournament.PointsTable.Count(p => p.Id == idplayer) > 0)
            {
                return tournament.PointsTable.First(p => p.Id == idplayer).IdGalakta;
            }

            return idRet;
        }

        public void ExportToGalakta(string path)
        {
            XElement elem =
                new XElement("Tournament",
                    new XElement("Players",
                        from players in this.PointsTable
                        select new XElement("Player",
                                   new XElement("PlayerId", players.IdGalakta),
                                   new XElement("PlayerIdentityCorpo", players.CorpoIdentity),
                                   new XElement("PlayerIdentityRunner", players.RunnerIdentity),
                                   new XElement("PlayerAlias", players.Alias),
                                   new XElement("PlayerName", players.Name),
                                   new XElement("PlayerSurname", players.Surname))),

                    new XElement("Rounds",
                        from rounds in this.Rounds
                        select new XElement("Round",
                                   new XElement("Number", rounds.Number),
                                   new XElement("Games",
                                       from games in rounds.Games
                                       select new XElement("Game",
                                                  new XElement("Player1Id", GetGALAKTAPlayerId(games.Player1Id, this)),
                                                  new XElement("Player2Id", GetGALAKTAPlayerId(games.Player2Id, this)),
                                                  new XElement("Player1Score", games.Player1Score),
                                                  new XElement("Player2Score", games.Player2Score),
                                                  new XElement("Player1Score1", games.Player1Score1),
                                                  new XElement("Player1Score2", games.Player1Score2),
                                                  new XElement("Player2Score1", games.Player2Score1),
                                                  new XElement("Player2Score2", games.Player2Score2),
                                                  new XElement("BYE", games.IsBYE ? "1" : "0"),
                                                  new XElement("IsSecondGameNotStarted", games.IsSecondGameNotStarted ? "1" : "0")
                                                  )))),

                    this.GetPlayoffsXElement());

            elem.Save(path);
        }

        private XElement GetPlayoffsXElement()
        {
            //if (this.playoffs == null) return null;

            XElement eRet = new XElement("Playoffs");

            //if (this.playoffs.IsFinal16())
            //{
            //    eRet.Add(new XElement("Round",
            //                 new XElement("Type", "A"),
            //                 new XElement("Games",
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_01.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_01.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_01.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_01.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_01.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_01.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_01.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_01.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_02.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_02.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_02.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_02.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_02.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_02.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_02.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_02.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_03.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_03.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_03.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_03.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_03.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_03.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_03.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_03.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_04.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_04.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_04.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_04.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_04.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_04.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_04.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_04.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_05.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_05.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_05.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_05.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_05.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_05.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_05.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_05.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_06.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_06.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_06.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_06.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_06.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_06.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_06.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_06.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_07.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_07.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_07.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_07.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_07.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_07.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_07.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_07.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_08.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_08.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_08.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_08.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_08.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_08.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_08.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_08.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_09.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_09.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_09.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_09.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_09.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_09.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_09.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_09.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_10.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_10.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_10.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_10.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_10.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_10.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_10.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_10.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_11.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_11.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_11.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_11.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_11.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_11.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_11.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_11.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_12.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_12.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_12.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_12.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_12.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_12.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_12.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_12.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_13.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_13.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_13.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_13.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_13.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_13.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_13.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_13.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_14.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_14.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_14.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_14.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_14.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_14.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_14.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_14.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_15.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_15.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_15.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_15.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_15.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_15.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_15.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_15.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_16_16.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_16_16.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_16_16.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_16_16.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_16_16.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_16_16.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_16_16.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_16_16.Player2Score2))
            //                     )));
            //}

            //if (this.playoffs.IsFinal8())
            //{
            //    eRet.Add(new XElement("Round",
            //                 new XElement("Type", "E"),
            //                 new XElement("Games",
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_01.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_01.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_01.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_01.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_01.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_01.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_01.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_01.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_02.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_02.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_02.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_02.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_02.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_02.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_02.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_02.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_03.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_03.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_03.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_03.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_03.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_03.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_03.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_03.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_04.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_04.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_04.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_04.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_04.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_04.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_04.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_04.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_05.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_05.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_05.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_05.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_05.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_05.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_05.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_05.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_06.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_06.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_06.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_06.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_06.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_06.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_06.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_06.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_07.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_07.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_07.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_07.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_07.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_07.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_07.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_07.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_8_08.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_8_08.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_8_08.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_8_08.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_8_08.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_8_08.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_8_08.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_8_08.Player2Score2))
            //                     )));
            //}

            //if (this.playoffs.IsFinal4())
            //{
            //    eRet.Add(new XElement("Round",
            //                 new XElement("Type", "Q"),
            //                 new XElement("Games",
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_4_01.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_4_01.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_4_01.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_4_01.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_4_01.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_4_01.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_4_01.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_4_01.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_4_02.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_4_02.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_4_02.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_4_02.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_4_02.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_4_02.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_4_02.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_4_02.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_4_03.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_4_03.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_4_03.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_4_03.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_4_03.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_4_03.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_4_03.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_4_03.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_4_04.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_4_04.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_4_04.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_4_04.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_4_04.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_4_04.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_4_04.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_4_04.Player2Score2))
            //                     )));
            //}

            //if (this.playoffs.IsFinal2())
            //{
            //    eRet.Add(new XElement("Round",
            //                 new XElement("Type", "S"),
            //                 new XElement("Games",
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_2_01.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_2_01.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_2_01.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_2_01.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_2_01.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_2_01.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_2_01.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_2_01.Player2Score2)),
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final_2_02.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final_2_02.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final_2_02.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final_2_02.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final_2_02.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final_2_02.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final_2_02.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final_2_02.Player2Score2))
            //                     )));
            //}

            //if (this.playoffs.IsFinal())
            //{
            //    eRet.Add(new XElement("Round",
            //                 new XElement("Type", "F"),
            //                 new XElement("Games",
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Final.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Final.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Final.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Final.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Final.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Final.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Final.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Final.Player2Score2))
            //                     )));
            //}

            //if (this.playoffs.IsGame3rd())
            //{
            //    eRet.Add(new XElement("Round",
            //                 new XElement("Type", "T"),
            //                 new XElement("Games",
            //                     new XElement("Game",
            //                         new XElement("Player1Id", GetGALAKTAPlayerId(this.playoffs.Game3rdPlace.Player1Id, this)),
            //                         new XElement("Player2Id", GetGALAKTAPlayerId(this.playoffs.Game3rdPlace.Player2Id, this)),
            //                         new XElement("Player1Score", this.playoffs.Game3rdPlace.Player1Score),
            //                         new XElement("Player2Score", this.playoffs.Game3rdPlace.Player2Score),
            //                         new XElement("Player1Score1", this.playoffs.Game3rdPlace.Player1Score1),
            //                         new XElement("Player1Score2", this.playoffs.Game3rdPlace.Player1Score2),
            //                         new XElement("Player2Score1", this.playoffs.Game3rdPlace.Player2Score1),
            //                         new XElement("Player2Score2", this.playoffs.Game3rdPlace.Player2Score2))
            //                     )));
            //}

            ////       <Playoffs>
            ////           <Round>
            ////               <Type>Q</Type>
            ////               <Games>
            ////                   <Game>
            ////                         <Player1Id>324</Player1Id>
            ////                         <Player2Id>2356</Player2Id>
            ////                         <Score>2_1</Score>
            ////                   </Game>
            ////                   ...............
            ////               </Games>
            ////           </Round>
            ////        </Playoffs>
            return eRet;
        }

        #endregion
    }
}
