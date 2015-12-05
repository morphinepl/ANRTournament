using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ANRTournament.Resources;

namespace ANRTournament.Controls
{
    public class PlayoffRoundComboBox : ComboBox
    {
        private readonly Dictionary<PlayoffRound, string> itemsource = new Dictionary<PlayoffRound, string>();

        public PlayoffRoundComboBox()
        {
            if (!App.IsInDesignMode)
            {
                itemsource.Add(PlayoffRound.Final_16, "1/16");

                itemsource.Add(PlayoffRound.Final_8, "1/8");
                itemsource.Add(PlayoffRound.Final_4, "1/4");
                itemsource.Add(PlayoffRound.Final_2, "1/2");
                itemsource.Add(PlayoffRound.Final, StringTable.PlayoffRoundComboBox_Final);

                this.ItemsSource = this.itemsource;
                this.DisplayMemberPath = "Value";
                this.SelectedValuePath = "Key";

                this.SelectedValue = PlayoffRound.Final_16;
            }
        }

        public void SetTop32()
        {
            itemsource.Clear();
            itemsource.Add(PlayoffRound.Final_16, "1/16");

            itemsource.Add(PlayoffRound.Final_8, "1/8");
            itemsource.Add(PlayoffRound.Final_4, "1/4");
            itemsource.Add(PlayoffRound.Final_2, "1/2");
            itemsource.Add(PlayoffRound.Final, "Finał");

            this.ItemsSource = this.itemsource;
            this.DisplayMemberPath = "Value";
            this.SelectedValuePath = "Key";

            this.SelectedValue = PlayoffRound.Final_16;
        }

        public void SetTop16()
        {
            itemsource.Clear();
            
            itemsource.Add(PlayoffRound.Final_8, "1/8");
            itemsource.Add(PlayoffRound.Final_4, "1/4");
            itemsource.Add(PlayoffRound.Final_2, "1/2");
            itemsource.Add(PlayoffRound.Final, "Finał");

            this.ItemsSource = this.itemsource;
            this.DisplayMemberPath = "Value";
            this.SelectedValuePath = "Key";

            this.SelectedValue = PlayoffRound.Final_8;
        }

        public void SetTop8()
        {
            itemsource.Clear();
            itemsource.Add(PlayoffRound.Final_4, "1/4");
            itemsource.Add(PlayoffRound.Final_2, "1/2");
            itemsource.Add(PlayoffRound.Final, "Finał");

            this.ItemsSource = this.itemsource;
            this.DisplayMemberPath = "Value";
            this.SelectedValuePath = "Key";

            this.SelectedValue = PlayoffRound.Final_4;
        }

        public void SetTop4()
        {
            itemsource.Clear();
            
            itemsource.Add(PlayoffRound.Final_2, "1/2");
            itemsource.Add(PlayoffRound.Final, "Finał");

            this.ItemsSource = this.itemsource;
            this.DisplayMemberPath = "Value";
            this.SelectedValuePath = "Key";

            this.SelectedValue = PlayoffRound.Final_2;
        }

        public void SetTop2()
        {
            itemsource.Clear();

            itemsource.Add(PlayoffRound.Final, "Finał");

            this.ItemsSource = this.itemsource;
            this.DisplayMemberPath = "Value";
            this.SelectedValuePath = "Key";

            this.SelectedValue = PlayoffRound.Final;
        }
    }
}

