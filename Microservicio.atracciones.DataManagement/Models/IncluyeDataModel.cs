using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class IncluyeDataModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Descripcion { get; set; } = null!;
}