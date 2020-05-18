//CommandUpdateDto.cs

using System.ComponentModel.DataAnnotations;

namespace WNSA.Dtos
{

 public class WNSAUpdateDto
    {
        // This is handled by SQL Server
       // public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name  { get; set; }
    
        [Required]
        public string Role { get; set; }
  
        [Required]
        public string Personal { get; set; }
     
    }
}
