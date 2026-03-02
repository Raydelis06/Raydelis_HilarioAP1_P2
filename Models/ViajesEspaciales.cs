using System.ComponentModel.DataAnnotations;

namespace Raydelis_HilarioAP1_P2.Models;

public class ViajesEspaciales
{
    [Key]
    public int ViajeId { get; set; }
    [Required(ErrorMessage = "El campo fecha de viaje es obligatorio.")]
    public DateTime FechaViaje { get; set; }
    [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
    public string Descripcion { get; set; } = null!;
    [Required(ErrorMessage = "El campo costo es obligatorio.")]
    public double Costo { get; set; }
}
