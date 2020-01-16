using System;
using System.Collections.Generic;
using System.Text;

using Wizard.Misc;
using Wizard.Views;
using Wizard.Views.Pages;

namespace Wizard.ViewModels
{
    class vmMainMenu : Page
    {
        public RelayCommand Search { get; set; } = new RelayCommand();
        public RelayCommand Config { get; set; } = new RelayCommand();
        public RelayCommand Run { get; set; } = new RelayCommand();

        public vmMainMenu()
        {
            Search.Callback += Search_Callback;
            Config.Callback += Config_Callback;
            Run.Callback += Run_Callback;
            Title.Text = "Main menu";
        }

        private void Search_Callback()
        {
            Next = new Search();
        }

        private void Config_Callback()
        {
            Next = new Config();
        }

        private void Run_Callback()
        {
            Next = new Connect();
        }
    }
}
