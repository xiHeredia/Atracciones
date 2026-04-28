using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class ImagenAtraccionDataModel
{
    public int AtId { get; set; }
    public int ImgId { get; set; }
    public string? ImagenUrl { get; set; }
    public string? ImagenDescripcion { get; set; }
}