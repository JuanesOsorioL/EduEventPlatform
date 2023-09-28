using System.ComponentModel.DataAnnotations;

namespace EduEventPlatform.Shared.Entities
{
    public class Participant
    {
        public int Id { get; set; }

        // nombre participante
        [Display(Name = "Nombre Participante")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NameParticipant { get; set; } = null!;

        // afiliacion institucional
        [Display(Name = "Afiliacion Institucional")]
        [MaxLength(50, ErrorMessage = "El campo {1} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {1} es obligatorio.")]
        public string InstitutionalAffiliation { get; set; } = null!;

        // area de interes
        [Display(Name = "Area Interes")]
        [MaxLength(50, ErrorMessage = "El campo {2} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {2} es obligatorio.")]
        public string AreaInterest { get; set; } = null!;

        // tipo participante
        [Display(Name = "Tipo Participante")]
        [MaxLength(300, ErrorMessage = "El campo {3} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {3} es obligatorio.")]
        public string TypeParticipation { get; set; } = null!;

    }
}
