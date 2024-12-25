using Microsoft.AspNetCore.Mvc;

namespace MVC_Day3.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index1()
        {
            return Content("This is Index1 from FirstController");
        }

        public IActionResult Index2()
        {
            return Content("This is Index2 from FirstController");
        }

        public IActionResult Index3()
        {
            return Content("This is Index3 from FirstController");
        }
    }
}
