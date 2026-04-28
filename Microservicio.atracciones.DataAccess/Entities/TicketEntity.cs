using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class TicketEntity
{
    public int TckId { get; set; }
    public Guid TckGuid { get; set; }

    public int AtId { get; set; }

    public string TckTitulo { get; set; } = null!;
    public decimal TckPrecio { get; set; }
    public string TckTipoParticipante { get; set; } = null!;
    public int TckCapacidadMaxima { get; set; }
    public int TckCuposDisponibles { get; set; }

    public DateTimeOffset TckFechaIngreso { get; set; }
    public string TckUsuarioIngreso { get; set; } = null!;
    public string TckIpIngreso { get; set; } = null!;

    public DateTimeOffset? TckFechaMod { get; set; }
    public string? TckUsuarioMod { get; set; }
    public string? TckIpMod { get; set; }

    public DateTimeOffset? TckFechaEliminacion { get; set; }
    public string? TckUsuarioEliminacion { get; set; }
    public string? TckIpEliminacion { get; set; }

    public string TckEstado { get; set; } = "A";

    public AtraccionEntity Atraccion { get; set; } = null!;
}