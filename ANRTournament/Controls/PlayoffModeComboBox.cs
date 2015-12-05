
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ANRTournament.Controls
{
    public class PlayoffModeComboBox : ComboBox
    {
        private readonly Dictionary<PlayoffRound, string> itemsource = new Dictionary<PlayoffRound, string>();

        public PlayoffModeComboBox()
        {
            if (!App.IsInDesignMode)
            {
                itemsource.Add(PlayoffRound.Final_16, "32");

                itemsource.Add(PlayoffRound.Final_8, "16");
                itemsource.Add(PlayoffRound.Final_4, "8");
                itemsource.Add(PlayoffRound.Final_2, "4");
                itemsource.Add(PlayoffRound.Final, "2");

                this.ItemsSource = this.itemsource;
                this.DisplayMemberPath = "Value";
                this.SelectedValuePath = "Key";

                this.SelectedValue = PlayoffRound.Final_16;
            }
        }
    }
}
