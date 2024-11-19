using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository _developerRepository;

        public DevelopersController()
        {
            _developerRepository = new DeveloperRepository();
        }

        public IActionResult Index()
        {
            IEnumerable<Developer> allDevelopers = _developerRepository.GetDevelopers();
            return Content(FormatDeveloperInfo(allDevelopers), "text/html");
        }

        private string FormatDeveloperInfo(Developer developer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<ul>");
            sb.AppendLine($"<li>Id: {developer?.Id ?? 0}</li>");
            sb.AppendLine($"<li>Name: {developer?.Name ?? "unknown"}</li>");
            sb.AppendLine($"</ul>");
            string developerInfo = sb.ToString();

            return developerInfo;
        }

        private string FormatDeveloperInfo(IEnumerable<Developer> developers)
        {
            string developerInfo = "<ul>";
            foreach (Developer developer in developers)
            {
                developerInfo += $"<li>Developer {developer.Id}{FormatDeveloperInfo(developer)}</li>";
            }
            developerInfo += "</ul>";

            return developerInfo;
        }
    }
}
