using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult method1(string name,int age,string color)
        {
            return Content($"Welcome {name} your age is {age} years old ");
        }
        public IActionResult method2()
        {
            return Content("M2");
        }
    }
}
