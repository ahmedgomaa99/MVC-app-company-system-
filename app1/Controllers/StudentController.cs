using app1.Models;
using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
	public class StudentController : Controller
	{
		//public IActionResult Index()
		//{
		//	return View();
		//}
		public IActionResult showall()
		{
			Student_BL student_BL = new Student_BL();
			List<STUDENT> li= student_BL.Getall();
			return View("showall",li);

		}
		public IActionResult showbyid(int id)
		{
			Student_BL student_BL = new Student_BL();
			STUDENT li = student_BL.getbyid(id);
			return View("showbyid", li);
		}

	}
}
