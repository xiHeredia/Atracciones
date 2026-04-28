using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class IdiomaAtraccionEntity
{
    public int IdId { get; set; }
    public int AtId { get; set; }

    public DateTimeOffset IaFechaIngreso { get; set; }
    public string IaUsuarioIngreso { get; set; } = null!;

    public DateTimeOffset? IaFechaEliminacion { get; set; }
    public string? IaUsuarioEliminacion { get; set; }

    public string IaEstado { get; set; } = "A";

    public IdiomaEntity Idioma { get; set; } = null!;
    public AtraccionEntity Atraccion { get; set; } = null!;
}