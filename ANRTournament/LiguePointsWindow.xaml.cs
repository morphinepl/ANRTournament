using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using ANRTournament.Objects;
using System.Collections.ObjectModel;
using ANRTournament.Resources;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for LiguePointsWindow.xaml
    /// </summary>
    public partial class LiguePointsWindow : Window
    {
        private Tournament tournament = null;
        private ObservableCollection<LiguePoints> liguepoints = new ObservableCollection<LiguePoints>();

        private LiguePointsWindow()
        {
            InitializeComponent();

            this.DataContext = liguepoints;

            this.num1stPlace.Value = App.Settings.LiguePoints1stPlace;
            this.num2ndPlace.Value = App.Settings.LiguePoints2ndPlace;
            this.num3rdPlace.Value = App.Settings.LiguePoints3rdPlace;
            this.num4thPlace.Value = App.Settings.LiguePoints4thPlace;
            this.num5thPlace.Value = App.Settings.LiguePoints5thPlace;
            this.num6thPlace.Value = App.Settings.LiguePoints6thPlace;
            this.num7thPlace.Value = App.Settings.LiguePoints7thPlace;
            this.num8thPlace.Value = App.Settings.LiguePoints8thPlace;

            this.numDraw.Value = App.Settings.LiguePointsDraw;
            this.numFaction.Value = App.Settings.LiguePointsFactionCorpo;
            this.numLoose.Value = App.Settings.LiguePointsLoose;
            this.numParticipation.Value = App.Settings.LiguePointsTournament;
            this.numWin.Value = App.Settings.LiguePointsWin;
            this.numWinBYE.Value = App.Settings.LiguePointsWin_BYE;

            this.chkSmallPoints.IsChecked = App.Settings.LiguePointsPlusMinus;

            this.num1stPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.num2ndPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.num3rdPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.num4thPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.num5thPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.num6thPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.num7thPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.num8thPlace.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.numDraw.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.numFaction.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.numLoose.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.numParticipation.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.numWin.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);
            this.numWinBYE.ValueChanged += new RoutedPropertyChangedEventHandler<object>(options_ValueChanged);

            this.chkSmallPoints.Checked += new RoutedEventHandler(chk_CheckedChanged);
            this.chkSmallPoints.Unchecked += new RoutedEventHandler(chk_CheckedChanged);
        }

        public LiguePointsWindow(Tournament tournament)
            : this()
        {
            this.tournament = tournament;

            this.Recalculate();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = "TXT (*.txt)|*.txt",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".txt",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.ExportAsTxtFormatted(saveDialog.FileName);
            }
        }

        private void chk_CheckedChanged(object sender, RoutedEventArgs e)
        {
            this.SaveOptions();
            this.Recalculate();
        }

        private void options_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.SaveOptions();
            this.Recalculate();
        }

        private void SaveOptions()
        {
            App.Settings.LiguePoints1stPlace = this.num1stPlace.Value.HasValue ? this.num1stPlace.Value.Value : 0;
            App.Settings.LiguePoints2ndPlace = this.num2ndPlace.Value.HasValue ? this.num2ndPlace.Value.Value : 0;
            App.Settings.LiguePoints3rdPlace = this.num3rdPlace.Value.HasValue ? this.num3rdPlace.Value.Value : 0;
            App.Settings.LiguePoints4thPlace = this.num4thPlace.Value.HasValue ? this.num4thPlace.Value.Value : 0;
            App.Settings.LiguePoints5thPlace = this.num5thPlace.Value.HasValue ? this.num5thPlace.Value.Value : 0;
            App.Settings.LiguePoints6thPlace = this.num6thPlace.Value.HasValue ? this.num6thPlace.Value.Value : 0;
            App.Settings.LiguePoints7thPlace = this.num7thPlace.Value.HasValue ? this.num7thPlace.Value.Value : 0;
            App.Settings.LiguePoints8thPlace = this.num8thPlace.Value.HasValue ? this.num8thPlace.Value.Value : 0;

            App.Settings.LiguePointsDraw = this.numDraw.Value.HasValue ? this.numDraw.Value.Value : 0;
            App.Settings.LiguePointsFactionCorpo = this.numFaction.Value.HasValue ? this.numFaction.Value.Value : 0;
            App.Settings.LiguePointsFactionRunner = this.numFaction.Value.HasValue ? this.numFaction.Value.Value : 0;
            App.Settings.LiguePointsLoose = this.numLoose.Value.HasValue ? this.numLoose.Value.Value : 0;
            App.Settings.LiguePointsTournament = this.numParticipation.Value.HasValue ? this.numParticipation.Value.Value : 0;
            App.Settings.LiguePointsWin = this.numWin.Value.HasValue ? this.numWin.Value.Value : 0;
            App.Settings.LiguePointsWin_BYE = this.numWinBYE.Value.HasValue ? this.numWinBYE.Value.Value : 0;

            App.Settings.LiguePointsPlusMinus = this.chkSmallPoints.IsChecked.HasValue ? this.chkSmallPoints.IsChecked.Value : false;

            App.Settings.SaveToIni();
        }

        private void Recalculate()
        {
            this.liguepoints.Clear();

            foreach (Player player in this.tournament.PointsTable.OrderBy(p => p.Place))
            {
                Player bestraceplayercorpo = this.tournament.PointsTable.Where(p => p.RaceCorpo == player.RaceCorpo).OrderBy(p => p.Place).FirstOrDefault();
                Player bestraceplayerrunner = this.tournament.PointsTable.Where(p => p.RaceRunner == player.RaceRunner).OrderBy(p => p.Place).FirstOrDefault();

                int placepoints = 0;
                switch (player.Place)
                {
                    case 1:
                        placepoints = App.Settings.LiguePoints1stPlace;
                        break;
                    case 2:
                        placepoints = App.Settings.LiguePoints2ndPlace;
                        break;
                    case 3:
                        placepoints = App.Settings.LiguePoints3rdPlace;
                        break;
                    case 4:
                        placepoints = App.Settings.LiguePoints4thPlace;
                        break;
                    case 5:
                        placepoints = App.Settings.LiguePoints5thPlace;
                        break;
                    case 6:
                        placepoints = App.Settings.LiguePoints6thPlace;
                        break;
                    case 7:
                        placepoints = App.Settings.LiguePoints7thPlace;
                        break;
                    case 8:
                        placepoints = App.Settings.LiguePoints8thPlace;
                        break;
                    default:
                        break;
                }

                this.liguepoints.Add(
                    new LiguePoints()
                    {
                        Player = player,
                        PointsDraw = App.Settings.LiguePointsDraw * player.GamesDraw,
                        PointsFactionCorpo = (bestraceplayercorpo.Id == player.Id ? App.Settings.LiguePointsFactionCorpo : 0),
                        PointsFactionRunner = (bestraceplayerrunner.Id == player.Id ? App.Settings.LiguePointsFactionRunner : 0),
                        PointsLoose = App.Settings.LiguePointsLoose * player.GamesLoose,
                        PointsParticipation = App.Settings.LiguePointsTournament,
                        PointsPlace = placepoints,
                        PointsPlusMinus = (App.Settings.LiguePointsPlusMinus ? (player.SmallPointsPlus - player.SmallPointsMinus > 0 ? player.SmallPointsPlus - player.SmallPointsMinus : 0) : 0),
                        //PointsWin10 = App.Settings.LiguePointsWin_1_0 * this.tournament.Rounds.SelectMany(r => r.Games).Count(g => (g.Player1Id == player.Id && g.Score == GameScore.Score_1_0) || (g.Player2Id == player.Id && g.Score == GameScore.Score_0_1)),
                        //PointsWin20 = App.Settings.LiguePointsWin_2_0 * this.tournament.Rounds.SelectMany(r => r.Games).Count(g => (g.Player1Id == player.Id && g.Score == GameScore.Score_2_0) || (g.Player2Id == player.Id && g.Score == GameScore.Score_0_2)),
                        PointsWin = App.Settings.LiguePointsWin * this.tournament.Rounds.SelectMany(r => r.Games).Count(g => (g.Player1Id == player.Id && g.Player1Score > g.Player2Score && g.IsBYE == false) || (g.Player2Id == player.Id && g.Player2Score > g.Player1Score && g.IsBYE == false)),
                        PointsWinBye = App.Settings.LiguePointsWin_BYE * this.tournament.Rounds.SelectMany(r => r.Games).Count(g => (g.Player1Id == player.Id && g.IsBYE == true) || (g.Player2Id == player.Id && g.IsBYE == true))
                    });
            }
        }

        private bool ExportAsTxtFormatted(string path)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("[code=html:0]");
            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------+");
            strBuilder.AppendLine(string.Format("|  #  | {0} | {1} | {2} | WYG | BYE | REM | PRZ | FCO | FRU | UCZ | +/- | MSC | SUM |",
                                                StringTable.MainWindow_Gracz.PadRight(13, ' '),
                                                StringTable.MainWindow_FrakCorp.PadRight(8, ' '),
                                                StringTable.MainWindow_FrakRun.PadRight(8, ' ')));
            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------+");

            foreach (LiguePoints points in this.liguepoints)
            {
                string name = points.Player.Alias;
                if (name.Length > 13) name = name.Substring(0, 13);

                strBuilder.AppendFormat("| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11} | {12} | {13} |",
                                         points.Player.Place.ToString().PadLeft(3, ' '),
                                         name.PadRight(13, ' '),
                                         Enums.RaceCorpoToString(points.Player.RaceCorpo).PadRight(8, ' '),
                                         Enums.RaceRunnerToString(points.Player.RaceRunner).PadRight(8, ' '),
                                         points.PointsWin.ToString().PadLeft(3, ' '),
                                         points.PointsWinBye.ToString().PadLeft(3, ' '),
                                         points.PointsDraw.ToString().PadLeft(3, ' '),
                                         points.PointsLoose.ToString().PadLeft(3, ' '),
                                         points.PointsFactionCorpo.ToString().PadLeft(3, ' '),
                                         points.PointsFactionRunner.ToString().PadLeft(3, ' '),
                                         points.PointsParticipation.ToString().PadLeft(3, ' '),
                                         points.PointsPlusMinus.ToString().PadLeft(3, ' '),
                                         points.PointsPlace.ToString().PadLeft(3, ' '),
                                         points.SumaricPoints.ToString().PadLeft(3, ' '));
                strBuilder.AppendLine();
            }

            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------+");
            strBuilder.AppendLine("[/code]");

            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.Write(strBuilder.ToString());
            }

            return true;
        }
    }
}
