using System.Net.Sockets;

namespace Core
{
    public class Server
    {
        private readonly TcpListener _listener;

        public Server(TcpListener listener)
        {
            _listener = listener;
        }

        public void Serve()
        {
            _listener.Start();
        }
    }
}