using System;
using System.Collections.Generic;
using System.Text;

using Wizard.Misc;
using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmFooter
    {
        public string Copyright { get; private set; } = "Copyright";
        public string Company { get; private set; } = "Company";
        public string Uri { get; private set; } = "http://www.google.se";
        public RelayCommand Hyperlink { get; private set; } = new RelayCommand();
        public string Version { get; private set; }

        public RelayCommand Back { get; private set; } = new RelayCommand();
        public RelayCommand Next { get; private set; } = new RelayCommand();
        public RelayCommand Exit { get; private set; } = new RelayCommand();

        public vmFooter()
        {
            Copyright = AquireCopyright();
            Company = AquireCompany();
            Hyperlink.Callback += Hyperlink_Callback;
            Version = AquireVersion();

            PageHandler.SetNavigationCommands(Back, Next, Exit);
        }

        private string AquireCopyright()
        {
            var year = DateTime.Now.Year;
            var tmp = $"©{year}";
            return tmp;
        }

        private string AquireCompany()
        {
            var file = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return file.CompanyName;
        }

        private void Hyperlink_Callback(object parameter)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = Uri,
                UseShellExecute = true  // Needed for .Net Core.
            };
            System.Diagnostics.Process.Start(psi);
        }

        private string AquireVersion()
        {
            var version = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion;
            var tmp = $"Version: {version}";
            return tmp;
        }
    }
}
