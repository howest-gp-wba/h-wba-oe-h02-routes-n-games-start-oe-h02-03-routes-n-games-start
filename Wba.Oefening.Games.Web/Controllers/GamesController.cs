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

        /**
         * show the info of one game
         */
        public IActionResult ShowGame(int id)
        {
            //get the game using the id(FirstOrDefault)
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check if null
            if (game == null)
            {
                return NotFound();
            }
            //return content => FormatGameInfo(Game)
            var title = game.Title;
            return Content(_formatService.FormatGameInfo(game), "text/html");
        }

        public IActionResult Index()
        {
            IEnumerable<Game> games = _gameRepository.GetGames();
            return Content($"{FormatGameInfo(games)}", "text/html");
        }

        private string FormatGameInfo(Game game)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            sb.AppendLine($"<li>Id: {game?.Id ?? 0}</li>");
            sb.AppendLine($"<li>Title: {game?.Title ?? "no title"}</li>");
            sb.AppendLine($"<li>Developer: {game?.Developer?.Name ?? "no developer"}</li>");
            sb.AppendLine($"<li>Rating: {game?.Rating ?? 0}</li>");
            sb.AppendLine("</ul>");
            string gameInfo = sb.ToString();

            return gameInfo;
        }

        private string FormatGameInfo(IEnumerable<Game> games)
        {
            string gameInfo = "<ul>";
            foreach (Game game in games)
            {
                gameInfo += $"<li>Game {game.Id}{FormatGameInfo(game)}</li>";
            }
            gameInfo += "</ul>";

            return gameInfo;
        }
    }
}
