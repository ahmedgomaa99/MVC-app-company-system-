using app1.Models;
using app1.Reposatory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
	public class DepartmentController : Controller

		
	{
		IDepartmentRepo departmentRepo;
		IEmployeRepo employeRepo;

        public DepartmentController(IDepartmentRepo _departmentRepo ,IEmployeRepo _employeRepo)
        {
			departmentRepo = _departmentRepo;
            employeRepo = _employeRepo;
        }
		[Authorize]
        public IActionResult showall()
		{
			List<Department> list = departmentRepo.Getall();

			return View("showall", list);

		}
		public IActionResult DeptEmp(int id) 
		{ 
			return View("DeptEmp",departmentRepo.Getall());//deptlist
		
		}
		public IActionResult GetEmpsByDeptid(int id) 
		{ 
			List<Employee> e=employeRepo.getbyDeptId(id);
			return Json(e);
		
		
		}
		[HttpGet]
		public IActionResult add2()
		{
			return View("add");
		}
		[HttpPost]
		public IActionResult add(Department d)
		{
			if (d.Name != null)
			{
				departmentRepo.add(d);
				departmentRepo.SaveChanges();
				return RedirectToAction("showall");
				;
			
		}

			return View("add",d);

		}

		public IActionResult delete(int id)
		{
			departmentRepo.delete(id);
			departmentRepo.SaveChanges();
			return RedirectToAction("showall");



		}
	}
}
