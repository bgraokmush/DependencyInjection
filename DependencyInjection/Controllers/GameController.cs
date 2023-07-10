using DependencyInjection.Data;
using DependencyInjection.Models;
using DependencyInjection.Queue;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IPartRepository _partRepository;
        private readonly PerformanceCounter _performCounter;
        private readonly ILogger<GameController> _logger;

        public GameController(IGameRepository gameRepository, 
                              IShopRepository shopRepository, 
                              IPartRepository partRepository,
                              PerformanceCounter performCounter,
                              ILogger<GameController> logger
                              )
        {
            _gameRepository = gameRepository;
            _shopRepository = shopRepository;
            _partRepository = partRepository;
            _performCounter = performCounter;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"\n[SINGLETON]\tShopRepo ID:{_shopRepository.InstanceID}, In Perf Counter: {_performCounter.ShopRepositoryID}");
            _logger.LogInformation($"\n[TRANSIENT]\tGameRepo ID:{_gameRepository.InstanceID}, In Perf Counter: {_performCounter.GameRepositoryID}");
            _logger.LogInformation($"\n[SCOPED   ]\tPartRepo ID:{_partRepository.InstanceID}, In Perf Counter: {_performCounter.PartRepositoryID}");

            var games = _gameRepository.GetAllGames();
            return View(games);
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(Game game, ConsolePublisher publisher)
        {
            int lastID = _gameRepository.GetLastGameId();
            _gameRepository.AddGame(lastID, game, publisher);
            return RedirectToAction("Index");
        }
    }
}
