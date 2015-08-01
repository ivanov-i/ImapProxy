using System;

namespace Core
{
    public class Server : IServer
    {
        private readonly Action<IWorkItem> _workFunction;

        public Server(Action<IWorkItem> workFunction)
        {
            _workFunction = workFunction;
        }

        public void Serve(IWorkItem client)
        {
            _workFunction(client);
        }
    }
}