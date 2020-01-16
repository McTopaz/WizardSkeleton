using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

using Wizard.Misc;
using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHeader
    {
        public Brush Background { get; set; } = Brushes.CornflowerBlue;
        public Title Title { get; private set; } = new Title();

        public vmHeader()
        {
            PageHandler.Title = Title;
        }
    }
}
