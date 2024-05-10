using System.ComponentModel.DataAnnotations;

namespace BlackJackk.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Type { get; set; }
        [Required(ErrorMessage = "La informacion es obligatoria obligatorio")]
        public string Information { get; set; }

        //Relacion con el User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
