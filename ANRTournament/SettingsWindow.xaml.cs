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

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            //this.ctrlBYEScore.OnlySettingsBYEScores();
            this.chkMainTabSetting.IsChecked = App.Settings.MainTabSetting == Objects.Settings.MainTabSettings.PointsTableWithRoundsSeparate;            
            //this.ctrlBYEScore.SelectedValue = App.Settings.BYEScore;

            switch (App.Settings.DiceSystem)
            {
                case DiceSystem.OnlyRandom:
                    this.rdbRandom.IsChecked = true;
                    break;

                case DiceSystem.FullEnabled:
                    this.rdbEnabled.IsChecked = true;
                    break;

                case DiceSystem.Disabled:
                default:
                    this.rdbDisabled.IsChecked = true;
                    break;
            }

            this.chkColumnDC.IsChecked = App.Settings.ColumnDC;
            this.chkColumnGalakta.IsChecked = App.Settings.ColumnG;
            this.chkColumnPayment.IsChecked = App.Settings.ColumnPayment;            
            this.chkColumnRank.IsChecked = App.Settings.ColumnRank;
            this.chkBYEOnlyForLosers.IsChecked = App.Settings.BYEOnlyForLosers;
            this.chkAutoSave.IsChecked = App.Settings.AutoSave;
            this.chkBYEHasDice.IsChecked = App.Settings.BYEHasDice;
            this.chkRandomTieAfterPoints.IsChecked = App.Settings.RandomTieAfterPoints;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            App.Settings.MainTabSetting = this.chkMainTabSetting.IsChecked.Value ? Objects.Settings.MainTabSettings.PointsTableWithRoundsSeparate : Objects.Settings.MainTabSettings.PointsTableWithRoundsTogether;
            //App.Settings.BYEScore = (GameScore)ctrlBYEScore.SelectedValue;

            if (this.rdbRandom.IsChecked.Value)
            {
                App.Settings.DiceSystem = DiceSystem.OnlyRandom;
            }
            else if (this.rdbEnabled.IsChecked.Value)
            {
                App.Settings.DiceSystem = DiceSystem.FullEnabled;
            }
            else
            {
                App.Settings.DiceSystem = DiceSystem.Disabled;
            }

            App.Settings.ColumnDC = this.chkColumnDC.IsChecked.Value;
            App.Settings.ColumnG = this.chkColumnGalakta.IsChecked.Value;
            App.Settings.ColumnPayment = this.chkColumnPayment.IsChecked.Value;
            App.Settings.ColumnRank = this.chkColumnRank.IsChecked.Value;
            App.Settings.BYEOnlyForLosers = this.chkBYEOnlyForLosers.IsChecked.Value;
            App.Settings.AutoSave = this.chkAutoSave.IsChecked.Value;
            App.Settings.BYEHasDice = this.chkBYEHasDice.IsChecked.Value && this.rdbEnabled.IsChecked.Value;
            App.Settings.RandomTieAfterPoints = this.chkRandomTieAfterPoints.IsChecked.Value;

            App.Settings.SaveToIni();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void rdbDiceSystem_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (!this.rdbEnabled.IsChecked.Value) this.chkBYEHasDice.IsChecked = false;

            this.chkBYEHasDice.IsEnabled = rdbEnabled.IsChecked.Value;
        }
    }
}