using Microsoft.AspNetCore.Mvc;

namespace SalesWebApp.Controllers
{
    public class Departments : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
