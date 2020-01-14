using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmMainWindow
    {
        public UserControl Page { get; set; }

        public vmMainWindow()
        {
            Page = new Views.Pages.Start();
            PageHandler.SetDisplayingPage(this);
        }
    }
}
