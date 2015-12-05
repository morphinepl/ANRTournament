using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ANRTournament.Controls
{
    public class TournamentImportanceComboBox : ComboBox
    {
        private readonly Dictionary<TournamentImportance, string> itemsource = new Dictionary<TournamentImportance, string>();
                
        public TournamentImportanceComboBox()
        {
            if (!App.IsInDesignMode)
            {
                itemsource.Add(TournamentImportance.Local, "Lokalny");
                itemsource.Add(TournamentImportance.Big, "Duży turniej");
                itemsource.Add(TournamentImportance.Champioship, "Mistrzowski");                

                this.ItemsSource = this.itemsource;
                this.DisplayMemberPath = "Value";
                this.SelectedValuePath = "Key";
            }
        }
    }
}
