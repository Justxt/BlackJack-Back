using System.ComponentModel.DataAnnotations;

namespace BlackJackk.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }
        
        //Relacion con usuario
        public int UsuarioId { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string Title { get; set; }
        [Required(ErrorMessage = "La Descripcion es obligatoria")]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ResolutionDate { get; set;}


    }
}
