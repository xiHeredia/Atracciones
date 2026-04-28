using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class FacturaDataModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }

    public int ReservaId { get; set; }

    public string Numero { get; set; } = null!;
    public DateTimeOffset FechaEmision { get; set; }
    public decimal Total { get; set; }

    public string? Observacion { get; set; }
    public string OrigenCanal { get; set; } = null!;

    public string Estado { get; set; } = null!;
    public string? MotivoInhabilitacion { get; set; }
}