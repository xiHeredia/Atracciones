using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class ImagenEntity
{
    public int ImgId { get; set; }
    public Guid ImgGuid { get; set; }

    public string ImgUrl { get; set; } = null!;
    public string? ImgDescripcion { get; set; }

    public DateTimeOffset ImgFechaIngreso { get; set; }
    public string ImgUsuarioIngreso { get; set; } = null!;
    public string ImgIpIngreso { get; set; } = null!;

    public DateTimeOffset? ImgFechaMod { get; set; }
    public string? ImgUsuarioMod { get; set; }
    public string? ImgIpMod { get; set; }

    public DateTimeOffset? ImgFechaEliminacion { get; set; }
    public string? ImgUsuarioEliminacion { get; set; }
    public string? ImgIpEliminacion { get; set; }

    public string ImgEstado { get; set; } = "A";
    public ICollection<ImagenAtraccionEntity> ImagenesAtraccion { get; set; } = new List<ImagenAtraccionEntity>();
}