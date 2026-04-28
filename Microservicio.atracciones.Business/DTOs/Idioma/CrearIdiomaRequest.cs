using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Idioma;

public class CrearIdiomaRequest
{
    public string Nombre { get; set; } = null!;
}