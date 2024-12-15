using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
	public class StateController : Controller
	{
		public IActionResult SetSession(string k) {
			HttpContext.Session.SetString("Name", "Ahmed");
			HttpContext.Session.SetInt32("age", 50);

			return Content("Data Session Sucess");
		
		}
		public IActionResult GetSession(string name) {
			string? x=HttpContext.Session.GetString("Name");
			int? y=HttpContext.Session.GetInt32("age");
			return Content($"{x}\n{y}");
		}

	}
}
