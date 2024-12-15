using app1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app1.Models
{
	public class Employee
	{
        [Key]
        public int ID { get; set; }
   
        [Display(Name = "StdName")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
		//[UniqeName]
		//[Remote(action: "checkName", controller: "Employee", AdditionalFields = "Address", ErrorMessage = "NAme Must Contain ITI")]
		public string ?Name { get; set; }
		[Display(Name ="Emp Salary")]
		[Required(ErrorMessage ="Salaly Required :)")]
		
		public int Salary { get; set; }
		[Required]
		[RegularExpression(@"(\w+\.(jpg|png))",ErrorMessage ="Image must Be .PNG or .JPG")]
		public string ?imgURL { get; set; }
		[Required]
		public string ?JobTitle { get; set; }
		[Required]
		//[RegularExpression("(alex|assiut)")]
		//[RegularExpression("[azAZ]{3,25}")]
		//[RegularExpression(@"(Mansoura|Cairo)",ErrorMessage = "Only From Mansoura Or Cairo")]
		public string ?Address { get; set; }
		//[Required]
		//[Range(20,50)]
		//      [Display(Name = "Employee Age")]

		//      public int age { get; set; }
		[Required]
        [ForeignKey("Department")]
		[Display(Name ="Department")]
		public int DeptId { get; set; }
		public Department? Department{ get; set; }



	}
}
