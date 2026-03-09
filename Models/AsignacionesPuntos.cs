using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raydelis_HilarioAP1_P2.Models
{
    public class AsignacionesPuntos
    {
        [Key]
        public int IdAsignacion { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Range(1, int.MaxValue, ErrorMessage = "Este Campo es obligatorio")]
        public int EstudianteId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Este Campo es obligatorio")]
        public int TotalPuntos { get; set; } = 0;

        [ForeignKey("IdAsignacion")]
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public ICollection<DetalleAsignacionPuntos> DetallesAsignacion { get; set; } = new List<DetalleAsignacionPuntos>();
    }
}
