using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Core
{
    public interface IServer
    {
        void Serve(TcpClient client);
    }
}