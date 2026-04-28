using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.DataManagement.Models;

public class UsuarioDataModel
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public IReadOnlyList<string> Roles { get; set; } = [];
}