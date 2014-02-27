using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XSockets.Client;

namespace XSocketsConsoleClient
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread.Sleep(10000);   //To allow the console to be attached to the visual studio debugger.
            // Will throw here.
            string catalog = "";
            string filter = "";
            try
            {
                catalog = RoleEnvironment.GetConfigurationSettingValue("XSockets.PluginCatalog").ToString();
                filter = RoleEnvironment.GetConfigurationSettingValue("XSockets.PluginFilter").ToString();
            }
            catch (Exception)
            {
            }

            try
            {
                Console.WriteLine("Pluginsettings. Catalog: " + catalog);
                Console.WriteLine("Pluginsettings. Filter: " + filter);
                XSocketClient ws = new XSocketClient(@"ws://127.0.0.1:4502/Generic", "http://*", true);
                ws.OnOpen += (s, e) =>
                {
                    Console.WriteLine("Connected");
                };

                ws.OnClose += (s, e) =>
                {
                    Console.WriteLine("Disconnected");
                };

                ws.OnError += (s, e) =>
                {
                    Console.WriteLine("Error: " + e.ToString());
                };
                ws.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" - Exception connecting to XSockets: " + ex.ToString());
            }

            while (true)
            {
                Thread.Sleep(10000);

            }
        }
    }
}
