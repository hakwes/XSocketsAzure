using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Azure.XSocketsServer;

namespace Azure.XSocketServer
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("Azure.XSocketServer entry point called", "Information");
            XSocketsBootstrap host;
            host = new XSocketsBootstrap();
            host.Start();

            // Just display the known plugins (XSockets Contollers )
            foreach (var plugin in host.XSocketPlugins)
            {
                Trace.TraceInformation(string.Format("Plugin {0} is registred and ready", plugin.Value.Alias));
            }
            while (true)
            {
                Trace.TraceInformation("Current number of Connections: " + host.CurrentNumberOfConnections);
                Thread.Sleep(10000);
            }


        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;
            return base.OnStart();
        }
    }
}
