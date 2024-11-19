using System.Text;
using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Web.Services
{
    public class FormatService : IFormatService
    {
        public string FormatDeveloperInfo(Developer developer)
        {
            int developerId = developer?.Id ?? 0;
            string developerName = developer?.Name ?? "unknown";

            if (developerName != "unknown")
            {
                string developerLink = $"<a href=\"/Developers/{developerId}\">{developerName}</a>";
                developerName = developerLink;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<ul>");
            sb.AppendLine($"<li>Id: {developerId}</li>");
            sb.AppendLine($"<li>Name: {developerName}</li>");
            sb.AppendLine($"</ul>");
            string developerInfo = sb.ToString();

            return developerInfo;
        }

        public string FormatDeveloperInfo(IEnumerable<Developer> developers)
        {
            string developerInfo = "<ul>";
            foreach (Developer developer in developers)
            {
                developerInfo += $"<li>Developer {developer.Id}{FormatDeveloperInfo(developer)}</li>";
            }
            developerInfo += "</ul>";

            return developerInfo;
        }

        public string FormatGameInfo(Game game)
        {
            int gameId = game?.Id ?? 0;
            string gameTitle = game?.Title ?? "unknown";
            string developerName = game?.Developer?.Name ?? "unknown";
            int gameRating = game?.Rating ?? 0;

            if (gameTitle != "unknown")
            {
                string gameLink = $"<a href=\"/Games/{gameId}\">{gameTitle}</a>";
                gameTitle = gameLink;
            }

            if (developerName != "unknown")
            {
                int developerId = game?.Developer?.Id ?? 0;
                string developerLink = $"<a href=\"/Developers/{developerId}\">{developerName}</a>";
                developerName = developerLink;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            sb.AppendLine($"<li>Id: {gameId}</li>");
            sb.AppendLine($"<li>Title: {gameTitle}</li>");
            sb.AppendLine($"<li>Developer: {developerName}</li>");
            sb.AppendLine($"<li>Rating: {gameRating}</li>");
            sb.AppendLine("</ul>");
            string gameInfo = sb.ToString();

            return gameInfo;
        }

        public string FormatGameInfo(IEnumerable<Game> games)
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
