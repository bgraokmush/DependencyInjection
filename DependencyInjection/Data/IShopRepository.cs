using DependencyInjection.Models;

namespace DependencyInjection.Data
{
    public interface IShopRepository
    {
        public Guid InstanceID { get; set; }
        void Sell(Game game, decimal offer);
    }
}
