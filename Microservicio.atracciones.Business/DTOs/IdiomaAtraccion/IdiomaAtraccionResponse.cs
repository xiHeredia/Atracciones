using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.IdiomaAtraccion;

public class IdiomaAtraccionResponse
{
    public int AtId { get; set; }
    public int IdId { get; set; }
    public string? IdiomaNombre { get; set; }
}