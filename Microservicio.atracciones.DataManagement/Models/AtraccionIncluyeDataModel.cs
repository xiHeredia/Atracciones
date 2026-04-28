using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class AtraccionIncluyeDataModel
{
    public int AtId { get; set; }
    public int IncId { get; set; }
    public string? IncluyeDescripcion { get; set; }
}