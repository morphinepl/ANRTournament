using System.Collections.Generic;
using System.Windows;
using ANRTournament.Objects;
using System.ComponentModel;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Controls;
using System.Xml;

namespace ANRTournament
{
    /// <summary>
    /// Interaction logic for GalaktaPlayersWindow.xaml
    /// </summary>
    public partial class GalaktaPlayersWindow : Window
    {
        public static ObservableCollection<GalaktaSelectingPlayer> GalaktaPlayersList { get; set; }        
        private BackgroundWorker bkgGetPlayers = new BackgroundWorker();
        private string errormessage = string.Empty;

        public GalaktaPlayersWindow()
        {
            InitializeComponent();
            
            this.bkgGetPlayers.DoWork += new DoWorkEventHandler(bkgGetPlayers_DoWork);
            this.bkgGetPlayers.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkgGetPlayers_RunWorkerCompleted);

            this.busyIndicator.IsBusy = true;
            this.bkgGetPlayers.RunWorkerAsync();
        }

        private void bkgGetPlayers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.errormessage))
                new PME("Błąd pobierania danych." + Environment.NewLine + this.errormessage);

            this.errormessage = string.Empty;

            this.dgPlayers.DataContext = GalaktaPlayersList;
            this.busyIndicator.IsBusy = false;
        }
        
        private void bkgGetPlayers_DoWork(object sender, DoWorkEventArgs e)
        {
            GalaktaPlayersList = new ObservableCollection<GalaktaSelectingPlayer>();

            try
            {
                WebClient cli = new WebClient() { Encoding = Encoding.UTF8 };
                string xml = cli.DownloadString("http://netrunner.galakta.pl/index.php?p=3");

                int pocz = xml.IndexOf("<table id=\"rounded-corner\" summary=\"Spis graczy\">");
                int kon = xml.IndexOf("</table>", pocz);
                xml = xml.Substring(pocz, kon - pocz + 8);

                xml = xml.Replace("text-align:left;", "")
                         .Replace("text-align:right;", "")
                         .Replace("text-align:center;", "")
                         .Replace("&", "&amp;");

                XDocument doc = XDocument.Parse(xml);

                var rows = doc.Root.Descendants("tbody").Descendants("tr").Where(p => p.Attribute("class").Value == "do_srodka");

                foreach (var item in rows)
                {
                    int idgalakta = 0;
                    string alias = "";  //item.Element("PlayerAlias").Value;
                    int rank = 0;       //Convert.ToInt32(string.IsNullOrWhiteSpace(item.Element("PlayerRank").Value) ? "0" : item.Element("PlayerRank").Value)
                    string name = "";   //item.Element("PlayerName").Value
                    string surname = "";//item.Element("PlayerSurname").Value

                    //IdGalakta
                    var ids = item.Descendants("a").Where(x => x.Attribute("href").Value.StartsWith("index.php?p=4&id_p="));
                    if (ids != null && ids.Count() > 0)
                    {
                        XElement playernode = ids.First();
                        if (!Int32.TryParse(playernode.Attribute("href").Value.Replace("index.php?p=4&id_p=", ""), out idgalakta)) continue;

                        //alias + imie + nazwisko
                        if (playernode.Value.Trim().Contains('"'))
                        {
                            string[] names = playernode.Value.Trim().Split('"');

                            if (names.Length == 3)
                            {
                                name = names[0].Trim();
                                alias = names[1].Trim();
                                surname = names[2].Trim();
                            }
                            else
                            {
                                alias = playernode.Value.Trim();
                            }
                        }
                        else
                        {
                            //Alias, Name, Surname
                            string[] names = playernode.Value.Trim().Split(' ');
                            if (names.Length == 2)
                            {
                                name = names[0].Trim();
                                surname = names[1].Trim();
                            }
                            else if (names.Length == 3)
                            {
                                name = names[0].Trim();
                                surname = names[1].Trim() + " " + names[2].Trim();
                            }
                            else
                            {
                                surname = playernode.Value.Trim();
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }




                    GalaktaSelectingPlayer player = new GalaktaSelectingPlayer()
                            {
                                Selected = false,
                                Player = new Player()
                                {
                                    IdGalakta = idgalakta,
                                    Alias = alias,
                                    RankBeforeTournament = rank,
                                    Name = name,
                                    Surname = surname,
                                }
                            };

                    GalaktaPlayersList.Add(player);
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }
        }
        
        /*
        private void bkgGetPlayers_DoWork(object sender, DoWorkEventArgs e)
        {
            this.PlayersList.Clear();

            try
            {
                WebClient cli = new WebClient() { Encoding = Encoding.UTF8 };
                string xml = cli.DownloadString("http://www.dominogry.pl/netrunner-lcg.pl/xml/xml.php");
                xml = xml.Replace("&amp;#322;", "ł")
                         .Replace("&amp;#321;", "Ł")

                         .Replace("&amp;#380;", "ż")
                         .Replace("&amp;#379;", "Ż")

                         .Replace("&amp;#281;", "ę")

                         .Replace("&amp;#347;", "ś")
                         .Replace("&amp;#346;", "Ś")

                         .Replace("&amp;#261;", "ą")

                         .Replace("&amp;#378;", "ź")
                         .Replace("&amp;#377;", "Ź")

                         .Replace("&amp;#324;", "ń")

                         ;

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(xml);

                XDocument doc = XDocument.Parse(xml);

                var list = (from item in doc.Root.Descendants("player")
                            select new GalaktaSelectingPlayer()
                            {
                                Selected = false,
                                Player = new Player()
                                {
                                    IdGalakta = Convert.ToInt32(item.Element("PlayerId").Value),
                                    Alias = item.Element("PlayerAlias").Value,
                                    RankBeforeTournament = Convert.ToInt32(string.IsNullOrWhiteSpace(item.Element("PlayerRank").Value) ? "0" : item.Element("PlayerRank").Value),
                                    Name = item.Element("PlayerName").Value,
                                    Surname = item.Element("PlayerSurname").Value,
                                }
                            });

                foreach (var item in list)
                {
                    PlayersList.Add(item);
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }
        }
        */
        

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(this.dgPlayers.ItemsSource) as ListCollectionView;
            view.Filter = item =>
            {
                if (string.IsNullOrEmpty(this.txtFilter.Text)) return true;

                bool show = true;
                GalaktaSelectingPlayer currentplayer = item as GalaktaSelectingPlayer;
                if (currentplayer != null)
                {
                    show = currentplayer.Player.Alias.ToLower().Contains(this.txtFilter.Text.ToLower()) ||
                           currentplayer.Player.Name.ToLower().Contains(this.txtFilter.Text.ToLower()) ||
                           currentplayer.Player.Surname.ToLower().Contains(this.txtFilter.Text.ToLower());
                }
                return show;
            };
        }

        private void txtFilter_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                this.btnSearch_Click(sender, new RoutedEventArgs());
            }
        }

        private void btnDeleteFilter_Click(object sender, RoutedEventArgs e)
        {
            this.txtFilter.Text = string.Empty;
            ListCollectionView view = CollectionViewSource.GetDefaultView(this.dgPlayers.ItemsSource) as ListCollectionView;
            view.Filter = item =>
            {
                return true;
            };
        }
    }
}
