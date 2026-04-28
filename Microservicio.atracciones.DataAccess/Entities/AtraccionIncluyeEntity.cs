using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Microservicio.atracciones.DataAccess.Entities;

namespace Microservicio.atracciones.DataAccess.Entities;

public class AtraccionIncluyeEntity
{
    public int IncId { get; set; }
    public int AtId { get; set; }

    public DateTimeOffset AiFechaIngreso { get; set; }
    public string AiUsuarioIngreso { get; set; } = null!;

    public DateTimeOffset? AiFechaEliminacion { get; set; }
    public string? AiUsuarioEliminacion { get; set; }

    public string AiEstado { get; set; } = "A";

    public IncluyeEntity Incluye { get; set; } = null!;
    public AtraccionEntity Atraccion { get; set; } = null!;
}