using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.atracciones.Business.DTOs.Categoria;

public class CrearCategoriaRequest
{
    public int? ParentId { get; set; }
    public string Nombre { get; set; } = null!;
}