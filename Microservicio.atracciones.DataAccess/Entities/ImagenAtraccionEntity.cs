using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class ImagenAtraccionEntity
{
    public int ImgId { get; set; }
    public int AtId { get; set; }

    public DateTimeOffset ImaFechaIngreso { get; set; }
    public string ImaUsuarioIngreso { get; set; } = null!;

    public DateTimeOffset? ImaFechaEliminacion { get; set; }
    public string? ImaUsuarioEliminacion { get; set; }

    public string ImaEstado { get; set; } = "A";

    public ImagenEntity Imagen { get; set; } = null!;
    public AtraccionEntity Atraccion { get; set; } = null!;
}