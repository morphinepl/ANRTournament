using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Win32;
using ANRTournament.Controls;
using ANRTournament.Objects;
using System.Configuration;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using ANRTournament.Resources;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string tournamentFilePath = string.Empty;

        private Tournament tournament = new Tournament()
                                                {
                                                    Name = "",
                                                    Date = DateTime.Today,
                                                    Importance = TournamentImportance.Local,
                                                };

        public MainWindow()
        {
            InitializeComponent();

            this.lblVersion.Content = string.Format(this.lblVersion.Content.ToString(), Assembly.GetEntryAssembly().GetName().Version.ToString(3));
            this.Title = this.lblVersion.Content.ToString();

            this.RefreshTournamentDataContexts();

            this.bkgGenerateRound.DoWork += new DoWorkEventHandler(bkgGenerateRound_DoWork);
            this.bkgGenerateRound.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkgGenerateRound_RunWorkerCompleted);
            this.bkgGenerateRound.ProgressChanged += new ProgressChangedEventHandler(bkgGenerateRound_ProgressChanged);

            if (App.Settings.MainTabSetting == Settings.MainTabSettings.PointsTableWithRoundsSeparate)
            {
                this.gridRounds.Children.Remove(this.brdTablePoints);
                this.gridTablePoints.Children.Add(this.brdTablePoints);
                this.tabTablePoints.Visibility = System.Windows.Visibility.Visible;

                this.brdRounds.SetValue(Grid.ColumnProperty, 0);
                this.brdRounds.SetValue(Grid.ColumnSpanProperty, 2);
                this.brdRounds.MaxWidth = 700;
            }
            else
            {
                this.tbMain.SelectedIndex = 1;
            }

            this.colDiceCount.Visibility = System.Windows.Visibility.Collapsed;

            this.colDeckcheck.Visibility = App.Settings.ColumnDC ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.colGalakta.Visibility = App.Settings.ColumnG ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.colPayment.Visibility = App.Settings.ColumnPayment ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.colRankBeforeTournament.Visibility = App.Settings.ColumnRank ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

            #region Generowanie Playerów
#if DEBUG
            this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "morphine",
                    Name = "Tomasz",
                    Surname = "Bator",
                    RankBeforeTournament = 666,
                    DeckCheck = true,
                    Payment = true,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });

            this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "Alf",
                    Name = "Włochaty",
                    Surname = "Kosmita",
                    RankBeforeTournament = 777,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });

            this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "Tinky Winky",
                    Name = "Fioletowy",
                    Surname = "Tubiś",
                    RankBeforeTournament = 1333,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });

            this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "Dipsy",
                    Name = "Zielony",
                    Surname = "Tubiś",
                    RankBeforeTournament = 1249,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });

            this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "Laa-Laa",
                    Name = "Żółta",
                    Surname = "Tubiśka",
                    RankBeforeTournament = 1111,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });

            this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "Po",
                    Name = "Czerwona",
                    Surname = "Tubiśka",
                    RankBeforeTournament = 903,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });

            this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "Noo-Noo",
                    Name = "Że niby",
                    Surname = "odkurzacz :)",
                    RankBeforeTournament = 1098,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });

            for (int i = 0; i < 10; i++)
            {
                this.tournament.PointsTable.Add(
                new Player()
                {
                    Alias = "Player" + i.ToString(),
                    Name = "Player" + i.ToString(),
                    Surname = "Player" + i.ToString(),
                    RankBeforeTournament = 1098,
                    CorpoIdentity = "NBN: The World is Yours*",
                    RunnerIdentity = "Iain Stirling: Retired Spook",
                });
            }
#endif
            #endregion
        }

        #region bkgGenerateRound

        private BackgroundWorker bkgGenerateRound = new BackgroundWorker();
        private Round roundToAdd;

        private void bkgGenerateRound_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bkgGenerateRound_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BusyIndicator.IsBusy = false;

            if (roundToAdd == null)
            {
                new PMI(StringTable.MainWindow_NieMoznaWygenerowacWiecejRund);
                return;
            }

            this.tournament.Rounds.Add(roundToAdd);

            foreach (Round ctrl in this.tabRound.Items)
            {
                ctrl.ScoreEnabled = false;
            }

            (this.tabRound.Items[this.tabRound.Items.Count - 1] as Round).ScoreEnabled = true;
            this.tabRound.SelectedIndex = this.tabRound.Items.Count - 1;
        }

        private void bkgGenerateRound_DoWork(object sender, DoWorkEventArgs e)
        {
            roundToAdd = this.tournament.CreateNextRound();
        }

        #endregion

        delegate void PlayerPlaceChanged();

        private void SortPlayers()
        {
            SortDescription tablesort = new SortDescription("Place", ListSortDirection.Ascending);
            this.dgPointsTable.Items.SortDescriptions.Clear();
            this.dgPointsTable.Items.SortDescriptions.Add(tablesort);
        }

        private void tournament_PlayerPlaceChanged(object sender, EventArgs e)
        {
            this.dgPointsTable.Dispatcher.Invoke(new PlayerPlaceChanged(this.SortPlayers));
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPlayerAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Player playerToAdd = new Player() { Place = this.tournament.PointsTable.Count + 1 };

                bool added = false;
                while (!added)
                {
                    PlayerWindow frmPlayer = new PlayerWindow(playerToAdd) { Owner = this };
                    if (frmPlayer.ShowDialog() == true)
                    {
                        if (this.tournament.PointsTable.Where(p => p.Alias == playerToAdd.Alias).Count() > 0)
                        {
                            new PMW(StringTable.MainWindow_PlayerExists);
                            continue;
                        }

                        this.tournament.AddPlayer(playerToAdd);
                        added = true;
                        continue;
                    }
                    else
                    {
                        added = true;
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                new PME("Błąd dodawania gracza." + Environment.NewLine + ex.Message + Environment.NewLine + (ex.InnerException == null ? "" : ex.InnerException.Message));
            }
        }

        private void btnPlayerDeactivate_Click(object sender, RoutedEventArgs e)
        {
            Player playerToDel = this.dgPointsTable.SelectedItem as Player;
            if (playerToDel == null) return;


            if (this.tournament.Rounds.Count == 0)
            {
                if (PMW.Show(StringTable.MainWindow_PlayerDelete, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            }
            else
            {
                if (PMW.Show(StringTable.MainWindow_PlayerDeactivate, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            }

            this.tournament.RemovePlayer(playerToDel);

            this.dgPointsTable.Items.Refresh();
        }

        private void btnPlayerEdit_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.Clone();

            bool edited = false;
            while (!edited)
            {
                PlayerWindow frmPlayer = new PlayerWindow(playerToEdit) { Owner = this };
                if (frmPlayer.ShowDialog() == true)
                {
                    if (this.tournament.PointsTable.Where(p => p.Alias == playerToEdit.Alias).Count() > 1)
                    {
                        new PMW(StringTable.MainWindow_PlayerExists);
                        continue;
                    }

                    edited = true;
                    continue;
                }
                else
                {
                    playerToEdit.Restore();
                    edited = true;
                    continue;
                }
            }

            this.dgPointsTable.Items.Refresh();
        }

        private void btnPrintTable_Click(object sender, RoutedEventArgs e)
        {
            XamlTemplatePrinter.PrintPointsTable(this.tournament.PointsTable);
        }

        private void btnNewRound_Click(object sender, RoutedEventArgs e)
        {
            if (!this.tournament.IsLastRoundEnded())
            {
                new PMW(StringTable.MainWindow_LastRoundNotEnd);
                return;
            }

            this.BusyIndicator.IsBusy = true;
            this.bkgGenerateRound.RunWorkerAsync();
            //this.bkgGenerateRound_DoWork(null, null);
            //this.bkgGenerateRound_RunWorkerCompleted(null, null);
            //this.BusyIndicator.IsBusy = false;
        }

        private void btnNewRoundHand_Click(object sender, RoutedEventArgs e)
        {
            if (!this.tournament.IsLastRoundEnded())
            {
                new PMW(StringTable.MainWindow_LastRoundNotEnd);
                return;
            }

            if (this.tournament.Rounds.Count == 0) this.tournament.GenerateAllGames();

            CreateRoundWindow wnd = new CreateRoundWindow(this.tournament.AllGames, (this.tournament.PointsTable.Where(p => p.Active == true).Count() + 1) / 2);
            if (wnd.ShowDialog() == true)
            {
                foreach (Round ctrl in this.tabRound.Items)
                {
                    ctrl.ScoreEnabled = false;
                }

                this.tournament.AddRound(wnd.Round);

                this.tabRound.SelectedIndex = this.tabRound.Items.Count - 1;
            }
        }

        private void btnDeleteRound_Click(object sender, RoutedEventArgs e)
        {
            if (this.tournament.Rounds.Count == 0) return;
            if (PMW.Show(StringTable.MainWindow_DeleteRound, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

            this.tournament.DeleteLastRound();

            if (this.tabRound.Items.Count != 0)
            {
                (this.tabRound.Items[this.tabRound.Items.Count - 1] as Round).ScoreEnabled = true;
            }
        }

        private void btnStartPlayoffsTop16_Click(object sender, RoutedEventArgs e)
        {
            if (this.tournament.Rounds == null ||
                this.tournament.Rounds.Count == 0) return;

            this.BusyIndicator.IsBusy = true;


            this.tournament.CreatePlayoffsDoubleElimination(DoubleEliminationPlayoffRound.Top16);

            this.ctrlPlayoffs16.DataContext = null;
            this.ctrlPlayoffs16.DataContext = this.tournament.Playoffs16;
            this.BusyIndicator.IsBusy = false;
        }

        private void btnStartPlayoffsTop8_Click(object sender, RoutedEventArgs e)
        {
            if (this.tournament.Rounds == null ||
                this.tournament.Rounds.Count == 0) return;

            this.BusyIndicator.IsBusy = true;


            this.tournament.CreatePlayoffsDoubleElimination(DoubleEliminationPlayoffRound.Top8);

            this.ctrlPlayoffs8.DataContext = null;
            this.ctrlPlayoffs8.DataContext = this.tournament.Playoffs8;
            this.BusyIndicator.IsBusy = false;
        }

        private void btnDeletePlayoffs_Click(object sender, RoutedEventArgs e)
        {
            if (PMW.Show(StringTable.MainWindow_DeletePlayoffs, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

            this.tournament.ClearPlayoffs();
        }

        private void btnPrintPlayoffs_Click(object sender, RoutedEventArgs e)
        {
            //if (this.cmbPrintPlayoffs.SelectedValue == null) return;

            //PlayoffRound playoffround = (PlayoffRound)this.cmbPrintPlayoffs.SelectedValue;
            //XamlTemplatePrinter.PrintPlayoffs(this.tournament.Playoffs, playoffround);
        }

        private void btnPrintFinalResults_Click(object sender, RoutedEventArgs e)
        {
            XamlTemplatePrinter.PrintFinalResults(this.tournament.FinalResults);
        }

        private void btnRefreshFinalResults_Click(object sender, RoutedEventArgs e)
        {
            this.tournament.RefreshFinalResults();
            this.SortFinalResults();
        }

        private void dgPointsTable_RowDoubleClick(object sender, EventArgs e)
        {
            this.btnPlayerEdit_Click(sender, new RoutedEventArgs());
        }

        private void dgPointsTable_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems)
            {
                Player player = item as Player;
                if (player == null) continue;


                //foreach (var roundctrl in this.stpRounds.Children)
                //{
                //    RoundControl roundCtrl = roundctrl as RoundControl;
                //    if (roundctrl == null) continue;

                //    roundCtrl.SelectPlayerGame(player.Id);
                //}
            }
        }

        #region Menu

        private void mniNew_Click(object sender, RoutedEventArgs e)
        {
            if (PMW.Show(StringTable.MainWindow_NiezapisaneDane, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

            this.tournament = new Tournament();
            this.RefreshTournamentDataContexts();
        }

        private void mniOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiTurniejow + " (*.ant)|*.ant",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                AddExtension = true,
                DefaultExt = ".ant",
                CheckPathExists = true,
                CheckFileExists = true,
            };

            if (openDialog.ShowDialog() == true)
            {
                this.BusyIndicator.IsBusy = true;
                this.tournamentFilePath = openDialog.FileName;
                this.tournament = Tournament.Load(openDialog.FileName);
                this.RefreshTournamentDataContexts();
                this.BusyIndicator.IsBusy = false;
            }
        }

        private void mniSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tournamentFilePath))
            {
                this.mniSaveAs_Click(sender, e);
            }
            else
            {
                this.BusyIndicator.IsBusy = true;
                Tournament.Save(this.tournament, this.tournamentFilePath);
                this.BusyIndicator.IsBusy = false;
            }
        }

        private void mniSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiTurniejow + " (*.ant)|*.ant",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".ant",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.BusyIndicator.IsBusy = true;
                this.tournamentFilePath = saveDialog.FileName;
                Tournament.Save(this.tournament, saveDialog.FileName);
                this.BusyIndicator.IsBusy = false;
            }
        }

        private void mniStatistics_Click(object sender, RoutedEventArgs e)
        {
            (new StatisticsWindow(this.tournament)).ShowDialog();
        }

        private void mniLiguePoints_Click(object sender, RoutedEventArgs e)
        {
            (new LiguePointsWindow(this.tournament)).ShowDialog();
        }

        private void mniPlayersImport_Click(object sender, RoutedEventArgs e)
        {
            if (this.tournament.Rounds.Count > 0)
            {
                if (PMW.Show(StringTable.MainWindow_ResetTournament, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            }

            OpenFileDialog openDialog = new OpenFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiGraczy + " (*.anp)|*.anp",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                AddExtension = true,
                DefaultExt = ".anp",
                CheckPathExists = true,
                CheckFileExists = true,
            };

            if (openDialog.ShowDialog() == true)
            {
                this.BusyIndicator.IsBusy = true;
                List<Player> playerList = Tournament.LoadPlayers(openDialog.FileName);
                if (playerList == null) return;

                this.tournament = new Tournament();

                foreach (Player player in playerList)
                {
                    player.Active = true;
                    player.Bucholz = 0;
                    player.CorpoWins = 0;
                    player.DeckCheck = false;
                    player.DiceCount = 0;
                    player.GamesDraw = 0;
                    player.GamesWin = 0;
                    player.GamesLoose = 0;
                    player.MBucholz = 0;
                    player.Place = 0;
                    player.Points = 0;
                    player.RankBeforeTournament = 0;
                    player.SmallPointsMinus = 0;
                    player.SmallPointsPlus = 0;
                    player.Payment = false;
                    player.SuperBYE = false;
                    this.tournament.AddPlayer(player);
                }

                this.tournament.RefreshPointsTable();
                this.RefreshTournamentDataContexts();
                this.BusyIndicator.IsBusy = false;
            }
        }

        private void mniPlayersSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiGraczy + " (*.anp)|*.anp",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".anp",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.BusyIndicator.IsBusy = true;
                Tournament.SavePlayers(this.tournament, saveDialog.FileName);
                this.BusyIndicator.IsBusy = false;
            }
        }

        private void mniPlayersDeckcheck_Click(object sender, RoutedEventArgs e)
        {
            DeckCheckWindow frmDC = new DeckCheckWindow(this.tournament.PointsTable);
            frmDC.ShowDialog();
        }

        private void mniPlayersImportGalakta_Click(object sender, RoutedEventArgs e)
        {
            GalaktaPlayersWindow frmPlayers = new GalaktaPlayersWindow() { Owner = this };
            if (frmPlayers.ShowDialog() == true)
            {
                foreach (var item in GalaktaPlayersWindow.GalaktaPlayersList.Where(p => p.Selected == true))
                {
                    if (string.IsNullOrEmpty(item.Player.Alias))
                    {
                        item.Player.Alias = item.Player.NameSurname;
                    }

                    if (this.tournament.PointsTable.Where(p => p.Alias == item.Player.Alias).Count() > 0)
                    {
                        new PMW(StringTable.MainWindow_PlayerExists);
                        continue;
                    }

                    this.tournament.AddPlayer(item.Player);
                }
            }
        }

        private void mniExportTablePointsToTxt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiTXT + " (*.txt)|*.txt",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".txt",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.ExportTablePointsAsTxt(saveDialog.FileName);
            }
        }

        private void mniExportTablePointsToTxtFormatted_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiTXT + " (*.txt)|*.txt",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".txt",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.ExportTablePointsAsTxtFormatted(saveDialog.FileName);
            }
        }

        private void mniExportRoundsToTxtFormatted_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiTXT + " (*.txt)|*.txt",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".txt",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.ExportRoundsAsTxtFormatted(saveDialog.FileName);
            }
        }

        private void mniExportFinalResultsToTxtFormatted_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiTXT + " (*.txt)|*.txt",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".txt",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.ExportFinalResultsAsTxtFormatted(saveDialog.FileName);
            }
        }

        private void mniExportTablePointsToHTML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiHTML + " (*.html)|*.html",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".html",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.ExportTablePointsAsHTML(saveDialog.FileName);
            }
        }

        private void mniExportFinalResultsToHTML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = StringTable.MainWindow_PlikiHTML + " (*.html)|*.html",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".html",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.ExportFinalResultsAsHTML(saveDialog.FileName);
            }
        }

        private void mniExportTournamentToGalakta_Click(object sender, RoutedEventArgs e)
        {
            if (this.tournament == null) return;

            if (this.tournament.PointsTable.Count(p => p.IdGalakta <= 0) > 0)
            {
                new PMW("Aby wyeksportować wyniki do rankingu wszyscy gracze muszą być zsynchronizowani.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = "Pliki galakta (*.galakta)|*.galakta",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".galakta",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                this.tournament.ExportToGalakta(saveDialog.FileName);
            }
        }

        private void mniSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow frmSettings = new SettingsWindow();
            frmSettings.ShowDialog();

            this.colDiceCount.Visibility = System.Windows.Visibility.Collapsed;

            this.colDeckcheck.Visibility = App.Settings.ColumnDC ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.colGalakta.Visibility = App.Settings.ColumnG ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.colPayment.Visibility = App.Settings.ColumnPayment ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            this.colRankBeforeTournament.Visibility = App.Settings.ColumnRank ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

            foreach (Game game in this.tournament.Rounds.SelectMany(r => r.Games).Where(g => g.Player2Id == Guid.Empty && g.IsBYE == true))
            {
                game.Player1Dice = App.Settings.BYEHasDice;
            }
        }

        private void mniHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow frmAbout = new AboutWindow();
            frmAbout.ShowDialog();
        }

        private void mniExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        private void FinalResultsFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(this.dgFinalResults.ItemsSource) as ListCollectionView;
            view.Filter = item =>
            {
                TextBox control = sender as TextBox;
                if (control == null || string.IsNullOrEmpty(control.Text))
                    return true;
                bool show = true;
                FinalResult result = item as FinalResult;
                if (result != null)
                {
                    show = result.Player.Alias.ToLower().Contains(control.Text.ToLower());
                }
                return show;
            };
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(this.dgPointsTable.ItemsSource) as ListCollectionView;
            view.Filter = item =>
            {
                TextBox control = sender as TextBox;
                if (control == null || string.IsNullOrEmpty(control.Text))
                    return true;
                bool show = true;
                Player player = item as Player;
                if (player != null)
                {
                    show = player.Alias.ToLower().Contains(control.Text.ToLower());
                }
                return show;
            };
        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (((System.Windows.Input.RoutedCommand)(e.Command)).Name == "Save")
            {
                this.mniSave_Click(sender, new RoutedEventArgs());
            }

            if (((System.Windows.Input.RoutedCommand)(e.Command)).Name == "Open")
            {
                this.mniOpen_Click(sender, new RoutedEventArgs());
            }
        }

        private void RefreshTournamentDataContexts()
        {
            this.tournament.PlayerPlaceChanged += new EventHandler(tournament_PlayerPlaceChanged);
            this.DataContext = this.tournament;
            this.ctrlPlayoffs16.DataContext = null;
            this.ctrlPlayoffs16.DataContext = this.tournament.Playoffs16;

            this.ctrlPlayoffs8.DataContext = null;
            this.ctrlPlayoffs8.DataContext = this.tournament.Playoffs8;

            this.tournament_PlayerPlaceChanged(null, null);

            if (this.tabRound.Items.Count != 0)
            {
                (this.tabRound.Items[this.tabRound.Items.Count - 1] as Round).ScoreEnabled = true;
                this.tabRound.SelectedIndex = this.tabRound.Items.Count - 1;
            }

            this.SortFinalResults();
        }

        private void SortFinalResults()
        {
            SortDescription tablesort = new SortDescription("FinalPlace", ListSortDirection.Ascending);
            this.dgFinalResults.Items.SortDescriptions.Clear();
            this.dgFinalResults.Items.SortDescriptions.Add(tablesort);
        }

        #region Export do TXT

        private bool ExportTablePointsAsTxt(string path)
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendLine(string.Format("#;{0};{1};{2};{3};{4};{5};{6};{7};+/-;{8};",
                                                StringTable.MainWindow_Gracz,
                                                StringTable.MainWindow_FrakcjaCorpo,
                                                "CID",
                                                StringTable.MainWindow_FrakcjaRunner,
                                                "RID",
                                                StringTable.MainWindow_LiczbaGier,
                                                StringTable.MainWindow_Punkty,
                                                StringTable.MainWindow_B,
                                                StringTable.MainWindow_WRP));

            foreach (Player player in this.tournament.PointsTable.OrderBy(p => p.Place))
            {
                strBuilder.AppendFormat("{0};", player.Place.ToString());
                strBuilder.AppendFormat("{0} '{1}' {2};", player.Name, player.Alias, player.Surname);
                strBuilder.AppendFormat("{0};", player.RaceCorpo.ToString());
                strBuilder.AppendFormat("{0};", player.CorpoIdentity);
                strBuilder.AppendFormat("{0};", player.RaceRunner.ToString());
                strBuilder.AppendFormat("{0};", player.RunnerIdentity);
                strBuilder.AppendFormat("{0};", player.GamesCount);
                strBuilder.AppendFormat("{0};", player.Points.ToString());
                strBuilder.AppendFormat("{0};", player.Bucholz.ToString());
                strBuilder.AppendFormat("{0};", player.SmallPointsPlusMinus);
                strBuilder.AppendFormat("{0};", player.GamesWinDrawLoose);
                strBuilder.AppendLine();
            }

            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.Write(strBuilder.ToString());
            }

            return true;
        }

        private bool ExportTablePointsAsTxtFormatted(string path)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("[code=html:0]");
            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
            strBuilder.AppendLine(string.Format("|  #  | {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} |  +/-  |  {8}  |",
                                                StringTable.MainWindow_Gracz.PadRight(33, ' '),
                                                StringTable.MainWindow_FrakCorp.PadRight(8, ' '),
                                                "CID".PadRight(43, ' '),
                                                StringTable.MainWindow_FrakRun.PadRight(8, ' '),
                                                "RID".PadRight(43, ' '),
                                                StringTable.MainWindow_LG.PadRight(2, ' '),
                                                StringTable.MainWindow_Punkty.PadRight(6, ' '),
                                                StringTable.MainWindow_B.PadLeft(3, ' '),
                                                StringTable.MainWindow_WRP));
            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");

            foreach (Player player in this.tournament.PointsTable.OrderBy(p => p.Place))
            {
                string name = string.Format("{0} '{1}' {2}", player.Name, player.Alias, player.Surname);
                if (name.Length > 33) name = name.Substring(0, 33);

                string corpoID = string.IsNullOrEmpty(player.CorpoIdentity) ? "" : player.CorpoIdentity;
                string runnerID = string.IsNullOrEmpty(player.RunnerIdentity) ? "" : player.RunnerIdentity;

                strBuilder.AppendFormat("| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} |",
                                         player.Place.ToString().PadLeft(3, ' '),
                                         name.PadRight(33, ' '),
                                         Enums.RaceCorpoToString(player.RaceCorpo).PadRight(8, ' '),
                                         corpoID.PadRight(43, ' '),
                                         Enums.RaceRunnerToString(player.RaceRunner).PadRight(8, ' '),
                                         runnerID.PadRight(43, ' '),
                                         player.GamesCount.ToString().PadLeft(2, ' '),
                                         player.Points.ToString().PadLeft(6, ' '),
                                         player.Bucholz.ToString().PadLeft(3, ' '),
                                         player.SmallPointsPlusMinus.ToString().PadLeft(5, ' '),
                                         player.GamesWinDrawLoose.ToString().PadLeft(7, ' '));
                strBuilder.AppendLine();
            }

            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
            strBuilder.AppendLine("[/code]");

            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.Write(strBuilder.ToString());
            }

            return true;
        }

        private bool ExportTablePointsAsHTML(string path)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("<style type=\"text/css\">");
            strBuilder.AppendLine("table {vertical-align: middle}");
            strBuilder.AppendLine("thead {border:solid 2px; border-color:black}");
            strBuilder.AppendLine("tr {background-color:#fff;}");
            strBuilder.AppendLine("tr:hover {background-color:#efefef;}");
            strBuilder.AppendLine("th {padding: 2px 6px 2px 6px;}");
            strBuilder.AppendLine("td {padding: 2px 6px 2px 6px;} ");
            strBuilder.AppendLine("</style>");

            strBuilder.AppendLine("<table rules=\"cols\" border=\"1\">");
            strBuilder.AppendLine("<thead>");
            strBuilder.AppendLine("<tr>");
            strBuilder.AppendLine("    <th>#</th>");
            strBuilder.AppendLine(string.Format("	   <th>{0}</th>", StringTable.MainWindow_Gracz));
            strBuilder.AppendLine("    <th>CID</th>");
            strBuilder.AppendLine("    <th>RID</th>");
            strBuilder.AppendLine(string.Format("	   <th>{0}</th>", StringTable.MainWindow_LG));
            strBuilder.AppendLine(string.Format("	   <th>{0}</th>", StringTable.MainWindow_Punkty));
            strBuilder.AppendLine(string.Format("	   <th>{0}</th>", StringTable.MainWindow_B));
            strBuilder.AppendLine("	<th>+/-</th>");
            strBuilder.AppendLine(string.Format("	   <th>{0}</th>", StringTable.MainWindow_WRP));
            strBuilder.AppendLine("</tr>");
            strBuilder.AppendLine("</thead>");
            strBuilder.AppendLine("<tbody>");

            foreach (Player player in this.tournament.PointsTable.OrderBy(p => p.Place))
            {
                string name = string.Format("{0} '{1}' {2}", player.Name, player.Alias, player.Surname);
                if (name.Length > 33) name = name.Substring(0, 33);

                string corpoID = string.IsNullOrEmpty(player.CorpoIdentity) ? "" : player.CorpoIdentity;
                string runnerID = string.IsNullOrEmpty(player.RunnerIdentity) ? "" : player.RunnerIdentity;

                strBuilder.AppendLine("<tr>");
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", player.Place.ToString()));
                strBuilder.AppendLine(string.Format("    <td>{0}</td>", name));
                strBuilder.AppendLine(string.Format("    <td>{0}</td>", corpoID));
                strBuilder.AppendLine(string.Format("    <td>{0}</td>", runnerID));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", player.GamesCount.ToString()));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", player.Points));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", player.Bucholz.ToString()));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", player.SmallPointsPlusMinus));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", player.GamesWinDrawLoose));
                strBuilder.AppendLine("</tr>");
            }

            strBuilder.AppendLine("</tbody>");
            strBuilder.AppendLine("</table>");

            using (StreamWriter outfile = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8))
            {
                outfile.Write(strBuilder.ToString());
            }

            return true;
        }


        private bool ExportRoundsAsTxtFormatted(string path)
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (Round round in this.tournament.Rounds)
            {
                strBuilder.AppendLine("[code=html:0]");
                strBuilder.AppendLine("+---------------------------------------------------------+");
                strBuilder.AppendFormat("+- {1} {0} --------------------------------------------+", round.Number.ToString().PadLeft(2, ' '), StringTable.CreateRoundWindow_Runda.PadRight(7, ' '));
                strBuilder.AppendLine();
                strBuilder.AppendLine("+---------------------------------------------------------+");
                string wynik = (StringTable.RoundControl_Wynik.Length > 5 ? StringTable.RoundControl_Wynik.Substring(0, 5) : StringTable.RoundControl_Wynik);
                strBuilder.AppendFormat("|  #  | {0} | {2} | {1} |", StringTable.CreateRoundWindow_Gracz1.PadRight(19, ' '), StringTable.CreateRoundWindow_Gracz2.PadRight(19, ' '), wynik.PadRight(5, ' '));
                strBuilder.AppendLine();
                strBuilder.AppendLine("+---------------------------------------------------------+");

                foreach (Game game in round.Games)
                {
                    string name1 = string.Format("{0}", game.Player1Alias);
                    if (name1.Length > 19) name1 = name1.Substring(0, 19);

                    string name2 = string.Format("{0}", game.Player2Alias);
                    if (name2.Length > 19) name2 = name2.Substring(0, 19);

                    strBuilder.AppendFormat("| {0} | {1} | {2} | {3} |",
                                             game.Number.ToString().PadLeft(3, ' '),
                                             name1.PadLeft(19, ' '),
                                             game.Player1Score.ToString() + " : " + game.Player2Score.ToString(),//Enums.GameScoreToString(game.Score).PadRight(5, ' '),
                                             name2.PadRight(19, ' '));
                    strBuilder.AppendLine();
                }

                strBuilder.AppendLine("+---------------------------------------------------------+");
                strBuilder.AppendLine("[/code]");
                strBuilder.AppendLine();
                strBuilder.AppendLine();
            }

            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.Write(strBuilder.ToString());
            }

            return true;
        }

        private bool ExportFinalResultsAsTxtFormatted(string path)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("[code=html:0]");
            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
            strBuilder.AppendLine(string.Format("+--------------------------------------------------------------------------------    {0}     ------------------------------------------------------------------------------------+", StringTable.MainWindow_KlasyfikacjaKoncowa.PadRight(20, ' ')));
            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
            strBuilder.AppendLine(string.Format("|  #  | {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} |  +/-  |  {8}  |",
                                                StringTable.MainWindow_Gracz.PadRight(33, ' '),
                                                StringTable.MainWindow_FrakCorp.PadRight(8, ' '),
                                                "CID".PadRight(43, ' '),
                                                StringTable.MainWindow_FrakRun.PadRight(8, ' '),
                                                "RID".PadRight(43, ' '),
                                                StringTable.MainWindow_LG.PadRight(2, ' '),
                                                StringTable.MainWindow_Punkty.PadRight(6, ' '),
                                                StringTable.MainWindow_B.PadLeft(3, ' '),
                                                StringTable.MainWindow_WRP));
            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");

            foreach (FinalResult result in this.tournament.FinalResults.OrderBy(p => p.FinalPlace))
            {
                string name = string.Format("{0} '{1}' {2}", result.Player.Name, result.Player.Alias, result.Player.Surname);
                if (name.Length > 33) name = name.Substring(0, 33);

                string corpoID = string.IsNullOrEmpty(result.Player.CorpoIdentity) ? "" : result.Player.CorpoIdentity;
                string runnerID = string.IsNullOrEmpty(result.Player.RunnerIdentity) ? "" : result.Player.RunnerIdentity;

                strBuilder.AppendFormat("| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} |",
                                         result.Player.Place.ToString().PadLeft(3, ' '),
                                         name.PadRight(33, ' '),
                                         Enums.RaceCorpoToString(result.Player.RaceCorpo).PadRight(8, ' '),
                                         corpoID.PadRight(43, ' '),
                                         Enums.RaceRunnerToString(result.Player.RaceRunner).PadRight(8, ' '),
                                         runnerID.PadRight(43, ' '),
                                         result.Player.GamesCount.ToString().PadLeft(2, ' '),
                                         result.Player.Points.ToString().PadLeft(6, ' '),
                                         result.Player.Bucholz.ToString().PadLeft(3, ' '),
                                         result.Player.SmallPointsPlusMinus.ToString().PadLeft(5, ' '),
                                         result.Player.GamesWinDrawLoose.ToString().PadLeft(7, ' '));
                strBuilder.AppendLine();
            }

            strBuilder.AppendLine("+-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
            strBuilder.AppendLine("[/code]");

            using (StreamWriter outfile = new StreamWriter(path))
            {
                outfile.Write(strBuilder.ToString());
            }

            return true;
        }

        private bool ExportFinalResultsAsHTML(string path)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendLine("<style type=\"text/css\">");
            strBuilder.AppendLine("table {vertical-align: middle}");
            strBuilder.AppendLine("thead {border:solid 2px; border-color:black}");
            strBuilder.AppendLine("tr {background-color:#fff;}");
            strBuilder.AppendLine("tr:hover {background-color:#efefef;}");
            strBuilder.AppendLine("th {padding: 2px 6px 2px 6px;}");
            strBuilder.AppendLine("td {padding: 2px 6px 2px 6px;} ");
            strBuilder.AppendLine("</style>");

            strBuilder.AppendLine("<table rules=\"cols\" border=\"1\">");
            strBuilder.AppendLine("<thead>");
            strBuilder.AppendLine("<tr>");
            strBuilder.AppendLine("    <th>#</th>");
            strBuilder.AppendLine(string.Format("	   <th>{0}</th>", StringTable.MainWindow_Gracz));
            strBuilder.AppendLine("    <th>CID</th>");
            strBuilder.AppendLine("    <th>RID</th>");
            strBuilder.AppendLine(string.Format("    <th>{0}</th>", StringTable.MainWindow_LG));
            strBuilder.AppendLine(string.Format("    <th>{0}</th>", StringTable.MainWindow_Punkty));
            strBuilder.AppendLine(string.Format("    <th>{0}</th>", StringTable.MainWindow_B));
            strBuilder.AppendLine("	<th>+/-</th>");
            strBuilder.AppendLine(string.Format("    <th>{0}</th>", StringTable.MainWindow_WRP));
            strBuilder.AppendLine("</tr>");
            strBuilder.AppendLine("</thead>");
            strBuilder.AppendLine("<tbody>");

            foreach (FinalResult result in this.tournament.FinalResults.OrderBy(p => p.FinalPlace))
            {
                string name = string.Format("{0} '{1}' {2}", result.Player.Name, result.Player.Alias, result.Player.Surname);
                if (name.Length > 33) name = name.Substring(0, 33);

                string corpoID = string.IsNullOrEmpty(result.Player.CorpoIdentity) ? "" : result.Player.CorpoIdentity;
                string runnerID = string.IsNullOrEmpty(result.Player.RunnerIdentity) ? "" : result.Player.RunnerIdentity;

                strBuilder.AppendLine("<tr>");
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", result.FinalPlace.ToString()));
                strBuilder.AppendLine(string.Format("    <td>{0}</td>", name));
                strBuilder.AppendLine(string.Format("    <td>{0}</td>", corpoID));
                strBuilder.AppendLine(string.Format("    <td>{0}</td>", runnerID));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", result.Player.GamesCount.ToString()));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", result.Player.Points));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", result.Player.Bucholz.ToString()));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", result.Player.SmallPointsPlusMinus));
                strBuilder.AppendLine(string.Format("    <td align=\"center\">{0}</td>", result.Player.GamesWinDrawLoose));
                strBuilder.AppendLine("</tr>");
            }

            strBuilder.AppendLine("</tbody>");
            strBuilder.AppendLine("</table>");

            using (StreamWriter outfile = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8))
            {
                outfile.Write(strBuilder.ToString());
            }

            return true;
        }

        #endregion

        #region Tabela wyników context menu
        /*
        private void mniCorpoHB_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceCorpo = RaceCorpo.HaasBioroid;
        }

        private void mniCorpoJinteki_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceCorpo = RaceCorpo.Jinteki;
        }

        private void mniCorpoNBN_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceCorpo = RaceCorpo.NBN;
        }

        private void mniCorpoWeyland_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceCorpo = RaceCorpo.WeylandConsortium;
        }

        private void mniRunnerAnarch_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceRunner = RaceRunner.Anarch;
        }

        private void mniRunnerCriminal_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceRunner = RaceRunner.Criminal;
        }

        private void mniRunnerShaper_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceRunner = RaceRunner.Shaper;
        }

        private void mniRunnerApex_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceRunner = RaceRunner.Apex;
        }

        private void mniRunnerAdam_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceRunner = RaceRunner.Adam;
        }

        private void mniRunnerSunny_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.RaceRunner = RaceRunner.Sunny;
        }
        */

        private void mniGalaktaSynchro_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            GalaktaPlayersWindow players = new GalaktaPlayersWindow() { Owner = this };
            if (players.ShowDialog() == true)
            {
                if (GalaktaPlayersWindow.GalaktaPlayersList.Count(p => p.Selected == true) > 0)
                {
                    playerToEdit.IdGalakta = GalaktaPlayersWindow.GalaktaPlayersList.First(p => p.Selected == true).Player.IdGalakta;
                }
            }
        }

        private void mniGridPayment_Click(object sender, RoutedEventArgs e)
        {
            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.Payment = !playerToEdit.Payment;
        }

        private void mniGridSuperBYE_Click(object sender, RoutedEventArgs e)
        {
            if (this.tournament != null && this.tournament.Rounds.Count > 0) return;

            Player playerToEdit = this.dgPointsTable.SelectedItem as Player;
            if (playerToEdit == null) return;

            playerToEdit.SuperBYE = !playerToEdit.SuperBYE;

            if (this.tournament != null) this.tournament.RefreshPointsTable();
        }

        private void mniGridDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player playerToDel = this.dgPointsTable.SelectedItem as Player;
            if (playerToDel == null) return;


            if (this.tournament.Rounds.Count != 0)
            {
                if (PMW.Show(StringTable.MainWindow_PlayerDeactivate, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            }

            this.tournament.RemovePlayer(playerToDel);

            this.dgPointsTable.Items.Refresh();
        }

        private void mniGridActivatePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player playerToActivate = this.dgPointsTable.SelectedItem as Player;
            if (playerToActivate == null) return;

            if (this.tournament.Rounds.Count != 0)
            {
                if (PMW.Show(StringTable.MainWindow_PlayerActivate, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            }

            this.tournament.ActivatePlayer(playerToActivate);

            this.dgPointsTable.Items.Refresh();
        }

        private void mniGridDisqualificationPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player playerToDisqualify = this.dgPointsTable.SelectedItem as Player;
            if (playerToDisqualify == null) return;

            if (PMW.Show(StringTable.MainWindow_PlayerDisqualification, MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

            this.tournament.DisqualifyPlayer(playerToDisqualify);
        }

        #endregion


        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            if (this.cmbLanguage.SelectedValue.ToString() != "pl")
            {
                ContextMenu menu = sender as ContextMenu;
                if (menu == null) return;

                foreach (var item in menu.Items)
                {
                    MenuItem mni = item as MenuItem;
                    if (mni == null) continue;

                    if (mni.Name == "mniGalaktaSynchro")
                    {
                        mni.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
            }
            else
            {
                ContextMenu menu = sender as ContextMenu;
                if (menu == null) return;

                foreach (var item in menu.Items)
                {
                    MenuItem mni = item as MenuItem;
                    if (mni == null) continue;

                    if (mni.Name == "mniGalaktaSynchro")
                    {
                        mni.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
        }

        /*
        #region Export do jpg
        
        public void GetImageFromTablePoints()
        {
            this.grdTable.Children.Remove(this.dgPointsTable);
            wnd = new Window();
            wnd.Height = double.NaN;
            wnd.Width = double.NaN;
            wnd.DataContext = this.tournament;
            wnd.Content = this.dgPointsTable;
            wnd.Loaded += new RoutedEventHandler(wnd_Loaded);

            wnd.Show();
        }
        Window wnd;
        RenderTargetBitmap result;
        void wnd_Loaded(object sender, RoutedEventArgs e)
        {
            Size size = new Size(this.dgPointsTable.ActualWidth, this.dgPointsTable.ActualHeight);
            if (size.IsEmpty) return;

            RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual drawingvisual = new DrawingVisual();
            using (DrawingContext context = drawingvisual.RenderOpen())
            {
                context.DrawRectangle(new VisualBrush(this.dgPointsTable), null, new Rect(new Point(), size));
                context.Close();
            }

            wnd.Content = null;
            result.Render(drawingvisual);
            this.grdTable.Children.Add(this.dgPointsTable);
            wnd.Close();

            using (Stream stm = File.Create(@"c:\aaa.jpg"))
            {
                this.SaveAsJpg(result, stm);
            }
        }

        public void SaveAsJpg(RenderTargetBitmap src, Stream outputStream)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(src));

            encoder.Save(outputStream);
        }

        private void mniExportTablePointsToImage_Click(object sender, RoutedEventArgs e)
        {
            this.GetImageFromTablePoints();            
        }

        #endregion
        */
    }
}


/* 
    Poprawione/Zrobione:
    -
    -
    -
 */

/*
 * !!!!!!!!!!!!!!!!Także super by było jakby pole do podawania ID (combo wyboru Identity) obsługiwało wyszukiwanie tekstowe. Przy rozrastającej się ilości ID, znacznie usprawniłoby to dodawanie graczy.
 * 
 * 
 * 
 * 
 Na prośbę Tomka/morphine, opisy (v0.1.6) :
 
- statystyki frakcji bez graczy/bez zdefiniowanych frakcji graczy pokazują not a number (NaN) zamiast 0. Tekst wyjeżdza czasem poza okno (powiększyć okno)
- bardzo przydałby się jakiś help, nawet w formie pliku tekstowego, opisujący funkcjonalności i opcje (np. kolumny tabel są mało zrozumiałe na pierwszy rzut oka).
- przydatna byłaby opcja przypisania każdego gracza do grupy - albo uprzednio gdzieś ustalonej, albo po prostu jako wartość tekstowa. Przy losowaniu par, preferować graczy należących do różnych grup, jeśli to możliwe. Na pewno ma to sens dla 1 rundy, nie jestem pewien czy dla dalszych też, ale w sumie czemu nie. Używanie tego jako opcja (używaj w grup w 1 rundzie, we wszystkich, nie używaj) byłoby fajne dla turniejów międzymiastowych, gdzie gracze chcieliby częściej "wpadać" na ludzi nie ze swojej grupy/miasta, wciąż w obrębie Swiss. 
- możliwość przeprowadzenia rozgrywek ligowych - widzę, że jest już coś się w tym temacie tworzy. W ogólności, chodzi o ewentualne wsparcie rozgrywek z arbitralnie ułożonymi parami (np. każdy z każdym), gdzie kolejne gry niekoniecznie wykonywane są w formie pełnych rund. Żeby nie wywracać wszystkiego, w obecnym systemie dałoby się to chyba zrobić, dokładając sobie tyle rund ile trzeba i każdą ustawiając recznie - bez wymogu, że runda musi być pełna.
 
 
 */

/* mplain suggestions
 * 
 * 
 * 
 * 
 * There is a 'Players List' function, but it's really hard to use it. If I have 30 players stored in the database, but only 16 show up for the tournament, I now need to manually search and delete the players that I don't need. I might take me more time than to just write everything from the scratch. Could you maybe make a database that would have the list of all players, and I would have to select the ones I want, then press some button and the tournament would be generated with those players? It would be much more convenient that deleting those i don't need.
 */

/*
 * It would be useful if he added an option to print match slips for submitting results.
 * 
 * 
 * i have still some suggestions:

- manually pairing the round: i think it would be easyier to use, if on the right side the current round is given, and the user can manually get single matches out (to the left side) an put in another way back to the left. in most cases, i would just rearrange single matches instead the whole round. (just my 2 Cents )

- another Thing with manually Pairings: when i try to do that, the enemys of the current round are also locked. i think, that should not

- i would love to have the Chance for a cutsheet of the round. for me, i have a solution based on xslt:
http://www.blinckmann.eu/download/cutsheet.zip
just expand in anr-tournament-folder, save a tournament with minumum one round as "cutsheet.ant" in the Folder and open cutshet.xml with "open with Internet Explorer". sounds complicated? yes, but it works for me, and thats enough  (in case of different Printer-Options and different IE-Versions, on some Computers the sheet is wierd) but if you could include such a function in the round-dialog it would be really great! for many TO's 

- importing Players will import the payment-status as well. when i will Import Players, i want to use them for a new tournament. on registration i could mark the payment (while they pay) an delete all players without payment. 

- the new identity-support is great. i think it would be a bit easier, if the identities are listet in a catalog-file (for example XML). then the Software would be safe for the future 
 */


/* 
 * Dialog - Show all opponents of a certain player - to see who he played against already.
 * 
2. W eksporcie tabeli do txt brak kolumn CW i RW za to jest niepotrzebna MB.
3. Przy wpisywaniu wyników mogłoby być tak jak w inwazji domyślnie wpisany wynik -:-, bo teraz są 0 i jeszcze nie wpisane gry są od razu w tabeli uwzględnia wszystkie nieskończone mecze jako remisy.
 */
/* Z BGG
1) Split the statistic chart into two, one for Runner and one for Corporation. I find that it's not really meaningful to know what percentage of the total decks were Haas-Bioroid, when it would only be 50% if every Corporation was Haas-Bioroid. For our own statistics, I just multiplied all of the percentages by two to give them actual meaning.

2) The Wins / Draws / Loses column is a little deceptive with the new rules, since it makes it look like everyone is going to time. I understand that it represents whether matches were won or lost, but that seems like a very rare occurrence, so it might make more sense to represent this as wins, draws, and loses for games, not matches. This might just be my personal view, though, and it may not be shared by others.

3) It would be nice to have a way to allow players to be added to an in-progress round. We had two entrants who arrived two minutes into the first round, so we let them enter right away, paired against each other. I ended up having to delete the round and create another one manually with the same pairings to include them. I realize this is a fringe case, so it may not be worth implementing.

4) Adding a way to keep track of the win condition would be great as well, for statistical purposes. We kept track of flat-lines (and whether they were from net, meat, or brain damage), because our group was very interested to see how prevalent they are. It would be great to have that built right into this software.
 
1) When I gave my tournament report for our group, I realized that I didn't have information about what identities were being played. I would love the ability to add the identity for each side, with bo points if there's a pie chart that shows the split by identity instead of faction (both pie charts would be nice, though). In order to avoid having to update the software every time a new identity is added, you could just provide a text box for the Runner and Corporation sides for each player, where the user can simply type the name of the identity.

 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 - Eksport txt ze średnikami przebiegu gry (rundy) (gracz1;wynik11;wynik12;gracz2;wynik21;wynik22)
 - () Jeszcze jedna prośba od graczy: którym ID gramy z danej frakcji (Anarch: Noise, Wizzard etc.). - dwa pola tekstowe w graczu
 - (Selverin) jakiś niemiec prosił o dodanie możliwości rejestracji graczy z BYEm (zasady jak na worldsach gdzie kilku uprzywilejowanych graczy w "nagrodę" dostaje bye na pierwszą rundę)
  
 - blankiety do wpisywania wyniku z rundy
 
 - eksport wyników / rund / klasyfikacji końcowej do HTML
 
 - statystyki gier danej frakcji 
        Jinteki - ogólnie - wygrane 40% - przegrane 60%
                  Anarch  - wygrane 40% - przegrane 60%
                  Criminal- wygrane 75% - przegrane 25%
 
 - statystyki gracza - co wygrał i przegrał
   
 - Eksport Playoff (formated)
 */