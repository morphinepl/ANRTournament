using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Markup;
using System.Xml;
using System.IO;
using ANRTournament.Objects;
using System.Collections.ObjectModel;
using ANRTournament.Resources;
using System.Security;

namespace ANRTournament
{
    public abstract class XamlTemplatePrinter
    {
        private static void PrintDocumentPaginator(XpsDocumentWriter xpsDocumentWriter, DocumentPaginator document)
        {
            xpsDocumentWriter.Write(document);
        }

        private static XpsDocumentWriter GetPrintXpsDocumentWriter(PrintQueue printQueue)
        {
            XpsDocumentWriter xpsWriter = PrintQueue.CreateXpsDocumentWriter(printQueue);
            return xpsWriter;
        }

        private static void PrintFlowDocument(PrintQueue printQueue, DocumentPaginator document)
        {
            XpsDocumentWriter xpsDocumentWriter = GetPrintXpsDocumentWriter(printQueue);
            PrintDocumentPaginator(xpsDocumentWriter, document);
        }

        private static PrintDialog GetPrintDialog()
        {
            PrintDialog printDialog;

            // Create a Print dialog.
            PrintDialog dlg = new PrintDialog();

            // Show the printer dialog.  If the return is "true",
            // the user made a valid selection and clicked "Ok".
            if (dlg.ShowDialog() == true)
                printDialog = dlg; // return the dialog the user selections.
            else
                printDialog = null;

            return printDialog;
        }

        private static void PrintDocument(IDocumentPaginatorSource flowDocument)
        {
            PrintDialog flowPrintDialog = XamlTemplatePrinter.GetPrintDialog();
            if (flowPrintDialog == null)
                return;

            PrintQueue flowPrintQueue = flowPrintDialog.PrintQueue;
            flowPrintQueue.CurrentJobSettings.Description = "ANRTournament Document";
            XamlTemplatePrinter.PrintFlowDocument(flowPrintQueue, flowDocument.DocumentPaginator);
        }

        private static IDocumentPaginatorSource RenderFlowDocumentTemplate(Round round)
        {
            string rawXamlText = GetRoundXamlString(round);

            //Use the XAML reader to create a FlowDocument from the XAML string.
            FlowDocument document = XamlReader.Load(new XmlTextReader(new StringReader(rawXamlText))) as FlowDocument;
            return document;
        }

        private static IDocumentPaginatorSource RenderFlowDocumentTemplate(ObservableCollection<Player> players)
        {
            string rawXamlText = GetPointsTableXamlString(players);

            //Use the XAML reader to create a FlowDocument from the XAML string.
            FlowDocument document = XamlReader.Load(new XmlTextReader(new StringReader(rawXamlText))) as FlowDocument;
            return document;
        }

        private static IDocumentPaginatorSource RenderFlowDocumentTemplate(ObservableCollection<FinalResult> results)
        {
            string rawXamlText = GetPointsTableXamlString(results);

            //Use the XAML reader to create a FlowDocument from the XAML string.
            FlowDocument document = XamlReader.Load(new XmlTextReader(new StringReader(rawXamlText))) as FlowDocument;
            return document;
        }

        private static IDocumentPaginatorSource RenderFlowDocumentTemplate(Playoffs playoffs, PlayoffRound round)
        {
            string rawXamlText = GetPlayoffsTableXamlString(playoffs, round);

            //Use the XAML reader to create a FlowDocument from the XAML string.
            FlowDocument document = XamlReader.Load(new XmlTextReader(new StringReader(rawXamlText))) as FlowDocument;
            return document;
        }

        #region XAML Strings

        private static string GetRoundXamlString(Round round)
        {
            StringBuilder xamlString = new StringBuilder();

            xamlString.AppendLine("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" ");
            xamlString.AppendLine(" ColumnWidth=\"400\" FontSize=\"16\" FontFamily=\"Arial\">");

            //Header
            xamlString.AppendLine("<Paragraph TextAlignment=\"Center\" FontSize=\"16pt\" FontWeight=\"Bold\">");
            xamlString.AppendFormat("{1} {0} ", round.Number, StringTable.RoundControl_Runda);
            xamlString.AppendLine("</Paragraph>");

            //Tabela gier
            xamlString.AppendLine("<Table CellSpacing=\"10\">");
            xamlString.AppendLine("<Table.Columns><TableColumn Width=\"100\"/><TableColumn Width=\"200\"/><TableColumn Width=\"200\"/></Table.Columns>");
            xamlString.AppendLine("<TableRowGroup>");

            //Header tabeli
            xamlString.AppendLine("<TableRow>");
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\" TextAlignment=\"Right\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Nr);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz1);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz2);
            xamlString.AppendLine();
            xamlString.AppendLine("</TableRow>");

            //wiersze tabeli
            int lp = 1;
            foreach (Game game in round.Games)
            {
                //co 10 pagebreak
                if (lp != 1 && (lp % 30) - 1 == 0)
                {
                    xamlString.AppendLine("</TableRowGroup>");
                    xamlString.AppendLine("</Table>");
                    xamlString.AppendLine("<Section BreakPageBefore=\"True\"/>");

                    //Header
                    xamlString.AppendLine("<Paragraph TextAlignment=\"Center\" FontSize=\"16pt\" FontWeight=\"Bold\">");
                    xamlString.AppendFormat("{1} {0} ", round.Number, StringTable.RoundControl_Runda);
                    xamlString.AppendLine("</Paragraph>");

                    //Tabela gier
                    xamlString.AppendLine("<Table CellSpacing=\"10\">");
                    xamlString.AppendLine("<Table.Columns><TableColumn Width=\"100\"/><TableColumn Width=\"200\"/><TableColumn Width=\"200\"/></Table.Columns>");
                    xamlString.AppendLine("<TableRowGroup>");

                    //Header tabeli
                    xamlString.AppendLine("<TableRow>");
                    xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\" TextAlignment=\"Right\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Nr);
                    xamlString.AppendLine();
                    xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz1);
                    xamlString.AppendLine();
                    xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz2);
                    xamlString.AppendLine();
                    xamlString.AppendLine("</TableRow>");
                }


                xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", game.Number.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(game.Player1Alias));
                xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", string.IsNullOrWhiteSpace(SecurityElement.Escape(game.Player2Alias)) ? "BYE" : SecurityElement.Escape(game.Player2Alias));
                xamlString.AppendLine("</TableRow>");
                lp++;
            }

            xamlString.AppendLine("</TableRowGroup>");
            xamlString.AppendLine("</Table>");

            //koniec dokumentu
            xamlString.AppendLine("</FlowDocument>");

            return xamlString.ToString();
        }

        private static string GetPointsTableXamlString(ObservableCollection<Player> players)
        {
            StringBuilder xamlString = new StringBuilder();

            xamlString.AppendLine("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" ");
            xamlString.AppendLine(" ColumnWidth=\"400\" FontSize=\"16\" FontFamily=\"Arial\">");

            //Header
            xamlString.AppendLine("<Paragraph TextAlignment=\"Center\" FontSize=\"16pt\" FontWeight=\"Bold\">");
            xamlString.Append(StringTable.MainWindow_TabelaWynikow);
            xamlString.AppendLine("</Paragraph>");

            //Tabela gier
            xamlString.AppendLine("<Table CellSpacing=\"10\">");
            xamlString.AppendLine("<Table.Columns><TableColumn Width=\"50\"/><TableColumn Width=\"300\"/><TableColumn Width=\"90\"/><TableColumn Width=\"70\"/><TableColumn Width=\"70\"/><TableColumn Width=\"70\"/></Table.Columns>");
            xamlString.AppendLine("<TableRowGroup>");

            //Header tabeli
            xamlString.AppendLine("<TableRow>");
            xamlString.AppendLine("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Right\">#</Paragraph></TableCell>");
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.MainWindow_Gracz);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_FrakcjaCorpo);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_FrakcjaRunner);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_Punkty);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_WRP);
            xamlString.AppendLine();
            xamlString.AppendLine("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">+/-</Paragraph></TableCell>");
            xamlString.AppendLine("</TableRow>");

            //wiersze tabeli
            int lp = 1;
            foreach (Player player in players.OrderBy(p => p.Place))
            {
                xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", player.Place.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph>{0} '{1}' {2}</Paragraph></TableCell>", SecurityElement.Escape(player.Name), SecurityElement.Escape(player.Alias), SecurityElement.Escape(player.Surname));
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", player.RaceCorpo.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", player.RaceRunner.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", player.Points.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", player.GamesWinDrawLoose);
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", player.SmallPointsPlusMinus);
                xamlString.AppendLine("</TableRow>");
                lp++;
            }

            xamlString.AppendLine("</TableRowGroup>");
            xamlString.AppendLine("</Table>");

            //koniec dokumentu
            xamlString.AppendLine("</FlowDocument>");

            return xamlString.ToString();
        }

        private static string GetPointsTableXamlString(ObservableCollection<FinalResult> finalResults)
        {
            StringBuilder xamlString = new StringBuilder();

            xamlString.AppendLine("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" ");
            xamlString.AppendLine(" ColumnWidth=\"400\" FontSize=\"16\" FontFamily=\"Arial\">");

            //Header
            xamlString.AppendLine("<Paragraph TextAlignment=\"Center\" FontSize=\"16pt\" FontWeight=\"Bold\">");
            xamlString.Append(StringTable.MainWindow_KlasyfikacjaKoncowa);
            xamlString.AppendLine("</Paragraph>");

            //Tabela gier
            xamlString.AppendLine("<Table CellSpacing=\"10\">");
            xamlString.AppendLine("<Table.Columns><TableColumn Width=\"50\"/><TableColumn Width=\"300\"/><TableColumn Width=\"90\"/><TableColumn Width=\"70\"/><TableColumn Width=\"70\"/><TableColumn Width=\"70\"/></Table.Columns>");
            xamlString.AppendLine("<TableRowGroup>");

            //Header tabeli
            xamlString.AppendLine("<TableRow>");
            xamlString.AppendLine("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Right\">#</Paragraph></TableCell>");
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.MainWindow_Gracz);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_FrakcjaCorpo);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_FrakcjaCorpo);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_Punkty);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">{0}</Paragraph></TableCell>", StringTable.MainWindow_WRP);
            xamlString.AppendLine();
            xamlString.AppendLine("<TableCell><Paragraph FontSize=\"13pt\" FontWeight=\"Bold\" TextAlignment=\"Center\">+/-</Paragraph></TableCell>");
            xamlString.AppendLine("</TableRow>");

            //wiersze tabeli
            int lp = 1;
            foreach (FinalResult result in finalResults.OrderBy(p => p.FinalPlace))
            {
                xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", result.FinalPlace.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph>{0} '{1}' {2}</Paragraph></TableCell>", SecurityElement.Escape(result.Player.Name), SecurityElement.Escape(result.Player.Alias), SecurityElement.Escape(result.Player.Surname));
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", result.Player.RaceCorpo.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", result.Player.RaceRunner.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", result.Player.Points.ToString());
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", result.Player.GamesWinDrawLoose);
                xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Center\">{0}</Paragraph></TableCell>", result.Player.SmallPointsPlusMinus);
                xamlString.AppendLine("</TableRow>");
                lp++;
            }

            xamlString.AppendLine("</TableRowGroup>");
            xamlString.AppendLine("</Table>");

            //koniec dokumentu
            xamlString.AppendLine("</FlowDocument>");

            return xamlString.ToString();
        }

        private static string GetPlayoffsTableXamlString(Playoffs playoffs, PlayoffRound round)
        {
            StringBuilder xamlString = new StringBuilder();

            xamlString.AppendLine("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" ");
            xamlString.AppendLine(" ColumnWidth=\"400\" FontSize=\"16\" FontFamily=\"Arial\">");

            //Header
            xamlString.AppendLine("<Paragraph TextAlignment=\"Center\" FontSize=\"16pt\" FontWeight=\"Bold\">");

            string header = string.Empty;
            switch (round)
            {
                case PlayoffRound.Final_16:
                    header = StringTable.MainWindow_1_16;
                    break;
                case PlayoffRound.Final_8:
                    header = StringTable.MainWindow_1_8;
                    break;
                case PlayoffRound.Final_4:
                    header = StringTable.MainWindow_1_4;
                    break;
                case PlayoffRound.Final_2:
                    header = StringTable.MainWindow_1_2;
                    break;
                case PlayoffRound.Final:
                    header = StringTable.MainWindow_Final;
                    break;
                default:
                    break;
            }

            xamlString.Append(header);
            xamlString.AppendLine("</Paragraph>");

            //Tabela gier
            xamlString.AppendLine("<Table CellSpacing=\"10\">");
            xamlString.AppendLine("<Table.Columns><TableColumn Width=\"100\"/><TableColumn Width=\"200\"/><TableColumn Width=\"200\"/></Table.Columns>");
            xamlString.AppendLine("<TableRowGroup>");

            //Header tabeli
            xamlString.AppendLine("<TableRow>");
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\" TextAlignment=\"Right\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Nr);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz1);
            xamlString.AppendLine();
            xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz2);
            xamlString.AppendLine();
            xamlString.AppendLine("</TableRow>");

            //wiersze tabeli
            int lp = 1;

            switch (round)
            {
                #region 1/16

                case PlayoffRound.Final_16:

                    if (!playoffs.IsFinal16()) break;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_01.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_01.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_02.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_02.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_03.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_03.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_04.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_04.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_05.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_05.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_06.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_06.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_07.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_07.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_08.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_08.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_09.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_09.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_10.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_10.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_11.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_11.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_12.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_12.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_13.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_13.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_14.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_14.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_15.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_15.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_16.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_16_16.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    break;

                #endregion

                #region 1/8

                case PlayoffRound.Final_8:

                    if (!playoffs.IsFinal8()) break;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_01.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_01.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_02.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_02.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_03.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_03.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_04.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_04.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_05.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_05.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_06.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_06.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_07.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_07.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_08.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_8_08.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    break;

                #endregion

                #region 1/4

                case PlayoffRound.Final_4:

                    if (!playoffs.IsFinal4()) break;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_01.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_01.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_02.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_02.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_03.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_03.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_04.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_4_04.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    break;

                #endregion

                #region 1/2

                case PlayoffRound.Final_2:

                    if (!playoffs.IsFinal2()) break;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_2_01.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_2_01.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    xamlString.AppendFormat("<TableRow {0}>", lp % 2 == 0 ? " Background=\"LightGray\"" : string.Empty);
                    xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_2_02.Player1Alias));
                    xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final_2_02.Player2Alias));
                    xamlString.AppendLine("</TableRow>");
                    lp++;

                    break;

                #endregion

                #region Final

                case PlayoffRound.Final:

                    if (playoffs.IsFinal())
                    {
                        xamlString.Append("<TableRow>");
                        xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                        xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final.Player1Alias));
                        xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Final.Player2Alias));
                        xamlString.AppendLine("</TableRow>");
                        lp++;
                    }

                    if (playoffs.IsGame3rd())
                    {
                        xamlString.AppendLine("</TableRowGroup>");
                        xamlString.AppendLine("</Table>");

                        xamlString.AppendLine("<Paragraph TextAlignment=\"Center\" FontSize=\"16pt\" FontWeight=\"Bold\"></Paragraph>");
                        xamlString.AppendFormat("<Paragraph TextAlignment=\"Center\" FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph>", StringTable.MainWindow_GraOTrzecieMiejsce);
                        xamlString.AppendLine();

                        //Tabela finału
                        xamlString.AppendLine("<Table CellSpacing=\"10\">");
                        xamlString.AppendLine("<Table.Columns><TableColumn Width=\"100\"/><TableColumn Width=\"200\"/><TableColumn Width=\"200\"/></Table.Columns>");
                        xamlString.AppendLine("<TableRowGroup>");

                        //Header tabeli
                        xamlString.AppendLine("<TableRow>");
                        xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\" TextAlignment=\"Right\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Nr);
                        xamlString.AppendLine();
                        xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz1);
                        xamlString.AppendLine();
                        xamlString.AppendFormat("<TableCell><Paragraph FontSize=\"16pt\" FontWeight=\"Bold\">{0}</Paragraph></TableCell>", StringTable.RoundControl_Gracz2);
                        xamlString.AppendLine();
                        xamlString.AppendLine("</TableRow>");

                        xamlString.Append("<TableRow>");
                        xamlString.AppendFormat("<TableCell><Paragraph TextAlignment=\"Right\">{0}</Paragraph></TableCell>", lp);
                        xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Game3rdPlace.Player1Alias));
                        xamlString.AppendFormat("<TableCell><Paragraph>{0}</Paragraph></TableCell>", SecurityElement.Escape(playoffs.Game3rdPlace.Player2Alias));
                        xamlString.AppendLine("</TableRow>");
                        lp++;
                    }

                    break;

                #endregion

                default:
                    break;
            }

            xamlString.AppendLine("</TableRowGroup>");
            xamlString.AppendLine("</Table>");

            //koniec dokumentu
            xamlString.AppendLine("</FlowDocument>");

            return xamlString.ToString();
        }
        
        #endregion

        public static void PrintRound(Round round)
        {
            if (round == null) return;
            IDocumentPaginatorSource flowDocument = XamlTemplatePrinter.RenderFlowDocumentTemplate(round);
            PrintDocument(flowDocument);
        }

        public static void PrintPointsTable(ObservableCollection<Player> playersTable)
        {
            if (playersTable == null) return;
            IDocumentPaginatorSource flowDocument = XamlTemplatePrinter.RenderFlowDocumentTemplate(playersTable);
            PrintDocument(flowDocument);
        }

        public static void PrintPlayoffs(Playoffs playoffs, PlayoffRound round)
        {
            if (playoffs == null) return;
            IDocumentPaginatorSource flowDocument = XamlTemplatePrinter.RenderFlowDocumentTemplate(playoffs, round);
            PrintDocument(flowDocument);
        }

        public static void PrintFinalResults(ObservableCollection<FinalResult> finalResults)
        {
            if (finalResults == null) return;
            IDocumentPaginatorSource flowDocument = XamlTemplatePrinter.RenderFlowDocumentTemplate(finalResults);
            PrintDocument(flowDocument);
        }
    }
}
