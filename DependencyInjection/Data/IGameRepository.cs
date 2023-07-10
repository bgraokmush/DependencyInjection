using DependencyInjection.Models;
using DependencyInjection.Queue;

namespace DependencyInjection.Data
{
    public interface IGameRepository
    {
        public Guid InstanceID { get; set; }

        public IEnumerable<Game> GetAllGames();

        public Game AddGame(int lastID, Game game, IPublisher publisher);

        public int GetLastGameId();
    }
}
