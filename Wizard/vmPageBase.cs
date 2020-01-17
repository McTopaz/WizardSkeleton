using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

using Wizard.Misc;
using Wizard.Views.Pages;

namespace Wizard
{
    abstract class vmPageBase
    {
        public Title Title { get; protected set; } = new Title();
        public UserControl Next { get; protected set; }
        public IPage Container { get; set; }
    }
}
