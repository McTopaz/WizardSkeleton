using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmHeader
    {
        public Brush Background { get; set; } = Brushes.CornflowerBlue;
        public string Title { get; set; } = "Title";
        public double TitleSize { get; set; } = 20;
        public Brush TitleColor { get; set; } = Brushes.White;
    }
}
