using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataAccess.Entities;

public class CategoriaEntity
{
    public int CatId { get; set; }
    public Guid CatGuid { get; set; }
    public int? CatParentId { get; set; }
    public string CatNombre { get; set; } = null!;

    public DateTimeOffset CatFechaIngreso { get; set; }
    public string CatUsuarioIngreso { get; set; } = null!;
    public string CatIpIngreso { get; set; } = null!;

    public DateTimeOffset? CatFechaMod { get; set; }
    public string? CatUsuarioMod { get; set; }
    public string? CatIpMod { get; set; }

    public DateTimeOffset? CatFechaEliminacion { get; set; }
    public string? CatUsuarioEliminacion { get; set; }
    public string? CatIpEliminacion { get; set; }

    public string CatEstado { get; set; } = "A";

    public CategoriaEntity? CategoriaPadre { get; set; }
    public ICollection<CategoriaEntity> Subcategorias { get; set; } = new List<CategoriaEntity>();

    public ICollection<CategoriaAtraccionEntity> CategoriasAtraccion { get; set; } = new List<CategoriaAtraccionEntity>();
}