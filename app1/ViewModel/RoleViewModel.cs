using System.ComponentModel.DataAnnotations;

namespace app1.ViewModel
{
    public class RoleViewModel
    {
        [Display (Name ="Role Name")]
        public string? RoleName { get; set; }
    }
}
