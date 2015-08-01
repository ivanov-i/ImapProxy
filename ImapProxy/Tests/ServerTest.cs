using System.Net;
using System.Net.Sockets;
using System.Threading;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServerTest
    {
        public class Server : IServer
        {
            private static readonly AutoResetEvent H = new AutoResetEvent(false);
            public void Serve(TcpClient client)
            {
                H.Set();
            }

            public static bool Wait()
            {
                return H.WaitOne(5000);
            }
        }

        [TestMethod]
        public void ListensOnListenerAndAccepts()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 0);
            var listener = new Listener(tcpListener, new Server());
            listener.Listen();
            var endPoint = (IPEndPoint)tcpListener.LocalEndpoint;
            var port = endPoint.Port;
            Assert.AreNotEqual(0, port);
            var client = new TcpClient("localhost", port);
            Assert.IsTrue(client.Connected);
            Assert.IsTrue(Server.Wait());
            tcpListener.Stop();
        }
    }
}
