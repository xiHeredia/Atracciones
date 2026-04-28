using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Microservicio.atracciones.Business.DTOs.UsuarioRol;

public class UsuarioRolResponse
{
    public int UsuarioRolId { get; set; }
    public int UsuarioId { get; set; }
    public int RolId { get; set; }
    public string? RolDescripcion { get; set; }
}