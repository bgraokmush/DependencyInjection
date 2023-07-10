using DependencyInjection.Models;

namespace DependencyInjection.Data
{
    public class ShopRepository : IShopRepository
    {
        public Guid InstanceID { get; set; }
        public ShopRepository() : this(Guid.NewGuid())
        {
        }
        public ShopRepository(Guid ınstanceID)
        {
            InstanceID = ınstanceID;
        }


        public void Sell(Game game, decimal offer)
        {
            Console.WriteLine($"{game} oyunu şu fiyata satıldı, {offer}");
        }
    }
}
