using System;
using System.Collections.Generic;
using System.Linq;
using XSockets.Core.Common.Configuration;
using XSockets.Core.Configuration;
using XSockets.Plugin.Framework.Attributes;


namespace Azure.XSocketsServer
{
    public class MyConfig : ConfigurationSetting
    {
        public MyConfig()
        {
            Endpoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 4502);
            Port = 4502;
            BufferSize = 8192;
            //RemoveInactiveStorageAfterXDays = 7;
            //RemoveInactiveChannelsAfterXMinutes = 30;
            NumberOfAllowedConections = -1;
        }
    }
}

