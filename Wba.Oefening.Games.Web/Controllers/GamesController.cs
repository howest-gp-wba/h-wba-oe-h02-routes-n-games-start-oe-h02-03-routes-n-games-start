using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;
        private readonly FormatService _formatService;

        public GamesController()
        {
            _gameRepository = new GameRepository();
            _formatService = new FormatService();
        }

        public IActionResult Index()
        {
            IEnumerable<Game> games = _gameRepository.GetGames();
            string infoAllGames = _formatService.FormatGameInfo(games);

            return Content(infoAllGames, "text/html");
        }

        public IActionResult ShowGame(int gameId)
        {
            IEnumerable<Game> games = _gameRepository.GetGames();
            Game searchedGame = games.FirstOrDefault(game => game.Id == gameId);

            if (searchedGame == null) return NotFound();

            string infoSearchedGame = _formatService.FormatGameInfo(searchedGame);

            return Content(infoSearchedGame, "text/html");
        }
    }
}
