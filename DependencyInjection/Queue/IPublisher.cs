namespace DependencyInjection.Queue
{
    public interface IPublisher
    {
        void Send(string message);
    }
}
