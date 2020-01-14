using System;
using System.Collections.Generic;
using System.Text;

using Wizard.Misc;
using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmStart : Page
    {
        public RelayCommand Language { get; private set; } = new RelayCommand();

        public vmStart()
        {
            Language.Callback += Language_Callback;
            Next = new Views.Pages.Main();
        }

        private void Language_Callback()
        {
        }
    }
}
