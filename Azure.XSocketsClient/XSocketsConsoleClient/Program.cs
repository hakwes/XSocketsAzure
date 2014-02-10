using System;
using System.Collections.Generic;
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

            try
            {
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
