using Microsoft.AspNetCore.Identity;

namespace app1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? address { get; set; }


    }
}
