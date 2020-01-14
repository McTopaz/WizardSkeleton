using System;
using System.Collections.Generic;
using System.Text;

using Wizard.Misc;

namespace Wizard.ViewModels
{
    class vmMain : Page
    {
        public RelayCommand Search { get; set; } = new RelayCommand();
        public RelayCommand Config { get; set; } = new RelayCommand();
        public RelayCommand Run { get; set; } = new RelayCommand();

        public vmMain()
        {
            Search.Callback += Search_Callback;
            Config.Callback += Config_Callback;
            Run.Callback += Run_Callback;
        }

        private void Search_Callback()
        {
            Console.WriteLine("");
        }

        private void Config_Callback()
        {
            Console.WriteLine("");
        }

        private void Run_Callback()
        {
            Console.WriteLine("");
        }
    }
}
