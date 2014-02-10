using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework;
using XSockets.Plugin.Framework.Attributes;

namespace Azure.XSocketsServer
{
    public class XSocketsBootstrap
    {
        private IXSocketServerContainer Wss;

        public XSocketsBootstrap()
        {
            Wss = XSockets.Plugin.Framework.Composable.GetExport<IXSocketServerContainer>();
        }
        public void Start()
        {

            Wss.StartServers(withInterceptors: true);
        }


        public void Stop()
        {
            Wss.StopServers();
        }

        public System.Collections.Generic.IEnumerable<XSockets.Plugin.Framework.WithMetaData<IXSocketController, IXSocketMetadata>> XSocketPlugins
        {
            get
            {
                return Wss.XSocketPlugins;
            }
        }

        public ulong CurrentNumberOfConnections
        {
            get
            {
                return Wss.CurrentNumberOfConnections;
            }
        }

        public ulong TotalNumberOfConnections
        {
            get
            {
                return Wss.TotalNumberOfConnections;
            }
        }
    }
}
