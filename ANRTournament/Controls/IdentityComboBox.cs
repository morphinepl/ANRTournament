using ANRTournament.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ANRTournament.Controls
{
    public class CorpoIdentityComboBox : ComboBox
    {
        public CorpoIdentityComboBox()
        {
            if (!App.IsInDesignMode)
            {
                this.ItemsSource = CorpoIdentity.CorpoIdentities;
                //this.DisplayMemberPath = "IdentityName";
                this.SelectedValuePath = "IdentityName";
            }
        }
    }

    public class RunnerIdentityComboBox : ComboBox
    {
        public RunnerIdentityComboBox()
        {
            if (!App.IsInDesignMode)
            {
                this.ItemsSource = RunnerIdentity.RunnerIdentities;
                //this.DisplayMemberPath = "IdentityName";
                this.SelectedValuePath = "IdentityName";                
            }
        }
    }
}
