using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.ImagenAtraccion;

public class CrearImagenAtraccionRequest
{
    public int AtId { get; set; }
    public int ImgId { get; set; }
}