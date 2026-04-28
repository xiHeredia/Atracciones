using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.AtraccionIncluye;

public class AtraccionIncluyeResponse
{
    public int AtId { get; set; }
    public int IncId { get; set; }
    public string? IncluyeDescripcion { get; set; }
}