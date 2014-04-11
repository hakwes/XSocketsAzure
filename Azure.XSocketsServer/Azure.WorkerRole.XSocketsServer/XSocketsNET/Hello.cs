using System.Diagnostics;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Core.Common.Socket.Event.Interface;

namespace Azure.XSocketServer.XSocketsNET
{
    public class Hello : XSocketController
    {
        public void SendHello()
        {
            Trace.TraceInformation("Hello");
            this.Send("Hello", "SendHello");
        }

        public void HelloConfirmation()
        {
            Trace.TraceInformation("Hello Confirmation");
            this.Send("Hello confirmed", "HelloConfirmation");
        }

    }
}
