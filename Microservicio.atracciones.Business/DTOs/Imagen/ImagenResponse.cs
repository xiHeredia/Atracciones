using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Imagen;

public class ImagenResponse
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Url { get; set; } = null!;
    public string? Descripcion { get; set; }
}
