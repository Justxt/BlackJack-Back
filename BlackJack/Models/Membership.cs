using System.ComponentModel.DataAnnotations;

namespace BlackJackk.Models
{
    public class Membership
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El tipo de memebresia es obligatorio")]
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "El tiempo de duracion es obligatorio")]
        public int DurationTimeMonth { get; set; }
    }
}
