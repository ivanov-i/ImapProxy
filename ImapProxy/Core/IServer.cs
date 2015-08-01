namespace Core
{
    public interface IServer
    {
        void Serve(IWorkItem client);
    }
}