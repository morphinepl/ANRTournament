using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANRTournament
{
    /// <summary>
    /// Corporation faction
    /// </summary>
    public enum RaceCorpo
    {
        NotSet,

        /// <summary>
        /// Haas-Bioroid
        /// </summary>
        HaasBioroid,

        /// <summary>
        /// Jinteki
        /// </summary>
        Jinteki,

        /// <summary>
        /// NBN
        /// </summary>
        NBN,

        /// <summary>
        /// Weyland Consortium
        /// </summary>
        WeylandConsortium,
    }

    /// <summary>
    /// Runner faction
    /// </summary>
    public enum RaceRunner
    {
        NotSet,

        /// <summary>
        /// Anarch
        /// </summary>
        Anarch,

        /// <summary>
        /// Criminal
        /// </summary>
        Criminal,

        /// <summary>
        /// Shaper
        /// </summary>
        Shaper,

        /// <summary>
        /// Apex
        /// </summary>
        Apex,

        /// <summary>
        /// Adam
        /// </summary>
        Adam,

        /// <summary>
        /// Sunny
        /// </summary>
        Sunny,

    }

    /// <summary>
    /// Rangi turniejów
    /// </summary>
    public enum TournamentImportance
    {
        /// <summary>
        /// Turniej lokalny
        /// </summary>
        Local,

        /// <summary>
        /// Duży turniej
        /// </summary>
        Big,

        /// <summary>
        /// Mistrzowski
        /// </summary>
        Champioship,
    }

    /// <summary>
    /// Wynik gry Player1 - Player2
    /// </summary>
    public enum GameScore
    {
        NotSet,
        Score_BYE,
        Score_0_0,
        Score_0_1,
        Score_1_0,
        Score_1_1,
        Score_2_0,
        Score_0_2,
        Score_2_1, 
        Score_1_2,
    }

    public abstract class Enums{
        public static string GameScoreToString(GameScore score) 
        {
            string sRet = "_ : _";
            switch (score)
            {
                case GameScore.NotSet:
                    sRet = "_ : _";
                    break;
                case GameScore.Score_BYE:
                    sRet = " BYE ";
                    break;
                case GameScore.Score_0_0:
                    sRet = "0 : 0";
                    break;
                case GameScore.Score_0_1:
                    sRet = "0 : 1";
                    break;
                case GameScore.Score_1_0:
                    sRet = "1 : 0";
                    break;
                case GameScore.Score_1_1:
                    sRet = "1 : 1";
                    break;
                case GameScore.Score_2_0:
                    sRet = "2 : 0";
                    break;
                case GameScore.Score_0_2:
                    sRet = "0 : 2";
                    break;
                case GameScore.Score_2_1:
                    sRet = "2 : 1";
                    break;
                case GameScore.Score_1_2:
                    sRet = "1 : 2";
                    break;
                default:
                    break;
            }
            return sRet;
        }

        public static string RaceCorpoToString(RaceCorpo race) 
        {
            string sRet = "";

            switch (race)
            {
                case RaceCorpo.HaasBioroid:
                    sRet = "HB";
                    break;
                case RaceCorpo.Jinteki:
                    sRet = "Jinteki";
                    break;
                case RaceCorpo.NBN:
                    sRet = "NBN";
                    break;
                case RaceCorpo.WeylandConsortium:
                    sRet = "Weyland";
                    break;                
                default:
                    break;
            }

            return sRet;
        }

        public static string RaceRunnerToString(RaceRunner race)
        {
            string sRet = "";

            switch (race)
            {
                case RaceRunner.Anarch:
                    sRet = "Anarch";
                    break;
                case RaceRunner.Criminal:
                    sRet = "Criminal";
                    break;
                case RaceRunner.Shaper:
                    sRet = "Shaper";
                    break;
                case RaceRunner.Apex:
                    sRet = "Apex";
                    break;
                case RaceRunner.Adam:
                    sRet = "Adam";
                    break;
                case RaceRunner.Sunny:
                    sRet = "Sunny";
                    break;
                default:
                    break;
            }

            return sRet;
        }
    }

    public enum PlayoffRound
    {
        Final_16,
        Final_8,
        Final_4,
        Final_2,
        Final,
    }

    public enum DoubleEliminationPlayoffRound
    {
        WithoutPlayoffs,
        Top16,
        Top8,
    }

    public enum DiceSystem
    {
        Disabled,
        OnlyRandom,
        FullEnabled,
    }
}
