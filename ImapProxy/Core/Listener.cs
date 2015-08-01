using System;
using System.Net.Sockets;

namespace Core
{
    public class Listener
    {
        private readonly TcpListener _listener;
        private readonly IServer _server;
        private readonly IWorkItemFactory _wiFactory;

        public Listener(TcpListener listener, IServer server, IWorkItemFactory wiFactory)
        {
            _listener = listener;
            _server = server;
            _wiFactory = wiFactory;
        }

        public async void Listen()
        {
            _listener.Start(10000);
            try
            {
                while (true)
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    _server.Serve(_wiFactory.CreateWorkItem(client));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}