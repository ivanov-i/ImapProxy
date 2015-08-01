using System.Net;
using System.Net.Sockets;
using System.Threading;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ListenerTest
    {
        public class Server : IServer
        {
            private readonly CountdownEvent _workersCounter;

            public Server(int n)
            {
                _workersCounter = new CountdownEvent(n);
            }

            public void Serve(TcpClient client)
            {
                _workersCounter.Signal();
            }

            public bool Wait()
            {
                return _workersCounter.Wait(5000);
            }
        }

        [TestMethod]
        public void ListensOnListenerAndAccepts()
        {
            VerifyConnections(1);
        }

        [TestMethod]
        public void TwoConnections()
        {
            VerifyConnections(2);
        }

        [TestMethod]
        public void TwentyConnections()
        {
            VerifyConnections(20);
        }

        [TestMethod, TestCategory("Slow")]
        public void StressTest()
        {
            Assert.Inconclusive("This one takes about a minute");
            VerifyConnections(100000);
        }

        private static void VerifyConnections(int n)
        {
            var server = new Server(n);
            var tcpListener = new TcpListener(IPAddress.Any, 0);
            var listener = new Listener(tcpListener, server);
            listener.Listen();
            var endPoint = (IPEndPoint)tcpListener.LocalEndpoint;
            var port = endPoint.Port;
            Assert.AreNotEqual(0, port);
            for (var i = 0; i < n; i++)
            {
                var client = new TcpClient("127.0.0.1", port);
                Assert.IsTrue(client.Connected);
                client.Close();
            }
            Assert.IsTrue(server.Wait());
            tcpListener.Stop();
        }
    }
}
