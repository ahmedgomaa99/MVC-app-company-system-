using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app1.Models
{
    public class STUDENT
    {

        [Key]


        public int Id { get; set; }
        [Display(Name = "StdName")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [RegularExpression(@"(\w+\.(jpg|png))")]
        public string? IMGurl { get; set; }
        //[Required]
        //[RegularExpression("(alex|assiut)")]
        //[RegularExpression("[azAZ]{3,25}")]
        //[RegularExpression(@"(Mansoura|Cairo)")]
        //public string? Address { get; set; }
        //[Required]
        //[Range(20, 50)]
        //[Display(Name = "Employee Age")]

        //public int age { get; set; }

    }

    
}
