using app1.Models;
using System.ComponentModel.DataAnnotations;

namespace app1.ViewModel
{
	public class UniqeNameAttribute:ValidationAttribute
	{
		//protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		//{
		//	if (value == null)
		//		return null;
		//	string newName=value.ToString();
		//	ITIContext context=new ITIContext();
		//	Employee emp=context.Employees.FirstOrDefault(x=>x.Name==newName);

		//	if (emp != null)
		//	{
		//		return new ValidationResult("Name Must Be Uniqe")
		//	}
		//	else 
		//	{
		//		return ValidationResult.Success;
		//	}



		//}
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
				return null;
			string new_name = value.ToString();
			ITIContext context=new ITIContext();
			Employee employee= context.Employees.FirstOrDefault(x=>x.Name==new_name);

			if (employee != null) {
				return new ValidationResult("Name Must Be Uniqe");
			}
            else
            {
                return ValidationResult.Success;
            }
        }
	}
}
