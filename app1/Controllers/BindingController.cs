using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
	public class BindingController : Controller
	{
		public IActionResult call(int id,string n)
		{
			return Content($"{id}--------{n}");
		}
	}
}
