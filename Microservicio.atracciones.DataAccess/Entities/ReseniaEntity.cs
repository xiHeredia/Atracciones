using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class ReseniaEntity
{
    public int RsnId { get; set; }
    public Guid RsnGuid { get; set; }

    public int AtId { get; set; }
    public int RevId { get; set; }

    public string RsnComentario { get; set; } = null!;
    public short RsnRating { get; set; }

    public DateTimeOffset RsnFechaCreacion { get; set; }
    public string RsnUsuarioCreacion { get; set; } = null!;
    public string RsnIpCreacion { get; set; } = null!;

    public DateTimeOffset? RsnFechaMod { get; set; }
    public string? RsnUsuarioMod { get; set; }
    public string? RsnIpMod { get; set; }

    public DateTimeOffset? RsnFechaEliminacion { get; set; }
    public string? RsnUsuarioEliminacion { get; set; }
    public string? RsnIpEliminacion { get; set; }

    public string RsnEstado { get; set; } = "A";

    public AtraccionEntity Atraccion { get; set; } = null!;
    public ReservaEntity Reserva { get; set; } = null!;
}