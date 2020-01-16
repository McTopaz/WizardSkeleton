﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Wizard.Misc
{
    interface ITitle
    {
        string Text { get; set; }
        double Size { get; set; }
        Brush Color { get; set; }
    }
}
