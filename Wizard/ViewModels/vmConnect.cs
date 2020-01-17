using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using Wizard.Views.Pages;
using Wizard.Misc;

using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmConnect : vmPageBase
    {
        public bool UseNetwork { get; set; } = true;
        public EnableConnectFields EnableFields { get; set; } = new EnableConnectFields();

        // Network
        public IPAddress IpAddress { get; set; } = IPAddress.Loopback;
        public double Port { get; set; } = 10001;
        public Protocols Protocol { get; set; } = Protocols.Udp;

        // Serial
        public string Comport { get; set; } = "";
        public int Baudrate { get; set; } = 2400;
        public int Databits { get; set; } = 8;
        public Paritys Parity { get; set; } = Paritys.Even;
        public StopBits StopBits { get; set; } = StopBits.One;

        public IEnumerable<string> Comports { get; private set; } = RJCP.IO.Ports.SerialPortStream.GetPortNames();
        public IEnumerable<int> Baudrates { get; private set; } = new int[] { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 };

        public vmConnect()
        {
            Title.Text = "Select communication method";
            Next = new Run();
        }
    }

    [AddINotifyPropertyChangedInterface]
    class EnableConnectFields
    {
        // Network
        public bool IpAddress { get; set; } = true;
        public bool Port { get; set; } = true;
        public bool Protocol { get; set; } = true;

        // Serial
        public bool Comport { get; set; } = true;
        public bool Baudrate { get; set; } = true;
        public bool DataBits { get; set; } = true;
        public bool Parity { get; set; } = true;
        public bool StopBits { get; set; } = true;
    }
}
