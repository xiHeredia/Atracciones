using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataAccess.Entities;

public class AtraccionEntity
{
    public int AtId { get; set; }
    public Guid AtGuid { get; set; }
    public int DesId { get; set; }

    public string? AtNumEstablecimiento { get; set; }
    public string AtNombre { get; set; } = null!;
    public string? AtDescripcion { get; set; }
    public int AtTotalResenias { get; set; }
    public string? AtDireccion { get; set; }
    public int? AtDuracionMinutos { get; set; }
    public string? AtPuntoEncuentro { get; set; }
    public decimal? AtPrecioReferencia { get; set; }
    public bool AtIncluyeAcompaniante { get; set; }
    public bool AtIncluyeTransporte { get; set; }
    public bool AtDisponible { get; set; }

    public DateTimeOffset AtFechaIngreso { get; set; }
    public string AtUsuarioIngreso { get; set; } = null!;
    public string AtIpIngreso { get; set; } = null!;

    public DateTimeOffset? AtFechaMod { get; set; }
    public string? AtUsuarioMod { get; set; }
    public string? AtIpMod { get; set; }

    public DateTimeOffset? AtFechaEliminacion { get; set; }
    public string? AtUsuarioEliminacion { get; set; }
    public string? AtIpEliminacion { get; set; }

    public string AtEstado { get; set; } = "A";

    public DestinoEntity Destino { get; set; } = null!;
    public ICollection<CategoriaAtraccionEntity> CategoriasAtraccion { get; set; } = new List<CategoriaAtraccionEntity>();
    public ICollection<AtraccionIncluyeEntity> AtraccionesIncluye { get; set; } = new List<AtraccionIncluyeEntity>();
    public ICollection<ImagenAtraccionEntity> ImagenesAtraccion { get; set; } = new List<ImagenAtraccionEntity>();
    public ICollection<IdiomaAtraccionEntity> IdiomasAtraccion { get; set; } = new List<IdiomaAtraccionEntity>();
}
