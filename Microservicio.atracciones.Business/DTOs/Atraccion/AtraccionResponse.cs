using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Atraccion;

public class AtraccionResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal? PrecioReferencia { get; set; }
    public int DestinoId { get; set; }
    public string DestinoNombre { get; set; } = null!;
}