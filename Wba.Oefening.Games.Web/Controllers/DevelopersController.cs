using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository _developerRepository;
        private readonly FormatService _formatService;

        public DevelopersController()
        {
            _developerRepository = new DeveloperRepository();
            _formatService = new FormatService();
        }

        public IActionResult Index()
        {
            IEnumerable<Developer> allDevelopers = _developerRepository.GetDevelopers();
            string infoAllDevelopers = _formatService.FormatDeveloperInfo(allDevelopers);

            return Content(infoAllDevelopers, "text/html");
        }

        public IActionResult ShowDeveloper(int developerId)
        {
            IEnumerable<Developer> allDevelopers = _developerRepository.GetDevelopers();
            Developer searchedDeveloper = allDevelopers.FirstOrDefault(dev => dev.Id == developerId);

            if (searchedDeveloper == null) return NotFound();

            string infoSearchedDeveloper = _formatService.FormatDeveloperInfo(searchedDeveloper);

            return Content(infoSearchedDeveloper, "text/html");
        }
    }
}
