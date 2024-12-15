using System.ComponentModel.DataAnnotations;

namespace app1.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		public string ?Name { get; set; }
		public List<Employee>? Employees { get; set; }
	}
}
