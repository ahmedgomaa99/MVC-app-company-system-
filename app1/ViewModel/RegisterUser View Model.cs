using System.ComponentModel.DataAnnotations;

namespace app1.ViewModel
{
    public class RegisterUser_View_Model
    {
        public string? User_Name { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
