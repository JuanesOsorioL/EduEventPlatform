using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduEventPlatform.Shared.Entities
{
    public class EventSchedule
    {
        public int Id { get; set; }

        // Horario de la sesión
        [Display(Name = "Hora de Inicio")]
        [Required(ErrorMessage = "Debe proporcionar la hora de inicio de la sesión.")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Hora de Finalización")]
        [Required(ErrorMessage = "Debe proporcionar la hora de finalización de la sesión.")]
        public DateTime EndTime { get; set; }

        // Información sobre la sesión
        [Display(Name = "Nombre de la Sesión")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe proporcionar un nombre para la sesión.")]
        public string SessionName { get; set; } = null!;

        // Ponente
        [Display(Name = "Ponente")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe proporcionar el nombre del ponente.")]
        public string Speaker { get; set; } = null!;

        // Tema tratado en la sesión
        [Display(Name = "Tema de la Sesión")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "Debe proporcionar el tema tratado en la sesión.")]
        public string SessionTopic { get; set; } = null!;
    }
}
