using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Usuario;

public class ActualizarUsuarioRequest
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string? Password { get; set; }
}