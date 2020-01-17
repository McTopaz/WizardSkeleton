using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using Wizard.Misc;

using PropertyChanged;

namespace Wizard.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class vmConnect : Page
    {
        public bool UseNetwork { get; set; } = true;
        public EnableConnectFields EnableParameters { get; set; } = new EnableConnectFields(true);

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

        public vmConnect()
        {
            Title.Text = "Select communication method";
            Next = new Views.Pages.Run();
        }
    }

    [AddINotifyPropertyChangedInterface]
    class EnableConnectFields
    {
        // Network
        public bool IpAddress { get; set; }
        public bool Port { get; set; }
        public bool Protocol { get; set; }

        // Serial
        public bool Comport { get; set; }
        public bool Baudrate { get; set; }
        public bool DataBits { get; set; }
        public bool Parity { get; set; }
        public bool StopBits { get; set; }

        public EnableConnectFields(bool useNetwork = true)
        {
            IpAddress = useNetwork;
            Port = useNetwork;
            Protocol = useNetwork;

            Comport = !useNetwork;
            Baudrate = !useNetwork;
            DataBits = !useNetwork;
            Parity = !useNetwork;
            StopBits = !useNetwork;
        }
    }
}
