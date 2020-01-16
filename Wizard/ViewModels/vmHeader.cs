using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

using Wizard.Misc;
using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHeader : ITitle
    {
        public Brush Background { get; set; } = Brushes.CornflowerBlue;
        public string Text { get; set; } = "Title";
        public double Size { get; set; } = 20;
        public Brush Color { get; set; } = Brushes.White;

        public vmHeader()
        {
            PageHandler.Title = this;
        }
    }
}
