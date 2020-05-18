using System.ComponentModel.DataAnnotations;

namespace WNSA.Models
{

 public class WNSAModel //: Controller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
         [Required]
        public string Role { get; set; }
         [Required]
        public string Personal { get; set; }

      /*   public Command(int Id, string HowTo, string Role, string Personal)
        {

        } */
        
    }
}
