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
using System.Collections.ObjectModel;
using PieControls;
using ANRTournament.Objects;
using ANRTournament.Resources;
using System.IO;
using Microsoft.Win32;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();            
        }

        public StatisticsWindow(Tournament tournament)
            : this()
        {
            #region Rozkład % korpo-runner

            SortedList<string, int> sortedStatRace = new SortedList<string, int>()
            {                
                { "iCH", tournament.PointsTable.Where(p => p.RaceCorpo == RaceCorpo.HaasBioroid).Count() },
                { "iCJ", tournament.PointsTable.Where(p => p.RaceCorpo == RaceCorpo.Jinteki).Count()  },
                { "iCN", tournament.PointsTable.Where(p => p.RaceCorpo == RaceCorpo.NBN).Count() },
                { "iCW", tournament.PointsTable.Where(p => p.RaceCorpo == RaceCorpo.WeylandConsortium).Count() },
                
                { "iRA", tournament.PointsTable.Where(p => p.RaceRunner == RaceRunner.Anarch).Count() },
                { "iRC", tournament.PointsTable.Where(p => p.RaceRunner == RaceRunner.Criminal).Count() },                
                { "iRS", tournament.PointsTable.Where(p => p.RaceRunner == RaceRunner.Shaper).Count() },                
            };

            ObservableCollection<PieSegment> raceStatCollection = new ObservableCollection<PieSegment>();

            foreach (var item in sortedStatRace)
            {
                string name = string.Empty;
                Color color = Colors.Black;

                switch (item.Key)
                {
                    case "iCH":
                        name = StringTable.MainWindow_CMenu_CorpoHB;
                        color = Colors.Violet;
                        break;

                    case "iCJ":
                        name = StringTable.MainWindow_CMenu_CorpoJinteki;
                        color = Colors.DarkRed;
                        break;

                    case "iCN":
                        name = StringTable.MainWindow_CMenu_CorpoNBN;
                        color = Colors.Gold;
                        break;

                    case "iCW":
                        name = StringTable.MainWindow_CMenu_CorpoWeyland;
                        color = Colors.DarkGreen;
                        break;

                    case "iRA":
                        name = StringTable.MainWindow_CMenu_RunnerAnarch;
                        color = Colors.OrangeRed;
                        break;

                    case "iRC":
                        name = StringTable.MainWindow_CMenu_RunnerCriminal;
                        color = Colors.Blue;
                        break;

                    case "iRS":
                        name = StringTable.MainWindow_CMenu_RunnerShaper;
                        color = Colors.LightGreen;
                        break;

                    default:
                        break;
                }

                raceStatCollection.Add(new PieSegment { Color = color, Value = item.Value, Name = name });
            }

            ctrlRaseChart.Data = raceStatCollection;

            #endregion

            #region Top 16

            if (tournament.PointsTable.Count > 16)
            {
                IEnumerable<Player> top16 = tournament.PointsTable.OrderBy(c => c.Place).Take(16);
                SortedList<string, int> sortedStatRaceTop = new SortedList<string, int>()
                {
                    { "iCH", top16.Where(p => p.RaceCorpo == RaceCorpo.HaasBioroid).Count() },
                    { "iCJ", top16.Where(p => p.RaceCorpo == RaceCorpo.Jinteki).Count()  },
                    { "iCN", top16.Where(p => p.RaceCorpo == RaceCorpo.NBN).Count() },
                    { "iCW", top16.Where(p => p.RaceCorpo == RaceCorpo.WeylandConsortium).Count() },
                
                    { "iRA", top16.Where(p => p.RaceRunner == RaceRunner.Anarch).Count() },
                    { "iRC", top16.Where(p => p.RaceRunner == RaceRunner.Criminal).Count() },                
                    { "iRS", top16.Where(p => p.RaceRunner == RaceRunner.Shaper).Count() },                    
                };

                ObservableCollection<PieSegment> raceStatCollectionTop = new ObservableCollection<PieSegment>();

                foreach (var item in sortedStatRaceTop)
                {
                    string name = string.Empty;
                    Color color = Colors.Black;

                    switch (item.Key)
                    {
                        case "iCH":
                            name = StringTable.MainWindow_CMenu_CorpoHB;
                            color = Colors.Violet;
                            break;

                        case "iCJ":
                            name = StringTable.MainWindow_CMenu_CorpoJinteki;
                            color = Colors.DarkRed;
                            break;

                        case "iCN":
                            name = StringTable.MainWindow_CMenu_CorpoNBN;
                            color = Colors.Gold;
                            break;

                        case "iCW":
                            name = StringTable.MainWindow_CMenu_CorpoWeyland;
                            color = Colors.DarkGreen;
                            break;

                        case "iRA":
                            name = StringTable.MainWindow_CMenu_RunnerAnarch;
                            color = Colors.OrangeRed;
                            break;

                        case "iRC":
                            name = StringTable.MainWindow_CMenu_RunnerCriminal;
                            color = Colors.Blue;
                            break;

                        case "iRS":
                            name = StringTable.MainWindow_CMenu_RunnerShaper;
                            color = Colors.LightGreen;
                            break;

                        default:
                            break;
                    }

                    raceStatCollectionTop.Add(new PieSegment { Color = color, Value = item.Value, Name = name });
                }

                ctrlRaseTopChart.Data = raceStatCollectionTop;
            }
            else
            {
                this.grpStatRaceTop.Visibility = System.Windows.Visibility.Collapsed;

            }
            #endregion

            #region Wygrane / Przegrane



            #endregion
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveAsJpg()
        {
            Size size = new Size(this.grdStat.ActualWidth, this.grdStat.ActualHeight);
            if (size.IsEmpty) return;

            RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);

            DrawingVisual drawingvisual = new DrawingVisual();
            using (DrawingContext context = drawingvisual.RenderOpen())
            {
                context.DrawRectangle(new VisualBrush(this.grdStat), null, new Rect(new Point(), size));
                context.Close();
            }

            result.Render(drawingvisual);

            SaveFileDialog saveDialog = new SaveFileDialog()
            {
                Filter = "JPG (*.jpg)|*.jpg",
                ValidateNames = true,
                InitialDirectory = Directory.GetCurrentDirectory(),
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = ".jpg",
                CheckPathExists = true,
            };

            if (saveDialog.ShowDialog() == true)
            {
                using (Stream stm = File.Create(saveDialog.FileName))
                {
                    this.SaveAsJpg(result, stm);
                }
            }
        }

        private void SaveAsJpg(RenderTargetBitmap src, Stream outputStream)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(src));

            encoder.Save(outputStream);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.SaveAsJpg();
        }
    }
}
