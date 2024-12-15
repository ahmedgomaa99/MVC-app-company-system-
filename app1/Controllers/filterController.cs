using app1.Filtters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
    [HandleErrorMetaData]

    public class filterController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            throw new Exception("NOOOOOOOOOOOOOOO");

        }
        public IActionResult ok()
        {
            throw new Exception("NOOOOOOOOOOOOOOO");

        }
        public IActionResult no()
        {
            throw new Exception("NOOOOOOOOOOOOOOO");

        }
        public IActionResult bad()
        {
            throw new Exception("NOOOOOOOOOOOOOOO");

        }
    }
}
