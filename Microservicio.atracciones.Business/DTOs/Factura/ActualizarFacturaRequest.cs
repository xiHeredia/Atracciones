using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Factura;

public class ActualizarFacturaRequest
{
    public int Id { get; set; }

    public int ReservaId { get; set; }

    public string Numero { get; set; } = null!;
    public decimal Total { get; set; }

    public string? Observacion { get; set; }
    public string OrigenCanal { get; set; } = null!;
}