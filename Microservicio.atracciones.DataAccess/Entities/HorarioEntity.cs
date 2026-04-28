using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class HorarioEntity
{
    public int HorId { get; set; }
    public Guid HorGuid { get; set; }

    public int TckId { get; set; }

    public DateOnly HorFecha { get; set; }
    public TimeOnly HorHoraInicio { get; set; }
    public TimeOnly HorHoraFin { get; set; }
    public int HorCuposDisponibles { get; set; }

    public DateTimeOffset HorFechaIngreso { get; set; }
    public string HorUsuarioIngreso { get; set; } = null!;
    public string HorIpIngreso { get; set; } = null!;

    public DateTimeOffset? HorFechaMod { get; set; }
    public string? HorUsuarioMod { get; set; }
    public string? HorIpMod { get; set; }

    public DateTimeOffset? HorFechaEliminacion { get; set; }
    public string? HorUsuarioEliminacion { get; set; }
    public string? HorIpEliminacion { get; set; }

    public string HorEstado { get; set; } = "A";

    public TicketEntity Ticket { get; set; } = null!;
}