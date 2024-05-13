using System.ComponentModel.DataAnnotations;

namespace BlackJack.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "El asunto es obligatorio.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Status { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ResolutionDate { get; set; }

        // Aqui la relación con Usuario
        public User User { get; set; }


    }
}
