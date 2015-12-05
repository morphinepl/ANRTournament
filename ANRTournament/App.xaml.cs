using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Timers;
using ANRTournament.Objects;
using WPFLocalizeExtension.Engine;
using System.Globalization;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Timer splashTimer = new Timer(2000);
        private SplashScreen splashScreen = null;

        public static Settings Settings { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                return DesignerProperties.GetIsInDesignMode(new DependencyObject());
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            int splashnumber = DateTime.Now.Millisecond % 4;
            string splashPath = "Resources/splashScreen.png";

            switch (splashnumber)
            {
                case 1:
                    //splashPath = "Resources/splashScreen2.png";
                    break;

                case 2:
                    //splashPath = "Resources/splashScreen3.png";
                    break;

                case 3:
                    //splashPath = "Resources/splashScreen4.png";
                    break;

                case 0:
                default:
                    splashPath = "Resources/splashScreen.png";
                    break;
            }

            splashScreen = new SplashScreen(splashPath);
            splashTimer.Elapsed += new ElapsedEventHandler(splashTimer_Elapsed);
            splashTimer.Start();
            splashScreen.Show(false, true);

            try
            {
                if (!System.IO.File.Exists(RunnerIdentity.RunnersPath)) RunnerIdentity.Save();
                if (!System.IO.File.Exists(CorpoIdentity.CorpoPath)) CorpoIdentity.Save();

                RunnerIdentity.LoadRunnerIdentities();
                CorpoIdentity.LoadCorpoIdentities();

                Settings = Settings.LoadFromIni();
                Settings.DiceSystem = DiceSystem.Disabled;
            }
            catch
            {
                Settings = new Settings();
                Settings.SaveToIni();
            }
        }

        private void splashTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (splashTimer != null)
            {
                splashTimer.Stop();
                splashTimer.Close();
            }

            splashScreen.Close(new TimeSpan(0, 0, 2));

            splashTimer = null;
        }

        public static void SetLanguage(string lang)
        {
            LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(lang);
        }
    }
}
