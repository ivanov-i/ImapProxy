using System;
using System.Threading.Tasks;

namespace Core
{
    public class Server : IServer
    {
        private readonly Action<IWorkItem> _workFunction;

        public Server(Action<IWorkItem> workFunction)
        {
            _workFunction = workFunction;
        }

        public async void Serve(IWorkItem client)
        {
            await Task.Run(() => _workFunction(client));
        }
    }
}