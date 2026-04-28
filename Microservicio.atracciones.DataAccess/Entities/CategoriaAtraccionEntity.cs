using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class CategoriaAtraccionEntity
{
    public int CatId { get; set; }
    public int AtId { get; set; }

    public DateTimeOffset CaFechaIngreso { get; set; }
    public string CaUsuarioIngreso { get; set; } = null!;

    public DateTimeOffset? CaFechaEliminacion { get; set; }
    public string? CaUsuarioEliminacion { get; set; }

    public string CaEstado { get; set; } = "A";

    public CategoriaEntity Categoria { get; set; } = null!;
    public AtraccionEntity Atraccion { get; set; } = null!;
}