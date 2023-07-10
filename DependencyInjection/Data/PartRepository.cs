namespace DependencyInjection.Data
{
    public class PartRepository : IPartRepository
    {
        public Guid InstanceID { get; set; }
        public PartRepository() : this(Guid.NewGuid())
        {
        }
        public PartRepository(Guid ınstanceID)
        {
            InstanceID = ınstanceID;
        }


        public int GetStock(int gameID)
        {
            return 0;
        }
    }
}
