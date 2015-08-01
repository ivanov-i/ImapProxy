using System;
using System.Net.Sockets;

namespace Core
{
    public class Listener
    {
        private readonly TcpListener _listener;
        private readonly IServer _server;

        public Listener(TcpListener listener, IServer server)
        {
            _listener = listener;
            _server = server;
        }

        public async void Listen()
        {
            _listener.Start();
            try
            {
                var client = await _listener.AcceptTcpClientAsync();
                _server.Serve(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}