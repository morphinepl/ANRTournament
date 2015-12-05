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

        public int LiguePointsWin = 3;
        public int LiguePointsWin_BYE = 3;
        public int LiguePointsDraw = 1;
        public int LiguePointsLoose = 0;

        public int LiguePointsFactionCorpo = 1;
        public int LiguePointsFactionRunner = 1;
        public int LiguePointsTournament = 1;
        public int LiguePoints1stPlace = 3;
        public int LiguePoints2ndPlace = 2;
        public int LiguePoints3rdPlace = 1;
        public int LiguePoints4thPlace = 0;
        public int LiguePoints5thPlace = 0;
        public int LiguePoints6thPlace = 0;
        public int LiguePoints7thPlace = 0;
        public int LiguePoints8thPlace = 0;
        public bool LiguePointsPlusMinus = false;
        
        #endregion

        public enum MainTabSettings
        {
            PointsTableWithRoundsTogether,
            PointsTableWithRoundsSeparate
        }

        public bool RandomTieAfterPoints = false;
    }
}
