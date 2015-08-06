using System.Net.Sockets;

namespace Core
{
    public interface IServer
    {
        void Serve(TcpClient client);
    }
}