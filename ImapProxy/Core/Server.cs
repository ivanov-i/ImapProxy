using System.Net.Sockets;

namespace Core
{
    public class Server
    {
        private readonly TcpListener _listener;
        private readonly IWorker _worker;

        public Server(TcpListener listener, IWorker worker)
        {
            _listener = listener;
            _worker = worker;
        }

        public async void Serve()
        {
            _listener.Start();
            var client = await _listener.AcceptTcpClientAsync();
            _worker.Work(client);
        }
    }
}