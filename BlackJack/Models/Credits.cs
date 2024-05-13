using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class Credits
    {
        public int Id { get; set; }

        //Relacion con el usuario
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal YourCredits { get; set; }
        [Required(ErrorMessage = "La cantidad a invertir es obligatoria")]
        public decimal CreditsAmountInvested { get; set; }
    }
}
