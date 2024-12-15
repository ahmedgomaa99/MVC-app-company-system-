using System.ComponentModel.DataAnnotations;

namespace app1.ViewModel
{
    public class Login_user_view_model
    {
        [Required (ErrorMessage ="*")]
        public string Name { get; set; }
        [Required]
        [DataType (DataType.Password)]
        public string password {  get; set; }
        [Display (Name ="Rememeber Me !")]

        public  bool RememeberMe {  get; set; }

    }
}
