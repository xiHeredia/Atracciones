using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.ImagenAtraccion;

public class ImagenAtraccionResponse
{
    public int AtId { get; set; }
    public int ImgId { get; set; }
    public string? ImagenUrl { get; set; }
    public string? ImagenDescripcion { get; set; }
}