using BlackJack.Models;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de método de pago es obligatorio.")]
        public string Type { get; set; }

        // Relación con Tarjeta de Crédito
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        // Relación con Usuario
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
