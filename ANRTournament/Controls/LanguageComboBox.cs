using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ANRTournament.Controls
{
    public class LanguageComboBox : ComboBox
    {
        private readonly Dictionary<string, string> itemsource = new Dictionary<string, string>();

        public LanguageComboBox()
        {
            if (!App.IsInDesignMode)
            {
                itemsource.Add("pl", "Polski");
                itemsource.Add("en", "English");
                itemsource.Add("de", "Deutsch");
                

                this.ItemsSource = this.itemsource;
                this.DisplayMemberPath = "Value";
                this.SelectedValuePath = "Key";

                this.SelectedValue = App.Settings.Language;
                LanguageComboBox_SelectionChanged(null, null);
            }

            this.SelectionChanged += new SelectionChangedEventHandler(LanguageComboBox_SelectionChanged);
        }

        void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.SetLanguage(this.SelectedValue.ToString());
            App.Settings.Language = this.SelectedValue.ToString();
            App.Settings.SaveToIni();
        }
    }
}
