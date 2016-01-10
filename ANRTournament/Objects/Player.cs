using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace ANRTournament.Objects
{
    /// <summary>
    /// Gracz
    /// </summary>
    public class Player : INotifyPropertyChanged
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

        private Player player_org = null;

        #region private members

        private bool superbye = false;
        private int idgalakta = 0;
        private int points = 0;
        private Guid id = Guid.NewGuid();
        private string corpoidentity = null;
        private string runneridentity = null;
        private int place = 0;
        private string name = string.Empty;
        private string surname = string.Empty;
        private string alias = string.Empty;        
        private int rankbeforetournament = 0;
        private int gameswin = 0;
        private int gamesdraw = 0;
        private int gamesloose = 0;
        private int smallpointsplus = 0;
        private int smallpointsminus = 0;
        private int dicecount = 0;
        private bool deckcheck = false;
        private bool active = true;
        private int bucholz = 0;
        private int mbucholz = 0;
        private bool payment = false;
        private bool addPlayerToLastRound = false;

        private int runnerwins = 0;
        private int corpowins = 0;

        #endregion

        public event EventHandler PlaceChanged = null;

        public event EventHandler PlayerDataChanged = null;

        /// <summary>
        /// Identyfikator gracza w serwisie GALAKTA
        /// </summary>
        public int IdGalakta
        {
            get { return this.idgalakta; }
            set
            {
                if (value != this.idgalakta)
                {
                    this.idgalakta = value;
                    NotifyPropertyChanged("IdGalakta");
                }
            }
        }

        /// <summary>
        /// Identyfikator gracza
        /// </summary>
        public Guid Id
        {
            get { return this.id; }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        /// <summary>
        /// Identity
        /// </summary>
        public string CorpoIdentity
        {
            get { return this.corpoidentity; }
            set
            {
                if (value != this.corpoidentity)
                {
                    this.corpoidentity = value;
                    NotifyPropertyChanged("CorpoIdentity");
                    NotifyPropertyChanged("RaceCorpo");
                    if (this.PlayerDataChanged != null) this.PlayerDataChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Identity
        /// </summary>
        public string RunnerIdentity
        {
            get { return this.runneridentity; }
            set
            {
                if (value != this.runneridentity)
                {
                    this.runneridentity = value;
                    NotifyPropertyChanged("RunnerIdentity");
                    NotifyPropertyChanged("RaceRunner");
                    if (this.PlayerDataChanged != null) this.PlayerDataChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Miejsce
        /// </summary>
        public int Place
        {
            get { return this.place; }
            set
            {
                if (value != this.place)
                {
                    this.place = value;
                    NotifyPropertyChanged("Place");
                    if (this.PlaceChanged != null) this.PlaceChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Imię
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
                    NotifyPropertyChanged("NameSurname");
                    NotifyPropertyChanged("NameSurnameAlias");
                    if (this.PlayerDataChanged != null) this.PlayerDataChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Nazwisko
        /// </summary>
        public string Surname
        {
            get { return this.surname; }
            set
            {
                if (value != this.surname)
                {
                    this.surname = value;
                    NotifyPropertyChanged("Surname");
                    NotifyPropertyChanged("NameSurname");
                    NotifyPropertyChanged("NameSurnameAlias");
                    if (this.PlayerDataChanged != null) this.PlayerDataChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Pseudo
        /// </summary>
        public string Alias
        {
            get { return this.alias; }
            set
            {
                if (value != this.alias)
                {
                    this.alias = value;
                    NotifyPropertyChanged("Alias");
                    NotifyPropertyChanged("NameSurnameAlias");
                    if (this.PlayerDataChanged != null) this.PlayerDataChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Frakcja (rasa)
        /// </summary>
        public RaceCorpo RaceCorpo
        {
            get
            {
                if (ANRTournament.Objects.CorpoIdentity.CorpoIdentities.Exists(i => i.IdentityName == this.CorpoIdentity))
                {
                    return ANRTournament.Objects.CorpoIdentity.CorpoIdentities.First(i => i.IdentityName == this.CorpoIdentity).Race;
                }

                return ANRTournament.RaceCorpo.NotSet;
            }
        }

        /// <summary>
        /// Frakcja (rasa)
        /// </summary>
        public RaceRunner RaceRunner
        {
            get
            {
                if (ANRTournament.Objects.RunnerIdentity.RunnerIdentities.Exists(i => i.IdentityName == this.RunnerIdentity))
                {
                    return ANRTournament.Objects.RunnerIdentity.RunnerIdentities.First(i => i.IdentityName == this.RunnerIdentity).Race;
                }

                return ANRTournament.RaceRunner.NotSet;
            }
        }

        /// <summary>
        /// Ranking przed turniejem
        /// </summary>
        public int RankBeforeTournament
        {
            get { return this.rankbeforetournament; }
            set
            {
                if (value != this.rankbeforetournament)
                {
                    this.rankbeforetournament = value;
                    NotifyPropertyChanged("RankBeforeTournament");
                }
            }
        }

        /// <summary>
        /// Liczba gier wygranych
        /// </summary>
        public int GamesWin
        {
            get { return this.gameswin; }
            set
            {
                if (value != this.gameswin)
                {
                    this.gameswin = value;
                    NotifyPropertyChanged("GamesWin");
                    NotifyPropertyChanged("GamesWinDrawLoose");
                    NotifyPropertyChanged("GamesCount");
                    NotifyPropertyChanged("PlaceRate");
                }
            }
        }

        /// <summary>
        /// Liczba gier zremisowanych
        /// </summary>
        public int GamesDraw
        {
            get { return this.gamesdraw; }
            set
            {
                if (value != this.gamesdraw)
                {
                    this.gamesdraw = value;
                    NotifyPropertyChanged("GamesDraw");
                    NotifyPropertyChanged("GamesWinDrawLoose");
                    NotifyPropertyChanged("GamesCount");
                    NotifyPropertyChanged("PlaceRate");
                }
            }
        }

        /// <summary>
        /// Liczba gier przegranych
        /// </summary>
        public int GamesLoose
        {
            get { return this.gamesloose; }
            set
            {
                if (value != this.gamesloose)
                {
                    this.gamesloose = value;
                    NotifyPropertyChanged("GamesLoose");
                    NotifyPropertyChanged("GamesWinDrawLoose");
                    NotifyPropertyChanged("GamesCount");
                    NotifyPropertyChanged("PlaceRate");
                }
            }
        }

        /// <summary>
        /// Małe punkty na plus 
        /// </summary>
        public int SmallPointsPlus
        {
            get { return this.smallpointsplus; }
            set
            {
                if (value != this.smallpointsplus)
                {
                    this.smallpointsplus = value;
                    NotifyPropertyChanged("SmallPointsPlus");
                    NotifyPropertyChanged("SmallPointsPlusMinus");
                    NotifyPropertyChanged("PlaceRate");
                }
            }
        }

        /// <summary>
        /// Małe punkty na minus
        /// </summary>
        public int SmallPointsMinus
        {
            get { return this.smallpointsminus; }
            set
            {
                if (value != this.smallpointsminus)
                {
                    this.smallpointsminus = value;
                    NotifyPropertyChanged("SmallPointsMinus");
                    NotifyPropertyChanged("SmallPointsPlusMinus");
                    NotifyPropertyChanged("PlaceRate");
                }
            }
        }

        /// <summary>
        /// Tie-Break korpo-runner (zwraca mniejszy)
        /// </summary>
        public int CorpoRunnerTieBreak
        {
            get { return (this.corpowins < this.runnerwins ? this.corpowins : this.runnerwins); }
        }

        /// <summary>
        /// Liczba gier wygranych runnerem
        /// </summary>
        public int RunnerWins
        {
            get { return this.runnerwins; }
            set
            {
                if (value != this.runnerwins)
                {
                    this.runnerwins = value;
                    NotifyPropertyChanged("RunnerWins");
                    NotifyPropertyChanged("CorpoRunnerTieBreak");
                }
            }
        }

        /// <summary>
        /// Liczba gier wygranych korporacją
        /// </summary>
        public int CorpoWins
        {
            get { return this.corpowins; }
            set
            {
                if (value != this.corpowins)
                {
                    this.corpowins = value;
                    NotifyPropertyChanged("CorpoWins");
                    NotifyPropertyChanged("CorpoRunnerTieBreak");
                }
            }
        }

        /// <summary>
        /// Random tie
        /// </summary>
        public int LastTieBreak
        {
            get { return Tournament.RandomGenerator.Next(999); }
        }

        /// <summary>
        /// Liczba gier zaczynanych
        /// </summary>
        public int DiceCount
        {
            get { return this.dicecount; }
            set
            {
                if (value != this.dicecount)
                {
                    this.dicecount = value;
                    NotifyPropertyChanged("DiceCount");
                }
            }
        }

        /// <summary>
        /// Zweryfikowany deck
        /// </summary>
        public bool DeckCheck
        {
            get { return this.deckcheck; }
            set
            {
                if (value != this.deckcheck)
                {
                    this.deckcheck = value;
                    NotifyPropertyChanged("DeckCheck");
                }
            }
        }

        /// <summary>
        /// Płatność
        /// </summary>
        public bool Payment
        {
            get { return this.payment; }
            set
            {
                if (value != this.payment)
                {
                    this.payment = value;
                    NotifyPropertyChanged("Payment");
                }
            }
        }

        /// <summary>
        /// Dodaj do ostatniej rundy
        /// </summary>
        public bool AddPlayerToLastRound
        {
            get { return this.addPlayerToLastRound; }
            set
            {
                if (value != this.addPlayerToLastRound)
                {
                    this.addPlayerToLastRound = value;
                    NotifyPropertyChanged("AddPlayerToLastRound");
                }
            }
        }

        /// <summary>
        /// Gracz aktywny
        /// </summary>
        public bool Active
        {
            get { return this.active; }
            set
            {
                if (value != this.active)
                {
                    this.active = value;
                    NotifyPropertyChanged("Active");
                }
            }
        }

        /// <summary>
        /// Bucholz
        /// </summary>
        public int Bucholz
        {
            get { return this.bucholz; }
            set
            {
                if (value != this.bucholz)
                {
                    this.bucholz = value;
                    NotifyPropertyChanged("Bucholz");
                }
            }
        }

        /// <summary>
        /// MBucholz
        /// </summary>
        public int MBucholz
        {
            get { return this.mbucholz; }
            set
            {
                if (value != this.mbucholz)
                {
                    this.mbucholz = value;
                    NotifyPropertyChanged("MBucholz");
                }
            }
        }

        /// <summary>
        /// Punkty
        /// </summary>
        public int Points
        {
            get { return this.points; }
            set
            {
                if (value != this.points)
                {
                    this.points = value;
                    NotifyPropertyChanged("Points");
                    NotifyPropertyChanged("PlaceRate");
                }
            }
        }

        /// <summary>
        /// SuperBYE
        /// </summary>
        public bool SuperBYE
        {
            get { return this.superbye; }
            set
            {
                if (value != this.superbye)
                {
                    this.superbye = value;
                    NotifyPropertyChanged("SuperBYE");
                }
            }
        }

        #region Wyliczane

        /// <summary>
        /// Liczba gier
        /// </summary>
        public int GamesCount
        {
            get { return this.GamesLoose + this.GamesDraw + this.GamesWin; }
        }

        /// <summary>
        /// Imię i nazwisko
        /// </summary>
        public string NameSurname
        {
            get { return this.Name + " " + this.Surname; }
        }

        /// <summary>
        /// Imię i nazwisko i nazwa
        /// </summary>
        public string NameSurnameAlias
        {
            get { return string.Format("{0} '{1}' {2}",this.Name, this.Alias, this.Surname); }
        }

        /// <summary>
        /// W-R-P
        /// </summary>
        public string GamesWinDrawLoose
        {
            get { return this.GamesWin + "-" + this.GamesDraw + "-" + this.GamesLoose; }
        }

        /// <summary>
        /// +/-
        /// </summary>
        public string SmallPointsPlusMinus
        {
            get { return this.SmallPointsPlus + "/" + this.SmallPointsMinus; }
        }

        /// <summary>
        /// Współczynnkik miejsca
        /// </summary>
        public int PlaceRate
        {
            get { return Points * 100000 + (SmallPointsPlus - SmallPointsMinus) * 1000 + SmallPointsPlus; }
        }

        #endregion

        internal void Clone()
        {
            this.player_org = new Player()
            {
                Alias = this.Alias,
                DeckCheck = this.DeckCheck,
                GamesDraw = this.GamesDraw,
                GamesLoose = this.GamesLoose,
                GamesWin = this.GamesWin,
                Name = this.Name,
                Place = this.Place,
                CorpoIdentity = this.CorpoIdentity,
                RunnerIdentity = this.RunnerIdentity,
                RankBeforeTournament = this.RankBeforeTournament,
                SmallPointsMinus = this.SmallPointsMinus,
                SmallPointsPlus = this.SmallPointsPlus,
                Surname = this.Surname,
            };
        }

        internal void Restore()
        {
            this.Alias = this.player_org.Alias;
            this.DeckCheck = this.player_org.DeckCheck;
            this.GamesDraw = this.player_org.GamesDraw;
            this.GamesLoose = this.player_org.GamesLoose;
            this.GamesWin = this.player_org.GamesWin;
            this.Name = this.player_org.Name;
            this.Place = this.player_org.Place;
            this.CorpoIdentity = this.player_org.CorpoIdentity;
            this.RunnerIdentity = this.player_org.RunnerIdentity;
            this.RankBeforeTournament = this.player_org.RankBeforeTournament;
            this.SmallPointsMinus = this.player_org.SmallPointsMinus;
            this.SmallPointsPlus = this.player_org.SmallPointsPlus;
            this.Surname = this.player_org.Surname;
        }
    }
}
