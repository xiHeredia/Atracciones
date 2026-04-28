using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Microservicio.atracciones.DataAccess.Entities;

public class IdiomaEntity
{
    public int IdiId { get; set; }
    public Guid IdiGuid { get; set; }
    public string IdiDescripcion { get; set; } = null!;

    public DateTimeOffset IdiFechaIngreso { get; set; }
    public string IdUsuarioIngreso { get; set; } = null!;
    public string IdiIpIngreso { get; set; } = null!;

    public DateTimeOffset? IdiFechaMod { get; set; }
    public string? IdUsuarioMod { get; set; }
    public string? IdiIpMod { get; set; }

    public DateTimeOffset? IdiFechaEliminacion { get; set; }
    public string? IdUsuarioEliminacion { get; set; }
    public string? IdiIpEliminacion { get; set; }

    public string IdiEstado { get; set; } = "A";
    public ICollection<IdiomaAtraccionEntity> IdiomasAtraccion { get; set; } = new List<IdiomaAtraccionEntity>();
}