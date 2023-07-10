using DependencyInjection.Models;
using DependencyInjection.Queue;

namespace DependencyInjection.Data
{
    public class GameRepository : IGameRepository
    {
        public Guid InstanceID { get; set; }
        public GameRepository() : this(Guid.NewGuid())
        {
        }
        public GameRepository(Guid ınstanceID)
        {
            InstanceID = ınstanceID;
        }

        List<Game> games = new List<Game>()
        {
                new Game { Id = 1, Title = "Super Mario Bros.", LastPrice = 19.99m },
                new Game { Id = 2, Title = "Contra", LastPrice = 29.99m },
                new Game { Id = 3, Title = "Metroid", LastPrice = 39.99m },
                new Game { Id = 4, Title = "GTA", LastPrice = 49.99m }
        };

        public Game AddGame(int lastID, Game game, IPublisher publisher)
        {
            publisher.Send("A new game has been added to the repository.");
            
            //DB olmadığı için manuel arttırıyoruz
            game.Id = lastID + 1;
            
            games.Add(game);
            return game;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return games;
        }

        public int GetLastGameId()
        {
            return games.Max(g => g.Id);
        }
    }

}