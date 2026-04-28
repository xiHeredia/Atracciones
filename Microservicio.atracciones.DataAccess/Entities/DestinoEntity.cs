using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataAccess.Entities;

public class DestinoEntity
{
    public int DesId { get; set; }
    public Guid DesGuid { get; set; }
    public string DesNombre { get; set; } = null!;
    public string DesPais { get; set; } = null!;
    public string? DesImagenUrl { get; set; }

    public DateTimeOffset DesFechaIngreso { get; set; }
    public string DesUsuarioIngreso { get; set; } = null!;
    public string DesIpIngreso { get; set; } = null!;

    public DateTimeOffset? DesFechaMod { get; set; }
    public string? DesUsuarioMod { get; set; }
    public string? DesIpMod { get; set; }

    public DateTimeOffset? DesFechaEliminacion { get; set; }
    public string? DesUsuarioEliminacion { get; set; }
    public string? DesIpEliminacion { get; set; }

    public string DesEstado { get; set; } = "A";

    public ICollection<AtraccionEntity> Atracciones { get; set; } = new List<AtraccionEntity>();
}