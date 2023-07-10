namespace DependencyInjection.Data
{
    public interface IPartRepository
    {
        public Guid InstanceID { get; set; }
        int GetStock(int gameID);
    }
}
