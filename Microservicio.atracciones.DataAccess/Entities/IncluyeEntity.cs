using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataAccess.Entities;

public class IncluyeEntity
{
    public int IncId { get; set; }
    public Guid IncGuid { get; set; }
    public string IncDescripcion { get; set; } = null!;
    public string IncEstado { get; set; } = "A";

    public ICollection<AtraccionIncluyeEntity> AtraccionesIncluye { get; set; } = new List<AtraccionIncluyeEntity>();
}