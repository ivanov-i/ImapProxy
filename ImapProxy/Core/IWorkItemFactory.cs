using System.Net.Sockets;

namespace Core
{
    public interface IWorkItemFactory
    {
        IWorkItem CreateWorkItem(TcpClient client);
    }
}