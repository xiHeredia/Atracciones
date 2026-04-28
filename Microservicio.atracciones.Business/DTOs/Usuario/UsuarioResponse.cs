using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Microservicio.atracciones.Business.DTOs.Usuario;

public class UsuarioResponse
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Login { get; set; } = null!;
    public IReadOnlyList<string> Roles { get; set; } = [];
}