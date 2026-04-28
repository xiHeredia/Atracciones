using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Atraccion;

public class AtraccionFiltroRequest
{
    public string? Nombre { get; set; }
    public int? DestinoId { get; set; }
}