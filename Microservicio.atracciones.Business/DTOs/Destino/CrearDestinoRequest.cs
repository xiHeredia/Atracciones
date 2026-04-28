using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Destino;

public class CrearDestinoRequest
{
    public string Nombre { get; set; } = null!;
    public string Pais { get; set; } = null!;
    public string? ImagenUrl { get; set; }
}