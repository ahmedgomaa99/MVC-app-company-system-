using app1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app1.ViewModel
{
    public class EmpPlusDeptList
    {
        public int ID { get; set; }
       

		public string? Name { get; set; }
        public int Salary { get; set; }
        public string? imgURL { get; set; }
        public string? JobTitle { get; set; }
        public string? Address { get; set; }
        public int DeptId { get; set; }
        public List <Department> DepartmentList { get; set; }

    }
}
