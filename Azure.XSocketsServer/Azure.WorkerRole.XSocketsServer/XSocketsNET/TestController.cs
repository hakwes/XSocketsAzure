using System.Diagnostics;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Core.Common.Socket.Event.Interface;

namespace Azure.XSocketServer.XSocketsNET
{
    public class TestController : XSocketController
    {
        public void Hello()
        {
            Trace.TraceInformation("Hello sent");
            this.SendToAll("Hello","Hello");
        }
    }
}
