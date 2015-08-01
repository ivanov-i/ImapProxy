using System.Net;
using System.Net.Sockets;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServerTest
    {
        public class Server : IServer
        {
            public static bool Worked { get; set; }
            public void Serve(TcpClient client)
            {
                Worked = true;
            }
        }

        [TestMethod]
        public void ListensOnListenerAndAccepts()
        {
            var listener = new TcpListener(IPAddress.Any, 0);
            var server = new Listener(listener, new Server());
            server.Listen();
            var endPoint = (IPEndPoint)listener.LocalEndpoint;
            var port = endPoint.Port;
            Assert.AreNotEqual(0, port);
            var client = new TcpClient("localhost", port);
            Assert.IsTrue(client.Connected);
            listener.Stop();
            Assert.IsTrue(Server.Worked);
        }
    }
}
