using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class FacturaEntity
{
    public int FacId { get; set; }
    public Guid FacGuid { get; set; }

    public int RevId { get; set; }

    public string FacNumero { get; set; } = null!;
    public DateTimeOffset FacFechaEmision { get; set; }
    public decimal FacTotal { get; set; }

    public string? FacObservacion { get; set; }
    public string FacOrigenCanal { get; set; } = null!;

    public string FacUsuarioIngreso { get; set; } = null!;
    public string FacIpIngreso { get; set; } = null!;

    public DateTimeOffset? FacFechaMod { get; set; }
    public string? FacUsuarioMod { get; set; }
    public string? FacIpMod { get; set; }

    public DateTimeOffset? FacFechaEliminacion { get; set; }
    public string? FacUsuarioEliminacion { get; set; }
    public string? FacIpEliminacion { get; set; }

    public string FacEstado { get; set; } = "A";
    public string? FacMotivoInhabilitacion { get; set; }
    public long FacRowVersion { get; set; }

    public ReservaEntity Reserva { get; set; } = null!;
}