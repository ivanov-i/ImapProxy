using System.Net;
using System.Net.Sockets;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServerTest
    {
        [TestMethod]
        public void ListensOnListener()
        {
            var listener = new TcpListener(IPAddress.Any, 0);
            var server = new Server(listener);
            server.Serve();
            var endPoint = (IPEndPoint)listener.LocalEndpoint;
            var port = endPoint.Port;
            Assert.AreNotEqual(0, port);
            var client = new TcpClient("localhost", port);
            Assert.IsTrue(client.Connected);
            listener.Stop();
        }
    }
}
