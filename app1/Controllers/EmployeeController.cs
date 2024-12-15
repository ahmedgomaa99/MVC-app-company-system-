using app1.Models;
using app1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using app1.Reposatory;

namespace app1.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext context = new ITIContext();
        //public IActionResult Index()
        //{
        //    return View();
        //}\
       IEmployeRepo emplyeeRepo;
        IDepartmentRepo departmentRepo;
        public EmployeeController(IEmployeRepo empRepo,IDepartmentRepo dptRepo)
        {
            emplyeeRepo = empRepo;
			departmentRepo= dptRepo;


		}
        public IActionResult Details(int id)
        {
            Employee e = emplyeeRepo.GetById(id);

            return View("Details", e);
        }
        public IActionResult PatialDetails(int id)
        {
           

            return PartialView("_PatialDetails", emplyeeRepo.GetById(id));
        }

        public IActionResult index() 
        {
            
            List<Employee> emp = emplyeeRepo.Getall();
           

            return View("showalle", emp);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = emplyeeRepo.GetById(id);
            List<Department>deptList=departmentRepo.Getall();
            //List<Department> deptList = context.Departments.ToList();
            EmpPlusDeptList empView = new EmpPlusDeptList();

            empView.ID = employee.ID;
            empView.Name = employee.Name;
            empView.Salary = employee.Salary;
            empView.imgURL = employee.imgURL;
            empView.JobTitle = employee.JobTitle;
            empView.Address = employee.Address;
            empView.DeptId = employee.DeptId;
            empView.DepartmentList = deptList;
            return View("edit", empView);
        }
      
        [HttpPost]
        public IActionResult saveedit(EmpPlusDeptList employeeFromReq)
        {
            if (ModelState.IsValid== true) { 
            
            Employee empdb=emplyeeRepo.GetById(employeeFromReq.ID);
                empdb.Name = employeeFromReq.Name;
                empdb.JobTitle = employeeFromReq.JobTitle;
                empdb.Address = employeeFromReq.Address;
                empdb.Salary = employeeFromReq.Salary;
				empdb.imgURL = employeeFromReq.imgURL;
				empdb.DeptId = employeeFromReq.DeptId;
				empdb.ID = employeeFromReq.ID;
				emplyeeRepo.update(empdb);

				emplyeeRepo.SaveChanges(); 

            return RedirectToAction("Index");

            }
			//employeeFromReq.DepartmentList = context.Departments.ToList();
			employeeFromReq.DepartmentList = departmentRepo.Getall();

			return View("edit", employeeFromReq);
        }
       
        [HttpGet]
        public IActionResult New()
        {

			//ViewData["DeptList"] = context.Departments.ToList();
			ViewData["DeptList"] = departmentRepo.Getall();
			return View("new");
        }
        [HttpPost]
        public IActionResult SaveNew(Employee empFromReq)
        {
            //if (empFromReq.Name != null && empFromReq.Salary>=6000&&empFromReq.DeptId>0)
           if(ModelState.IsValid==true)
            {
                if (empFromReq.DeptId != 0)
                {
                    emplyeeRepo.add(empFromReq);
                    //context.Employees.Add(empFromReq);
                    emplyeeRepo.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("DeptId", "Select Department");




                }
				

			}
			ViewData["DeptList"] = departmentRepo.Getall();

			return View("new", empFromReq);

		}
        [HttpGet]
        public IActionResult delete(int id)
        {

            //Employee? empdb = context.Employees.FirstOrDefault(x => x.ID == id);

            //if (empdb != null)
            //{
            //    context.Employees.Remove(empdb);
            //    context.SaveChanges();

            //}
            emplyeeRepo.delete(id);
            emplyeeRepo.SaveChanges();

            return RedirectToAction("index");

        }
        public IActionResult checkName( string Name,string address)
        {
            if ((Name.Contains("iti")|| Name.Contains("ITI"))&& (address=="Mansoura"))
            {
                return Json(true);
            }
            return Json(false);
        }


	}
}
