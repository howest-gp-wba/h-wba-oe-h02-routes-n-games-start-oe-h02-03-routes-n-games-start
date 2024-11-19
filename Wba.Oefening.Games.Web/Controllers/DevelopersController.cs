using Microsoft.AspNetCore.Components.Web;
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

        public IActionResult ShowDeveloper(int developerId)
        {
            IEnumerable<Developer> allDevelopers = _developerRepository.GetDevelopers();
            Developer searchedDeveloper = allDevelopers.FirstOrDefault(dev => dev.Id == developerId);

            if (searchedDeveloper == null) return NotFound();

            return Content(FormatDeveloperInfo(searchedDeveloper), "text/html");
        }

        private string FormatDeveloperInfo(Developer developer)
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
