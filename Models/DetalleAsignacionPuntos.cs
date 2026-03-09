using System.ComponentModel.DataAnnotations;

namespace Raydelis_HilarioAP1_P2.Models
{
    public class DetalleAsignacionPuntos
    {
        [Key]
        public int IdDetalle { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public int IdAsignacion { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public int TipoPuntoId { get; set; }
        public int CantidadPuntos { get; set; } = 0;
    }
}
