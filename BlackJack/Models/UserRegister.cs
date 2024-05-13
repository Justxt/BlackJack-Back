using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class UserRegister
    {
        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
