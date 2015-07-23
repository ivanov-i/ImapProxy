using System.Net;
using System.Net.Sockets;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServerTest
    {
        public class Worker : IWorker
        {
            public static bool Worked { get; set; }
            public void Work(TcpClient client)
            {
                Worked = true;
            }
        }

        [TestMethod]
        public void ListensOnListenerAndAccepts()
        {
            var listener = new TcpListener(IPAddress.Any, 0);
            var server = new Server(listener, new Worker());
            server.Serve();
            var endPoint = (IPEndPoint)listener.LocalEndpoint;
            var port = endPoint.Port;
            Assert.AreNotEqual(0, port);
            var client = new TcpClient("localhost", port);
            Assert.IsTrue(client.Connected);
            listener.Stop();
            Assert.IsTrue(Worker.Worked);
        }
    }
}
