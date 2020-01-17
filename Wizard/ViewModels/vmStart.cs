using System;
using System.Collections.Generic;
using System.Text;

using Wizard.Views.Pages;
using Wizard.Misc;

using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmStart : vmPageBase
    {
        public RelayCommand Language { get; private set; } = new RelayCommand();

        public vmStart()
        {
            Language.Callback += Language_Callback;
            Title.Text = "Start";
            Next = new MainMenu();
        }

        private void Language_Callback()
        {
        }
    }
}
