using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Serialization;

namespace ANRTournament.Objects
{
    public class CorpoIdentity
    {
        public static readonly List<CorpoIdentity> CorpoIdentities = new List<CorpoIdentity>() 
        {
            new CorpoIdentity() { IdentityName = "Cerebral Imaging: Infinite Frontiers", Race = RaceCorpo.HaasBioroid, ForegroundColor = Brushes.Violet },
            new CorpoIdentity() { IdentityName = "Custom Biotics: Engineered for Success", Race = RaceCorpo.HaasBioroid, ForegroundColor = Brushes.Violet },
            new CorpoIdentity() { IdentityName = "Cybernetics Division: Humanity Upgraded", Race = RaceCorpo.HaasBioroid, ForegroundColor = Brushes.Violet },
            new CorpoIdentity() { IdentityName = "Haas-Bioroid: Engineering the Future", Race = RaceCorpo.HaasBioroid, ForegroundColor = Brushes.Violet },
            new CorpoIdentity() { IdentityName = "Haas-Bioroid: Stronger Together", Race = RaceCorpo.HaasBioroid, ForegroundColor = Brushes.Violet },
            new CorpoIdentity() { IdentityName = "NEXT Design: Guarding the Net", Race = RaceCorpo.HaasBioroid, ForegroundColor = Brushes.Violet },
            new CorpoIdentity() { IdentityName = "The Foundry: Refinning the Process", Race = RaceCorpo.HaasBioroid, ForegroundColor = Brushes.Violet },

            new CorpoIdentity() { IdentityName = "Chronos Protocol: Selective Mind-mapping", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Harmony Medtech: Biomedical Pioneer", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Industrial Genomics: Growing Solutions", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Jinteki Biotech: Life Imagined", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Jinteki: Personal Evolution", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Jinteki: Replicating Perfection", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Nisei Division: The Next Generation", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Pālanā Foods: Sustainable Growth", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },
            new CorpoIdentity() { IdentityName = "Tennin Institute: The Secrets Within", Race = RaceCorpo.Jinteki, ForegroundColor = Brushes.Red },

            new CorpoIdentity() { IdentityName = "Haarpsichord Studios: Entertainment Unleashed", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },
            new CorpoIdentity() { IdentityName = "Harishchandra Ent.: Where You're the Star", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },
            new CorpoIdentity() { IdentityName = "NBN: Making News", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },
            new CorpoIdentity() { IdentityName = "NBN: The World is Yours*", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },
            new CorpoIdentity() { IdentityName = "Near-Earth Hub: Broadcast Center", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },
            new CorpoIdentity() { IdentityName = "New Angeles Sol: Your News", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },
            new CorpoIdentity() { IdentityName = "Spark Agency: Worldswide Reach", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },
            new CorpoIdentity() { IdentityName = "SYNC: Everything, Everywhere", Race = RaceCorpo.NBN, ForegroundColor = Brushes.Yellow },

            new CorpoIdentity() { IdentityName = "Argus Security: Protection Guaranteed", Race = RaceCorpo.WeylandConsortium, ForegroundColor = Brushes.LightGreen },
            new CorpoIdentity() { IdentityName = "Blue Sun: Powering the Future", Race = RaceCorpo.WeylandConsortium, ForegroundColor = Brushes.LightGreen },
            new CorpoIdentity() { IdentityName = "Gagarin Deep Space: Expanding the Horizon", Race = RaceCorpo.WeylandConsortium, ForegroundColor = Brushes.LightGreen },
            new CorpoIdentity() { IdentityName = "GRNDL: Power Unleashed", Race = RaceCorpo.WeylandConsortium, ForegroundColor = Brushes.LightGreen },
            new CorpoIdentity() { IdentityName = "Titan Transnational: Investing In Your Future", Race = RaceCorpo.WeylandConsortium, ForegroundColor = Brushes.LightGreen },
            new CorpoIdentity() { IdentityName = "Weyland Consortium: Because We Built It", Race = RaceCorpo.WeylandConsortium, ForegroundColor = Brushes.LightGreen },
            new CorpoIdentity() { IdentityName = "Weyland Consortium: Building a Better World", Race = RaceCorpo.WeylandConsortium, ForegroundColor = Brushes.LightGreen }, 
        };

        public RaceCorpo Race { get; set; }
        public string IdentityName { get; set; }

        [XmlIgnoreAttribute]
        public Brush ForegroundColor { get; set; }

        [XmlIgnoreAttribute]
        public static string CorpoPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "Corpo.xml");

        public static bool Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(CorpoIdentities.GetType());
                TextWriter textWriter = new StreamWriter(CorpoPath);
                serializer.Serialize(textWriter, CorpoIdentities);
                textWriter.Close();
            }
            catch (Exception ex)
            {
                new PME(String.Format("Error saving corpo identities list.", CorpoPath, ex.Message));
                return false;
            }

            return true;
        }

        public static void LoadCorpoIdentities()
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<CorpoIdentity>));
                TextReader textReader = new StreamReader(CorpoPath);

                CorpoIdentities.Clear();
                foreach (var item in (List<CorpoIdentity>)deserializer.Deserialize(textReader))
                {
                    switch (item.Race)
                    {
                        case RaceCorpo.NotSet:
                        case RaceCorpo.HaasBioroid:
                            item.ForegroundColor = Brushes.Violet;
                            break;
                        case RaceCorpo.Jinteki:
                            item.ForegroundColor = Brushes.Red;
                            break;
                        case RaceCorpo.NBN:
                            item.ForegroundColor = Brushes.Yellow;
                            break;
                        case RaceCorpo.WeylandConsortium:
                            item.ForegroundColor = Brushes.LightGreen;
                            break;
                        default:
                            break;
                    }
                    CorpoIdentities.Add(item);
                }

                textReader.Close();
            }
            catch (Exception ex)
            {
                new PME(String.Format("Error loading corpo identities list", CorpoPath, ex.Message));
            }
        }
    }

    public class RunnerIdentity
    {
        public static readonly List<RunnerIdentity> RunnerIdentities = new List<RunnerIdentity>()
        {
            new RunnerIdentity() { IdentityName = "Edward Kim: Humanity's Hammer", Race = RaceRunner.Anarch, ForegroundColor = Brushes.Orange },
            new RunnerIdentity() { IdentityName = "MaxX: Maximum Punk Rock", Race = RaceRunner.Anarch, ForegroundColor = Brushes.Orange },
            new RunnerIdentity() { IdentityName = "Noise: Hacker Extraordinaire", Race = RaceRunner.Anarch, ForegroundColor = Brushes.Orange },
            new RunnerIdentity() { IdentityName = "Quetzal: Free Spirit", Race = RaceRunner.Anarch, ForegroundColor = Brushes.Orange },
            new RunnerIdentity() { IdentityName = "Reina Roja: Freedom Fighter", Race = RaceRunner.Anarch, ForegroundColor = Brushes.Orange},
            new RunnerIdentity() { IdentityName = "Valencia Estevez: The Angel of Cayambe", Race = RaceRunner.Anarch, ForegroundColor = Brushes.Orange },
            new RunnerIdentity() { IdentityName = "Whizzard: Master Gamer", Race = RaceRunner.Anarch, ForegroundColor = Brushes.Orange },

            new RunnerIdentity() { IdentityName = "Armand \"Geist\" Walker: Tech Lord", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Andromeda: Dispossessed Ristie", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Gabriel Santiago: Consummate Professional", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Iain Stirling: Retired Spook", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Ken \"Express\" Tenma: Disappeared Clone", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Laramy Fisk: Savvy Investor", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Leela Patel: Trained Pragmatist", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Nero Severn: Information Broker", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },
            new RunnerIdentity() { IdentityName = "Silhouette: Stealth Operative", Race = RaceRunner.Criminal, ForegroundColor = Brushes.LightBlue },

            new RunnerIdentity() { IdentityName = "Chaos Theory: Wünderkind", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },
            new RunnerIdentity() { IdentityName = "Exile: Streethawk", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },
            new RunnerIdentity() { IdentityName = "Hayley Kaplan: Universal Scholar", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },
            new RunnerIdentity() { IdentityName = "Jesminder Sareen: Girl Behind the Curtain", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },
            new RunnerIdentity() { IdentityName = "Kate \"Mac\" McCaffrey: Digital Tinker", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },
            new RunnerIdentity() { IdentityName = "Nasir Meidan: Cyber Explorer", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },
            new RunnerIdentity() { IdentityName = "Rielle \"Kit\" Peddler: Transhuman", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },            
            new RunnerIdentity() { IdentityName = "The Professor: Keeper of Knowledge", Race = RaceRunner.Shaper, ForegroundColor = Brushes.LightGreen },

            new RunnerIdentity() { IdentityName = "Apex: Invasive Predator", Race = RaceRunner.Apex, ForegroundColor = Brushes.OrangeRed },

            new RunnerIdentity() { IdentityName = "Adam: Compulsive Hacker", Race = RaceRunner.Adam, ForegroundColor = Brushes.Olive },

            new RunnerIdentity() { IdentityName = "Sunny Lebeau: Security Specialist", Race = RaceRunner.Sunny, ForegroundColor = Brushes.LightGray },
        };

        public RaceRunner Race { get; set; }
        public string IdentityName { get; set; }

        [XmlIgnoreAttribute]
        public Brush ForegroundColor { get; set; }

        [XmlIgnoreAttribute]
        public static string RunnersPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), "Runners.xml");

        public static bool Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(RunnerIdentities.GetType());
                TextWriter textWriter = new StreamWriter(RunnersPath);
                serializer.Serialize(textWriter, RunnerIdentities);
                textWriter.Close();
            }
            catch (Exception ex)
            {
                new PME(String.Format("Error saving runners identities list.", RunnersPath, ex.Message));
                return false;
            }

            return true;
        }

        public static void LoadRunnerIdentities()
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<RunnerIdentity>));
                TextReader textReader = new StreamReader(RunnersPath);

                RunnerIdentities.Clear();
                foreach (var item in (List<RunnerIdentity>)deserializer.Deserialize(textReader))
                {
                    switch (item.Race)
                    {
                        case RaceRunner.NotSet:
                        case RaceRunner.Anarch:
                            item.ForegroundColor = Brushes.Orange;
                            break;
                        case RaceRunner.Criminal:
                            item.ForegroundColor = Brushes.LightBlue;
                            break;
                        case RaceRunner.Shaper:
                            item.ForegroundColor = Brushes.LightGreen;
                            break;
                        case RaceRunner.Apex:
                            item.ForegroundColor = Brushes.OrangeRed;
                            break;
                        case RaceRunner.Adam:
                            item.ForegroundColor = Brushes.Olive;
                            break;
                        case RaceRunner.Sunny:
                            item.ForegroundColor = Brushes.LightGray;
                            break;
                        default:
                            break;
                    }

                    RunnerIdentities.Add(item);
                }

                textReader.Close();
            }
            catch (Exception ex)
            {
                new PME(String.Format("Error loading runners identities list", RunnersPath, ex.Message));
            }
        }

    }
}
