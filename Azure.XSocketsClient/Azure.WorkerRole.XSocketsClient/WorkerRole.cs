using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Reflection;
using System.IO;

namespace Azure.XSocketsClientWorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        Process xsocketsClient;
        
        public override void Run()
        {
            Trace.TraceInformation("Azure.SimulatorWorker entry point called", "Information");

            xsocketsClient = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            string path = Assembly.GetExecutingAssembly().Location;

            startInfo.WorkingDirectory = Path.GetDirectoryName(path);
            startInfo.FileName = "Azure.XSocketsConsoleClient.exe";

            Trace.TraceInformation("Starting: " + Path.Combine(startInfo.WorkingDirectory, startInfo.FileName));

            xsocketsClient.StartInfo = startInfo;
            xsocketsClient.Start();

            while (true)
            {
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
