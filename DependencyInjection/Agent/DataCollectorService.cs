namespace DependencyInjection.Agent
{
    public class DataCollectorService
    {
        public async Task<int> GetActiveUserCount()
        {
            return await Task.FromResult(new Random().Next(10,50));
        }
    }
}
