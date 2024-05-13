using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class UserLogin
    {
        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
