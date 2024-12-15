using app1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace app1.Controllers
{
    public class HomeController : Controller
    {

        // no static no overloaded

        public IActionResult show(int id)
        {
            //ViewResult viewResult = new ViewResult();

            //viewResult.ViewName = "view";
            //return viewResult;

            if (id > 10)
            {
                //ViewResult viewResult = new ViewResult();

                //viewResult.ViewName = "view";
                //return viewResult;
                return View("view");
            }
            else
            {
                //ContentResult C=new ContentResult();
                //C.Content = "not applicable";
                //return C;
                return Content("HAPPPPPPPPPPPPPY");
                
            }
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
