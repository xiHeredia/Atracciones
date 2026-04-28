using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.UsuarioRol;

public class CrearUsuarioRolRequest
{
    public int UsuarioId { get; set; }
    public int RolId { get; set; }
}