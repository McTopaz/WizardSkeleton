using System;
using System.Collections.Generic;
using System.Text;

using Wizard.Misc;
using Wizard.Views;
using Wizard.Views.Pages;

namespace Wizard.ViewModels
{
    class vmMainMenu : vmPageBase
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
            Container.Next = new Page(Next);
        }

        private void Config_Callback()
        {
            Next = new Config();
            Container.Next = new Page(Next);
        }

        private void Run_Callback()
        {
            Next = new Connect();
            Container.Next = new Page(Next);
            var vm = Container.Next.ViewModel as vmConnect;
            UpdateConnectViewModel(vm);
        }

        private void UpdateConnectViewModel(vmConnect vm)
        {
            var parameters = new EnableConnectFields()
            {
                DataBits = false,
                Parity = false,
                StopBits = false
            };

            vm.EnableFields = parameters;
            vm.UseNetwork = true;
        }
    }
}
