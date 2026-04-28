using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class ReservaEntity
{
    public int RevId { get; set; }
    public Guid RevGuid { get; set; }
    public string RevCodigo { get; set; } = null!;

    public int CliId { get; set; }
    public int HorId { get; set; }

    public DateTimeOffset RevFechaReservaUtc { get; set; }

    public decimal RevSubtotal { get; set; }
    public decimal RevValorIva { get; set; }
    public decimal RevTotal { get; set; }

    public string RevOrigenCanal { get; set; } = null!;

    public string RevUsuarioIngreso { get; set; } = null!;
    public string RevIpIngreso { get; set; } = null!;

    public DateTimeOffset? RevFechaMod { get; set; }
    public string? RevUsuarioMod { get; set; }
    public string? RevIpMod { get; set; }

    public DateTimeOffset? RevFechaCancelacion { get; set; }
    public string? RevUsuarioCancelacion { get; set; }
    public string? RevIpCancelacion { get; set; }
    public string? RevMotivoCancelacion { get; set; }

    public string RevEstado { get; set; } = "A";

    public ClienteEntity Cliente { get; set; } = null!;
    public HorarioEntity Horario { get; set; } = null!;
}