namespace DependencyInjection.Queue
{
    public class ConsolePublisher : IPublisher
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
