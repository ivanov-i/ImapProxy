using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Core
{
    public class Server : IServer
    {
        private readonly Action<TcpClient> _workFunction;

        public Server(Action<TcpClient> workFunction)
        {
            _workFunction = workFunction;
        }

        public async void Serve(TcpClient client)
        {
            await Task.Run(() => _workFunction(client));
        }
    }
}