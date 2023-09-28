using System.ComponentModel.DataAnnotations;

namespace EduEventPlatform.Shared.Entities
{
    public class AcademicEvent
    {
        public int Id { get; set; }

        // Nombre del evento
        [Display(Name = "Nombre del Evento")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe proporcionar el nombre del evento.")]
        public string EventName { get; set; } = null!;

        // Fecha de inicio
        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "Debe proporcionar la fecha de inicio del evento.")]
        public DateTime StartDate { get; set; }

        // Fecha de finalización
        [Display(Name = "Fecha de Finalización")]
        [Required(ErrorMessage = "Debe proporcionar la fecha de finalización del evento.")]
        public DateTime EndDate { get; set; }

        // Ubicación
        [Display(Name = "Ubicación")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe proporcionar la ubicación del evento.")]
        public string Location { get; set; } = null!;

        // Descripción
        [Display(Name = "Descripción")]
        [MaxLength(1000, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe proporcionar una descripción para el evento.")]
        public string Description { get; set; } = null!;

        // Tema del evento
        [Display(Name = "Tema del Evento")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe proporcionar el tema del evento.")]
        public string EventTheme { get; set; } = null!;
    }
}

