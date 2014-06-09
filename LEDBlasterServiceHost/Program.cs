using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LEDBlasterREST;

namespace LEDBlasterServiceHost
{
    class Program
    {
        private static ServiceHost _serviceHost;

        static void Main(string[] args)
        {
            try
            {
                _serviceHost = new ServiceHost(typeof(RGBLedService));

                // Returns a list of ipaddress configuration
                var ips = Dns.GetHostEntry(Dns.GetHostName());

                // Select the first entry. I hope it's this maschines IP
                var ipAddress = ips.AddressList.First(ipa => ipa.AddressFamily == AddressFamily.InterNetwork);

                _serviceHost.Opening += serviceHost_Opening;
                _serviceHost.Opened += serviceHost_Opened;
                _serviceHost.Closed += serviceHost_Closed;
                _serviceHost.Closing += serviceHost_Closing;
                _serviceHost.Open();
                Console.WriteLine("Your IP-Address: " + ipAddress);
                Console.WriteLine("Press ENTER to end service");
                Console.ReadLine();
                _serviceHost.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press ENTER to end service");
                Console.ReadLine();
                return;
            }
        }

        static void serviceHost_Closing(object sender, EventArgs e)
        {
            Console.WriteLine("Service closing ... stand by");
        }

        static void serviceHost_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Service closed");
        }

        static void serviceHost_Opening(object sender, EventArgs e)
        {
            Console.WriteLine("Service opening ... Stand by");
        }

        static void serviceHost_Opened(object sender, EventArgs e)
        {
            var urls = new String[] { string.Empty };
            Console.WriteLine("Service opened.");
            foreach (var address in _serviceHost.BaseAddresses)
            {
                Console.WriteLine("Service URL:\t" + address);
            }
            Console.WriteLine("Waiting for clients...");
        }
    }
}
