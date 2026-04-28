using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.IdiomaAtraccion;

public class CrearIdiomaAtraccionRequest
{
    public int AtId { get; set; }
    public int IdId { get; set; }
}