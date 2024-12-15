using app1.Reposatory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace app1.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IEmployeRepo employeRepo;

		public ServiceController(IEmployeRepo employeRepo)
        {
			this.employeRepo = employeRepo;
		}
		//[Authorize]	
		public IActionResult TestAuth()
		{

			if (User.Identity.IsAuthenticated==true)
			{
                Claim IDclaim = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier);
                Claim addressclaim = User.Claims.FirstOrDefault(e => e.Type == "addressuser");
                string id = IDclaim.Value;
				string? name=User.Identity.Name;
				return Content($"Welcome MR/MS {name}--\n {id}");

			}
			return Content("Welcome Ya Guest ");
		}
        public IActionResult Index()
		{
			ViewBag.id = employeRepo.id;

			return View("index");
		}
	}
}
