using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XSockets.Client40;

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
                XSocketClient ws = new XSocketClient(@"ws://127.0.0.1:4502/Hello", "http://*", true);
                ws.OnOpen += (s, e) =>
                {
                    Console.WriteLine("Connected");
                    // Start sending messages
                    while (true)
                    {
                        try
                        {
                            if (ws.IsConnected)
                            {
                                ws.Send("", "SendHello");
                            }
                        }
                        catch { }
                        Thread.Sleep(5000);

                    }
                };

                ws.OnClose += (s, e) =>
                {
                    Console.WriteLine("Disconnected");
                };

                ws.OnError += (s, e) =>
                {
                    Console.WriteLine("Error: " + e.data.ToString());
                };

                ws.Bind("SendHello", s =>
                {
                    try
                    {
                        Console.WriteLine("Hello received");
                        ws.Send("", "HelloConfirmation");
                        
                    }
                    catch
                    {
                        Console.WriteLine("Could not send ");
                    }
                });

                ws.Bind("HelloConfirmation", s =>
                {
                    try
                    {
                        Console.WriteLine("Hello confirmed");
                    }
                    catch
                    {
                        Console.WriteLine("Could not send ");
                    }
                });

                ws.Open();

                // Keep console alive
                while (true)
                {
                    Thread.Sleep(10000);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(" - Exception connecting to XSockets: " + ex.ToString());
            }

        }
    }
}
