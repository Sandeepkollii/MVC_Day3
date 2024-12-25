using Microsoft.AspNetCore.Mvc;

namespace MVC_Day3.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index1()
        {
            return Content("This is Index1 from SecondController");
        }

        public IActionResult Index2()
        {
            return Content("This is Index2 from SecondController");
        }

        public IActionResult Index3()
        {
            return Content("This is Index3 from SecondController");
        }
    }
}
