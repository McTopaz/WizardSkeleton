using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

using PropertyChanged;

namespace Wizard.Misc
{
    [AddINotifyPropertyChangedInterface]
    class Title
    {
        public string Text { get; set; }
        public double Size { get; set; }
        public Brush Color { get; set; }

        public Title()
        {
            Text = "Title";
            Size = 20;
            Color = Brushes.White;
        }
    }
}
