using Microsoft.AspNetCore.Mvc;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
