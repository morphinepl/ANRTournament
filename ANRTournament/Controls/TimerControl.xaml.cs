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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;

namespace ANRTournament.Controls
{
    /// <summary>
    /// Interaction logic for TimerControl.xaml
    /// </summary>
    public partial class TimerControl : UserControl
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int secondsToEnd = 0;
        private int secondsStart = 0;
        private BigTimerWindow bigtimer = null;

        private readonly Dictionary<int, string> itemsource = new Dictionary<int, string>();

        public TimerControl()
        {
            InitializeComponent();

            if (!App.IsInDesignMode)
            {
                for (int i = 90; i > 0; i = i - 5)
                {
                    itemsource.Add(i, i.ToString());
                }

                this.cmbTime.ItemsSource = this.itemsource;
                this.cmbTime.DisplayMemberPath = "Value";
                this.cmbTime.SelectedValuePath = "Key";

                this.cmbTime.SelectedValue = 75;
            }

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.secondsToEnd > 0)
            {
                if (secondsToEnd == 300)
                {
                    try
                    {
                        string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "audio", "timer5end.wav");
                        SoundPlayer audio = new SoundPlayer(path);
                        audio.Play();
                    }
                    catch { }
                }
                this.secondsToEnd--;
            }
            else
            {
                //Koniec rundy 
                try
                {
                    string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "audio", "timerstop.wav");
                    SoundPlayer audio = new SoundPlayer(path);
                    audio.Play();
                }
                catch { }

                this.timer.Stop();
            }

            this.RefreshTime();
        }

        private void RefreshTime()
        {
            int hours = secondsToEnd / 3600;
            int minutes = (secondsToEnd % 3600) / 60;
            int seconds = (secondsToEnd % 3600) % 60;

            string time = string.Format("{0}:{1}:{2}",
                                        hours.ToString().PadLeft(2, '0'),
                                        minutes.ToString().PadLeft(2, '0'),
                                        seconds.ToString().PadLeft(2, '0'));

            this.lblTimer.Content = time;

            try
            {
                if (this.bigtimer != null)
                {
                    this.bigtimer.Time = time;
                }
            }
            catch { }
        }

        public void SetTimer(int seconds)
        {
            this.secondsToEnd = seconds;
            this.secondsStart = seconds;
        }

        public void StartTimer()
        {
            this.timer.Start();

            try
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "audio", "timerstart.wav");
                SoundPlayer audio = new SoundPlayer(path);
                audio.Play();
            }
            catch { }
        }

        public void StopTimer()
        {
            this.timer.Stop();
        }

        public void ResetTimer()
        {
            this.timer.Stop();
            this.secondsToEnd = secondsStart;
            this.RefreshTime();
            this.timer.Start();

            try
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "audio", "timerstart.wav");
                SoundPlayer audio = new SoundPlayer(path);
                audio.Play();
            }
            catch { }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this.StartTimer();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            this.StopTimer();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            this.ResetTimer();
        }

        private void btnSetTimer_Click(object sender, RoutedEventArgs e)
        {
            this.SetTimer((int)this.cmbTime.SelectedValue * 60);
            this.RefreshTime();
        }

        private void btnZoom_Click(object sender, RoutedEventArgs e)
        {
            this.bigtimer = null;
            this.bigtimer = new BigTimerWindow();
            this.bigtimer.ShowDialog();
        }
    }
}
