using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Factura;

public class CrearFacturaRequest
{
    public int ReservaId { get; set; }

    public string? Numero { get; set; }
    public decimal Total { get; set; }

    public string? Observacion { get; set; }
    public string OrigenCanal { get; set; } = null!;
}