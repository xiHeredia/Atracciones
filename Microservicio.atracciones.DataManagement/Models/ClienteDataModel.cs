using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class ClienteDataModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }

    public int UsuarioId { get; set; }

    public string TipoIdentificacion { get; set; } = null!;
    public string NumeroIdentificacion { get; set; } = null!;
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? RazonSocial { get; set; }
    public string Correo { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
}