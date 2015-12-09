using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace ANRTournament.Objects
{
    [Serializable]
    public class Settings
    {
        #region Zapis/Odczyt ustawień

        public static string IniFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\ANRTournamentSettings.ini";

        public void SaveToIni()
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
            XmlTextWriter XmlTextWriter = new XmlTextWriter(IniFilePath, Encoding.UTF8);
            XmlTextWriter.Formatting = Formatting.Indented;
            Serializer.Serialize(XmlTextWriter, this);
            XmlTextWriter.Close();
        }

        public static Settings LoadFromIni()
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
            XmlTextReader XmlTextReader = new XmlTextReader(IniFilePath);

            Settings iniFile = (Settings)Serializer.Deserialize(XmlTextReader);
            XmlTextReader.Close();
            return iniFile;
        }

        #endregion

        /// <summary>
        /// Ustawienie głównego taba
        /// </summary>
        public MainTabSettings MainTabSetting = MainTabSettings.PointsTableWithRoundsSeparate;

        /// <summary>
        /// Język
        /// </summary>
        public string Language = "pl";

        /// <summary>
        /// System "kostki"
        /// </summary>
        public DiceSystem DiceSystem = DiceSystem.Disabled;

        ///// <summary>
        ///// Punktowanie BYE (+/-)
        ///// </summary>
        //public GameScore BYEScore = GameScore.Score_2_0;

        public bool ColumnDC = true;

        public bool ColumnG = false;

        public bool ColumnPayment = true;

        public bool ColumnRank = false;

        public bool BYEOnlyForLosers = false;
        
        public bool BYEHasDice = false;

        public bool AutoSave = true;

        #region Punkty ligowe

        public int LeaguePointsWin = 3;
        public int LeaguePointsWin_BYE = 3;
        public int LeaguePointsDraw = 1;
        public int LeaguePointsLoose = 0;

        public int LeaguePointsFactionCorpo = 1;
        public int LeaguePointsFactionRunner = 1;
        public int LeaguePointsTournament = 1;
        public int LeaguePoints1stPlace = 3;
        public int LeaguePoints2ndPlace = 2;
        public int LeaguePoints3rdPlace = 1;
        public int LeaguePoints4thPlace = 0;
        public int LeaguePoints5thPlace = 0;
        public int LeaguePoints6thPlace = 0;
        public int LeaguePoints7thPlace = 0;
        public int LeaguePoints8thPlace = 0;
        public bool LeaguePointsPlusMinus = false;
        
        #endregion

        public enum MainTabSettings
        {
            PointsTableWithRoundsTogether,
            PointsTableWithRoundsSeparate
        }

        public bool RandomTieAfterPoints = false;
    }
}
