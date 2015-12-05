using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ANRTournament.Controls
{
    public class GameScoreComboBox : ComboBox
    {
        private readonly Dictionary<GameScore, string> itemsource = new Dictionary<GameScore, string>();

        public GameScoreComboBox()
        {
            if (!App.IsInDesignMode)
            {
                itemsource.Add(GameScore.NotSet, "_ : _");

                itemsource.Add(GameScore.Score_2_1, "2 : 1");
                itemsource.Add(GameScore.Score_1_2, "1 : 2");
                itemsource.Add(GameScore.Score_0_2, "0 : 2");
                itemsource.Add(GameScore.Score_2_0, "2 : 0");
                itemsource.Add(GameScore.Score_1_1, "1 : 1");
                itemsource.Add(GameScore.Score_0_1, "0 : 1");
                itemsource.Add(GameScore.Score_1_0, "1 : 0");
                itemsource.Add(GameScore.Score_0_0, "0 : 0");

                itemsource.Add(GameScore.Score_BYE, "BYE");

                this.ItemsSource = this.itemsource;
                this.DisplayMemberPath = "Value";
                this.SelectedValuePath = "Key";
            }
        }

        public void OnlySettingsBYEScores()
        {
            itemsource.Remove(GameScore.NotSet);
            itemsource.Remove(GameScore.Score_2_1);
            itemsource.Remove(GameScore.Score_1_2);
            itemsource.Remove(GameScore.Score_0_2);
            itemsource.Remove(GameScore.Score_1_1);
            itemsource.Remove(GameScore.Score_0_1);
            itemsource.Remove(GameScore.Score_0_0);
            itemsource.Remove(GameScore.Score_BYE);
        }
    }
}
