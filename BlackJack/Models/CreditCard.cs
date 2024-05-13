using BlackJack.Models;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de tarjeta es obligatorio.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "El número de tarjeta es obligatorio.")]
        [CreditCard(ErrorMessage = "El número de tarjeta no es válido.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "El nombre del titular de la tarjeta es obligatorio.")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Formato de fecha de expiración inválido. Debe ser MM/YY.")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "El código de seguridad es obligatorio.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "El código de seguridad debe tener 3 o 4 dígitos.")]
        public string CVV { get; set; }

        // Relación con Usuario
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
