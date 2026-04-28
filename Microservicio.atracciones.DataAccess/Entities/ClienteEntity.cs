using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Microservicio.atracciones.DataAccess.Entities;

public class ClienteEntity
{
    public int CliId { get; set; }
    public Guid CliGuid { get; set; }

    public int UsuId { get; set; }

    public string CliTipoIdentificacion { get; set; } = null!;
    public string CliNumeroIdentificacion { get; set; } = null!;
    public string CliNombres { get; set; } = null!;
    public string CliApellidos { get; set; } = null!;
    public string? CliRazonSocial { get; set; }
    public string CliCorreo { get; set; } = null!;
    public string? CliTelefono { get; set; }
    public string? CliDireccion { get; set; }

    public DateTimeOffset CliFechaIngreso { get; set; }
    public string CliUsuarioIngreso { get; set; } = null!;
    public string CliIpIngreso { get; set; } = null!;

    public DateTimeOffset? CliFechaEliminacion { get; set; }
    public string? CliUsuarioEliminacion { get; set; }
    public string? CliIpEliminacion { get; set; }

    public string CliEstado { get; set; } = "A";
    public long CliRowVersion { get; set; }

    public UsuarioEntity Usuario { get; set; } = null!;
}